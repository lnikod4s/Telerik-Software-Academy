namespace RegistrationTelerikAcademyTests.CustomExceptions
{
    using System;
    using System.Text;

    using OpenQA.Selenium;

    public class ElementStillVisibleException : ApplicationException
    {
        public ElementStillVisibleException()
        {
        }

        public ElementStillVisibleException(By by, GenericWebDriverTest ext, Exception ex)
        {
            var message = this.BuildElementStillVisibleExceptionText(by, ext);

            throw new ApplicationException(message, ex);
        }

        public ElementStillVisibleException(By by, GenericWebDriverTest ext)
        {
            var message = this.BuildElementStillVisibleExceptionText(by, ext);

            throw new ApplicationException(message);
        }

        private string BuildElementStillVisibleExceptionText(By by, GenericWebDriverTest ext)
        {
            var sb = new StringBuilder();

            var customLoggingMessage =
                $"#### The element with the location strategy:  {@by} ####\n ####IS STILL VISIBLE!####";
            sb.AppendLine(customLoggingMessage);

            var curentUrlMessage = $"The URL when the test failed was: {ext.Browser.Url}";
            sb.AppendLine(curentUrlMessage);

            return sb.ToString();
        }
    }
}