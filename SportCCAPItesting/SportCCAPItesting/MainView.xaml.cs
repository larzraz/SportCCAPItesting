using SportCCAPItesting.Views;
using SportCCAPItesting.Views.MatchPages;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SportCCAPItesting
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainView : TabbedPage
    {
        private DateTime Today = DateTime.Now;
        private DateTime TodayDateMinusTwo;
        private DateTime TodayDateMinusOne;
        private DateTime TodayDatePlusOne;
        private DateTime TodayDatePlusTwo;
        public MainView()
        {
            TodayDateMinusTwo = Today.AddDays(-2);
            TodayDateMinusOne = Today.AddDays(-1);
            TodayDatePlusOne = Today.AddDays(1);
            TodayDatePlusTwo = Today.AddDays(2);
            
            InitializeComponent();
            this.Children.Add(new TodaysMatches(TodayDateMinusTwo) { Title = TodayDateMinusTwo.ToShortDateString() });
            this.Children.Add(new TodaysMatches(TodayDateMinusOne) { Title = TodayDateMinusOne.ToShortDateString() });
            this.Children.Add(new TodaysMatches(Today) { Title = Today.ToShortDateString() });
            this.Children.Add(new TodaysMatches(TodayDatePlusOne) { Title = TodayDatePlusOne.ToShortDateString() });
            this.Children.Add(new TodaysMatches(TodayDatePlusTwo) { Title = TodayDatePlusTwo.ToShortDateString() });

        }
    }
}