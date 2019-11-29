using SportCCAPItesting.Models;
using SportCCAPItesting.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SportCCAPItesting.Views.MatchPages.MatchInfoPages.ContentViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TableView : ContentView
    {
        private TournamentTableViewModel TTVM;
        public TableView(Match match)
        {
            TTVM = new TournamentTableViewModel(match);
            BindingContext = TTVM;
           
            InitializeComponent();
            MyListView.ItemsSource = TTVM.Clubs;
        }
    }
}