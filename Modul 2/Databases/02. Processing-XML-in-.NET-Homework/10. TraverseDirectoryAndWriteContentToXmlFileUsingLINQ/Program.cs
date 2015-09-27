namespace TraverseDirectoryAndWriteContentToXmlFileUsingLINQ
{
    using System.IO;
    using System.Xml.Linq;

    internal class Program
    {
        private const string RootDirectory = @"C:\TMP\02. Processing-XML-in-.NET-Homework";

        private static void Main()
        {
            GenerateXmlDirectoryTree();
        }

        private static void GenerateXmlDirectoryTree()
        {
            var rootDir = new DirectoryInfo(RootDirectory);
            var xmlDirTree = GenerateXmlDirectoryTree(rootDir);
            var xDoc = new XDocument(xmlDirTree);
            xDoc.Save("../../directory.xml");
        }

        private static XElement GenerateXmlDirectoryTree(DirectoryInfo rootDir)
        {
            var dirsXml = new XElement("root");
            var subtreeXml = GenerateXmlDirectoryTreeRecursively(rootDir);
            dirsXml.Add(subtreeXml);

            return dirsXml;
        }

        private static XElement GenerateXmlDirectoryTreeRecursively(DirectoryInfo rootDir)
        {
            var dirXml = new XElement("dir", new XAttribute("name", rootDir.Name));

            foreach (var file in rootDir.GetFiles())
            {
                var fileXml = new XElement("file", new XAttribute("name", file.Name));
                dirXml.Add(fileXml);
            }

            foreach (var directory in rootDir.GetDirectories())
            {
                dirXml.Add(GenerateXmlDirectoryTreeRecursively(directory));
            }

            return dirXml;
        }
    }
}