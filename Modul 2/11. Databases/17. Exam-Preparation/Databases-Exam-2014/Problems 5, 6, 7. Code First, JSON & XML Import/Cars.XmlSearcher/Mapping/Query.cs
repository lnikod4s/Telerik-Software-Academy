namespace Cars.XmlSearcher.Mapping
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;

    [Serializable]
    public class Query
    {
        [XmlAttribute]
        public string OutputFileName { get; set; }

        // Id, Year, Model, Price, Manufacturer, Dealer
        public string OrderBy { get; set; }

        public List<WhereClause> WhereClauses { get; set; }
    }
}