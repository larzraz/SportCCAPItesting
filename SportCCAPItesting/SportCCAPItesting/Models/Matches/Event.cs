using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace SportCCAPItesting.Models.Matches
{
    
        [XmlRoot(ElementName = "event")]
        public class Event
        {
            [XmlElement(ElementName = "Goal")]
            public Goal Goal { get; set; }
            [XmlAttribute(AttributeName = "id")]
            public string Id { get; set; }
            [XmlAttribute(AttributeName = "ut")]
            public string Ut { get; set; }
            [XmlAttribute(AttributeName = "name")]
            public string Name { get; set; }
            [XmlAttribute(AttributeName = "fk")]
            public string Fk { get; set; }
            [XmlAttribute(AttributeName = "as")]
            public string As { get; set; }
            [XmlAttribute(AttributeName = "hs")]
            public string Hs { get; set; }
            [XmlAttribute(AttributeName = "type")]
            public string Type { get; set; }
            [XmlAttribute(AttributeName = "matchid")]
            public string Matchid { get; set; }
        }

    [XmlRoot(ElementName = "events")]
    public class Events
    {
        [XmlElement(ElementName = "event")]
        public List<Event> Event { get; set; }
    }


}
