
namespace GitIssuesManager
{
    partial class IssueView
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            btnSearch = new Button();
            DataGridIssues = new DataGridView();
            contextMenuStrip1 = new ContextMenuStrip(components);
            cmbRepository = new ComboBox();
            cmbService = new ComboBox();
            tabControl1 = new TabControl();
            tabPageIssueList = new TabPage();
            btnExport = new Button();
            btnImportLoad = new Button();
            btnEdit_tab = new Button();
            btnCreateNew_tab = new Button();
            tabPageCreateNewIssue = new TabPage();
            btnCancel_New = new Button();
            btnCreate_New = new Button();
            label2 = new Label();
            label1 = new Label();
            richTextBoxDescription_New = new RichTextBox();
            textBoxTitle_New = new TextBox();
            tabPageIssueDetails = new TabPage();
            btnCloseIssue_Details = new Button();
            btnCancel_Details = new Button();
            bntSave_Details = new Button();
            label5 = new Label();
            label6 = new Label();
            richTextBoxDescription_Details = new RichTextBox();
            textBoxTitle_Details = new TextBox();
            tabPageImport = new TabPage();
            btnCancelImport = new Button();
            btnImportConfirm = new Button();
            dataGridViewImportIssues = new DataGridView();
            progressBar = new ProgressBar();
            label3 = new Label();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)DataGridIssues).BeginInit();
            tabControl1.SuspendLayout();
            tabPageIssueList.SuspendLayout();
            tabPageCreateNewIssue.SuspendLayout();
            tabPageIssueDetails.SuspendLayout();
            tabPageImport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewImportIssues).BeginInit();
            SuspendLayout();
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(6, 6);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(179, 58);
            btnSearch.TabIndex = 1;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            // 
            // DataGridIssues
            // 
            DataGridIssues.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DataGridIssues.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridIssues.Location = new Point(191, 3);
            DataGridIssues.Name = "DataGridIssues";
            DataGridIssues.RowHeadersWidth = 62;
            DataGridIssues.Size = new Size(922, 675);
            DataGridIssues.TabIndex = 2;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(24, 24);
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // cmbRepository
            // 
            cmbRepository.FormattingEnabled = true;
            cmbRepository.Location = new Point(338, 47);
            cmbRepository.Name = "cmbRepository";
            cmbRepository.Size = new Size(293, 33);
            cmbRepository.TabIndex = 4;
            // 
            // cmbService
            // 
            cmbService.FormattingEnabled = true;
            cmbService.Location = new Point(12, 47);
            cmbService.Name = "cmbService";
            cmbService.Size = new Size(293, 33);
            cmbService.TabIndex = 4;
            // 
            // tabControl1
            // 
            tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl1.Controls.Add(tabPageIssueList);
            tabControl1.Controls.Add(tabPageCreateNewIssue);
            tabControl1.Controls.Add(tabPageIssueDetails);
            tabControl1.Controls.Add(tabPageImport);
            tabControl1.Location = new Point(0, 100);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1117, 712);
            tabControl1.TabIndex = 5;
            // 
            // tabPageIssueList
            // 
            tabPageIssueList.Controls.Add(btnExport);
            tabPageIssueList.Controls.Add(btnImportLoad);
            tabPageIssueList.Controls.Add(btnEdit_tab);
            tabPageIssueList.Controls.Add(btnCreateNew_tab);
            tabPageIssueList.Controls.Add(btnSearch);
            tabPageIssueList.Controls.Add(DataGridIssues);
            tabPageIssueList.Location = new Point(4, 34);
            tabPageIssueList.Name = "tabPageIssueList";
            tabPageIssueList.Padding = new Padding(3);
            tabPageIssueList.Size = new Size(1109, 674);
            tabPageIssueList.TabIndex = 0;
            tabPageIssueList.Text = "Issue List";
            tabPageIssueList.UseVisualStyleBackColor = true;
            // 
            // btnExport
            // 
            btnExport.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnExport.Location = new Point(6, 608);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(179, 58);
            btnExport.TabIndex = 1;
            btnExport.Text = "Export";
            btnExport.UseVisualStyleBackColor = true;
            // 
            // btnImportLoad
            // 
            btnImportLoad.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnImportLoad.Location = new Point(6, 544);
            btnImportLoad.Name = "btnImportLoad";
            btnImportLoad.Size = new Size(179, 58);
            btnImportLoad.TabIndex = 1;
            btnImportLoad.Text = "Import";
            btnImportLoad.UseVisualStyleBackColor = true;
            // 
            // btnEdit_tab
            // 
            btnEdit_tab.Location = new Point(6, 155);
            btnEdit_tab.Name = "btnEdit_tab";
            btnEdit_tab.Size = new Size(179, 58);
            btnEdit_tab.TabIndex = 1;
            btnEdit_tab.Text = "Edit";
            btnEdit_tab.UseVisualStyleBackColor = true;
            // 
            // btnCreateNew_tab
            // 
            btnCreateNew_tab.Location = new Point(6, 79);
            btnCreateNew_tab.Name = "btnCreateNew_tab";
            btnCreateNew_tab.Size = new Size(179, 58);
            btnCreateNew_tab.TabIndex = 1;
            btnCreateNew_tab.Text = "Create New Issue";
            btnCreateNew_tab.UseVisualStyleBackColor = true;
            // 
            // tabPageCreateNewIssue
            // 
            tabPageCreateNewIssue.Controls.Add(btnCancel_New);
            tabPageCreateNewIssue.Controls.Add(btnCreate_New);
            tabPageCreateNewIssue.Controls.Add(label2);
            tabPageCreateNewIssue.Controls.Add(label1);
            tabPageCreateNewIssue.Controls.Add(richTextBoxDescription_New);
            tabPageCreateNewIssue.Controls.Add(textBoxTitle_New);
            tabPageCreateNewIssue.Location = new Point(4, 34);
            tabPageCreateNewIssue.Name = "tabPageCreateNewIssue";
            tabPageCreateNewIssue.Padding = new Padding(3);
            tabPageCreateNewIssue.Size = new Size(1109, 674);
            tabPageCreateNewIssue.TabIndex = 1;
            tabPageCreateNewIssue.Text = "New Issue";
            tabPageCreateNewIssue.UseVisualStyleBackColor = true;
            // 
            // btnCancel_New
            // 
            btnCancel_New.Location = new Point(585, 549);
            btnCancel_New.Name = "btnCancel_New";
            btnCancel_New.Size = new Size(203, 56);
            btnCancel_New.TabIndex = 3;
            btnCancel_New.Text = "Cancel";
            btnCancel_New.UseVisualStyleBackColor = true;
            // 
            // btnCreate_New
            // 
            btnCreate_New.Location = new Point(376, 549);
            btnCreate_New.Name = "btnCreate_New";
            btnCreate_New.Size = new Size(203, 56);
            btnCreate_New.TabIndex = 3;
            btnCreate_New.Text = "Create";
            btnCreate_New.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(34, 78);
            label2.Name = "label2";
            label2.Size = new Size(102, 25);
            label2.TabIndex = 2;
            label2.Text = "Description";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(34, 10);
            label1.Name = "label1";
            label1.Size = new Size(44, 25);
            label1.TabIndex = 2;
            label1.Text = "Title";
            // 
            // richTextBoxDescription_New
            // 
            richTextBoxDescription_New.Location = new Point(34, 119);
            richTextBoxDescription_New.Name = "richTextBoxDescription_New";
            richTextBoxDescription_New.Size = new Size(1114, 386);
            richTextBoxDescription_New.TabIndex = 1;
            richTextBoxDescription_New.Text = "";
            // 
            // textBoxTitle_New
            // 
            textBoxTitle_New.Location = new Point(34, 44);
            textBoxTitle_New.Name = "textBoxTitle_New";
            textBoxTitle_New.Size = new Size(1114, 31);
            textBoxTitle_New.TabIndex = 0;
            // 
            // tabPageIssueDetails
            // 
            tabPageIssueDetails.Controls.Add(btnCloseIssue_Details);
            tabPageIssueDetails.Controls.Add(btnCancel_Details);
            tabPageIssueDetails.Controls.Add(bntSave_Details);
            tabPageIssueDetails.Controls.Add(label5);
            tabPageIssueDetails.Controls.Add(label6);
            tabPageIssueDetails.Controls.Add(richTextBoxDescription_Details);
            tabPageIssueDetails.Controls.Add(textBoxTitle_Details);
            tabPageIssueDetails.Location = new Point(4, 34);
            tabPageIssueDetails.Name = "tabPageIssueDetails";
            tabPageIssueDetails.Padding = new Padding(3);
            tabPageIssueDetails.Size = new Size(1109, 674);
            tabPageIssueDetails.TabIndex = 2;
            tabPageIssueDetails.Text = "Issue Details";
            tabPageIssueDetails.UseVisualStyleBackColor = true;
            // 
            // btnCloseIssue_Details
            // 
            btnCloseIssue_Details.Location = new Point(713, 545);
            btnCloseIssue_Details.Name = "btnCloseIssue_Details";
            btnCloseIssue_Details.Size = new Size(203, 56);
            btnCloseIssue_Details.TabIndex = 7;
            btnCloseIssue_Details.Text = "Close";
            btnCloseIssue_Details.UseVisualStyleBackColor = true;
            // 
            // btnCancel_Details
            // 
            btnCancel_Details.Location = new Point(504, 545);
            btnCancel_Details.Name = "btnCancel_Details";
            btnCancel_Details.Size = new Size(203, 56);
            btnCancel_Details.TabIndex = 7;
            btnCancel_Details.Text = "Cancel";
            btnCancel_Details.UseVisualStyleBackColor = true;
            // 
            // bntSave_Details
            // 
            bntSave_Details.Location = new Point(295, 545);
            bntSave_Details.Name = "bntSave_Details";
            bntSave_Details.Size = new Size(203, 56);
            bntSave_Details.TabIndex = 8;
            bntSave_Details.Text = "Save";
            bntSave_Details.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(34, 84);
            label5.Name = "label5";
            label5.Size = new Size(102, 25);
            label5.TabIndex = 5;
            label5.Text = "Description";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(34, 16);
            label6.Name = "label6";
            label6.Size = new Size(44, 25);
            label6.TabIndex = 6;
            label6.Text = "Title";
            // 
            // richTextBoxDescription_Details
            // 
            richTextBoxDescription_Details.Location = new Point(34, 125);
            richTextBoxDescription_Details.Name = "richTextBoxDescription_Details";
            richTextBoxDescription_Details.Size = new Size(1114, 386);
            richTextBoxDescription_Details.TabIndex = 4;
            richTextBoxDescription_Details.Text = "";
            // 
            // textBoxTitle_Details
            // 
            textBoxTitle_Details.Location = new Point(34, 50);
            textBoxTitle_Details.Name = "textBoxTitle_Details";
            textBoxTitle_Details.Size = new Size(1114, 31);
            textBoxTitle_Details.TabIndex = 3;
            // 
            // tabPageImport
            // 
            tabPageImport.Controls.Add(btnCancelImport);
            tabPageImport.Controls.Add(btnImportConfirm);
            tabPageImport.Controls.Add(dataGridViewImportIssues);
            tabPageImport.Location = new Point(4, 34);
            tabPageImport.Name = "tabPageImport";
            tabPageImport.Padding = new Padding(3);
            tabPageImport.Size = new Size(1109, 674);
            tabPageImport.TabIndex = 3;
            tabPageImport.Text = "Import Issues";
            tabPageImport.UseVisualStyleBackColor = true;
            // 
            // btnCancelImport
            // 
            btnCancelImport.Location = new Point(8, 73);
            btnCancelImport.Name = "btnCancelImport";
            btnCancelImport.Size = new Size(183, 61);
            btnCancelImport.TabIndex = 1;
            btnCancelImport.Text = "Cancel";
            btnCancelImport.UseVisualStyleBackColor = true;
            // 
            // btnImportConfirm
            // 
            btnImportConfirm.Location = new Point(8, 6);
            btnImportConfirm.Name = "btnImportConfirm";
            btnImportConfirm.Size = new Size(183, 61);
            btnImportConfirm.TabIndex = 1;
            btnImportConfirm.Text = "Import";
            btnImportConfirm.UseVisualStyleBackColor = true;
            // 
            // dataGridViewImportIssues
            // 
            dataGridViewImportIssues.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewImportIssues.Dock = DockStyle.Right;
            dataGridViewImportIssues.Location = new Point(208, 3);
            dataGridViewImportIssues.Name = "dataGridViewImportIssues";
            dataGridViewImportIssues.RowHeadersWidth = 62;
            dataGridViewImportIssues.Size = new Size(898, 668);
            dataGridViewImportIssues.TabIndex = 0;
            // 
            // progressBarImport
            // 
            progressBar.Location = new Point(672, 47);
            progressBar.Name = "progressBarImport";
            progressBar.Size = new Size(194, 34);
            progressBar.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 19);
            label3.Name = "label3";
            label3.Size = new Size(119, 25);
            label3.TabIndex = 3;
            label3.Text = "Service Name";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(338, 19);
            label4.Name = "label4";
            label4.Size = new Size(97, 25);
            label4.TabIndex = 3;
            label4.Text = "Repository";
            // 
            // IssueView
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1117, 812);
            Controls.Add(progressBar);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(tabControl1);
            Controls.Add(cmbService);
            Controls.Add(cmbRepository);
            Name = "IssueView";
            Text = "Issues";
            SizeChanged += IssueView_SizeChanged;
            ((System.ComponentModel.ISupportInitialize)DataGridIssues).EndInit();
            tabControl1.ResumeLayout(false);
            tabPageIssueList.ResumeLayout(false);
            tabPageCreateNewIssue.ResumeLayout(false);
            tabPageCreateNewIssue.PerformLayout();
            tabPageIssueDetails.ResumeLayout(false);
            tabPageIssueDetails.PerformLayout();
            tabPageImport.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewImportIssues).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion
        private Button btnSearch;
        private DataGridView DataGridIssues;
        private ContextMenuStrip contextMenuStrip1;
        private ComboBox cmbRepository;
        private ComboBox cmbService;
        private TabControl tabControl1;
        private TabPage tabPageIssueList;
        private TabPage tabPageCreateNewIssue;
        private Button btnCreate_New;
        private Label label2;
        private Label label1;
        private RichTextBox richTextBoxDescription_New;
        private TextBox textBoxTitle_New;
        private Label label3;
        private Label label4;
        private Button btnCreateNew_tab;
        private Button btnCancel_New;
        private Button btnEdit_tab;
        private TabPage tabPageIssueDetails;
        private Button btnCancel_Details;
        private Button bntSave_Details;
        private Label label5;
        private Label label6;
        private RichTextBox richTextBoxDescription_Details;
        private TextBox textBoxTitle_Details;
        private Button btnCloseIssue_Details;
        private TabPage tabPageImport;
        private Button btnImportConfirm;
        private DataGridView dataGridViewImportIssues;
        private Button btnExport;
        private Button btnImportLoad;
        private Button btnCancelImport;
        private ProgressBar progressBar;
    }
}
