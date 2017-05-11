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
            await context.Response.WriteAsync($"{nameof(FirstMiddleware)} in. \r\n");

            await _next(context);

            await context.Response.WriteAsync($"{nameof(FirstMiddleware)} out. \r\n");
        }
    }
}