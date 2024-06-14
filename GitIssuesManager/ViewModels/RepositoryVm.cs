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
