using SportCCAPItesting.Data;
using SportCCAPItesting.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SportCCAPItesting.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VenueListPage : ContentPage
    {
        private IList<Venue> venues = new ObservableCollection<Venue>();
        private List<Venue> Unsorted = new List<Venue>();
        private readonly DataManager dataManager = new DataManager();
        private readonly Country _country;
        private Venue _venue;

        public VenueListPage()
        {
            InitializeComponent();
            BindingContext = venues;
        }

        public VenueListPage(Country country)
        {
            _country = country;
            BindingContext = venues;
            Update();
            InitializeComponent();
        }

        private async void Update()
        {
            Sportccbetdata scc = await dataManager.GetAllVenues();
            foreach (Venue venue in scc.VenueList.Venue)
            {
                Int32.TryParse(venue.Capacity, out int a);
                venue.IDToInt = a;
            }
            Unsorted = scc.VenueList.Venue.OrderByDescending(o => o.IDToInt).ToList();

            foreach (Venue venue in Unsorted)
            {
                if (venue.Countryid == _country.Id)
                {
                    venues.Add(venue);
                }
            }
        }

        private async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;
            _venue = (Venue)e.Item;

            await DisplayAlert(_venue.Name, "Kapacitet: " + _venue.Capacity + "\n" + "Klub: " + _venue.Teamhostname, "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }
    }
}