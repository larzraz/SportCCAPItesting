using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace SportCCAPItesting.Models
{

    [XmlRoot(ElementName = "Competitor")]
    public class Competitor
    {
        [XmlElement(ElementName = "Tournament")]
        public List<Tournament> Tournament { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "Country")]
        public string Country { get; set; }
        [XmlAttribute(AttributeName = "Countryid")]
        public string Countryid { get; set; }
        [XmlAttribute(AttributeName = "tid")]
        public string Tid { get; set; }
        [XmlAttribute(AttributeName = "sn")]
        public string Sn { get; set; }
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
       [XmlAttribute(AttributeName= "ID")]
		public string ID { get; set; }

        [XmlElement(ElementName = "Home")]
        public Home Home { get; set; }
        [XmlElement(ElementName = "Away")]
        public Away Away { get; set; }
        [XmlElement(ElementName = "Total")]
        public Total Total { get; set; }
        [XmlAttribute(AttributeName = "Place")]
        public string Place { get; set; }

        public int PlaceInt { get; set; }

    }
}
