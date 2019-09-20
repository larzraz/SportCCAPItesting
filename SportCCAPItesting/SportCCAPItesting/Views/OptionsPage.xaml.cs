using SportCCAPItesting.Data;
using SportCCAPItesting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SportCCAPItesting.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    
    public partial class OptionsPage : ContentPage
    {
        private readonly DataManager dataManager = new DataManager();
        private readonly Country _country;
        private Sport sport;

        public OptionsPage()
        {
            InitializeComponent();
        }

        public OptionsPage(Country country)
        {
            _country = country;
            BindingContext = _country;
            InitializeComponent();
        }

        public OptionsPage(Country country, Sport sport) 
        {
           this.sport = sport;
            _country = country;
            BindingContext = _country;
            InitializeComponent();
        }

        private async void Venues_Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(
                new VenueListPage(_country));
        }

        private async void Players_Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(
                new PlayersView(_country));

        }
        private async void Clubs_Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(
                new CompetitorsPage(_country,sport));
        }

        private async void Leagues_Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(
               new LeaguesByCountryListView(_country));
        }
    }
}