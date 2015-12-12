namespace FindZipCodesTests.CustomExceptions
{
    using System;
    using System.Text;

    using OpenQA.Selenium;

    public class StillCheckedException : ApplicationException
    {
        public StillCheckedException()
        {
        }

        public StillCheckedException(By by, GenericWebDriverTest ext, Exception ex)
        {
            var message = this.BuildStillCheckedExceptionText(by, ext);

            throw new ApplicationException(message, ex);
        }

        public StillCheckedException(By by, GenericWebDriverTest ext)
        {
            var message = this.BuildStillCheckedExceptionText(by, ext);

            throw new ApplicationException(message);
        }

        private string BuildStillCheckedExceptionText(By by, GenericWebDriverTest ext)
        {
            var sb = new StringBuilder();

            var customLoggingMessage =
                $"#### The element with the location strategy:  {@by} ####\n ####WAS CHECKED!####";
            sb.AppendLine(customLoggingMessage);

            var cuurentUrlMessage = $"The URL when the test failed was: {ext.Browser.Url}";
            sb.AppendLine(cuurentUrlMessage);

            return sb.ToString();
        }
    }
}