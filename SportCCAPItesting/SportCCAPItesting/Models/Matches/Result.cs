using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace SportCCAPItesting.Models
{
    [XmlRoot(ElementName = "Result")]
    public class Result
    {
        [XmlElement(ElementName = "ScoreInfo")]
        public ScoreInfo ScoreInfo { get; set; }
    }
}
