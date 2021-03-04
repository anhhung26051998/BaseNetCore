﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Buca.Common.Exceptions
{
    public class UnauthorizedException : ExceptionBase
    {
        public override HttpStatusCode HttpStatusCode => HttpStatusCode.Unauthorized;

        public UnauthorizedException(string userFriendlyMessage, Exception innerException = null, object data = null, string message = null)
            : base(userFriendlyMessage, innerException, data, message)
        {
        }
    }
}
