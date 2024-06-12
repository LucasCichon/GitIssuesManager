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
            BtnSearch = new Button();
            DataGridIssues = new DataGridView();
            contextMenuStrip1 = new ContextMenuStrip(components);
            CmbRepository = new ComboBox();
            CmbService = new ComboBox();
            tabControl1 = new TabControl();
            tabPageIssueList = new TabPage();
            tabPageIssueDetails = new TabPage();
            BtnSave = new Button();
            label2 = new Label();
            label1 = new Label();
            richTextBoxDescription = new RichTextBox();
            textBoxTitle = new TextBox();
            label3 = new Label();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)DataGridIssues).BeginInit();
            tabControl1.SuspendLayout();
            tabPageIssueList.SuspendLayout();
            tabPageIssueDetails.SuspendLayout();
            SuspendLayout();
            // 
            // BtnSearch
            // 
            BtnSearch.Location = new Point(6, 6);
            BtnSearch.Name = "BtnSearch";
            BtnSearch.Size = new Size(179, 58);
            BtnSearch.TabIndex = 1;
            BtnSearch.Text = "Search";
            BtnSearch.UseVisualStyleBackColor = true;
            // 
            // DataGridIssues
            // 
            DataGridIssues.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridIssues.Dock = DockStyle.Right;
            DataGridIssues.Location = new Point(191, 3);
            DataGridIssues.Name = "DataGridIssues";
            DataGridIssues.RowHeadersWidth = 62;
            DataGridIssues.Size = new Size(1008, 639);
            DataGridIssues.TabIndex = 2;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(24, 24);
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // CmbRepository
            // 
            CmbRepository.FormattingEnabled = true;
            CmbRepository.Location = new Point(338, 47);
            CmbRepository.Name = "CmbRepository";
            CmbRepository.Size = new Size(293, 33);
            CmbRepository.TabIndex = 4;
            // 
            // CmbService
            // 
            CmbService.FormattingEnabled = true;
            CmbService.Location = new Point(12, 47);
            CmbService.Name = "CmbService";
            CmbService.Size = new Size(293, 33);
            CmbService.TabIndex = 4;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPageIssueList);
            tabControl1.Controls.Add(tabPageIssueDetails);
            tabControl1.Dock = DockStyle.Bottom;
            tabControl1.Location = new Point(0, 100);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1210, 683);
            tabControl1.TabIndex = 5;
            // 
            // tabPageIssueList
            // 
            tabPageIssueList.Controls.Add(BtnSearch);
            tabPageIssueList.Controls.Add(DataGridIssues);
            tabPageIssueList.Location = new Point(4, 34);
            tabPageIssueList.Name = "tabPageIssueList";
            tabPageIssueList.Padding = new Padding(3);
            tabPageIssueList.Size = new Size(1202, 645);
            tabPageIssueList.TabIndex = 0;
            tabPageIssueList.Text = "Issue List";
            tabPageIssueList.UseVisualStyleBackColor = true;
            // 
            // tabPageIssueDetails
            // 
            tabPageIssueDetails.Controls.Add(BtnSave);
            tabPageIssueDetails.Controls.Add(label2);
            tabPageIssueDetails.Controls.Add(label1);
            tabPageIssueDetails.Controls.Add(richTextBoxDescription);
            tabPageIssueDetails.Controls.Add(textBoxTitle);
            tabPageIssueDetails.Location = new Point(4, 34);
            tabPageIssueDetails.Name = "tabPageIssueDetails";
            tabPageIssueDetails.Padding = new Padding(3);
            tabPageIssueDetails.Size = new Size(1202, 645);
            tabPageIssueDetails.TabIndex = 1;
            tabPageIssueDetails.Text = "Issue Details";
            tabPageIssueDetails.UseVisualStyleBackColor = true;
            // 
            // BtnSave
            // 
            BtnSave.Location = new Point(486, 548);
            BtnSave.Name = "BtnSave";
            BtnSave.Size = new Size(203, 56);
            BtnSave.TabIndex = 3;
            BtnSave.Text = "Save";
            BtnSave.UseVisualStyleBackColor = true;
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
            // richTextBoxDescription
            // 
            richTextBoxDescription.Location = new Point(34, 119);
            richTextBoxDescription.Name = "richTextBoxDescription";
            richTextBoxDescription.Size = new Size(1114, 386);
            richTextBoxDescription.TabIndex = 1;
            richTextBoxDescription.Text = "";
            // 
            // textBoxTitle
            // 
            textBoxTitle.Location = new Point(34, 44);
            textBoxTitle.Name = "textBoxTitle";
            textBoxTitle.Size = new Size(1114, 31);
            textBoxTitle.TabIndex = 0;
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
            ClientSize = new Size(1210, 783);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(tabControl1);
            Controls.Add(CmbService);
            Controls.Add(CmbRepository);
            Name = "IssueView";
            Text = "Issues";
            ((System.ComponentModel.ISupportInitialize)DataGridIssues).EndInit();
            tabControl1.ResumeLayout(false);
            tabPageIssueList.ResumeLayout(false);
            tabPageIssueDetails.ResumeLayout(false);
            tabPageIssueDetails.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button BtnSearch;
        private DataGridView DataGridIssues;
        private ContextMenuStrip contextMenuStrip1;
        private ComboBox CmbRepository;
        private ComboBox CmbService;
        private TabControl tabControl1;
        private TabPage tabPageIssueList;
        private TabPage tabPageIssueDetails;
        private Button BtnSave;
        private Label label2;
        private Label label1;
        private RichTextBox richTextBoxDescription;
        private TextBox textBoxTitle;
        private Label label3;
        private Label label4;
    }
}
