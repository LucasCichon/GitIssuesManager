using Git.Models;
using GitIssuesManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitIssuesManager.Converters
{
    public static class GitConverter
    {
        public static IssueVm ToDomain(this Issue issue)
        {
            return new IssueVm()
            {
                id = issue.Id,
                title = issue.Title,
                description = issue.Body
            };
        }
    }
}
