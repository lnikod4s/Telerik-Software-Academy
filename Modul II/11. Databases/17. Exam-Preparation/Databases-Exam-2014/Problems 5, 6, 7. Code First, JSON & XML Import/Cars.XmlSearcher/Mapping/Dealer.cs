namespace Cars.XmlSearcher.Mapping
{
    using System.Collections.Generic;
    using System.Xml.Serialization;

    public class Dealer
    {
        [XmlAttribute]
        public string Name { get; set; }

        [XmlArrayItem(ElementName = "City")]
        public List<string> Cities { get; set; }
    }
}