using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(EstateManagment.Web.Areas.Identity.IdentityHostingStartup))]
namespace EstateManagment.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}