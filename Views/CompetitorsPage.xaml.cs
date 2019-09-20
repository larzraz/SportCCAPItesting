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
    public partial class CompetitorsPage : ContentPage
    {
        private readonly IList<Competitor> clubs = new ObservableCollection<Competitor>();
        private readonly DataManager dataManager = new DataManager();
        private readonly Country _country;
        private Sport _sport= new Sport();

        
       

        public CompetitorsPage()
        {
            BindingContext = clubs;
            Update();
            InitializeComponent();
      }

        public CompetitorsPage(Country country)
        {
            _sport.Id = "1";
            BindingContext = clubs;
            _country = country;
            Update();
            InitializeComponent();
        }

        public CompetitorsPage(Country country, Sport sport)
        {
            _sport = sport;
            BindingContext = clubs;
            _country = country;
            Update();
            InitializeComponent();
        }
        private async Task Update()
        {

            Sportccbetdata scc = await dataManager.GetAllCompetitorsByCountry(_country, _sport);
            foreach(Competitor comp in scc.Sport.Competitor)
            {
                clubs.Add(comp);
            }
            
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }
    }
}
