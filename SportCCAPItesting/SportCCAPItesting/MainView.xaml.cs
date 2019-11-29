using SportCCAPItesting.Views;
using SportCCAPItesting.Views.MatchPages.MatchesOverview;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SportCCAPItesting
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainView : TabbedPage
    {
        private DateTime Today = DateTime.Now;

        public MainView()
        {
            InitializeComponent();

           // this.Children.Add(new TodaysMatches(Today) { Title = "Live" });
             this.Children.Add(new TabGrid() { Title = "Live" });
             this.Children.Add(new FavoritePage());
             this.Children.Add(new CameraPage());
             this.Children.Add(new SettingsPage());
            this.Children.Add(new StackLayoutTesting());
            
            
            
        }
    }
}