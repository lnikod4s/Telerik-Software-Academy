namespace ConsoleWebServer.Framework.Common
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Reflection;

    using Contracts;

    using CustomExceptions;

    using HttpServerLogic;

    public class ResponseProvider
    {
        public HttpResponse GetResponse(string requestAsString)
        {
            HttpRequest request;
            try
            {
                var requestParser = new HttpRequest("GET", "/", "1.1");
                request = requestParser.Parse(requestAsString);
            }
            catch (Exception ex)
            {
                return new HttpResponse(new Version(1, 1), HttpStatusCode.BadRequest, ex.Message);
            }

            var response = this.Process(request);
            return response;
        }

        private HttpResponse Process(HttpRequest request)
        {
            if (request.Method.ToLower() == "head")
            {
                return new HttpResponse(request.ProtocolVersion, HttpStatusCode.OK, string.Empty);
            }

            if (request.Method.ToLower() == "options")
            {
                var routes =
                    Assembly.GetEntryAssembly()
                            .GetTypes()
                            .Where(x => x.Name.EndsWith("Controller") && typeof(Controller).IsAssignableFrom(x))
                            .Select(
                                x =>
                                    new
                                    {
                                        x.Name,
                                        Methods = x.GetMethods().Where(m => m.ReturnType == typeof(IActionResult))
                                    })
                            .SelectMany(
                                x => x.Methods.Select(
                                    m => string.Format(
                                        "/{0}/{1}/{{parameter}}",
                                        x.Name.Replace("Controller", string.Empty),
                                        m.Name)))
                            .ToList();

                return new HttpResponse(request.ProtocolVersion, HttpStatusCode.OK, string.Join(Environment.NewLine, routes));
            }

            if (new StaticFileHandler().CanHandle(request))
            {
                return new StaticFileHandler().Handle(request);
            }

            if (request.ProtocolVersion.Major <= 3)
            {
                HttpResponse response;
                try
                {
                    var controller = this.CreateController(request);
                    var actionInvoker = new ActionInvoker();
                    var actionResult = actionInvoker.InvokeAction(controller, request.Action);
                    response = actionResult.GetResponse();
                }
                catch (HttpNotFoundException exception)
                {
                    response = new HttpResponse(request.ProtocolVersion, HttpStatusCode.NotFound, exception.Message);
                }
                catch (Exception exception)
                {
                    response = new HttpResponse(request.ProtocolVersion, HttpStatusCode.InternalServerError, exception.Message);
                }

                return response;
            }

            return new HttpResponse(request.ProtocolVersion, HttpStatusCode.NotImplemented, "Request cannot be handled.");
        }

        private Controller CreateController(HttpRequest request)
        {
            var controllerClassName = request.Action.ControllerName + "Controller";
            var type =
                Assembly.GetEntryAssembly()
                        .GetTypes()
                        .FirstOrDefault(
                            x =>
                                x.Name.ToLower() == controllerClassName.ToLower() &&
                                typeof(Controller).IsAssignableFrom(x));
            if (type == null)
            {
                throw new HttpNotFoundException(
                    string.Format("Controller with name {0} not found!", controllerClassName));
            }

            var instance = (Controller)Activator.CreateInstance(type, request);
            return instance;
        }
    }
}