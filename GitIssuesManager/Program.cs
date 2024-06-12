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
            var identity = new Git.Identity(gitHubToken, user);
            IIssueView view = new IssueView();
            IGitClient client = new GitHubCLient(identity);

            var presenter = new IssuePresenter(view, client, identity);

            Application.Run((Form)view);
        }
    }
}