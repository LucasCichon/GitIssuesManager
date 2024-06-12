using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Git.Models
{
    public class EditIssue
    {
        public string number { get; set; }
        public string title { get; set; }
        public string body { get; set; }
    }
}
