namespace ConsoleWebServer.Framework.JsonActionResults
{
    using System.Collections.Generic;

    using HttpServerLogic;

    public class JsonActionResultWithCorsWithoutCaching : JsonActionResult
    {
        private readonly string corsSettings;

        public JsonActionResultWithCorsWithoutCaching(HttpRequest request, object content, string corsSettings)
            : base(request, content)
        {
            this.corsSettings = corsSettings;
        }

        public override void CreateResponseHeaders()
        {
            this.ResponseHeaders.Add(new KeyValuePair<string, string>("Access-Control-Allow-Origin", this.corsSettings));
            this.ResponseHeaders.Add(new KeyValuePair<string, string>("Cache-Control", "private, max-age=0, no-cache"));
        }
    }
}