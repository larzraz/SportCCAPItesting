using SportCCAPItesting.Models;
using SportCCAPItesting.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SportCCAPItesting.Views.MatchPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LiveMatchesView : ContentPage
    {
        LiveMatchesViewModel lmvm;

        public LiveMatchesView()
        {
            lmvm = new LiveMatchesViewModel();
            BindingContext = lmvm;
            InitializeComponent();
        }
        public LiveMatchesView(Country country)
        {
            lmvm = new LiveMatchesViewModel(country);
            BindingContext = lmvm;
            InitializeComponent();
            
        }

       async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;
            var match = (Match)e.Item;

            lmvm.SetToVisible(match);
            await Navigation.PushModalAsync(new GoalsByGame(match));


            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }
        

      //  private void OpenGoalsBtn_Clicked(object sender, EventArgs e)
        //{

        //}
    }
}
