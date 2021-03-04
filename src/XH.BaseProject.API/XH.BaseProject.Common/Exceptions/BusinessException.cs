using System;
using System.Net;

namespace XH.BaseProject.Common.Exceptions
{
    public class BusinessException : ExceptionBase
    {
        public override HttpStatusCode HttpStatusCode => HttpStatusCode.BadRequest;

        public BusinessException(string userFriendlyMessage, Exception innerException = null, object data = null, string message = null)
            : base(userFriendlyMessage, innerException, data, message)
        {
        }
    }
}
