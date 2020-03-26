using Microsoft.AspNetCore.Mvc.Filters;
using System.Text;
using System.Threading.Tasks;
using Tests.Infrastructure.Contarcts;

namespace Tests.Infrastructure.Filters
{
    public class DiagnosticFilter : IAsyncResultFilter
    {
        private readonly IFilterDiagnostics diagnostics;

        public DiagnosticFilter(IFilterDiagnostics diagnostics)
        {
            this.diagnostics = diagnostics;
        }

        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            await next();
            foreach (var msg in diagnostics.Messages)
            {
                var bytes = Encoding.ASCII.GetBytes($"<div>{msg}</div>");
                await context.HttpContext.Response.Body.WriteAsync(bytes, 0, bytes.Length);
            }

        }
    }
}
