using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace SportCCAPItesting.Models
{

    [XmlRoot(ElementName = "Sport")]
    public class Sport
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }

        [XmlElement(ElementName = "Competitor")]
        public List<Competitor> Competitor { get; set; }
    }

    [XmlRoot(ElementName = "SportList")]
    public class SportList
    {
        [XmlElement(ElementName = "Sport")]
        public List<Sport> Sport { get; set; }
    }

    [XmlRoot(ElementName = "sportccbetdata")]
    public class Sportccbetdata
    {
        [XmlElement(ElementName = "SportList")]
        public SportList SportList { get; set; }
        [XmlElement(ElementName = "CountryList")]
        public CountryList CountryList { get; set; }

        [XmlElement(ElementName = "VenueList")]
        public VenueList VenueList { get; set; }
        [XmlElement(ElementName = "Sport")]
        public Sport Sport { get; set; }
        [XmlElement(ElementName = "PlayerList")]
        public PlayerList PlayerList { get; set; }
    }


}


