using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace SportCCAPItesting.Models
{
    [XmlRoot(ElementName = "comment")]
    public class Comment
    {
        [XmlElement(ElementName = "Goals")]
        public Goals Goals { get; set; }
        [XmlElement(ElementName = "Cards")]
        public Cards Cards { get; set; }
    }
}
