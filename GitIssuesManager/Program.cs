using Git.Models;
using GitIssuesManager.Presenters;
using Git.Clients;
using GitIssuesManager.Views;
using Git.Interfaces;

namespace GitIssuesManager
{
    public static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            string gitHubToken = Properties.Settings.Default.GitHubUserToken;
            string user = Properties.Settings.Default.User;

            IIssueView view = new IssueView();
            IGitClient client = new GitHubCLient(new Git.Identity(gitHubToken, user));

            var presenter = new IssuePresenter(view, client);

            Application.Run((Form)view);
        }
    }
}