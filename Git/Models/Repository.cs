using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Git.Models
{

    public class Repositories
    {
        public Repository[] items { get; set; }
    }

    public class Repository
    {
        public string name { get; set; }
    }
}
