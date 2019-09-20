using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace SportCCAPItesting.Models
{
    [XmlRoot(ElementName = "Venue")]
    public class Venue
    {
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "countryid")]
        public string Countryid { get; set; }
        [XmlAttribute(AttributeName = "countryname")]
        public string Countryname { get; set; }
        [XmlAttribute(AttributeName = "teamhostid")]
        public string Teamhostid { get; set; }
        [XmlAttribute(AttributeName = "teamhostname")]
        public string Teamhostname { get; set; }
        [XmlAttribute(AttributeName = "Capacity")]
        public string Capacity { get; set; }
        [XmlAttribute(AttributeName = "sportid")]
        public string Sportid { get; set; }

        public int IDToInt { get; set; }
    }

    [XmlRoot(ElementName = "VenueList")]
    public class VenueList
    {
        [XmlElement(ElementName = "Venue")]
        public List<Venue> Venue { get; set; }
    }

}
