namespace XSLTransformation
{
    using System.Xml.Xsl;

    internal class Program
    {
        private static void Main()
        {
            var xslt = new XslCompiledTransform();
            xslt.Load("../../catalog.xsl");
            xslt.Transform("../../catalog.xml", "../../catalog.html");
        }
    }
}