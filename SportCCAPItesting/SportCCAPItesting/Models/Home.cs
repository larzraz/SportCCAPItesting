using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace SportCCAPItesting.Models
{
    [XmlRoot(ElementName = "Home")]
    public class Home
    {
        [XmlAttribute(AttributeName = "Played")]
        public string Played { get; set; }
        [XmlAttribute(AttributeName = "Won")]
        public string Won { get; set; }
        [XmlAttribute(AttributeName = "Draws")]
        public string Draws { get; set; }
        [XmlAttribute(AttributeName = "Lost")]
        public string Lost { get; set; }
        [XmlAttribute(AttributeName = "Scored")]
        public string Scored { get; set; }
        [XmlAttribute(AttributeName = "Conceded")]
        public string Conceded { get; set; }
        [XmlAttribute(AttributeName = "Difference")]
        public string Difference { get; set; }
        [XmlAttribute(AttributeName = "Points")]
        public string Points { get; set; }
    }

    [XmlRoot(ElementName = "Away")]
    public class Away
    {
        [XmlAttribute(AttributeName = "Played")]
        public string Played { get; set; }
        [XmlAttribute(AttributeName = "Won")]
        public string Won { get; set; }
        [XmlAttribute(AttributeName = "Draws")]
        public string Draws { get; set; }
        [XmlAttribute(AttributeName = "Lost")]
        public string Lost { get; set; }
        [XmlAttribute(AttributeName = "Scored")]
        public string Scored { get; set; }
        [XmlAttribute(AttributeName = "Conceded")]
        public string Conceded { get; set; }
        [XmlAttribute(AttributeName = "Difference")]
        public string Difference { get; set; }
        [XmlAttribute(AttributeName = "Points")]
        public string Points { get; set; }
    }

    [XmlRoot(ElementName = "Total")]
    public class Total
    {
        [XmlAttribute(AttributeName = "Played")]
        public string Played { get; set; }
        [XmlAttribute(AttributeName = "Won")]
        public string Won { get; set; }
        [XmlAttribute(AttributeName = "Draws")]
        public string Draws { get; set; }
        [XmlAttribute(AttributeName = "Lost")]
        public string Lost { get; set; }
        [XmlAttribute(AttributeName = "Scored")]
        public string Scored { get; set; }
        [XmlAttribute(AttributeName = "Conceded")]
        public string Conceded { get; set; }
        [XmlAttribute(AttributeName = "Difference")]
        public string Difference { get; set; }
        [XmlAttribute(AttributeName = "Points")]
        public string Points { get; set; }

        

        public int TotalPoints { get; set; }
    }
}
