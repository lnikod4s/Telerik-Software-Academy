namespace Cars.XmlSearcher.Mapping
{
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class Queries
    {

        private QueriesQuery[] queryField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Query")]
        public QueriesQuery[] Query
        {
            get
            {
                return this.queryField;
            }
            set
            {
                this.queryField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class QueriesQuery
    {

        private string orderByField;

        private QueriesQueryWhereClause[] whereClausesField;

        private string outputFileNameField;

        /// <remarks/>
        public string OrderBy
        {
            get
            {
                return this.orderByField;
            }
            set
            {
                this.orderByField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("WhereClause", IsNullable = false)]
        public QueriesQueryWhereClause[] WhereClauses
        {
            get
            {
                return this.whereClausesField;
            }
            set
            {
                this.whereClausesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string OutputFileName
        {
            get
            {
                return this.outputFileNameField;
            }
            set
            {
                this.outputFileNameField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class QueriesQueryWhereClause
    {

        private string propertyNameField;

        private string typeField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string PropertyName
        {
            get
            {
                return this.propertyNameField;
            }
            set
            {
                this.propertyNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }


}