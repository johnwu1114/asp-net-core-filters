using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace MyWebsite.Middlewares
{
    public class FirstMiddleware
    {
        private readonly RequestDelegate _next;

        public FirstMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            await context.Response.WriteAsync($"{GetType().Name} in. \r\n");

            try
            {
                await _next(context);
            }
            catch
            {
                await context.Response.WriteAsync($"{GetType().Name} catch exception. \r\n");
            }

            await context.Response.WriteAsync($"{GetType().Name} out. \r\n");
        }
    }
}