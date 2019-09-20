using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace SportCCAPItesting.Models
{
    [XmlRoot(ElementName = "Tournament")]
    public class Tournament
    {
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "contestgroupid")]
        public string Contestgroupid { get; set; }
        [XmlAttribute(AttributeName = "season")]
        public string Season { get; set; }
        [XmlAttribute(AttributeName = "contestCountryId")]
        public string ContestCountryId { get; set; }
        [XmlAttribute(AttributeName = "contestCountry")]
        public string ContestCountry { get; set; }
    }
}
