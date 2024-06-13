using Git.Common;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Git.Models
{
    public class EditIssue
    {
        public EditIssue(string number, string title, string description, IssueState state = IssueState.open)
        {
            this.number = number;
            this.title = title;
            this.body = description;
            this.state = state;
        }
        public string number { get; set; }
        public string title { get; set; }
        public string body { get; set; }
        public IssueState state { get; set; }
    }
}
