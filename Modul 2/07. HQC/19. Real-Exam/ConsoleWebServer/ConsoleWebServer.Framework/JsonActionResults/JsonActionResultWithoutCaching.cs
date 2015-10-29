namespace ConsoleWebServer.Framework.JsonActionResults
{
    using System.Collections.Generic;

    using HttpServerLogic;

    public class JsonActionResultWithoutCaching : JsonActionResult
    {
        public JsonActionResultWithoutCaching(HttpRequest request, object content)
            : base(request, content)
        {
        }

        public override void CreateResponseHeaders()
        {
            this.ResponseHeaders.Add(new KeyValuePair<string, string>("Cache-Control", "private, max-age=0, no-cache"));
        }
    }
}