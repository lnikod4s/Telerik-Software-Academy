namespace ExtractAllSongTitlesFromCatalogUsingXmlReader
{
    using System;
    using System.Xml;

    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine("All song titles in the catalog:");
            Console.WriteLine(new string('-', 70));
            using (var reader = XmlReader.Create("../../../catalog.xml"))
            {
                while (reader.Read())
                {
                    if ((reader.NodeType == XmlNodeType.Element) &&
                        (reader.Name == "title"))
                    {
                        Console.WriteLine(reader.ReadElementString());
                    }
                }
            }
        }
    }
}