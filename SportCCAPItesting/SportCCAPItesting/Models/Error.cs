using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace SportCCAPItesting.Models
{
    [XmlRoot(ElementName = "Error")]
    public class Error
    {
        [XmlAttribute(AttributeName = "ErrorCode")]
        public string ErrorCode { get; set; }
        [XmlAttribute(AttributeName = "Message")]
        public string Message { get; set; }
    }
}
