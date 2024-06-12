using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitIssuesManager.Views
{
    public interface IIssueView
    {
        long IssueId { get; set; }
        string IssueTitle { get; set; }
        string IssueDescription { get; set; }
        string State { get; set; }

        string ServiceName { get; set; }
        string RepositoryName { get; set; }

        event EventHandler SearchEvent;
        event EventHandler AddEvent;
        event EventHandler ModifyEvent;
        event EventHandler CloseEvent;
        event EventHandler SaveEvent;
        event EventHandler CancelEvent;
        event EventHandler ClearEvent;

        event EventHandler ChangeService;

        void SetIssueListBindingSource(BindingSource issueList);
        void SetServicesListBindingSource(BindingSource servicesList);
        void SetRepositoriesListBindingSource(BindingSource repositoriesList);
        void Show();
    }
}
