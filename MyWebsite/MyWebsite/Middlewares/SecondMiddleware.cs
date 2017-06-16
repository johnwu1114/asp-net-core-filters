using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace MyWebsite.Middlewares
{
    public class SecondMiddleware
    {
        private readonly RequestDelegate _next;

        public SecondMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            await context.Response.WriteAsync($"{GetType().Name} in. \r\n");

            await _next(context);

            await context.Response.WriteAsync($"{GetType().Name} out. \r\n");
        }
    }
}