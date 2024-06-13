using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

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
