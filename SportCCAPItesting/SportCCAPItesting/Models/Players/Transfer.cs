using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace SportCCAPItesting.Models
{
    [XmlRoot(ElementName = "Transfer")]
    public class Transfer
    {
        [XmlAttribute(AttributeName = "period")]
        public string Period { get; set; }
        [XmlAttribute(AttributeName = "FromTeamId")]
        public string FromTeamId { get; set; }
        [XmlAttribute(AttributeName = "FromTeam")]
        public string FromTeam { get; set; }
        [XmlAttribute(AttributeName = "ToTeamId")]
        public string ToTeamId { get; set; }
        [XmlAttribute(AttributeName = "ToTeam")]
        public string ToTeam { get; set; }
        [XmlAttribute(AttributeName = "Value")]
        public string Value { get; set; }
    }

}
