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
        private string _stringScore;

        [XmlAttribute(AttributeName = "Type")]
        public string Type { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get { return _name; } set { _name = value.Split(':')[0] + " - " + value.Split(':')[1]; OnPropertyChanged("Name"); OnPropertyChanged("StringScore"); } }
        public string StringScore { get { return _stringScore; } set { string[] s = Name.Split(':'); _stringScore = s[0]; } }
    }
}
