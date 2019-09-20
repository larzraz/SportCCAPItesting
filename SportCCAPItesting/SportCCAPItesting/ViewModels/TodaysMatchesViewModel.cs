using SportCCAPItesting.Data;
using SportCCAPItesting.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SportCCAPItesting.ViewModels
{
    public class TodaysMatchesViewModel : BaseViewModel
    {
        private List<MatchList> _listOfMatches;
        public List<MatchList> ListOfMatches { get { return _listOfMatches; } set { _listOfMatches = value; } }
        public Country Country { get; set; }

        public IList<Country> Countries { get; set; }
        public IList<Country> CountriesWithGames { get; set; }
        private DataManager dataManager = new DataManager();
        public Command LoadMatchesCommand { get; set; }

        public TodaysMatchesViewModel()
        {
            Countries = new ObservableCollection<Country>();
            CountriesWithGames = new ObservableCollection<Country>();
            LoadMatchesCommand = new Command(async () => await ExecuteLoadMatchesCommand());
            UpdateAsync();
           // UpdateApi();
        }

      
        private async Task UpdateAsync()
        {
            await ExecuteLoadMatchesCommand();
        }

        private async Task ExecuteLoadMatchesCommand()
        {
            Sport sportID = new Sport();
            sportID.Id = "1";
            await GetCountries();
            Sportccbetdata matches = await dataManager.GetAllLiveMatchesForTodayForOneSport(sportID);

            foreach (Country country1 in Countries)
            {
                foreach (Category cat in matches.Sports.Sport.Category)
                {
                    if (cat.Id == country1.Id)
                    {
                        foreach (Tournament tour in cat.Tournament)
                        {
                            foreach (Match match in tour.Match)
                            {
                                //var matchIndex = 0;
                                //if (!tour.Match.Contains(match))
                                //{
                                    country1.Matches.Add(match);
                               // }
                                //else
                                //{
                                //    matchIndex = tour.Match.IndexOf(match);
                                //    tour.Match.RemoveAt(matchIndex);
                                //    tour.Match.Insert(matchIndex, match);
                               // }

                                foreach (Competitor com in match.Competitors.Competitor)
                                {
                                    if (com.Type == "1")
                                    {
                                        match.HomeTeam = com;
                                    }
                                    if (com.Type == "2")
                                        match.AwayTeam = com;
                                }
                            }
                        }
                    }
                }
            }

            UpdateApi();

            
        }

        private async Task GetCountries()
        {
            Sportccbetdata scc = await dataManager.GetAllCountries();

            foreach (Country country in scc.CountryList.Countries)
            {
                var countryIndex = 0;
                if (!Countries.Contains(country))
                {
                    Countries.Add(country);
                }
                else
                    {
                        countryIndex = Countries.IndexOf(country);
                        Countries.RemoveAt(countryIndex);
                        Countries.Insert(countryIndex, country);
                    }
                }
                //var i = 0; 
            }
        private void UpdateApi()
        {
            foreach (Country country2 in Countries)
            {
                if (country2.Matches.Count >= 1)
                {
                    var country2Index = 0;
                    if (!CountriesWithGames.Contains(country2))
                    {
                        CountriesWithGames.Add(country2);
                    }
                    else
                    {
                        country2Index = CountriesWithGames.IndexOf(country2);
                        CountriesWithGames.RemoveAt(country2Index);
                        CountriesWithGames.Insert(country2Index, country2);
                    }

                }

            }
        }

    }

}