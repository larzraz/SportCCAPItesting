using SportCCAPItesting.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportCCAPItesting.ViewModels
{
    public class MatchInfoViewModel : BaseViewModel
    {
        public Match Match { get; set; }
        public MatchInfoViewModel(Match m)
        {
            Match = m;
        }
    }
}
