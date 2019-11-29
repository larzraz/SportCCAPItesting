using SportCCAPItesting.Models;
using SportCCAPItesting.Views.MatchPages.MatchInfoPages.ContentViews;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportCCAPItesting.ViewModels
{
    public class OverviewViewModel:BaseViewModel
    {
        private Match _match;
        public Match Match { get => _match; set { _match = value; OnPropertyChanged("Match"); } }
        public string ScoreName { get; set; }

        public OverviewViewModel(Match match)
        {
            Match = match;
            if (Match.Result == null)
                ScoreName = "0 - 0";
            else
            {
                ScoreName = Match.Result.ScoreInfo.Score[1].Name;
            }
            
           
        }
    }
}
