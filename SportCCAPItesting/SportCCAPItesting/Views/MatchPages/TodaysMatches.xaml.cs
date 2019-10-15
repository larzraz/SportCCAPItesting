using SportCCAPItesting.Models;
using SportCCAPItesting.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SportCCAPItesting.Views;
using SportCCAPItesting.Views.MatchPages;

namespace SportCCAPItesting.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TodaysMatches : ContentPage
    {
        DateTime Dt;
        TodaysMatchesViewModel tmv;
        public TodaysMatches(DateTime dt)
        {
            Dt = dt;
            tmv = new TodaysMatchesViewModel(dt);
            BindingContext = tmv;
            InitializeComponent();
           
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;
            //tmv.Country = (Country)e.Item;
            //await Navigation.PushModalAsync(
            //      new LiveMatchesView(tmv.Country))  ;
            await DisplayAlert("Liga", "KampInfo", "OK");
            
            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }
    }
}
