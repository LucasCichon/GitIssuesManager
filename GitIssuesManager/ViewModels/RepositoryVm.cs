using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitIssuesManager.ViewModels
{
    public class RepositoryVm
    {
        public string Name { get; }
        public RepositoryVm(string name)
        {
            this.Name = name;
        }
        public override string ToString() => Name;
    }
}
