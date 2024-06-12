using Git;
using Git.Interfaces;
using Git.Models;
using GitIssuesManager.Converters;
using GitIssuesManager.Views;

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
            _view.SearchEvent += SearchIssues;
            _view.ClearEvent += ClearIssues;
            _view.CloseEvent += CloseIssue;
            _view.ModifyEvent += ModifyIssue;
            _view.ChangeService += ChangeService;

            _view.SetIssueListBindingSource(_issuesBindingSource);
            _view.SetServicesListBindingSource(_servicesBindignSource);
            _view.SetRepositoriesListBindingSource(_repositoriesBindingSource);
            


            Load();
        }

        private void ChangeService(object? sender, EventArgs e)
        {
            _gitClient = GitClient.CreateClient(_view.ServiceName, _identity); 
        }

        private async void Load()
        {
            _servicesBindignSource.DataSource = GitService.GetAllGitServices();
            var repos = await _gitClient.GetRepositories();
            _repositoriesBindingSource.DataSource = repos.items.Select(i => i.name);
        }

        private async Task LoadAllIssuesList()
        {

            var gitIssues = await _gitClient.GetIssues(_view.RepositoryName);
            _issueList = gitIssues.items;
            var issueListVm = _issueList.Select(i => i.ToDomain());
            _issuesBindingSource.DataSource = issueListVm;

            _view.Show();
        }

        private async void SearchIssues(object? sender, EventArgs e)
        {
            await LoadAllIssuesList();
        }
        private void ModifyIssue(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void CloseIssue(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ClearIssues(object? sender, EventArgs e)
        {
            _issuesBindingSource.DataSource = null;
        }

    }
}
