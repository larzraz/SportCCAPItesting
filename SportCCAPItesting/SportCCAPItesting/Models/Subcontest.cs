using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace SportCCAPItesting.Models
{
    [XmlRoot(ElementName = "subcontest")]
    public class Subcontest
    {
        [XmlAttribute(AttributeName = "TournamentId")]
        public string TournamentId { get; set; }
        [XmlAttribute(AttributeName = "ContestName")]
        public string ContestName { get; set; }
        [XmlAttribute(AttributeName = "ContestGroupID")]
        public string ContestGroupID { get; set; }
        [XmlAttribute(AttributeName = "ContestGroupName")]
        public string ContestGroupName { get; set; }
        [XmlAttribute(AttributeName = "ContestPhase")]
        public string ContestPhase { get; set; }
        [XmlAttribute(AttributeName = "Finished")]
        public string Finished { get; set; }
        [XmlAttribute(AttributeName = "season")]
        public string Season { get; set; }
        [XmlAttribute(AttributeName = "countryid")]
        public string Countryid { get; set; }
        [XmlAttribute(AttributeName = "countryname")]
        public string Countryname { get; set; }
        [XmlAttribute(AttributeName = "tournamentSystem")]
        public string TournamentSystem { get; set; }
        [XmlAttribute(AttributeName = "hastable")]
        public string Hastable { get; set; }
    }
    [XmlRoot(ElementName = "SubContests")]
    public class SubContests
    {
        [XmlElement(ElementName = "subcontest")]
        public List<Subcontest> Subcontest { get; set; }
    }
}
