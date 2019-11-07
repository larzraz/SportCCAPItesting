using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;

namespace SportCCAPItesting.Models
{
    [XmlRoot(ElementName = "Match")]
    public class Match : BaseModel
    {

        private bool _isVisible = false;
        private string _minutes;
        private Result _result;


        [XmlElement(ElementName = "Competitors")]
        public Competitors Competitors { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
        [XmlAttribute(AttributeName = "status")]
        public string Status { get; set; }
        [XmlAttribute(AttributeName = "date")]
        public string Date { get; set; }
        [XmlAttribute(AttributeName = "CurentPeriod")]
        public string CurentPeriod { get; set; }
        [XmlAttribute(AttributeName = "minutes")]
        public string Minutes { get { return _minutes; } set { _minutes = value; OnPropertyChanged("Minutes"); } }
        [XmlAttribute(AttributeName = "commentary")]
        public string Commentary { get; set; }
        [XmlAttribute(AttributeName = "Published")]
        public string Published { get; set; }
        [XmlElement(ElementName = "Result")]
        public Result Result { get{ return _result; } set { _result = value; OnPropertyChanged("Result"); } }

        public Competitor HomeTeam { get; set; }
        public Competitor AwayTeam { get; set; }
        public string MatchTime { get {
                CultureInfo culture = new CultureInfo("da-DK");
                DateTime d =Convert.ToDateTime(Date,culture);
                DateTime date = DateTime.Parse(d.ToShortTimeString());
                return date.ToString("HH:mm");
            }
        }
        public string MatchDate
        {
            get
            {
                CultureInfo culture = new CultureInfo("da-DK");
                DateTime d = Convert.ToDateTime(Date, culture);
                DateTime date = DateTime.Parse(d.ToShortDateString());
                return date.ToString("MMM");
            }
        }
        public bool IsVisible { get { return _isVisible; } set { _isVisible = value; OnPropertyChanged("IsVisible"); } }
        public string Teams
        {
            get
            {
                if (HomeTeam == null)
                { return "null"; } else
                
                    return  $"{HomeTeam.Name} - {AwayTeam.Name}"; } }
        public ObservableCollection<Goal> Goals { get; set; }

        public string CountryID { get; set; } = "1";

        public string TournamentName { get; set; }

    }

    public class MatchList : List<Match>
    {
        public string Teams { get; set; }
        public List<Match> Matches => this;
    }
}
