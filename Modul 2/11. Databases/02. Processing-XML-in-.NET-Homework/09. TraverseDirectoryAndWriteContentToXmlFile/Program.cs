namespace TraverseDirectoryAndWriteContentToXmlFile
{
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;

    internal class Program
    {
        private const string RootDirectory = @"C:\TMP\02. Processing-XML-in-.NET-Homework";

        private static void Main()
        {
            GenerateXmlDirectoryTree();
        }

        private static void GenerateXmlDirectoryTree()
        {
            const string fileName = "../../directory.xml";
            var encoding = Encoding.GetEncoding("utf-8");
            var rootDirectory = new DirectoryInfo(RootDirectory);
            using (var writer = new XmlTextWriter(fileName, encoding))
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = ' ';
                writer.Indentation = 2;

                writer.WriteStartDocument();
                writer.WriteStartElement("root");
                TraverseRootDirectoryRecursively(writer, rootDirectory);
                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }

        private static void TraverseRootDirectoryRecursively(XmlTextWriter writer, DirectoryInfo rootDirectory)
        {
            if (!rootDirectory.GetFiles().Any() && !rootDirectory.GetDirectories().Any())
            {
                return;
            }

            writer.WriteStartElement("dir");
            writer.WriteStartAttribute("name", rootDirectory.Name);

            foreach (var file in rootDirectory.GetFiles())
            {
                writer.WriteStartElement("file");
                writer.WriteStartAttribute("name", file.Name);
                writer.WriteEndElement();
            }

            foreach (var directory in rootDirectory.GetDirectories())
            {
                TraverseRootDirectoryRecursively(writer, directory);
            }

            writer.WriteEndElement();
        }
    }
}