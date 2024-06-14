using Git.Models;
using GitIssuesManager.ViewModels;

namespace GitIssuesManager.Converters
{
    public static class GitObjectsConverter
    {
        public static IssueVm ToDomain(this Issue issue)
        {
            return new IssueVm()
            {
                id = issue.Id,
                title = issue.Title,
                description = issue.Body,
                number = issue.Number
            };
        }
    }
}
