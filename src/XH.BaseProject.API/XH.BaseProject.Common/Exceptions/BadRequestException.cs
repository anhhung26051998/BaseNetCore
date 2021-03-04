using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace XH.BaseProject.Common.Exceptions
{
    public class BadRequestException : ExceptionBase
    {
        public override HttpStatusCode HttpStatusCode => HttpStatusCode.BadRequest;

        public BadRequestException(string userFriendlyMessage, Exception innerException = null, object data = null, string message = null)
            : base(userFriendlyMessage, innerException, data, message)
        {
        }
    }
}
