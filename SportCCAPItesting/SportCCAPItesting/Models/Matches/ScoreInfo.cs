using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace SportCCAPItesting.Models
{
    [XmlRoot(ElementName = "ScoreInfo")]
    public class ScoreInfo
    {
        [XmlElement(ElementName = "Score")]
        public List<Score> Score { get; set; }
        [XmlElement(ElementName = "CornerInfo")]
        public CornerInfo CornerInfo { get; set; }
        [XmlElement(ElementName = "comment")]
        public Comment Comment { get; set; }
    }
}
