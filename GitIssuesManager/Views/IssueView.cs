using GitIssuesManager.Presenters;
using GitIssuesManager.Views;
using Microsoft.VisualStudio.Threading;

namespace GitIssuesManager
{
    public partial class IssueView : Form, IIssueView
    {
        private long _id;
        private string _state;
        private bool _isSuccessfull;
        private bool _importCompletedSuccessfully;
        private string _message;
        private bool _isEdit;
        private int _issueNumber;
        private bool _isImport;

        public event AsyncEventHandler SearchEventAsync;
        public event AsyncEventHandler CreateEventAsync;
        public event EventHandler LoadEvent;
        public event EventHandler EditEvent;
        public event AsyncEventHandler SaveEventAsync;
        public event AsyncEventHandler CloseEvent;
        public event EventHandler CancelEvent;
        public event EventHandler ClearEvent;
        public event EventHandler ChangeService;
        public event EventHandler ImportLoadEvent;
        public event AsyncEventHandler ImportCompleteEventAsync;
        public event EventHandler ExportEvent;

        public long IssueId { get => _id; set => _id = value; }
        public string NewIssueTitle { get => textBoxTitle_New.Text; set => textBoxTitle_New.Text = value; }
        public string DetailsIssueTitle { get => textBoxTitle_Details.Text; set => textBoxTitle_Details.Text = value; }
        public string NewIssueDescription { get => richTextBoxDescription_New.Text; set => richTextBoxDescription_New.Text = value; }
        public string DetailsIssueDescription { get => richTextBoxDescription_Details.Text; set => richTextBoxDescription_Details.Text = value; }
        public string State { get => _state; set => _state = value; }
        public string ServiceName { get => cmbService.SelectedValue?.ToString() ?? string.Empty; set => cmbService.SelectedItem = value; }
        public string RepositoryName { get => cmbRepository.SelectedValue?.ToString() ?? string.Empty; set => cmbRepository.SelectedItem = value; }
        public bool IsSuccessfull { get => _isSuccessfull; set => _isSuccessfull = value; }
        public string Message { get => _message; set => _message = value; }
        public bool IsEdit { get => _isEdit; set => _isEdit = value; }
        public bool IsImport { get => _isImport; set => _isImport = value; }
        public int IssueNumber { get => _issueNumber; set => _issueNumber = value; }
        public bool ImportCompletedSuccessfully { get => _importCompletedSuccessfully; set => _importCompletedSuccessfully = value; }

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

        public void SetIssueImportListBindingSource(BindingSource importList)
        {
            dataGridViewImportIssues.DataSource = importList;
        }

        public IssueView()
        {
            InitializeComponent();
            AssociateAndRaiseViewEvents();
            tabControl1.TabPages.Remove(tabPageCreateNewIssue);
            tabControl1.TabPages.Remove(tabPageIssueDetails);
            tabControl1.TabPages.Remove(tabPageImport);
        }

