using SportCCAPItesting.Models;
using SportCCAPItesting.ViewModels;
using SportCCAPItesting.Views.MatchPages;
using SportCCAPItesting.Views.MatchPages.MatchInfoPages.ContentViews;
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
    public partial class ListContentView : ContentView
    {
        DateTime Dt;
       
        TodaysMatchesViewModel tmv;
        public ListView listView { get; set; }
        public ListContentView(DateTime dt)
        {
            Dt = dt;
            listView = new ListView();
            tmv = new TodaysMatchesViewModel(dt);
            BindingContext = tmv;
            
            InitializeComponent();
            MyListView.ItemsSource = tmv.Tournaments;
            listView.ItemsSource = MyListView.ItemsSource;
        }
        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;
            Match match = (Match)e.Item;
            var var = (App.Current.MainPage as TabbedPage).CurrentPage;

            await (App.Current.MainPage as TabbedPage).CurrentPage.Navigation.PushModalAsync(
                  new MatchInfoPage(match));
            //await (App.Current.MainPage as TabbedPage).CurrentPage.Navigation.PushModalAsync(
            //     new OVP(match));


            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }
    }
}