using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace SportCCAPItesting.Models
{
    [XmlRoot(ElementName = "Bookmaker")]
    public class Bookmaker
    {
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
    }

    [XmlRoot(ElementName = "BookmakerList")]
    public class BookmakerList
    {
        [XmlElement(ElementName = "Bookmaker")]
        public List<Bookmaker> Bookmaker { get; set; }
    }

}
