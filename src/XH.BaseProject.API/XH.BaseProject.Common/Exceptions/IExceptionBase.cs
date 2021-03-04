using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace XH.BaseProject.Common.Exceptions
{
    public interface IExceptionBase
    {
        public HttpStatusCode HttpStatusCode { get; }
        public object DataTranfer { get; }
        public string UserFriendlyMessage { get; }
        public string Message { get; }
    }
}
