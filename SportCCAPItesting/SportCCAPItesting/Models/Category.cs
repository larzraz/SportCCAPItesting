using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace SportCCAPItesting.Models
{
    [XmlRoot(ElementName = "Category")]
    public class Category
    {
        [XmlElement(ElementName = "Tournament")]
        public List<Tournament> Tournament { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "Tournaments")]
        public Tournament T_Tournament { get; set; }


    }
}
