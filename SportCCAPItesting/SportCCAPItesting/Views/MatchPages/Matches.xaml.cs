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
    public partial class Matches : ContentPage
    {
        private IList<Match> _matches = new ObservableCollection<Match>();
        private DataManager dataManager = new DataManager();
        private Sport _sport = new Sport();

        public Matches()
        {
            BindingContext = _matches;
           // Update();
            InitializeComponent();
        }

        //public async void Update()
        //{
        //    _sport.Id ="1";  
        //    try
        //    {

            
        //    Sportccbetdata scc = await dataManager.GetAllMatchesForTodayForOneSport(_sport);

        //    foreach (Category cat in scc.Sports.Sport.Category)
        //    {
        //        foreach (Tournament tour in cat.Tournament)
        //        {
        //            foreach (Match match in tour.Match)
        //            {
        //                _matches.Add(match);
        //                match.HomeTeam = match.Competitors.Competitor[0];
        //                match.AwayTeam = match.Competitors.Competitor[1];
        //            }
        //        }
        //    }
        //    }catch(Exception e)
        //    {
        //        await DisplayAlert("Hovsa!","Du har ikke adgang til denne feature " + e, "OK");
        //    }

        //}

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
