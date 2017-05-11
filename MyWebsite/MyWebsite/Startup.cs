using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using MyWebsite.Middlewares;

namespace MyWebsite
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            app.UseMiddleware<FirstMiddleware>();
            app.UseMiddleware<SecondMiddleware>();
            app.UseMiddleware<ThirdMiddleware>();

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World! \r\n");
            });
        }
    }
}