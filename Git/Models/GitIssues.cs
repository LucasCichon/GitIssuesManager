using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Git.Models
{

    public class GitIssues
    {
        public Issue[] items { get; set; }
    }

    public class Issue
    {
        private long _id;
        private string _state;
        private string _title;
        private string _body;
        private int _number;

        [DisplayName("Id")]
        public long Id { get { return _id; } set { _id = value; } }

        [DisplayName("Number")]
        public int Number { get => _number; set => _number = value; }
        
        [DisplayName("State")]
        public string State { get { return _state; } set { _state = value; } }

        [DisplayName("Title")]
        [Required(ErrorMessage = "Issue title is required")]
        public string Title { get { return _title; } set { _title = value; } }

        [DisplayName("Description")]
        [Required(ErrorMessage = "Issue body is required")]
        public string Body { get { return _body; } set { _body = value; } }
    }    
}