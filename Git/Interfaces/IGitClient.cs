using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Git.Common;
using Git.Error;
using Git.Models;

namespace Git.Interfaces
{
    public interface IGitClient
    {
        Task<Either<IError, HttpStatusCode>> CreateNewIssue(NewIssue issue, string repositoryName);
        Task<Either<IError, GitIssues>> GetIssues(string repositoryName);
        Task<Either<IError, HttpStatusCode>> ModifyIssue(EditIssue issue, string repositoryName);
        Task <Either<IError, Repositories>> GetRepositories();
    }
}
