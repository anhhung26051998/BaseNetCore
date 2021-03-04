
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Net;
using XH.BaseProject.Common.APIRequest;

namespace XH.BaseProject.Common.Exceptions
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        public GlobalExceptionFilter()
        {
        }

        public void OnException(ExceptionContext context)
        {
            ILogger _logger = (ILogger)context.HttpContext.RequestServices.GetService(typeof(ILogger));

            _logger.LogError(context.Exception, context.Exception.Message);
            if (context.Exception.GetType().GetInterfaces().Any(x => x.FullName == typeof(IExceptionBase).FullName))
            {
                var exception = (IExceptionBase)context.Exception;
                context.HttpContext.Response.StatusCode = (int)exception.HttpStatusCode;
                context.Result = new JsonResult(new APIResult()
                {
                    Data = exception.DataTranfer,
                    SystemMessage = exception.Message,
                    UserFriendlyMessage = exception.UserFriendlyMessage
                });
            }
            else
            {
                var exception = context.Exception;
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Result = new JsonResult(new APIResult()
                {
                    Data = null,
                    SystemMessage = exception.Message == "An error occurred while updating the entries. See the inner exception for details."
                        ? exception.InnerException.Message
                        : exception.Message,
                    UserFriendlyMessage = "SomethingIsWrong"
                });
            }
        }
    }
}
