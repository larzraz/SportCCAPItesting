using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Xml.Serialization;

namespace SportCCAPItesting.Models
{
    [XmlRoot(ElementName = "Goal")]
    public class Goal : BaseModel
    {
        private bool _isVisible;
        private bool _isTypeVisible = false;

        [XmlAttribute(AttributeName = "goalid")]
        public string Goalid { get; set; }
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
        [XmlAttribute(AttributeName = "score")]
        public string Score { get; set; }
        [XmlAttribute(AttributeName = "team")]
        public string Team { get; set; }
        [XmlAttribute(AttributeName = "minute")]
        public string Minute { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "surname")]
        public string Surname { get; set; }
        [XmlAttribute(AttributeName = "firstname")]
        public string Firstname { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
        [XmlAttribute(AttributeName = "OldPlayerId")]
        public string OldPlayerId { get; set; }
        public bool IsVisible { get { return _isVisible; } set { _isVisible = value; OnPropertyChanged("IsVisible"); } }
        public bool IsTypeVisible { get { return _isTypeVisible; } set { _isTypeVisible = value; OnPropertyChanged("IsTypeVisible"); } }
    }

    [XmlRoot(ElementName = "Goals")]
    public class Goals
    {
        [XmlElement(ElementName = "Goal")]
        public ObservableCollection<Goal> Goal { get; set; }
    }

    public class ListOfGoals : ObservableCollection<Goal>
    {
        public string Teams { get; set; }
        public ObservableCollection<Goal> Goals { get; set; }// => this;
    }
}
