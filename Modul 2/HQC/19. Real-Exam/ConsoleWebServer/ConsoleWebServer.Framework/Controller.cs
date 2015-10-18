namespace ConsoleWebServer.Framework
{
    using ContentActionResults;

    using Contracts;

    using HttpServerLogic;

    using JsonActionResults;

    public abstract class Controller
    {
        protected Controller(HttpRequest request)
        {
            this.Request = request;
        }

        public HttpRequest Request { get; }

        protected IActionResult Content(object model)
        {
            return new ContentActionResultBase(this.Request, model);
        }

        protected IActionResult Json(object model)
        {
            return new JsonActionResultBase(this.Request, model);
        }

        protected RedirectActionResult Redirect(object model, string uri)
        {
            return new RedirectActionResult(this.Request, model, uri);
        }
    }
}