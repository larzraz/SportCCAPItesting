using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SportCCAPItesting.Models
{
    public class TournamentGroup:ObservableCollection<Match>
    {
        public string Name { get; set; }
        public ObservableCollection<Match> Tournaments { get; set; }
    }
}
