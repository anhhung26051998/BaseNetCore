using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using System;
using System.Collections.Generic;
using System.Text;

namespace XH.BaseProject.Common.FilterList
{
    public class FilterRequestBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (context.Metadata.ModelType == typeof(FilterRequest))
            {
                return new BinderTypeModelBinder(typeof(FilterRequestBinder));
            }

            return null;
        }
    }
}
