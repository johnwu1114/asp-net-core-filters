using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using MyWebsite.Filters;
using MyWebsite.Middlewares;

namespace MyWebsite
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(config =>
            {
                config.Filters.Add(new FirstActionFilter());
                config.Filters.Add(new ResultFilter());
                config.Filters.Add(new ExceptionFilter());
            });
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseMiddleware<FirstMiddleware>();
            //app.UseMiddleware<SecondMiddleware>();
            //app.UseMiddleware<ThirdMiddleware>();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}"
                );
            });
        }
    }
}