using SportCCAPItesting.Data;
using SportCCAPItesting.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SportCCAPItesting.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LeaguesByCountryListView : ContentPage
    {
        private readonly DataManager dataManager = new DataManager();
        private readonly Country _country;
        private readonly IList<Subcontest> subContests = new ObservableCollection<Subcontest>();
        private Player _player = new Player();
        private Subcontest _sub = new Subcontest();

        public LeaguesByCountryListView()
        {
            InitializeComponent();


        }

        public LeaguesByCountryListView(Country country)
        {
            _country = country;
            Update();
            BindingContext = subContests;

            InitializeComponent();
        }

        private async void Update()
        {

            Sportccbetdata scc = await dataManager.GetAllLeaguesByCountry(_country);
            if (scc.SubContests != null)
            {
                foreach (Subcontest subC in scc.SubContests.Subcontest)
                {
                    subContests.Add(subC);
                }
            }
        }
        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;
            _sub = (Subcontest)e.Item;
            await Navigation.PushModalAsync(
               new LeagueTableView(_sub.TournamentId));
            //await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }
    }
}
