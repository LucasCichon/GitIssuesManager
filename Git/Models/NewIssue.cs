using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Git.Models
{
    public class NewIssue
    {
        public string title { get; set; }
        public string body { get; set; }

        //private string _title;
        //private string _body;

        //[JsonPropertyName("title")]
        //public string Title { get => _title; set { _title = value;} }
        //[JsonPropertyName("body")]
        //public string Body { get => _body; set { _body = value; } }
    }

}

