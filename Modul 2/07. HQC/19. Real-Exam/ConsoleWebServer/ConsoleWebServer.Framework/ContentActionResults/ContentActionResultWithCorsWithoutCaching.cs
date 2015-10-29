namespace ConsoleWebServer.Framework.ContentActionResults
{
    using System.Collections.Generic;

    using HttpServerLogic;

    public class ContentActionResultWithCorsWithoutCaching : ContentActionResult
    {
        private readonly string corsSettings;

        public ContentActionResultWithCorsWithoutCaching(HttpRequest request, object content, string corsSettings)
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