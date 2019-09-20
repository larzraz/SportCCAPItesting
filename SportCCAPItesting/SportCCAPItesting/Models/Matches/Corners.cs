using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace SportCCAPItesting.Models
{
    [XmlRoot(ElementName = "Corners")]
    public class Corners
    {
        [XmlAttribute(AttributeName = "Type")]
        public string Type { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
    }
    [XmlRoot(ElementName = "CornerInfo")]
    public class CornerInfo
    {
        [XmlElement(ElementName = "Corners")]
        public Corners Corners { get; set; }
    }

}
