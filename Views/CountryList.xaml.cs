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
    public partial class CountryList : ContentPage

    {
        private IList<Country> countries = new ObservableCollection<Country>();
        private DataManager dataManager = new DataManager();

        public CountryList()
        {
            BindingContext = countries;
            Update();
            InitializeComponent();
         }
        async void Update()
        {
            Sportccbetdata scc = await dataManager.GetAllCountries();
            foreach (Country country in scc.CountryList.Countries)
            {
                countries.Add(country);
            }
        }
        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;
            await Navigation.PushModalAsync(
                new Sports((Country)e.Item));

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }
    }
}
