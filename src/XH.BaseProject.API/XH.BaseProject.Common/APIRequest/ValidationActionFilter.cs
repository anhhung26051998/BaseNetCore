using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XH.BaseProject.Common.Exceptions;

namespace XH.BaseProject.Common.APIRequest
{
   public class ValidationActionFilter : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //funtionValidateTOken();

            if (!filterContext.ModelState.IsValid)
            {
                Dictionary<string, string[]> validates = new Dictionary<string, string[]>();
                foreach (var item in filterContext.ModelState)
                {
                    validates.Add(item.Key, item.Value.Errors.Select(x => x.ErrorMessage).ToArray());
                }
                throw new BadRequestException("InputDataIsWrong", data: validates);
            }
        }

        //public void funtionValidateTOken()
        //{

        //}
    }
}
