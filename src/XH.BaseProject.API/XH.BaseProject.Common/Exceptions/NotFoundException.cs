using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Buca.Common.Exceptions
{
    public class NotFoundException : ExceptionBase
    {
        public override HttpStatusCode HttpStatusCode => HttpStatusCode.NotFound;

        public NotFoundException(string userFriendlyMessage, Exception innerException = null, object data = null, string message = null)
            : base(userFriendlyMessage, innerException, data, message)
        {
        }
    }
}
