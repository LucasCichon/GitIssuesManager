using Microsoft.VisualStudio.Threading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace GitIssuesManager.Views
{
    public interface IIssueView
    {
        long IssueId { get; set; }
        string NewIssueTitle { get; set; }
        string DetailsIssueTitle { get; set; }
        string NewIssueDescription { get; set; }
        string DetailsIssueDescription { get; set; }
        string State { get; set; }
        string Message { get; set; }
        bool IsSuccessfull { get; set; }
        int IssueNumber { get; set; }

        string ServiceName { get; set; }
        string RepositoryName { get; set; }
        bool IsEdit { get; set; }

        event AsyncEventHandler SearchEvent;
        event AsyncEventHandler CreateEvent;
        event EventHandler EditEvent;
        event EventHandler CloseEvent;
        event AsyncEventHandler SaveEvent;
        event EventHandler CancelEvent;
        event EventHandler ClearEvent;

        event EventHandler ChangeService;

        void SetIssueListBindingSource(BindingSource issueList);
        void SetServicesListBindingSource(BindingSource servicesList);
        void SetRepositoriesListBindingSource(BindingSource repositoriesList);
        void Show();
    }
}
