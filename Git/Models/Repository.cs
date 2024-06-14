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
