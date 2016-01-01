namespace Processing_JSON_in_.NET_Homework
{
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    public class HtmlGenerator
    {
        private const string ItemTemplateFormat = "<li><a href=\"\"><strong>[{0}]</strong></a></li>";

        public void CreateHtmlPage(string path, IEnumerable<IVideo> listItems)
        {
            var html = this.GenerateHtml(listItems);
            this.CreateFile(path, html);
        }

        private string GenerateHtml(IEnumerable<IVideo> listItems)
        {
            var html = new StringBuilder();
            html.AppendLine("<ul>");

            foreach (var listItem in listItems)
            {
                html.AppendFormat(ItemTemplateFormat, listItem.Title);
            }

            html.AppendLine("<ul>");
            return html.ToString();
        }

        private void CreateFile(string path, string html)
        {
            using (FileStream fileStream = new FileStream(path, FileMode.Create))
            {
                using (StreamWriter streamWriter = new StreamWriter(fileStream, Encoding.UTF8))
                {
                    streamWriter.WriteLine(html);
                }
            }
        }
    }
}