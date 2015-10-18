namespace ConsoleWebServer.Application
{
    public static class Program
    {
        public static void Main()
        {
            var webSever = new WebServerConsoleLogger();
            webSever.Start();
        }
    }
}