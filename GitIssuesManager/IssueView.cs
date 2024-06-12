using Git;
using Git.Extensions;
using Git.Interfaces;
using GitIssuesManager.Converters;
using GitIssuesManager.ViewModels;
using GitIssuesManager.Views;
using Newtonsoft.Json.Bson;
using System.ComponentModel;
using System.Configuration;

namespace GitIssuesManager
{
    public partial class IssueView : Form, IIssueView
    {
        private long _id;
        private string _state;

        public event EventHandler LoadEvent;
        public event EventHandler SearchEvent;
        public event EventHandler AddEvent;
        public event EventHandler ModifyEvent;
        public event EventHandler CloseEvent;
        public event EventHandler SaveEvent;
        public event EventHandler CancelEvent;
        public event EventHandler ClearEvent;
        public event EventHandler ChangeService;

        public long IssueId { get => _id; set => _id = value; }
        public string IssueTitle { get => textBoxTitle.Text; set => textBoxTitle.Text = value; }
        public string IssueDescription { get => richTextBoxDescription.Text; set => richTextBoxDescription.Text = value; }
        public string State { get => _state; set => _state = value; }
        public string ServiceName { get => CmbService.SelectedValue.ToString(); set => CmbService.SelectedItem = value; }
        public string RepositoryName { get => CmbRepository.SelectedValue.ToString(); set => CmbRepository.SelectedItem = value; }

        public void SetIssueListBindingSource(BindingSource issueList)
        {
            DataGridIssues.DataSource = issueList;
        }

        public void SetServicesListBindingSource(BindingSource servicesList)
        {
            CmbService.DataSource = servicesList;
        }

        public void SetRepositoriesListBindingSource(BindingSource repositoriesList)
        {
            CmbRepository.DataSource = repositoriesList;
        }


        public IssueView()
        {
            InitializeComponent();
            AssociateAndRaiseViewEvents();
            tabControl1.TabPages.Remove(tabPageIssueDetails);

        }

        private void AssociateAndRaiseViewEvents()
        {
            CmbService.SelectedValueChanged += delegate { ChangeService?.Invoke(this, EventArgs.Empty); };
            CmbService.SelectedIndexChanged += delegate { ChangeService?.Invoke(this, EventArgs.Empty); };
            CmbService.SelectedIndexChanged += delegate { ClearEvent?.Invoke(this, EventArgs.Empty); };
            CmbRepository.SelectedIndexChanged += delegate { ClearEvent?.Invoke(this, EventArgs.Empty); };
            BtnSearch.Click += delegate { SearchEvent?.Invoke(this, EventArgs.Empty); };
        }
    }
}
