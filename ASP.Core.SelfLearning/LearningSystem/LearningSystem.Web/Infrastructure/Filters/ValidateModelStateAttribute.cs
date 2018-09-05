
namespace LearningSystem.Web.Infrastructure.Filters
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using System.Linq;


    /// <summary>
    /// This action filter validates the model state, if the action
    /// </summary>
    public class ValidateModelStateAttribute :ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var controller = context.Controller as Controller;

                if (controller == null)
                {
                    return;
                }

                var modelKey = context
                    .ActionArguments
                    .FirstOrDefault(a => a.Key.ToLower()
                    .Contains("model"))
                    .Value;

                if (modelKey==null)
                {
                    return;
                }

                context.Result = controller.View();                    
            }
        }
    }
}
