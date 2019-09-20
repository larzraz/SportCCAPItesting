using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace SportCCAPItesting.Models
{
    [XmlRoot(ElementName = "Official")]
    public class Official
    {
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "typeid")]
        public string Typeid { get; set; }
        [XmlAttribute(AttributeName = "typename")]
        public string Typename { get; set; }
        [XmlAttribute(AttributeName = "countryid")]
        public string Countryid { get; set; }
        [XmlAttribute(AttributeName = "countryname")]
        public string Countryname { get; set; }
        [XmlAttribute(AttributeName = "DateOfBirth")]
        public string DateOfBirth { get; set; }
    }

    [XmlRoot(ElementName = "OfficialsList")]
    public class OfficialsList
    {
        [XmlElement(ElementName = "Official")]
        public List<Official> Official { get; set; }
    }
}
