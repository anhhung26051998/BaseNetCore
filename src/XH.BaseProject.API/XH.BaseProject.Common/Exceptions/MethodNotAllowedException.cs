using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Buca.Common.Exceptions
{
    public class MethodNotAllowedException : ExceptionBase
    {
        public override HttpStatusCode HttpStatusCode => HttpStatusCode.Unauthorized;

        public MethodNotAllowedException(string userFriendlyMessage, Exception innerException = null, object data = null, string message = null)
            : base(userFriendlyMessage, innerException, data, message)
        {
        }
    }
}
