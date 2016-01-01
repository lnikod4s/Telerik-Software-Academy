namespace ConsoleWebServer.Framework.CustomExceptions
{
    using System;

    using HttpServerLogic;

    public class ParserException : Exception
    {
        public ParserException(string message, ActionDescriptor request = null)
            : base(message)
        {
        }
    }
}