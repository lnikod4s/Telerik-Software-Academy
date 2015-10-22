namespace Cars.XmlSearcher.Mapping
{
    using System.Xml.Serialization;

    public class WhereClause
    {
        [XmlAttribute]
        public string PropertyName { get; set; }

        [XmlAttribute]
        public string Type { get; set; }

        [XmlIgnore]
        public WhereType TypeAsEnum
        {
            get
            {
                switch (this.Type)
                {
                    case "Contains":
                        return WhereType.Contains;
                    case "GreaterThan":
                        return WhereType.GreaterThan;
                    case "LessThan":
                        return WhereType.LessThan;
                    default:
                        return WhereType.Equals;
                }
            }
        }

        [XmlText]
        public string Value { get; set; }
    }
}