        private async void AssociateAndRaiseViewEvents()
        {
            cmbService.SelectedValueChanged += delegate { ChangeService?.Invoke(this, EventArgs.Empty); };
            cmbService.SelectedIndexChanged += delegate { ClearEvent?.Invoke(this, EventArgs.Empty); };
            cmbRepository.SelectedIndexChanged += delegate { ClearEvent?.Invoke(this, EventArgs.Empty); };

            //Search
            btnSearch.Click += async (s, e) =>
            {
                ClearMessageLabel();
                await SearchEventAsync?.InvokeAsync(this, EventArgs.Empty);
                if (!IsSuccessfull)
                {
                    MessageBox.Show(_message);
                    ClearEvent?.Invoke(this, EventArgs.Empty);
                }
                SetColumnsProperties();
            };

            #region Edit

            btnEdit_tab.Click += delegate
            {
                EditEvent?.Invoke(this, EventArgs.Empty);
                if (IsEdit)
                {
                    tabControl1.TabPages.Remove(tabPageIssueList);
                    tabControl1.TabPages.Add(tabPageIssueDetails);
                }
            };
            bntSave_Details.Click += async (s, e) =>
            {
                await SaveEventAsync?.InvokeAsync(s, e);
                if (IsSuccessfull)
                {
                    tabControl1.TabPages.Remove(tabPageIssueDetails);
                    tabControl1.TabPages.Add(tabPageIssueList);
                    IsEdit = false;
                }
                SetColumnsProperties();
                MessageBox.Show(_message);
            };
            btnCancel_Details.Click += delegate
            {
                tabControl1.TabPages.Remove(tabPageIssueDetails);
                tabControl1.TabPages.Add(tabPageIssueList);
            };
            btnCloseIssue_Details.Click += async (s, e) =>
            {
                var result = MessageBox.Show("Are you sure you want to close the Issue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    await CloseEvent?.InvokeAsync(this, EventArgs.Empty);
                    if (IsSuccessfull)
                    {
                        tabControl1.TabPages.Remove(tabPageIssueDetails);
                        tabControl1.TabPages.Add(tabPageIssueList);
                    }
                    SetColumnsProperties();
                    MessageBox.Show(_message);
                }
            };

            #endregion

            #region Create

            btnCreateNew_tab.Click += delegate
            {
                tabControl1.TabPages.Remove(tabPageIssueList);
                tabControl1.TabPages.Add(tabPageCreateNewIssue);
            };
            btnCreate_New.Click += async (s, e) =>
            {
                await CreateEventAsync?.InvokeAsync(this, EventArgs.Empty);
                if (IsSuccessfull)
                {
                    tabControl1.TabPages.Remove(tabPageCreateNewIssue);
                    tabControl1.TabPages.Add(tabPageIssueList);
                }
                SetColumnsProperties();
                MessageBox.Show(_message);
            };
            btnCancel_New.Click += delegate
            {
                tabControl1.TabPages.Remove(tabPageCreateNewIssue);
                tabControl1.TabPages.Add(tabPageIssueList);
            };

            #endregion

            #region Export

            btnExport.Click += delegate
            {
                ExportEvent.Invoke(this, EventArgs.Empty);
                if (IsSuccessfull)
                {
                    MessageBox.Show(_message);
                }
            };

            #endregion

            #region Import

            btnImportLoad.Click += delegate
            {
                ImportLoadEvent?.Invoke(this, EventArgs.Empty);
                if (IsImport)
                {
                    tabControl1.TabPages.Remove(tabPageIssueList);
                    tabControl1.TabPages.Add(tabPageImport);
                    SetColumnsProperties();
                }
            };
            btnImportConfirm.Click += async (s, e) =>
            {
                SetWarning("This may take some time");
                await ImportCompleteEventAsync?.InvokeAsync(this, EventArgs.Empty);
                if (ImportCompletedSuccessfully)
                {
                    SetSuccessInfo("Import Completed Successfully");
                    tabControl1.TabPages.Remove(tabPageImport);
                    tabControl1.TabPages.Add(tabPageIssueList);
                    MessageBox.Show("Import Completed Successfully");
                }
                if (!ImportCompletedSuccessfully)
                {
                    var reader = new StringReader(_message);
                    SetWarning(reader.ReadLine());
                    reader.Dispose();
                    MessageBox.Show(_message);
                }
            };
            btnCancelImport.Click += delegate
            {
                tabControl1.TabPages.Remove(tabPageImport);
                tabControl1.TabPages.Add(tabPageIssueList);
            };

            #endregion
        }
        private void IssueView_SizeChanged(object sender, EventArgs e)
        {
            SetColumnsProperties();
        }
        private void SetColumnsProperties()
        {
            try
            {
                if (!IsEdit && !IsImport && DataGridIssues.Columns.Contains("title"))
                {
                    DataGridIssues.Columns["description"].Width = DataGridIssues.Width - DataGridIssues.Columns["title"].Width;
                    DataGridIssues.Columns["id"].Visible = false;
                    DataGridIssues.Columns["number"].Visible = false;
                }
                if (IsImport)
                {
                    dataGridViewImportIssues.Columns["description"].Width = dataGridViewImportIssues.Width - dataGridViewImportIssues.Columns["title"].Width;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SetWarning(string message)
        {
            lblInformation.ForeColor = Color.Red;
            lblInformation.Text = message;
            lblInformation.Visible = true;
        }
        private void SetSuccessInfo(string message)
        {
            lblInformation.ForeColor = Color.DarkGreen;
            lblInformation.Text = message;
            lblInformation.Visible = true;
        }
        private void ClearMessageLabel()
        {
            lblInformation.Text = string.Empty;
            lblInformation.Visible = false;
        }
    }
}
