namespace ExtractPricesForAlbumsPublishedInThe1980sUsingXPath
{
    using System;
    using System.Xml;

    internal class Program
    {
        private static void Main()
        {
            const string xPathQuery = "/catalog/album[year]";
            var xmlDoc = new XmlDocument();
            xmlDoc.Load("../../../catalog.xml");

            var albumsList = xmlDoc.SelectNodes(xPathQuery);
            foreach (XmlNode albumNode in albumsList)
            {
                var year = int.Parse(albumNode.SelectSingleNode("year").InnerText);
                if (year < 1990 && year >= 1980)
                {
                    var albumName = albumNode.SelectSingleNode("name").InnerText;
                    var albumPrice = albumNode.SelectSingleNode("price").InnerText;
                    Console.WriteLine("{0}: {1}$", albumName, albumPrice);
                }
            }
        }
    }
}