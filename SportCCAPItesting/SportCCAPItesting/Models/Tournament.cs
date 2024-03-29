﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Xml.Serialization;
using Xamarin.Forms;

namespace SportCCAPItesting.Models
{
    [XmlRoot(ElementName = "Tournament")]
    public class Tournament
    {
        private string _name;
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }

        [XmlAttribute(AttributeName = "name")]
        public string Name { get { return _name.ToUpper(); } set { _name = value; } }

        [XmlAttribute(AttributeName = "contestgroupid")]
        public string Contestgroupid { get; set; }

        [XmlAttribute(AttributeName = "season")]
        public string Season { get; set; }

        [XmlAttribute(AttributeName = "contestCountryId")]
        public string ContestCountryId { get; set; }

        [XmlAttribute(AttributeName = "contestCountry")]
        public string ContestCountry { get; set; }

        [XmlElement(ElementName = "Match")]
        public ObservableCollection<Match> Match { get; set; }

        [XmlAttribute(AttributeName = "ContestGroupId")]
        public string ContestGroupId { get; set; }

        [XmlAttribute(AttributeName = "tournamentSystem")]
        public string TournamentSystem { get; set; }

        [XmlAttribute(AttributeName = "Gender")]
        public string Gender { get; set; }

        [XmlAttribute(AttributeName = "hastable")]
        public string Hastable { get; set; }

        [XmlElement(ElementName = "Competitor")]
        public ObservableCollection<Competitor> Competitor { get; set; }

        [XmlAttribute(AttributeName = "ContestGroupName")]
        public string ContestGroupName { get; set; }

        [XmlAttribute(AttributeName = "SeasonName")]
        public string SeasonName { get; set; }

       


    }
}