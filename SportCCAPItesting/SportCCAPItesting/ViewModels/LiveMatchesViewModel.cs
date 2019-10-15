using SportCCAPItesting.Data;
using SportCCAPItesting.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace SportCCAPItesting.ViewModels
{
    public class LiveMatchesViewModel : BaseViewModel
    {
        public Country Country { get; set; }
       
        public ObservableCollection<Match> Matches
        {
            get { return _matches; }
            set
            {

                _matches = value;
                MakeList(); 
            }
        }
        public ObservableCollection<ListOfGoals> ListOfGoal { get; set; }
        public ObservableCollection<Country> CountriesWithGames { get; set; }
        private DataManager dataManager = new DataManager();
        private ObservableCollection<Match> _matches;

        public Command OpenGoalScorersCommand { get; set; }


        public LiveMatchesViewModel(Country country)
        {
            Country = country;
            Matches = Country.Matches;
        }

        public LiveMatchesViewModel()
        {
        }

        internal void SetToVisible(Match match)
        {
            match.IsVisible = !match.IsVisible;
        }

        public void MakeList()
        {
            ListOfGoal = new ObservableCollection<ListOfGoals>();
            foreach(Match mtch in Country.Matches)
            {
                if(mtch.Result != null && mtch.Result.ScoreInfo.Comment != null)
                mtch.Goals = mtch.Result.ScoreInfo.Comment.Goals.Goal;
            }
        }
    }
}
