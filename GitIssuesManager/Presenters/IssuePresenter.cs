﻿using Git;
using Git.Clients;
using Git.Common;
using Git.Error;
using Git.Interfaces;
using Git.Models;
using GitIssuesManager.Converters;
using GitIssuesManager.ViewModels;
using GitIssuesManager.Views;
using System.Net;
using System.Windows.Forms;

namespace GitIssuesManager.Presenters
{
    public class IssuePresenter
    {
        private IIssueView _view;
        private IGitClient _gitClient;
        private IIOClient _ioClient;
        private readonly Identity _identity;
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

            foreach (var i in _issueImportList)
            {
                tasks.Add(Task.Run(() => _gitClient.CreateNewIssue(new NewIssue(i.Title, i.Description), repository)));
            }

            var result = await Task.WhenAll(tasks.ToArray());

            foreach(var i in result)
            {
                i.Match(success =>
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

            _view.Message = errorMessage;
            _view.IsSuccessfull = isSuccess;

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
                _view.Message = $"There was an error on modify Issue '{_view.DetailsIssueTitle}'. Message: {error.Message}, StatusCode: {((HttpError)error).StatusCode}";
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
                _view.Message = $"There was an error on create Issue '{_view.NewIssueTitle}'. Message: '{error.Message}', Status Code: {((HttpError)error).StatusCode}";
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
                _view.Message = $"There was an error when try to close Issue '{_view.DetailsIssueTitle}'. Message: {error.Message}, StatusCode: {((HttpError)error).StatusCode}";
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
            _gitClient = GitClient.CreateClient(_view.ServiceName, _identity);
        }
    }
}
