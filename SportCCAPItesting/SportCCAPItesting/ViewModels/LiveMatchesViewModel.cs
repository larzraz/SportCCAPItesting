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
       
        public ObservableCollection<Match> Matches { get; set; }
        public ObservableCollection<ListOfGoals> ListOfGoal { get; set; }
        public IList<Country> CountriesWithGames { get; set; }
       //public Match Match = new Match();
        private DataManager dataManager = new DataManager();
        public Command OpenGoalScorersCommand { get; set; }

        //public bool IsVisible { get { return Match.IsVisible; } set { Match.IsVisible = value; OnPropertyChanged("IsVisible"); } }


        public LiveMatchesViewModel(Country country)
        {
            Country = country;
            //LoadMatchesForCountryCommand = new Command(async () => await ExecuteLoadMatchesForCountryCommand());
            //CreateList()
            Matches = Country.Matches;
            MakeList();
            //OpenGoalScorersCommand = new Command(async () => await ExecuteOpenGoalScorersCommand());
        }

        public LiveMatchesViewModel()
        {
        }

        internal void SetToVisible(Match match)
        {

            match.IsVisible = !match.IsVisible;

            //OnPropertyChanged("IsVisible");
           
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
