namespace ExtractArtistsFromCatalogUsingXPath
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Xml;

    internal class Program
    {
        private static void Main()
        {
            const string xPathQuery = "/catalog/album";

            var xmlDoc = new XmlDocument();
            xmlDoc.Load("../../../catalog.xml");

            var albumsList = xmlDoc.SelectNodes(xPathQuery);
            var artistsList = ExtractArtistsFromCatalog(albumsList);

            PrintArtists(artistsList);
        }

        private static void PrintArtists(Dictionary<string, int> artistsList)
        {
            foreach (var artist in artistsList)
            {
                Console.WriteLine("{0}: {1} album(s)", artist.Key, artist.Value);
            }
        }

        private static Dictionary<string, int> ExtractArtistsFromCatalog(IEnumerable albumsList)
        {
            var artistsList = new Dictionary<string, int>();
            foreach (XmlNode album in albumsList)
            {
                var artistName = album.SelectSingleNode("artist").InnerText;
                if (!artistsList.ContainsKey(artistName))
                {
                    artistsList[artistName] = 0;
                }

                artistsList[artistName]++;
            }

            return artistsList;
        }
    }
}