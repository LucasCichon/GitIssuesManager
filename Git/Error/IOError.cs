namespace Git.Error
{
    public class IOError : IError
    {
        private string _message;
        
        public IOError(string message)
        {
            _message = message;
        }
       
        public string Message { get => _message; }
    }
}
