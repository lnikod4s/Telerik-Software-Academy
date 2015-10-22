namespace Cars.XmlSearcher.Mapping
{
    using System;
    using System.Xml.Serialization;

    [Serializable]
    public class Car
    {
        [XmlIgnore]
        public int Id { get; set; }

        [XmlAttribute]
        public string Manufacturer { get; set; }

        [XmlAttribute]
        public string Model { get; set; }

        [XmlAttribute]
        public int Year { get; set; }

        [XmlAttribute]
        public decimal Price { get; set; }

        public string TransmissionType { get; set; }

        public Dealer Dealer { get; set; }
    }
}