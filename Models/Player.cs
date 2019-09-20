using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace SportCCAPItesting.Models
{
    [XmlRoot(ElementName = "Player")]
    public class Player
    {
        [XmlElement(ElementName = "Transfer")]
        public List<Transfer> Transfer { get; set; }
        [XmlAttribute(AttributeName = "ID")]
        public string ID { get; set; }
        [XmlAttribute(AttributeName = "Name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "surname")]
        public string Surname { get; set; }
        [XmlAttribute(AttributeName = "firstname")]
        public string Firstname { get; set; }
        [XmlAttribute(AttributeName = "CountryId")]
        public string CountryId { get; set; }
        [XmlAttribute(AttributeName = "Country")]
        public string Country { get; set; }
        [XmlAttribute(AttributeName = "Position")]
        public string Position { get; set; }
        [XmlAttribute(AttributeName = "ShirtNumber")]
        public string ShirtNumber { get; set; }
        [XmlAttribute(AttributeName = "DateOfBirth")]
        public string DateOfBirth { get; set; }
        [XmlAttribute(AttributeName = "Height")]
        public string Height { get; set; }
        [XmlAttribute(AttributeName = "Weight")]
        public string Weight { get; set; }
        [XmlAttribute(AttributeName = "Foot")]
        public string Foot { get; set; }
        [XmlAttribute(AttributeName = "Age")]
        public string Age { get; set; }
        [XmlAttribute(AttributeName = "BirthCountry")]
        public string BirthCountry { get; set; }
        [XmlAttribute(AttributeName = "BirthPlace")]
        public string BirthPlace { get; set; }
    }
    [XmlRoot(ElementName = "PlayerList")]
    public class PlayerList
    {
        [XmlElement(ElementName = "Player")]
        public List<Player> Player { get; set; }
        [XmlAttribute(AttributeName = "TeamId")]
        public string TeamId { get; set; }
        [XmlAttribute(AttributeName = "TeamName")]
        public string TeamName { get; set; }
    }

}
