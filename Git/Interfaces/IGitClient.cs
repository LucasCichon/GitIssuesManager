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
        Task<bool> CreateNewIssue(NewIssue issue, string repositoryName);
        Task<GitIssues> GetIssues(string repositoryName);
        Task<bool> ModifyIssue(EditIssue issue, string repositoryName);
        Task CloseIssue(Int64 id);
        Task <Repositories> GetRepositories();
    }
}
