namespace RegistrationTelerikAcademyTests.CustomExceptions
{
    using System;
    using System.Text;

    using OpenQA.Selenium;

    public class NotCheckedException : ApplicationException
    {
        public NotCheckedException()
        {
        }

        public NotCheckedException(By by, GenericWebDriverTest ext, Exception ex)
        {
            var message = this.BuildNotCheckedExceptionText(by, ext);

            throw new ApplicationException(message, ex);
        }

        public NotCheckedException(By by, GenericWebDriverTest ext)
        {
            var message = this.BuildNotCheckedExceptionText(by, ext);

            throw new ApplicationException(message);
        }

        private string BuildNotCheckedExceptionText(By by, GenericWebDriverTest ext)
        {
            var sb = new StringBuilder();

            var customLoggingMessage =
                $"#### The element with the location strategy:  {@by} ####\n ####WAS NOT CHECKED!####";
            sb.AppendLine(customLoggingMessage);

            var cuurentUrlMessage = $"The URL when the test failed was: {ext.Browser.Url}";
            sb.AppendLine(cuurentUrlMessage);

            return sb.ToString();
        }
    }
}