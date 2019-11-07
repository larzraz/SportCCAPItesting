using SportCCAPItesting.Data;
using SportCCAPItesting.Models;
using SportCCAPItesting.Views;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SportCCAPItesting.ViewModels
{
    public class TodaysMatchesViewModel : BaseViewModel
    {      
        public ICommand ItemChangedCommand => new Command<ListContentView>(ItemChanged);
        public ICommand PositionChangedCommand => new Command<int>(PositionChanged);

        

        public Country Country { get; set; }

        
        public ObservableCollection<Country> Countries
        {
            get { return _countries; }
            set
            {
                Action setCountries = async () =>
                {
                    await GetCountries();
                };
                _countries = value;
                setCountries();
            }
        }
        public ObservableCollection<TournamentGroup> Tournaments
        {
            get { return _tournaments; }
            set
            {
                Action setMatches = async () =>
                {
                    await GetAllMatches(DateT);
                };
                _tournaments = value;
                setMatches();
            }
        }
      
       

        public ObservableCollection<ListContentView> LCV { get { return _lcv; } set { _lcv = value; OnPropertyChanged("LCV"); } }
        public ListContentView CurrentItem { get; set; }
        public int Position { get; set; }

        public ObservableCollection<Country> CountriesWithGames
        {
            get { return _countriesWithGames; }
            set
            {
                _countriesWithGames = value;
                Action test = async () =>
                {
                    await UpdateAsync();
                }; //OnPropertyChanged("CountriesWithGames");

                test();
            }
        }

        public ObservableCollection<Country> CountriesWithLiveGamesToday
        {
            get { return _countriesWithLiveGamesToday; }
            set
            {
                //Action SetMatches = async () =>
                //{
                //    await GetAllMatches();
                //};
                _countriesWithLiveGamesToday = value;
                //SetMatches();
            }
        }

        public ObservableCollection<Country> CountriesWithLiveGames { get; set; }
        public ObservableCollection<Match> Matches { get; set; }
        public ObservableCollection<Match> MatchesToday { get; set; }
        public ObservableCollection<ContentView> tdm { get { return _tdm; } set { _tdm = value; OnPropertyChanged("tdm"); } }

        public ObservableCollection<Category> Categories { get; set; }
        public ObservableCollection<Category> CategoriesWithLiveGames { get; set; }

        private DataManager dataManager = new DataManager();
        private ObservableCollection<Country> _countriesWithGames;
        private ObservableCollection<Country> _countriesWithLiveGamesToday;
        private ObservableCollection<ContentView> _tdm;
        private ObservableCollection<ListContentView> _lcv;
        private DateTime DateT;
        private ObservableCollection<TournamentGroup> _tournaments;
        public int i = 0;
        private ObservableCollection<Country> _countries;

        public Command LoadMatchesCommand { get; set; }
        public Sportccbetdata SportMatches { get; set; }
        public ObservableCollection<Test> Tests { get; set; }
        public bool HasPropertyValueChangedTodayMinus2 { get; set; }
        public bool HasPropertyValueChangedTodayMinus1 { get; set; }
        public bool HasPropertyValueChangedToday { get; set; }
        public bool HasPropertyValueChangedTodayPlus1 { get; set; }
        public bool HasPropertyValueChangedTodayPlus2 { get; set; }

        public TodaysMatchesViewModel(DateTime dt)
        {
            DateT = dt;
            Countries = new ObservableCollection<Country>();
            CountriesWithGames = new ObservableCollection<Country>();
            CountriesWithLiveGames = new ObservableCollection<Country>();
            MatchesToday = new ObservableCollection<Match>();
            Matches = new ObservableCollection<Match>();
            Categories = new ObservableCollection<Category>();
            CategoriesWithLiveGames = new ObservableCollection<Category>();
            CountriesWithLiveGamesToday = new ObservableCollection<Country>();
            Tournaments = new ObservableCollection<TournamentGroup>();
            tdm = new ObservableCollection<ContentView>();
            LoadMatchesCommand = new Command(async () => await ExecuteLoadMatchesCommand());
          
            
            OnPropertyChanged("CurrentItem");
            Position = 2;
            OnPropertyChanged("Position");
          //  int intervalInSeconds = 30;
            Sport sportww = new Sport();
            sportww.Id = "1";

            //Device.StartTimer(TimeSpan.FromSeconds(intervalInSeconds), () =>
            //{
            //    Device.BeginInvokeOnMainThread(async () => await GetEvents());
            //    return true;
            //});
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
            //await GetCountries();
            await MakeCountriesList(sportID);
            MakeListForCountriesWithGames();
        }

       
        private async Task GetAllMatches(DateTime dt)
        {
            i++;
            Sport spor = new Sport { Id = "1" };
            SportMatches = await dataManager.GetAllMatchesForTodayForOneSport(spor, dt);
            MatchesToday.Clear();
            Tournaments.Clear();

            foreach (Category cat in SportMatches.Sports.Sport.Category)
            {
                var country3 = CountriesWithLiveGamesToday.FirstOrDefault(x => x.Id == cat.Id);

                foreach (Tournament tour in cat.Tournaments)
                {
                    var tournamentGroup = new TournamentGroup() { Name = tour.Name };

                    foreach (Match match in tour.Match)
                    {
                        Match obj = country3.Matches.FirstOrDefault(x => x.Id == match.Id);
                        if (obj == null)
                        {
                            country3.Matches.Add(match);
                            MatchesToday.Add(match);
                            match.CountryID = country3.Id;
                            tournamentGroup.Add(match);
                        }
                        else
                        {
                            MatchesToday.Add(match);
                            match.CountryID = country3.Id;
                            tournamentGroup.Add(match);
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
                        match.TournamentName = tour.Name;
                    }
                    tournamentGroup.Date = dt.ToString("d" + ". " + "MMM");
                    if(!Tournaments.Contains(tournamentGroup))
                    Tournaments.Add(tournamentGroup);

                }
            }
        }

        private async Task MakeCountriesList(Sport sportID)
        {
            Sportccbetdata matches = await dataManager.GetAllLiveMatchesForTodayForOneSport(sportID);
            foreach (Category cat in matches.Sports.Sport.Category)
            {
                if(Countries.Count == 0)
                {
                    await GetCountries(); 
                }
                var country1 = Countries.FirstOrDefault(x => x.Id == cat.Id);
                foreach (Tournament tour in cat.Tournaments)
                {
                    var tournamentGroup = new TournamentGroup() { Name = tour.Name };
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
                        if (!Tournaments.Contains(tournamentGroup))
                        {
                            Tournaments.Add(tournamentGroup);
                        }                        
                    }
                }
                CategoriesWithLiveGames.Add(cat);
            }
        }

        private async Task GetCountries()
        {
            Sportccbetdata scc = await dataManager.GetAllCountries();

            foreach (Country country in scc.CountryList.Countries)
            {
                Country obj = Countries.FirstOrDefault(x => x.Id == country.Id);
                if (obj == null)
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

        private void ItemChanged(ListContentView obj)
        {
            CurrentItem = obj;

          //  obj.listView.ItemsSource = Tournaments;

            OnPropertyChanged("CurrentItem");
        }

        private void PositionChanged(int obj)
        {
            Position = obj;
            switch (Position)
            {
                case 0:
                    SetAllToFalse();
                    HasPropertyValueChangedTodayMinus2 = true;
                    OnPropertyChanged("HasPropertyValueChangedTodayMinus2");
                    break;

                case 1:
                    SetAllToFalse();
                    HasPropertyValueChangedTodayMinus1 = true;
                    OnPropertyChanged("HasPropertyValueChangedTodayMinus1");
                    break;

                case 2:
                    SetAllToFalse();
                    HasPropertyValueChangedToday = true;
                    OnPropertyChanged("HasPropertyValueChangedToday");
                    break;

                case 3:
                    SetAllToFalse();
                    HasPropertyValueChangedTodayPlus1 = true;
                    OnPropertyChanged("HasPropertyValueChangedTodayPlus1");
                    break;

                case 4:
                    SetAllToFalse();
                    HasPropertyValueChangedTodayPlus2 = true;
                    OnPropertyChanged("HasPropertyValueChangedTodayPlus2");
                    break;
            }

            OnPropertyChanged("Position");
        }

        private void SetAllToFalse()
        {
            HasPropertyValueChangedTodayMinus2 = false;
            HasPropertyValueChangedTodayMinus1 = false;
            HasPropertyValueChangedToday = false;
            HasPropertyValueChangedTodayPlus1 = false;
            HasPropertyValueChangedTodayPlus2 = false;
            OnPropertyChanged("HasPropertyValueChangedTodayMinus2");
            OnPropertyChanged("HasPropertyValueChangedTodayMinus1");
            OnPropertyChanged("HasPropertyValueChangedToday");
            OnPropertyChanged("HasPropertyValueChangedTodayPlus1");
            OnPropertyChanged("HasPropertyValueChangedTodayPlus2");
        }

        //private async Task GetEvents()
        //{
        //    Sportccbetdata scc = await dataManager.GetAllEvents();
        //    if (scc.Events.Event != null)
        //    {
        //        foreach (Event ev in scc.Events.Event)
        //        {
        //            Match obj = Matches.FirstOrDefault(x => x.Id == ev.Matchid);
        //            if (obj == null)
        //            {
        //                Match NewMatch = MatchesToday.FirstOrDefault(y => y.Id == ev.Matchid);
        //                if(NewMatch == null)
        //                {
        //                    await GetAllMatches();
        //                    NewMatch = MatchesToday.FirstOrDefault(y => y.Id == ev.Matchid);
        //                    if (NewMatch == null)
        //                        continue;
        //                    }
        //                int index = CountriesWithLiveGames.IndexOf(CountriesWithLiveGames.FirstOrDefault(x => x.Id == NewMatch.CountryID));
        //                CountriesWithGames.Add(CountriesWithLiveGames[index]);
        //                int newIndex = CountriesWithGames.IndexOf(CountriesWithLiveGames[index]);
        //                CountriesWithGames[newIndex].Matches.Add(NewMatch);
        //                obj = NewMatch;
        //            }
        //            var i = CountriesWithGames.FirstOrDefault(x => x.Id == obj.CountryID); ;
        //            int countryIndex = CountriesWithGames.IndexOf(i);
        //            int matchID = CountriesWithGames[countryIndex].Matches.IndexOf(CountriesWithGames[countryIndex].Matches.FirstOrDefault(x => x.Id == obj.Id));
        //            if (ev.Type == "goal-update")
        //            {
        //                try
        //                {
        //                    if (CountriesWithGames[countryIndex].Matches[matchID].Goals != null)
        //                    {
        //                        Goal o = CountriesWithGames[countryIndex].Matches[matchID].Goals.FirstOrDefault(z => z.Goalid == ev.Goal.Goalid);
        //                        if (o == null)
        //                        {
        //                            CountriesWithGames[countryIndex].Matches[matchID].Goals.Add(ev.Goal);
        //                            CountriesWithGames[countryIndex].Matches[matchID].Result.ScoreInfo.Score[0].Name = ev.Hs + "-" + ev.As;
        //                        }
        //                    }
        //                    else
        //                    {
        //                        CountriesWithGames[countryIndex].Matches[matchID].Goals.Add(ev.Goal);
        //                        CountriesWithGames[countryIndex].Matches[matchID].Result.ScoreInfo.Score[0].Name = ev.Hs + "-" + ev.As;
        //                    }
        //                }
        //                catch (Exception e)
        //                {
        //                    Console.WriteLine(e);
        //                }
        //            }
        //            if (ev.Type == "score")
        //            {
        //                try
        //                {
        //                    if (CountriesWithGames[countryIndex].Matches[matchID].Result != null)
        //                        CountriesWithGames[countryIndex].Matches[matchID].Result.ScoreInfo.Score[0].Name = ev.Hs + "-" + ev.As;
        //                }
        //                catch (Exception e)
        //                {
        //                    Console.WriteLine(e);
        //                }
        //            }

        //            if (ev.Type == "status")
        //                try
        //                {
        //                    if (ev.Name != "Result Only")
        //                        CountriesWithGames[countryIndex].Matches[matchID].Minutes = "0";
        //                }
        //                catch (Exception e)
        //                {
        //                    Console.WriteLine(e);
        //                }
        //        }
        //    }
        //}
    }
}