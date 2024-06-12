using Git;
using Git.Extensions;
using Git.Interfaces;
using GitIssuesManager.Converters;
using GitIssuesManager.ViewModels;
using GitIssuesManager.Views;
using Newtonsoft.Json.Bson;
using System.ComponentModel;
using System.Configuration;
using Microsoft.VisualStudio.Threading;
using System.Windows.Forms;

namespace GitIssuesManager
{
    public partial class IssueView : Form, IIssueView
    {
        private long _id;
        private string _state;
        private bool _isSuccessfull;
        private string _message;
        private bool _isEdit;
        private int _issueNumber;

        public event EventHandler LoadEvent;
        public event AsyncEventHandler SearchEvent;
        public event AsyncEventHandler CreateEvent;
        public event EventHandler EditEvent;
        public event EventHandler CloseEvent;
        public event AsyncEventHandler SaveEvent;
        public event EventHandler CancelEvent;
        public event EventHandler ClearEvent;
        public event EventHandler ChangeService;

        public long IssueId { get => _id; set => _id = value; }
        public string NewIssueTitle { get => textBoxTitle_New.Text; set => textBoxTitle_New.Text = value; }
        public string DetailsIssueTitle { get => textBoxTitle_Details.Text; set => textBoxTitle_Details.Text = value; }
        public string NewIssueDescription { get => richTextBoxDescription_New.Text; set => richTextBoxDescription_New.Text = value; }
        public string DetailsIssueDescription { get => richTextBoxDescription_Details.Text; set => richTextBoxDescription_Details.Text = value; }
        public string State { get => _state; set => _state = value; }
        public string ServiceName { get => cmbService.SelectedValue.ToString(); set => cmbService.SelectedItem = value; }
        public string RepositoryName { get => cmbRepository.SelectedValue.ToString(); set => cmbRepository.SelectedItem = value; }
        public bool IsSuccessfull { get => _isSuccessfull; set => _isSuccessfull = value; }
        public string Message { get => _message; set => _message = value; }
        public bool IsEdit { get => _isEdit; set => _isEdit = value; }
        public int IssueNumber { get => _issueNumber; set => _issueNumber = value; }

        public void SetIssueListBindingSource(BindingSource issueList)
        {
            DataGridIssues.DataSource = issueList;
        }

        public void SetServicesListBindingSource(BindingSource servicesList)
        {
            cmbService.DataSource = servicesList;
        }

        public void SetRepositoriesListBindingSource(BindingSource repositoriesList)
        {
            cmbRepository.DataSource = repositoriesList;
        }


        public IssueView()
        {
            InitializeComponent();
            AssociateAndRaiseViewEvents();
            tabControl1.TabPages.Remove(tabPageCreateNewIssue);
            tabControl1.TabPages.Remove(tabPageIssueDetails);

        }

        private async void AssociateAndRaiseViewEvents()
        {
            cmbService.SelectedValueChanged += delegate { ChangeService?.Invoke(this, EventArgs.Empty); };
            cmbService.SelectedIndexChanged += delegate { ClearEvent?.Invoke(this, EventArgs.Empty); };
            cmbRepository.SelectedIndexChanged += delegate { ClearEvent?.Invoke(this, EventArgs.Empty); };
            
            //Search
            btnSearch.Click += delegate { SearchEvent?.Invoke(this, EventArgs.Empty); };
            //Edit
            btnEdit_tab.Click += delegate {  EditEvent?.Invoke(this, EventArgs.Empty);
                if (IsEdit)
                {
                    tabControl1.TabPages.Remove(tabPageIssueList);
                    tabControl1.TabPages.Add(tabPageIssueDetails);
                }
            };
            bntSave_Details.Click += async (s, e)  => { 
                await SaveEvent?.InvokeAsync(s, e);
                if (IsSuccessfull)
                {
                    tabControl1.TabPages.Remove(tabPageIssueDetails);
                    tabControl1.TabPages.Add(tabPageIssueList);
                    IsEdit = false;
                }
                MessageBox.Show(_message);
            };
            //Create
            btnCreateNew_tab.Click += delegate
            {
                tabControl1.TabPages.Remove(tabPageIssueList);
                tabControl1.TabPages.Add(tabPageCreateNewIssue);
            };
            btnCreate_New.Click += async (s,e) => { 
                await CreateEvent?.InvokeAsync(this, EventArgs.Empty);
                if (IsSuccessfull)
                {
                    tabControl1.TabPages.Remove(tabPageCreateNewIssue);
                    tabControl1.TabPages.Add(tabPageIssueList);
                }
                MessageBox.Show(_message);
            };
            //Close
            btnCloseIssue_Details.Click += delegate { 
                var result = MessageBox.Show("Are you sure you want to close the Issue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if(result == DialogResult.Yes)
                {
                    CloseEvent?.Invoke(this, EventArgs.Empty);
                    MessageBox.Show(_message);
                }
            };
            //Cancel
            btnCancel_Details.Click += delegate
            {
                tabControl1.TabPages.Remove(tabPageIssueDetails);
                tabControl1.TabPages.Add(tabPageIssueList);
            };

            btnCancel_New.Click += delegate
            {
                tabControl1.TabPages.Remove(tabPageCreateNewIssue);
                tabControl1.TabPages.Add(tabPageIssueList);
            };
        }

        private void btnCreateNew_Click2(object sender, EventArgs e)
        {
            //tabControl1.TabPages.Remove(tabPageIssueList);
            //tabControl1.TabPages.Add(tabPageCreateNewIssue);
            //tabControl1.SelectTab(tabPageCreateNewIssue);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //tabControl1.TabPages.Remove(tabPageCreateNewIssue);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            //tabControl1.TabPages.Add(tabPageCreateNewIssue);
            //tabControl1.SelectTab(tabPageCreateNewIssue);
        }

        private void btnCancel_Details_Click(object sender, EventArgs e)
        {
        //    tabControl1.TabPages.Remove(tabPageIssueDetails);
            //tabControl1.SelectTab(tabPageCreateNewIssue);
        }
    }
}
