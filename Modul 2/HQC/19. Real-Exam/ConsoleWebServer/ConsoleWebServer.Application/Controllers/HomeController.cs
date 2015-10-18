namespace ConsoleWebServer.Application.Controllers
{
    using Framework;
    using Framework.ContentActionResults;
    using Framework.Contracts;
    using Framework.HttpServerLogic;

    public class HomeController : Controller
    {
        public HomeController(HttpRequest request)
            : base(request)
        {
        }

        public IActionResult Index(string param)
        {
            return this.Content("Home page :)");
        }

        public IActionResult Forum(string param)
        {
            return this.Redirect(this.Request, param);
        }

        public IActionResult LivePage(string param)
        {
            return new ContentActionResultWithoutCaching(this.Request, "Live page with no caching");
        }

        public IActionResult LivePageForAjax(string param)
        {
            return new ContentActionResultWithCorsWithoutCaching(this.Request, "Live page with no caching and CORS", "*");
        }
    }
}