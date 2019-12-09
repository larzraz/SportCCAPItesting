using SportCCAPItesting.Data;
using SportCCAPItesting.Models;
using SportCCAPItesting.Models.Events;
using SportCCAPItesting.Models.Matches;
using SportCCAPItesting.Views.MatchPages.MatchInfoPages.ContentViews;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Text;
using Xamarin.Forms;

namespace SportCCAPItesting.ViewModels
{
    public class OverviewViewModel : BaseViewModel
    {
        private Match _match;
        public Match Match { get => _match; set { _match = value; OnPropertyChanged("Match"); } }
        public string ScoreName { get; set; }
        private DataManager dm = new DataManager();
        public EventMockData MyProperty { get; set; }
        public List<FootballEvent> FirstHalf { get; set; }
        public List<FootballEvent> SecondHalf { get; set; }
        public Stats MatchStats { get; set; }

        public Image ImageField { get; set; }

        public OverviewViewModel(Match match)
        {
            Match = match;
            if (Match.Result == null)
                ScoreName = "0 - 0";
            else
            {
                ScoreName = Match.Result.ScoreInfo.Score[1].Name;
            }
            MyProperty = dm.GetEventMock();
            MatchStats = MyProperty.Stats;
            ConvertToPercentage(MatchStats);
            FirstHalf = MyProperty.FirstHalfEvents;
            SecondHalf = MyProperty.SecondHalfEvents;
            ImageField = new Image { Aspect = Aspect.AspectFit };
            ImageField.Source = ImageSource.FromResource("SportCCAPItesting.Field.jpg", typeof(OverviewViewModel).GetTypeInfo().Assembly);



        }
        private void ConvertToPercentage(Stats myStats)
        {
            double noOfOffsides = myStats.Offsides[0] + myStats.Offsides[1];
            double noOfShots = myStats.Shots[0] + myStats.Shots[1];
            double noOfFouls = myStats.Fouls[0] + myStats.Fouls[1];
            MatchStats.ActualPossesion = new int[2] { 0, 0 };
            MatchStats.ActualFouls = new int[2] { 0, 0 };
            MatchStats.ActualOffsides = new int[2] { 0, 0 };
            MatchStats.ActualShots = new int[2] { 0, 0 };


            int i = 0;
            int ii = 0;
            int iii = 0;
            int iiii = 0;
            foreach (double pos in MatchStats.Possesion)
            {
                MatchStats.ActualPossesion[i] = (int)pos;
                MatchStats.Possesion[i]= pos / 100;
                i++;
            }

            foreach (double pos in MatchStats.Offsides)
            {
                MatchStats.ActualOffsides[ii] = (int)pos;
                MatchStats.Offsides[ii] = pos / noOfOffsides;
                ii++;
            }

            foreach (double pos in MatchStats.Shots)
            {
                MatchStats.ActualShots[iii] = (int)pos;
                MatchStats.Shots[iii] = pos / noOfShots;
                iii++;
            }

            foreach (double pos in MatchStats.Fouls)
            {
                MatchStats.ActualFouls[iiii] = (int)pos;
                MatchStats.Fouls[iiii] = pos / noOfFouls;
                iiii++;
            }

        }
    }
}
