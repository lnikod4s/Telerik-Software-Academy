namespace ExtractAllSongTitlesFromCatalogUsingLINQ
{
    using System;
    using System.Linq;
    using System.Xml.Linq;

    internal class Program
    {
        private static void Main()
        {
            var xmlDoc = XDocument.Load("../../../catalog.xml");
            var songs =
                from song in xmlDoc.Descendants("song")
                select new
                {
                    Title = song.Element("title").Value
                };

            Console.WriteLine("All song titles in catalog:");
            Console.WriteLine(new string('-', 70));
            foreach (var song in songs)
            {
                Console.WriteLine(song.Title);
            }
        }
    }
}