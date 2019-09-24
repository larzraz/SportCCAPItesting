using SportCCAPItesting.Data;
using SportCCAPItesting.Models;
using SportCCAPItesting.Models.Matches;
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
        public Country Country { get; set; }
        public ObservableCollection<Country> Countries { get; set; }
        public ObservableCollection<Country> CountriesWithLiveGamesToday { get; set; }
        public ObservableCollection<Country> CountriesWithGames { get; set; }
        public ObservableCollection<Country> CountriesWithLiveGames { get; set; }
        public ObservableCollection<Match> Matches { get; set; }
        public ObservableCollection<Match> MatchesToday { get; set; }
        private DataManager dataManager = new DataManager();
        public Command LoadMatchesCommand { get; set; }
        public Sportccbetdata SportMatches { get; set; }
        public TodaysMatchesViewModel()
        {
            Countries = new ObservableCollection<Country>();
            CountriesWithGames = new ObservableCollection<Country>();
            CountriesWithLiveGames = new ObservableCollection<Country>();
            MatchesToday = new ObservableCollection<Match>();
            Matches = new ObservableCollection<Match>();
            LoadMatchesCommand = new Command(async () => await ExecuteLoadMatchesCommand());
            UpdateAsync();
            GetAllMatches();

            int intervalInSeconds = 30;
            Sport sportww = new Sport();
            sportww.Id = "1";

            Device.StartTimer(TimeSpan.FromSeconds(intervalInSeconds), () =>
            {
                Device.BeginInvokeOnMainThread(async () => GetEvents());
                return true;
            });
        }

        private async Task UpdateAsync()
        {
            try
            {
                await ExecuteLoadMatchesCommand();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private async Task ExecuteLoadMatchesCommand()
        {
            Sport sportID = new Sport();
            sportID.Id = "1";
            await GetCountries();
            await MakeCountriesList(sportID);
            MakeListForCountriesWithGames();
        }

        private async Task GetAllMatches()
        {
            Sport spor = new Sport { Id = "1" };
            SportMatches = await dataManager.GetAllMatchesForTodayForOneSport(spor);
        
            foreach (Country country3 in CountriesWithLiveGamesToday)
            {
                foreach (Category cat in SportMatches.Sports.Sport.Category)
                {
                    if (cat.Id == country3.Id)
                    {
                        foreach (Tournament tour in cat.Tournament)
                        {
                            foreach (Match match in tour.Match)
                            {                               
                                Match obj = country3.Matches.FirstOrDefault(x => x.Id == match.Id);
                                if (obj == null)
                                {
                                    country3.Matches.Add(match);
                                    MatchesToday.Add(match);
                                    match.CountryID = country3.Id;
                                }
                                else
                                {
                                    MatchesToday.Add(match);
                                    match.CountryID = country3.Id;
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

        private async Task MakeCountriesList(Sport sportID)
        {
            Sportccbetdata matches = await dataManager.GetAllLiveMatchesForTodayForOneSport(sportID);
            //SportMatches = matches;            
           
                foreach (Category cat in matches.Sports.Sport.Category)
                {
                    var country1 = Countries.FirstOrDefault(x => x.Id == cat.Id);
                   
                        foreach (Tournament tour in cat.Tournament)
                        {                            
                            foreach (Match match in tour.Match)
                            {
                                var matchIndex = 0;
                                Match obj = country1.Matches.FirstOrDefault(x => x.Id == match.Id);
                                if (obj == null)
                                {
                                    country1.Matches.Add(match);
                                    Matches.Add(match);
                                    match.CountryID = country1.Id;
                                }
                                else
                                {
                                    Matches.Add(match);
                                    match.CountryID = country1.Id;
                                    matchIndex = country1.Matches.IndexOf(obj);
                                    country1.Matches[matchIndex].Result = match.Result;
                                    country1.Matches[matchIndex].Minutes = match.Minutes;
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

        private async Task GetCountries()
        {
            Sportccbetdata scc = await dataManager.GetAllCountries();

            foreach (Country country in scc.CountryList.Countries)
            {               
                if (!Countries.Contains(country))
                {
                    Countries.Add(country);
                }               
            }
            CountriesWithLiveGamesToday = Countries;
        }

        private void MakeListForCountriesWithGames()
        {
            foreach (Country country2 in Countries)
            {
                if (country2.Matches.Count >= 1)
                {
                    Country obj = CountriesWithGames.FirstOrDefault(x => x.Id == country2.Id);
                    if (obj == null)
                    {
                        CountriesWithGames.Add(country2);
                    }
                }
            }

            foreach (Country country2 in CountriesWithLiveGamesToday)
            {
                if (country2.Matches.Count >= 1)
                {
                    Country obj = CountriesWithLiveGames.FirstOrDefault(x => x.Id == country2.Id);
                    if (obj == null)
                    {
                        CountriesWithLiveGames.Add(country2);
                    }
                }
            }
        }

        private async Task GetEvents()
        {

            Sportccbetdata scc = await dataManager.GetAllEvents();
            if (scc.Events.Event != null)
            {
                foreach (Event ev in scc.Events.Event)
                {
                    Match obj = Matches.FirstOrDefault(x => x.Id == ev.Matchid);
                    if (obj == null)
                    {
                        Match NewMatch = MatchesToday.FirstOrDefault(y => y.Id == ev.Matchid);
                        int index = CountriesWithLiveGames.IndexOf(CountriesWithLiveGames.FirstOrDefault(x => x.Id == NewMatch.CountryID));
                        CountriesWithGames.Add(CountriesWithLiveGames[index]);
                        int newIndex = CountriesWithGames.IndexOf(CountriesWithLiveGames[index]);
                        CountriesWithGames[newIndex].Matches.Add(NewMatch);
                        obj = NewMatch;
                    }
                    var i = CountriesWithGames.FirstOrDefault(x => x.Id == obj.CountryID); ;
                    int countryIndex = CountriesWithGames.IndexOf(i);
                    int matchID = CountriesWithGames[countryIndex].Matches.IndexOf(CountriesWithGames[countryIndex].Matches.FirstOrDefault(x => x.Id == obj.Id));
                    if (ev.Type == "goal-update")
                    {
                        if (CountriesWithGames[countryIndex].Matches[matchID].Goals != null)
                        {
                            Goal o = CountriesWithGames[countryIndex].Matches[matchID].Goals.FirstOrDefault(z => z.Goalid == ev.Goal.Goalid);
                            if (o == null)
                            {
                                CountriesWithGames[countryIndex].Matches[matchID].Goals.Add(ev.Goal);
                                CountriesWithGames[countryIndex].Matches[matchID].Result.ScoreInfo.Score[0].Name = ev.Hs + "-" + ev.As;
                            }
                        }
                        else
                        {
                            CountriesWithGames[countryIndex].Matches[matchID].Goals.Add(ev.Goal);
                            CountriesWithGames[countryIndex].Matches[matchID].Result.ScoreInfo.Score[0].Name = ev.Hs + "-" + ev.As;
                        }
                    }
                    if (ev.Type == "score")
                    {
                        CountriesWithGames[countryIndex].Matches[matchID].Result.ScoreInfo.Score[0].Name = ev.Hs + "-" + ev.As;
                    }
                }
            }
        }
    }
}