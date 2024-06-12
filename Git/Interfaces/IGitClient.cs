using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Git.Models;

namespace Git.Interfaces
{
    public interface IGitClient
    {
        Task<bool> IsAuthenticated();
        Task CreateNewIssue(NewIssue issue);
        Task<GitIssues> GetIssues(string repositoryName);
        Task ModifyIssue(Issue issue);
        Task CloseIssue(Int64 id);
        Task <Repositories> GetRepositories();
    }
}
