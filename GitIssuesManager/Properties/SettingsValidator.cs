using Git.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitIssuesManager.Properties
{
    public static class SettingsValidator
    {
        public static Dictionary<string, string> ValidateAndGetSettings()
        {
            string gitHubToken = Properties.Settings.Default.GitHubUserToken;
            if (string.IsNullOrEmpty(gitHubToken))
            {
                MessageBox.Show("There is no valid token for GitHub Service in configuration");
                Environment.Exit(0);
            }

            string user = Properties.Settings.Default.User;
            if (string.IsNullOrEmpty(user))
            {
                MessageBox.Show("There is no valid user in configuration");
                Environment.Exit(0);
            }

            return new Dictionary<string, string>()
            {
                { ServiceConstants.GitHubTokenUserTokenName, gitHubToken },
                { ServiceConstants.UserName, user },
            };
        }
    }
}
