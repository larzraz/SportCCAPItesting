using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace SportCCAPItesting.Models
{
    [XmlRoot(ElementName = "Card")]
    public class Card
    {
        [XmlAttribute(AttributeName = "cardid")]
        public string Cardid { get; set; }
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
        [XmlAttribute(AttributeName = "team")]
        public string Team { get; set; }
        [XmlAttribute(AttributeName = "minute")]
        public string Minute { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "surname")]
        public string Surname { get; set; }
        [XmlAttribute(AttributeName = "firstname")]
        public string Firstname { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
        [XmlAttribute(AttributeName = "OldPlayerId")]
        public string OldPlayerId { get; set; }
    }

    [XmlRoot(ElementName = "Cards")]
    public class Cards
    {
        [XmlElement(ElementName = "Card")]
        public List<Card> Card { get; set; }
    }
}
