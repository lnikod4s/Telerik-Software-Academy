namespace ConsoleWebServer.Framework.JsonActionResults
{
    using System.Collections.Generic;

    using HttpServerLogic;

    public class JsonActionResultWithCors : JsonActionResult
    {
        private readonly string corsSetting;

        public JsonActionResultWithCors(HttpRequest request, object content, string corsSettings)
            : base(request, content)
        {
            this.corsSetting = corsSettings;
        }

        public override void CreateResponseHeaders()
        {
            this.ResponseHeaders.Add(new KeyValuePair<string, string>("Access-Control-Allow-Origin", this.corsSetting));
        }
    }
}