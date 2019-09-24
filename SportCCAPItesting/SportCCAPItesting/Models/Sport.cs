using SportCCAPItesting.Models.Matches;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace SportCCAPItesting.Models
{

    [XmlRoot(ElementName = "Sport")]
    public class Sport
    {
        [XmlElement(ElementName = "Category")]
        public List<Category> Category { get; set; }
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
    public class Sportccbetdata : BaseModel
    {
        private CountryList _countryList;

        [XmlElement(ElementName = "SportList")]
        public SportList SportList { get; set; }
        [XmlElement(ElementName = "CountryList")]
        public CountryList CountryList { get { return _countryList; } set { _countryList = value; OnPropertyChanged("CountryList"); } }

        [XmlElement(ElementName = "BookmakerList")]
        public BookmakerList BookmakerList { get; set; }

        [XmlElement(ElementName = "VenueList")]
        public VenueList VenueList { get; set; }
        [XmlElement(ElementName = "Sport")]
        public Sport Sport { get; set; }
        [XmlElement(ElementName = "PlayerList")]
        public PlayerList PlayerList { get; set; }

        [XmlElement(ElementName = "Sports")]
        public Sports Sports { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
        [XmlElement(ElementName = "OfficialsList")]
        public OfficialsList OfficialsList { get; set; }

        [XmlElement(ElementName = "CoachList")]
        public CoachList CoachList { get; set; }
        [XmlElement(ElementName = "Category")]
        public Category Category { get; set; }
        [XmlElement(ElementName = "Error")]
        public Error Error { get; set; }
        [XmlElement(ElementName = "events")]
        public Events Events { get; set; }
        [XmlAttribute(AttributeName = "latest")]
        public string Latest { get; set; }

        [XmlElement(ElementName = "SubContests")]
        public SubContests SubContests { get; set; }

    }

    [XmlRoot(ElementName = "Sports")]
    public class Sports
    {
        [XmlElement(ElementName = "Sport")]
        public Sport Sport { get; set; }
    }




}


