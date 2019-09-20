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
    }
}
