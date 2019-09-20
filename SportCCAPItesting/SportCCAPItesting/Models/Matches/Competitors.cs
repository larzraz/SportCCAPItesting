using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace SportCCAPItesting.Models
{
    [XmlRoot(ElementName = "Competitors")]
    public class Competitors
    {
        [XmlElement(ElementName = "Competitor")]
        public List<Competitor> Competitor { get; set; }
    }

}
