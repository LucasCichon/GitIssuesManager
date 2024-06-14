using Git;
using Git.Clients;
using Git.Common;
using Git.Error;
using Git.Extensions;
using Git.Helpers;
using Git.Interfaces;
using Git.Models;
using GitIssuesManager.Converters;
using GitIssuesManager.ViewModels;
using GitIssuesManager.Views;
using System.ComponentModel;
using System.Net;
using System.Windows.Forms;

namespace GitIssuesManager.Presenters
{
    public class IssuePresenter
    {
        private IIssueView _view;
        private IGitClient _gitClient;
        private IGitHelper _gitHelper;
        private IIOClient _ioClient;
        private Identity _identity;
        private BindingSource _issuesBindingSource;
        private BindingSource _issuesImportBindingSource;
        private BindingSource _servicesBindignSource;
        private BindingSource _repositoriesBindingSource;
        private IEnumerable<Issue> _issueList;
        private IEnumerable<ImportExportIssue> _issueImportList;

        public IssuePresenter(IIssueView view, IGitClient client, Identity identity)
        {
            _issuesBindingSource = new BindingSource();
            _issuesBindingSource.DataSource = new List<IssueVm>();
            _issuesImportBindingSource = new BindingSource();
            _servicesBindignSource = new BindingSource();
            _repositoriesBindingSource = new BindingSource();
            _view = view;
            _gitClient = client;
            _identity = identity;
            _ioClient = new IOClient();
            _view.SearchEventAsync += SearchIssuesAsync;
            _view.CreateEventAsync += CreateEventAsync;
            _view.ClearEvent += ClearIssues;
            _view.CloseEvent += CloseIssue;
            _view.EditEvent += LoadIssueToEdit;
            _view.SaveEventAsync += SaveEventAsync;
            _view.ChangeService += ChangeService;
            _view.ImportLoadEvent += ImportLoadEvent;
            _view.ImportCompleteEventAsync += ImportCompleteEventAsync;
            _view.ExportEvent += ExportEvent;

            _view.SetIssueListBindingSource(_issuesBindingSource);
            _view.SetServicesListBindingSource(_servicesBindignSource);
            _view.SetRepositoriesListBindingSource(_repositoriesBindingSource);
            _view.SetIssueImportListBindingSource(_issuesImportBindingSource);
            
            LoadAsync();
        }

        private void ExportEvent(object? sender, EventArgs e)
        {
            using (var saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "txt files (*.txt)|*.txt";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var result = _ioClient.Export(saveFileDialog.FileName, _issueList?.Select(i => new ImportExportIssue(i.Title, i.Body)));
                    result.Match(success =>
                    {
                        _view.IsSuccessfull = true;
                        _view.Message = "Export Succeed!";
                    },
                    error =>
                    {
                        _view.IsSuccessfull = false;
                        _view.Message = error.Message;
                    });
                }
            }
        }

