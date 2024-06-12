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
        //private IGitClient _gitClient;
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

        public long IssueId { get => _id; set => _id = value; }
        public string IssueTitle { get => textBoxTitle.Text; set => textBoxTitle.Text = value; }
        public string IssueDescription { get => richTextBoxDescription.Text; set => richTextBoxDescription.Text = value; }
        public string State { get => _state; set => _state = value; }
        public string ServiceName { get => CmbService.SelectedText; set => CmbService.SelectedItem = value; }
        public string RepositoryName { get => CmbRepository.SelectedText; set => CmbRepository.SelectedItem = value; }

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
            BtnSearch.Click += delegate { SearchEvent?.Invoke(this, EventArgs.Empty); };
            CmbService.SelectedIndexChanged += delegate { ClearEvent?.Invoke(this, EventArgs.Empty); };
            CmbRepository.SelectedIndexChanged += delegate { ClearEvent?.Invoke(this, EventArgs.Empty); };
        }

        //private async void IssueView_Load(object sender, EventArgs e)
        //{
        //    CmbService.DataSource = new BindingSource(GitService.GetAllGitServiceNames(), null);
        //    //var token = GetCurrentIdentity();
        //    //_gitClient = Git.GitClient.CreateClient(GetServiceName(), GetCurrentIdentity()); ServicesRadioButtonsCheckedChangeEventRegister();

            
        //    await RefreshComponents();
            
        //}

        //public async Task RefreshComponents()
        //{
            //await GetCurrentRepositories();
            //await GetCurrentIssues();
        //}

        

        //private Identity GetCurrentIdentity() => Authenticator.GetCurrentIdentity(GetServiceName().GetService());

        //private string GetServiceName() => CmbService.Text;

        //private async Task<bool> ClientIsAuthenticated()
        //{
        //    var isAuthenticated = await _gitClient.IsAuthenticated();
        //    if (!isAuthenticated)
        //    {
        //        MessageBox.Show("User could not authenticate.");
        //        return false;
        //    }
        //    return true;
        //}

        //private void ServicesRadioButtonsCheckedChangeEventRegister()
        //{
        //    foreach (var button in this.Controls.OfType<RadioButton>())
        //    {
        //        button.CheckedChanged += new EventHandler(radioButtons_CheckedChanged);
        //    }
        //}
        //private async void radioButtons_CheckedChanged(object sender, EventArgs e)
        //{
        //    var button = sender as RadioButton;
        //    if (button.Checked)
        //    {
        //        _gitClient = Git.GitClient.CreateClient(GetServiceName(), GetCurrentIdentity());
        //    }
        //    await RefreshComponents();
        //}

        //private async void GetIssuesBtn_Click(object sender, EventArgs e)
        //{
        //    await GetCurrentIssues();
        //}

        ////private void SetRepositoriesComboBoxSource(IEnumerable<RepositoryVm> repositories)
        ////{

        ////}
        //private async Task<bool> GetCurrentIssues()
        //{
        //    var repositoryName = CmbRepository.SelectedValue.ToString();
        //    var issues = await _gitClient.GetIssues(repositoryName);
        //    var issuesVm = issues.items.Select(i => i.ToDomain()).ToList();
        //    var source = new BindingSource(issuesVm, null);
        //    DataGridIssues.DataSource = source;
        //    DataGridIssues.Refresh();
        //    return true;
        //}


    }
}
