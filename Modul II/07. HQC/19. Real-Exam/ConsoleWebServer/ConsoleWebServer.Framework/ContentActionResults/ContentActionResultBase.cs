namespace ConsoleWebServer.Framework.ContentActionResults
{
    using System.Collections.Generic;

    using HttpServerLogic;

    public class ContentActionResultBase : ContentActionResult
    {
        public ContentActionResultBase(HttpRequest request, object content)
            : base(request, content)
        {
        }

        public override void CreateResponseHeaders()
        {
            this.ResponseHeaders = new List<KeyValuePair<string, string>>();
        }
    }
}