        private void ImportLoadEvent(object? sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "txt files (*.txt)|*.txt";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var result = _ioClient.Import(openFileDialog.FileName);
                    result.Match(success =>
                    {
                        _view.IsImport = true;
                        _issueImportList = success;
                        _issuesImportBindingSource.DataSource = success.Select(i => new ImportExportIssueVm() { title = i.Title, description = i.Description});
                        _view.IsSuccessfull = true;
                        _view.Message = "Export Succeed!";
                    },
                    error =>
                    {
                        _view.IsSuccessfull = false;
                        _view.Message = error.Message;
                    });
                }
            }
        }

        private async Task ImportCompleteEventAsync(object? sender, EventArgs args)
        {
            var tasks = new List<Task<Either<IError, HttpStatusCode>>>();

            bool isSuccess = true;
            string errorMessage = string.Empty;
            HttpStatusCode statusCode = HttpStatusCode.Created;
            var repository = _view.RepositoryName;

            int numberOfImportActions = _gitHelper.GetNumberOfSeparateActions(RequestMethod.POST, _issueImportList.Count());
            int maxNumberOfConcurrentRequests = _gitHelper.GetNumberOfMaxConcurrentRequests(RequestMethod.POST);

            var issues = _issueImportList.ToList();

            for(int i = 0; i < numberOfImportActions; i++)
            {
                for (int j = 0; j < maxNumberOfConcurrentRequests; j++)
                {
                    int index = (i * maxNumberOfConcurrentRequests) + j;
                    if(index >= issues.Count) { break; }
                    var currentIssue = issues.ElementAt(index);
                    tasks.Add(Task.Run(() => _gitClient.CreateNewIssue(new NewIssue(currentIssue.Title, currentIssue.Description), repository)));
                }

                var result = await Task.WhenAll(tasks.ToArray());

                foreach(var r in result)
                {
                    r.Match(success =>
                    {
                        //
                    },
                    error =>
                    {
                        isSuccess = false;
                        errorMessage += error.Message + Environment.NewLine;
                        statusCode = ((HttpError)error).StatusCode;
                    });
                }

                if(i < numberOfImportActions - 1)
                {
                    await Task.Delay(60000);
                }
            }

            _view.Message = errorMessage;
            _view.ImportCompletedSuccessfully = isSuccess;

            await LoadAllIssuesListAsync();
        }

        private async Task SearchIssuesAsync(object? sender, EventArgs e)
        {
            await LoadAllIssuesListAsync();
        }
        private async Task LoadAllIssuesListAsync()
        {
            var result = await _gitClient.GetIssues(_view.RepositoryName);


            result.Match(success =>
            {
                _issueList = success.items;
                var issueListVm = _issueList.Select(i => i.ToDomain()).ToList();
                _issuesBindingSource.DataSource = issueListVm;
                _view.IsSuccessfull = true;
            },
            error =>
            {
                _view.IsSuccessfull = false;
                _view.Message = error.Message;
            });

            _view.Show();
        }

        private void LoadIssueToEdit(object? sender, EventArgs e)
        {
            ClearView();
            var issue = (IssueVm)_issuesBindingSource.Current;
            if(issue is null)
            {
                MessageBox.Show("There is no Issue selected.");
                return;
            }
            _view.IssueId = issue.id;
            _view.DetailsIssueTitle = issue.title;
            _view.DetailsIssueDescription = issue.description;
            _view.IssueNumber = issue.number;
            _view.IsEdit = true;
        }

        private async Task SaveEventAsync(object? sender, EventArgs e)
        {
            var issue = new EditIssue(_view.IssueNumber.ToString(), _view.DetailsIssueTitle, _view.DetailsIssueDescription);
            var result = await _gitClient.ModifyIssue(issue, _view.RepositoryName);

            result.Match(async success =>
            {
                _view.IsSuccessfull = true;
                _view.Message = $"Issue '{_view.DetailsIssueTitle}' Updated Successfully.";
                await LoadAllIssuesListAsync();
            },
            error =>
            {
                _view.IsSuccessfull = false;
                _view.Message = $"An error occured while modifying the Issue '{_view.DetailsIssueTitle}'. Message: {error.Message}, StatusCode: {((HttpError)error).StatusCode}";
            });
        }
        
        private async Task CreateEventAsync(object? sender, EventArgs e)
        {
            var newIssue = new NewIssue(_view.NewIssueTitle, _view.NewIssueDescription);
            var result = await _gitClient.CreateNewIssue(newIssue, _view.RepositoryName);

            result.Match(async success =>
            {
                _view.IsSuccessfull = true;
                _view.Message = $"Issue '{_view.NewIssueTitle}' Created Successfully.";
                await LoadAllIssuesListAsync();
            },
            error =>
            {
                _view.IsSuccessfull = false;
                _view.Message = $"An error occured while creating the Issue '{_view.NewIssueTitle}'. Message: '{error.Message}', Status Code: {((HttpError)error).StatusCode}";
            });
        }

        private async Task LoadAsync()
        {
            _servicesBindignSource.DataSource = GitService.GetAllGitServices();
            var result = await _gitClient.GetRepositories();
            result.Match(success =>
            {
                _repositoriesBindingSource.DataSource = success.items.Select(i => i.name);
                _view.IsSuccessfull = true;

            },
            error =>
            {
                _view.Message = error.Message;
                _view.IsSuccessfull = false;
                MessageBox.Show(error.Message);
            });
        }

        private async Task CloseIssue(object? sender, EventArgs e)
        {
            var issue = new EditIssue(_view.IssueNumber.ToString(), _view.DetailsIssueTitle, _view.DetailsIssueDescription, IssueState.closed);
            var result = await _gitClient.ModifyIssue(issue, _view.RepositoryName);

            result.Match(async success =>
            {
                _view.IsSuccessfull = true;
                _view.Message = $"Issue '{_view.DetailsIssueTitle}' Closed Successfully.";
                await LoadAllIssuesListAsync();
            },
            error =>
            {
                _view.IsSuccessfull = false;
                _view.Message = $"An error occured while closing the Issue '{_view.DetailsIssueTitle}'. Message: {error.Message}, StatusCode: {((HttpError)error).StatusCode}";
            });
        }

        private void ClearIssues(object? sender, EventArgs e)
        {
            _issuesBindingSource.DataSource = null;
        }

        private void ClearView()
        {
            _view.IsSuccessfull = false;
            _view.Message = string.Empty;
        }
        private void ChangeService(object? sender, EventArgs e)
        {
            try
            {
                var service = _view.ServiceName.GetService();
                _identity = Authenticator.GetCurrentIdentity(service);
                _gitClient = GitClient.CreateClient(_view.ServiceName, _identity);
                _gitHelper = GitHelper.CreateHelper(_view.ServiceName);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occured while changing the Service: {ex.Message}");
            }
        }
    }
}
