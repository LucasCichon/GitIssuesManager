using Git;
using Git.Common;
using Git.Interfaces;
using Git.Models;
using GitIssuesManager.Converters;
using GitIssuesManager.ViewModels;
using GitIssuesManager.Views;
using System.Windows.Forms;

namespace GitIssuesManager.Presenters
{
    public class IssuePresenter
    {
        private IIssueView _view;
        private IGitClient _gitClient;
        private readonly Identity _identity;
        private BindingSource _issuesBindingSource;
        private BindingSource _servicesBindignSource;
        private BindingSource _repositoriesBindingSource;
        private IEnumerable<Issue> _issueList;
        private IEnumerable<GitServiceType> _services;
        private IEnumerable<string> _repositories;

        public IssuePresenter(IIssueView view, IGitClient client, Identity identity)
        {
            _issuesBindingSource = new BindingSource();
            _servicesBindignSource = new BindingSource();
            _repositoriesBindingSource = new BindingSource();
            _view = view;
            _gitClient = client;
            _identity = identity;
            _view.SearchEvent += SearchIssuesAsync;
            _view.CreateEvent += CreateEventAsync;
            _view.ClearEvent += ClearIssues;
            _view.CloseEvent += CloseIssue;
            _view.EditEvent += LoadIssueToEdit;
            _view.SaveEvent += SaveEventAsync;
            _view.ChangeService += ChangeService;

            _view.SetIssueListBindingSource(_issuesBindingSource);
            _view.SetServicesListBindingSource(_servicesBindignSource);
            _view.SetRepositoriesListBindingSource(_repositoriesBindingSource);
            


            LoadAsync();
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

        private void ClearView()
        {
            _view.IsSuccessfull = false;
            _view.Message = string.Empty;
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
                _view.Message = $"There was an error on modify Issue '{_view.DetailsIssueTitle}'. Message: {error.Message}, StatusCode: {error.StatusCode}";
            });
        }

        private void ChangeService(object? sender, EventArgs e)
        {
            _gitClient = GitClient.CreateClient(_view.ServiceName, _identity); 
        }
        
        private async Task CreateEventAsync(object? sender, EventArgs e)
        {
            var newIssue = new NewIssue() { title = _view.NewIssueTitle, body = _view.NewIssueDescription };
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
                _view.Message = $"There was an error on create Issue '{_view.NewIssueTitle}'. Message: '{error.Message}', Status Code: {error.StatusCode}";
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

        private async Task LoadAllIssuesListAsync()
        {

            var result = await _gitClient.GetIssues(_view.RepositoryName);

            result.Match(success =>
            {
                _issueList = success.items;
                var issueListVm = _issueList.Select(i => i.ToDomain());
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

        private async Task SearchIssuesAsync(object? sender, EventArgs e)
        {
            await LoadAllIssuesListAsync();
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
                _view.Message = $"There was an error when try to close Issue '{_view.DetailsIssueTitle}'. Message: {error.Message}, StatusCode: {error.StatusCode}";
            });
        }

        private void ClearIssues(object? sender, EventArgs e)
        {
            _issuesBindingSource.DataSource = null;
        }

    }
}
