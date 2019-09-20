using SportCCAPItesting.Data;
using SportCCAPItesting.Models;
using SportCCAPItesting.ViewModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SportCCAPItesting.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Sports : ContentPage
    {
        SportListViewModel svm = new SportListViewModel();
       
        public Sports()
        {
            InitializeComponent();
            BindingContext = svm;
        }

        public Sports(Country country)
        {
            svm.Country = country;         
            BindingContext = svm;
            InitializeComponent();
        }

        private async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;
            svm.Sport = (Sport)e.Item;
            await Navigation.PushModalAsync(
                  new OptionsPage(svm.Country, svm.Sport));

           //Deselect Item
           ((ListView)sender).SelectedItem = null;
        }


    }
}