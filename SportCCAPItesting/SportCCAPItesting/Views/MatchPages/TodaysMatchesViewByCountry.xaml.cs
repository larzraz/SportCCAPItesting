using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using SportCCAPItesting.Models;
using SportCCAPItesting.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SportCCAPItesting.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TodaysMatchesViewByCountry : ContentPage
    {
        TodaysMatchesByCountryViewModel tmbc;
      
        public TodaysMatchesViewByCountry()
        {
            InitializeComponent();
            BindingContext = tmbc;
           
        }
        public TodaysMatchesViewByCountry(Country country)
        {
            InitializeComponent();
             tmbc= new TodaysMatchesByCountryViewModel(country);
           
            BindingContext = tmbc;

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
