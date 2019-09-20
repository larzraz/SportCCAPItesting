using SportCCAPItesting.Data;
using SportCCAPItesting.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SportCCAPItesting.ViewModels
{
    public class TodaysMatchesViewModel : BaseViewModel
    {
        private List<MatchList> _listOfMatches;
        public List<MatchList> ListOfMatches { get { return _listOfMatches; } set { _listOfMatches = value; } }
        public Country Country { get; set; }

        public ObservableCollection<Country> Countries { get; set; }
        
        public ObservableCollection<Country> CountriesWithGames { get; set; }
        public ObservableCollection<Match> Matches { get; set; }
        private DataManager dataManager = new DataManager();
        public Command LoadMatchesCommand { get; set; }
        public Sportccbetdata SportMatches { get; set; }


        public TodaysMatchesViewModel()
        {
            Countries = new ObservableCollection<Country>();
            CountriesWithGames = new ObservableCollection<Country>();
            LoadMatchesCommand = new Command(async () => await ExecuteLoadMatchesCommand());
            UpdateAsync();
            int intervalInSeconds = 30;

            Sport sportww = new Sport();
            sportww.Id = "1";

            Device.StartTimer(TimeSpan.FromSeconds(intervalInSeconds), () =>
            {
                Device.BeginInvokeOnMainThread(async () => UpdateAsync());
                return true;
            });
        }

        private async Task UpdateAsync()
        {
            try
            {
                await ExecuteLoadMatchesCommand();
            } catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
            
        }

        private async Task ExecuteLoadMatchesCommand()
        {
            //CountriesWithGames.Clear();
            //Countries.Clear();
             Sport sportID = new Sport();
            sportID.Id = "1";
             await GetCountries();
            await MakeCountriesList(sportID);
            MakeListForCountriesWithGames();
        }

        private async Task MakeCountriesList(Sport sportID)
        {
            Sportccbetdata matches = await dataManager.GetAllLiveMatchesForTodayForOneSport(sportID);
            SportMatches = matches;
            foreach (Country country1 in Countries)
            {
                foreach (Category cat in matches.Sports.Sport.Category)
                {
                    if (cat.Id == country1.Id)
                    {
                        foreach (Tournament tour in cat.Tournament)
                        {
                            Matches = tour.Match;
                            foreach (Match match in tour.Match)
                            {

                                var matchIndex = 0;
                                Match obj = country1.Matches.FirstOrDefault(x => x.Id == match.Id);
                                if (obj == null)
                                {
                                    country1.Matches.Add(match);
                                }
                                else
                            {
                                matchIndex = country1.Matches.IndexOf(obj);
                                    country1.Matches[matchIndex].Result = match.Result;
                                    //country1.Matches.RemoveAt(matchIndex);
                                    //country1.Matches.Insert(matchIndex, match);
                            }

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
        }

        private void MakeListForCountriesWithGames()
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
                        UpdateMatches(country2);
                    }
                }
            }
        }

        private void UpdateMatches(Country country1)
        {
           
                foreach (Category cat in SportMatches.Sports.Sport.Category)
                {
                    if (cat.Id == country1.Id)
                    {
                        foreach (Tournament tour in cat.Tournament)
                        {
                            Matches = tour.Match;
                            foreach (Match match in tour.Match)
                            {

                                var matchIndex = 0;
                                if (!country1.Matches.Contains(match))
                                {
                                    country1.Matches.Add(match);
                                }
                                else
                                {
                                    matchIndex = country1.Matches.IndexOf(match);
                                    country1.Matches.RemoveAt(matchIndex);
                                    country1.Matches.Insert(matchIndex, match);
                                }
                                
                            }
                        }
                    }
                }
            
        }
    }
}