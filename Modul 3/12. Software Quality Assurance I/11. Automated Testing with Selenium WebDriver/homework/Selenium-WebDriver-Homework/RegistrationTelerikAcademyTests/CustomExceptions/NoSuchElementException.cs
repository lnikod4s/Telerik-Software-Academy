namespace RegistrationTelerikAcademyTests.CustomExceptions
{
    using System;
    using System.Text;

    using OpenQA.Selenium;

    public class NoSuchElementException : ApplicationException
    {
        public NoSuchElementException()
        {
        }

        public NoSuchElementException(By by, GenericWebDriverTest ext, Exception ex)
        {
            var message = this.BuildNotFoundElementExceptionText(by, ext);

            throw new ApplicationException(message, ex);
        }

        public NoSuchElementException(By by, GenericWebDriverTest ext)
        {
            var message = this.BuildNotFoundElementExceptionText(by, ext);

            throw new ApplicationException(message);
        }

        private string BuildNotFoundElementExceptionText(By by, GenericWebDriverTest ext)
        {
            var sb = new StringBuilder();

            var customLoggingMessage = $"#### The element with the location strategy:  {@by} ####\n ####NOT FOUND!####";
            sb.AppendLine(customLoggingMessage);

            var cuurentUrlMessage = $"The URL when the test failed was: {ext.Browser.Url}";
            sb.AppendLine(cuurentUrlMessage);

            return sb.ToString();
        }
    }
}