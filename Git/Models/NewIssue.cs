using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Git.Models
{
    public class NewIssue
    {
        public string title { get; set; }
        public string body { get; set; }

        public NewIssue(string title, string body)
        {
            this.title = title;
            this.body = body;
        }
    }

}

