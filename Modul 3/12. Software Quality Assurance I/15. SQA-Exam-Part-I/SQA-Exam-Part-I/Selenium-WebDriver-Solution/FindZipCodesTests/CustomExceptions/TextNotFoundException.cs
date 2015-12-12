namespace FindZipCodesTests.CustomExceptions
{
    using System;
    using System.Text;

    public class TextNotFoundException : ApplicationException
    {
        public TextNotFoundException()
        {
        }

        public TextNotFoundException(string textToFind, GenericWebDriverTest ext, Exception ex)
        {
            var message = this.BuildTextNotFoundExceptionText(textToFind, ext);

            throw new ApplicationException(message, ex);
        }

        public TextNotFoundException(string textToFind, GenericWebDriverTest ext)
        {
            var message = this.BuildTextNotFoundExceptionText(textToFind, ext);

            throw new ApplicationException(message);
        }

        private string BuildTextNotFoundExceptionText(string textToFind, GenericWebDriverTest ext)
        {
            var sb = new StringBuilder();

            var customLoggingMessage = $"#### The text:  {textToFind} ####\n ####WAS NOT FOUND!####";
            sb.AppendLine(customLoggingMessage);

            var cuurentUrlMessage = $"The URL when the test failed was: {ext.Browser.Url}";
            sb.AppendLine(cuurentUrlMessage);

            return sb.ToString();
        }
    }
}