
namespace CamaraBazar.Web.Infrastricture.Filters
{
    using Microsoft.AspNetCore.Mvc.Filters;
    using System;
    using System.IO;

    public class LogAttribute : ActionFilterAttribute
    {

        //can be made also Async
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            using (var writer = new StreamWriter("logs.txt", true))
            {
                var dateTime = DateTime.Now;
                var ipAddress = context.HttpContext.Connection.RemoteIpAddress;
                var userName = context.HttpContext.User?.Identity?.Name ?? "Anonymous";
                var controller = context.Controller.GetType().Name;
                //var action = context.ActionDescriptor.DisplayName;

                //another approach:
                var action = context.RouteData.Values["action"];

                var logMessage = $"{dateTime} - {ipAddress} - {userName} - {controller}.{action}";

                if (context.Exception != null)
                {
                    var exceptionType = context.Exception.GetType().Name;
                    var exceptionMessage = context.Exception.Message;

                    logMessage = $"[!] {logMessage} - {exceptionType} - {exceptionMessage}";
                }

                writer.WriteLine(logMessage);
            }
        }
    }
}
