namespace RemoveAllAlbumsWithPriceGreatherThanTwentyUsingDOMParser
{
    using System.Xml;

    internal class Program
    {
        private static void Main()
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.Load("../../../catalog.xml");

            var rootNode = xmlDoc.DocumentElement;
            foreach (XmlElement album in rootNode.SelectNodes("album"))
            {
                var price = double.Parse(album["price"].InnerText);
                if (price > 20)
                {
                    rootNode.RemoveChild(album);
                }
            }

            xmlDoc.Save("../../new-catalog.xml");
        }
    }
}