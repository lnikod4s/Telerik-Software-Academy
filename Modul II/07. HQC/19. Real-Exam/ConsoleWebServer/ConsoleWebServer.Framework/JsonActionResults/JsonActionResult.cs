namespace ConsoleWebServer.Framework.JsonActionResults
{
    using System.Collections.Generic;
    using System.Net;

    using Common;

    using Contracts;

    using HttpServerLogic;

    using Newtonsoft.Json;

    public abstract class JsonActionResult : IActionResult
    {
        private readonly object content;

        public JsonActionResult(HttpRequest request, object content)
        {
            this.content = content;
            this.Request = request;
        }

        public HttpRequest Request { get; }

        public List<KeyValuePair<string, string>> ResponseHeaders { get; protected set; }

        public abstract void CreateResponseHeaders();

        public HttpResponse GetResponse()
        {
            var response = new HttpResponse(
                this.Request.ProtocolVersion,
                this.GetStatusCode(),
                this.GetContent(),
                HighQualityCodeExamPointsProvider.GetContentType());
            foreach (var responseHeader in this.ResponseHeaders)
            {
                response.AddHeader(responseHeader.Key, responseHeader.Value);
            }

            return response;
        }

        public virtual HttpStatusCode GetStatusCode()
        {
            return HttpStatusCode.OK;
        }

        public string GetContent()
        {
            return JsonConvert.SerializeObject(this.content);
        }
    }
}