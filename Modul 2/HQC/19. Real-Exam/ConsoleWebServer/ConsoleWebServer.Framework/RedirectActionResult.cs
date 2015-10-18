namespace ConsoleWebServer.Framework
{
    using System.Collections.Generic;

    using ContentActionResults;

    using HttpServerLogic;

    public class RedirectActionResult : ContentActionResult
    {
        private readonly string uri;

        public RedirectActionResult(HttpRequest request, object content, string uri)
            : base(request, content)
        {
            this.uri = uri;
        }

        public override void CreateResponseHeaders()
        {
            this.ResponseHeaders = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("Location", this.uri)
            };
        }
    }
}