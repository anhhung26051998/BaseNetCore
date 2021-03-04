using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace XH.BaseProject.Common.Exceptions
{
    public abstract class ExceptionBase : Exception, IExceptionBase
    {
        public object DataTranfer { get; set; }
        public string UserFriendlyMessage { get; set; }
        public virtual HttpStatusCode HttpStatusCode => HttpStatusCode.InternalServerError;

        public ExceptionBase(string userFriendlyMessage, Exception innerException = null, object data = null, string message = null)
            : base(message ?? innerException?.Message ?? userFriendlyMessage, innerException)
        {
            UserFriendlyMessage = userFriendlyMessage;
            DataTranfer = data;
        }
    }
}
