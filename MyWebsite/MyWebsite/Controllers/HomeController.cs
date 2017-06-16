using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebsite.Filters;

namespace MyWebsite.Controllers
{
    [TypeFilter(typeof(AuthorizationFilter))]
    public class HomeController : Controller
    {
        [TypeFilter(typeof(SecondActionFilter))]
        public void Index()
        {
            Response.WriteAsync("Hello World! \r\n");
        }
    }
}