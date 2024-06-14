namespace Git.Models
{
    public class ImportExportIssue 
    {
        private string _title { get; set; }
        private string _description { get; set; }
        public ImportExportIssue(string title, string description)
        {
            _title = title;
            _description = description;
        }

        public string Title { get { return _title; } }
        public string Description { get { return _description;} }
    }
}
