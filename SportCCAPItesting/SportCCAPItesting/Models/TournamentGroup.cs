using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace SportCCAPItesting.Models
{
    public class TournamentGroup:ObservableCollection<Match>
    {
        public string Name { get; set; }
        public ObservableCollection<Match> Tournaments { get; set; }
        public string Date { get; set; }
        public Image LeaguePicture { get; set; }
    }
}
