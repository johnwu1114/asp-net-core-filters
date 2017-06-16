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
                config.Filters.Add(new ActionFilter());
                config.Filters.Add(new ResultFilter());
                config.Filters.Add(new ExceptionFilter());
                config.Filters.Add(new ResourceFilter());
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