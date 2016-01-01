namespace ConsoleWebServer.Framework.JsonActionResults
{
    using System.Collections.Generic;

    using HttpServerLogic;

    public class JsonActionResultBase : JsonActionResult
    {
        public JsonActionResultBase(HttpRequest request, object content)
            : base(request, content)
        {
        }

        public override void CreateResponseHeaders()
        {
            this.ResponseHeaders = new List<KeyValuePair<string, string>>();
        }
    }
}