using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace SportCCAPItesting.Models
{
    [XmlRoot(ElementName = "Score")]
    public class Score:BaseModel
    {
        private string _name;
        [XmlAttribute(AttributeName = "Type")]
        public string Type { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get { return _name; } set { _name = value; OnPropertyChanged("Name"); } }
    }
}
