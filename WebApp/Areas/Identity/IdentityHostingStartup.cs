using Microsoft.AspNetCore.Hosting;
using WebApplication2.Areas.Identity;

[assembly: HostingStartup(typeof(IdentityHostingStartup))]
namespace WebApplication2.Areas.Identity
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