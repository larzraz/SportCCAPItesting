using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using SportCCAPItesting.Models;

namespace SportCCAPItesting.ViewModels
{
    public class GoalsByGameViewModel : BaseViewModel
    {
        private Match _match;
        public ObservableCollection<Goal> Goals { get; set; }
        public GoalsByGameViewModel(Match match)
        {
            this._match = match;
            Goals = match.Goals;
            
            foreach(Goal goal in Goals)
            {
                if (goal.Type != "Goal")
                {
                    goal.IsTypeVisible = true;
                }
            }
        }
    }
}
