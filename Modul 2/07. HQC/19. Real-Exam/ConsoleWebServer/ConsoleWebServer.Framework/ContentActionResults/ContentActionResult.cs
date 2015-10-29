namespace ConsoleWebServer.Framework.ContentActionResults
{
    using System.Collections.Generic;
    using System.Net;

    using Contracts;

    using HttpServerLogic;

    public abstract class ContentActionResult : IActionResult
    {
        private readonly object content;

        public ContentActionResult(HttpRequest request, object content)
        {
            this.content = content;
            this.Request = request;
            this.ResponseHeaders = new List<KeyValuePair<string, string>>();
        }

        public HttpRequest Request { get; }

        public List<KeyValuePair<string, string>> ResponseHeaders { get; protected set; }

        public abstract void CreateResponseHeaders();

        public HttpResponse GetResponse()
        {
            var response = new HttpResponse(
                this.Request.ProtocolVersion, HttpStatusCode.OK, this.content.ToString());
            foreach (var responseHeader in this.ResponseHeaders)
            {
                response.AddHeader(responseHeader.Key, responseHeader.Value);
            }

            return response;
        }
    }
}