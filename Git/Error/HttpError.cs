﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Git.Error
{
    public class HttpError : IError
    {
        private string _message;
        private HttpStatusCode _statusCode;
        public HttpError(string message)
        {
            _message = message;
        }
        public HttpError(HttpStatusCode statusCode)
        {
            _statusCode = statusCode;
        }
        public HttpError(string message, HttpStatusCode statusCode)
        {
            _message = message;
            _statusCode = statusCode;
        }
        public string Message { get => _message; }
        public HttpStatusCode StatusCode { get => _statusCode; }
    }
}
