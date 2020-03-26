using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;

namespace Tests.Infrastructure.Filters
{
    public class RangeExceptionAttrubute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is ArgumentOutOfRangeException)
            {
                context.Result = new ViewResult()
                {
                    ViewName = "Message",
                    ViewData = new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary())
                    { 
                        Model = "Data received cannot be processed"
                    },
                    StatusCode = 404
                };                
            }

            base.OnException(context);
        }
    }
}
