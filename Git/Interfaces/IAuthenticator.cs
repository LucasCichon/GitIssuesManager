namespace Git.Interfaces
{
    public interface IAuthenticator
    {
        public Task Authenticate();
    }
}