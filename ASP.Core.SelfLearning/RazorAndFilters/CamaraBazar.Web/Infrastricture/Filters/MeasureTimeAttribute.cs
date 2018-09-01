
namespace CamaraBazar.Web.Infrastricture.Filters
{
    using Microsoft.AspNetCore.Mvc.Filters;
    using System;
    using System.Diagnostics;
    using System.IO;

    public class MeasureTimeAttribute: ActionFilterAttribute
    {
        private Stopwatch stopwatch;
        //public MeasureTimeAttribute()
        //{
        //    this.stopwatch = new Stopwatch();
        //}

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            this.stopwatch = Stopwatch.StartNew();
        }

        public override void OnResultExecuted(ResultExecutedContext context)
        {
            this.stopwatch.Stop();
            using (var writer = new StreamWriter("action-Times.txt", true))
            {
                var dateTime = DateTime.UtcNow;
                var controller = context.Controller.GetType().Name;                
                var action = context.RouteData.Values["action"];
                var elapesedTime = this.stopwatch.Elapsed;

                var logMsg = $"{dateTime} - {controller}.{action} - {elapesedTime}";

                writer.WriteLine(logMsg);
            }
        }
    }
}
