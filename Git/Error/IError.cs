using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Git.Error
{
    public interface IError
    {
        string Message { get; }
        //HttpStatusCode StatusCode { get; }
    }
}
