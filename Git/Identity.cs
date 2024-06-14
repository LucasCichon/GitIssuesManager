
namespace Git
{
    public class Identity
    {
        private readonly string _token;
        private readonly string _user;

        public Identity(string token, string user)
        {
            _token = token;
            _user = user;
        }

        public string BearerToken { get => _token; }

        public string User { get => _user; }
    }
}
