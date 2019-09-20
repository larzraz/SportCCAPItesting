using SportCCAPItesting.Data;
using SportCCAPItesting.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SportCCAPItesting.ViewModels
{
    public class TodaysMatchesByCountryViewModel : BaseViewModel
    {
        public Country Country { get; set; }
        public IList<Match> Matches { get; set; }
        public IList<Country> CountriesWithGames { get; set; }
        private DataManager dataManager = new DataManager();
        public Command LoadMatchesForCountryCommand { get; set; }

        public TodaysMatchesByCountryViewModel(Country country)
        {
            Country = country;
            //LoadMatchesForCountryCommand = new Command(async () => await ExecuteLoadMatchesForCountryCommand());
            //CreateList()
            Matches = Country.Matches;
        }

        public TodaysMatchesByCountryViewModel()
        {
        }

        //private async void CreateList()
        //{
        //    await ExecuteLoadMatchesForCountryCommand();
        //}

        // private Task ExecuteLoadMatchesForCountryCommand()
        //  {

        //  }
    }
}
