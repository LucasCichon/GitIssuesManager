using Git.Models;
using GitIssuesManager.Presenters;
using Git.Clients;
using GitIssuesManager.Views;
using Git.Interfaces;
using Git.Common;
using GitIssuesManager.Properties;

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
            var settings = SettingsValidator.ValidateAndGetSettings();
            
            var identity = new Git.Identity(
                settings.GetValueOrDefault(ServiceConstants.GitHubTokenUserTokenName), 
                settings.GetValueOrDefault(ServiceConstants.UserName));
            IIssueView view = new IssueView();
            IGitClient client = new GitHubCLient(identity);

            var presenter = new IssuePresenter(view, client, identity);

            Application.Run((Form)view);
        }
    }
}