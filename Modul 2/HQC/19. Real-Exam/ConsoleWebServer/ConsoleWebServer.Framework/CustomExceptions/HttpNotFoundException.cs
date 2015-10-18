namespace ConsoleWebServer.Framework.CustomExceptions
{
    using System;

    public class HttpNotFoundException : Exception
    {
        public const string ClassName = "HttpNotFoundException";

        public HttpNotFoundException(string message)
            : base(message)
        {
        }
    }
}