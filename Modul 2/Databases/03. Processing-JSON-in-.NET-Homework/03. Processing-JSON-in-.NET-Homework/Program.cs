namespace Processing_JSON_in_.NET_Homework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Xml.Linq;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    internal class Program
    {
        private const string RssFeedUri = "https://www.youtube.com/feeds/videos.xml?channel_id=UCLC-vbm7OWvpbqzXaoAMGGw";
        private const string RssDownloadLocation = "../../rss.xml";

        private static void Main()
        {
            //Console.OutputEncoding = Encoding.UTF8;
            DownloadContentFromUri(RssFeedUri, RssDownloadLocation);

            var fileContent = Utility.GetFileContent(RssDownloadLocation);
            var xml = ConvertStringToXml(fileContent);
            var json = ConvertXmlToJson(xml);
            var poco = ConvertJsonToPoco(json);

            var videoTitles = SelectVideoTitlesFromJson(json);
            //Console.WriteLine(string.Join("\n", videoTitles));

            var htmlGenerator = new HtmlGenerator();
            htmlGenerator.CreateHtmlPage("../../rss.html", poco);
        }

        private static IEnumerable<IVideo> ConvertJsonToPoco(string json)
        {
            var jObject = JObject.Parse(json);
            var videosSet = jObject["feed"]["entry"];

            return videosSet.Select(video => JsonConvert.DeserializeObject<Video>(video.ToString()))
                .Cast<IVideo>()
                .ToList();
        }

        private static IEnumerable<JToken> SelectVideoTitlesFromJson(string json)
        {
            var jObject = JObject.Parse(json);
            var videoTitles = jObject["feed"]["entry"].Select(e => e["title"]);
            return videoTitles;
        }

        private static string ConvertXmlToJson(XObject xml)
        {
            var xmlToJson = JsonConvert.SerializeXNode(xml);
            return xmlToJson;
        }

        private static XDocument ConvertStringToXml(string fileContent)
        {
            var xml = XDocument.Parse(fileContent);
            return xml;
        }

        private static void DownloadContentFromUri(string uri, string path)
        {
            using (var webClient = new WebClient())
            {
                webClient.DownloadFile(uri, path);
            }
        }
    }
}