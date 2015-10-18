namespace ConsoleWebServer.Framework.ContentActionResults
{
    using System.Collections.Generic;

    using HttpServerLogic;

    public class ContentActionResultWithCors<TResult> : ContentActionResult
    {
        private readonly string corsSettings;

        public ContentActionResultWithCors(HttpRequest request, object content, string corsSettings)
            : base(request, content)
        {
            this.corsSettings = corsSettings;
        }

        public override void CreateResponseHeaders()
        {
            this.ResponseHeaders.Add(new KeyValuePair<string, string>("Access-Control-Allow-Origin", this.corsSettings));
        }
    }
}