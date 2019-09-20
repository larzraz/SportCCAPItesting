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
    public partial class GoalsByGame : ContentPage
    {
        //public ObservableCollection<Goal> Goals { get; set; }
        GoalsByGameViewModel vm;

        public GoalsByGame(Match match)
        {
            vm = new GoalsByGameViewModel(match);
            BindingContext = vm;
            
            InitializeComponent();   
        }

        internal void SetToVisible(Goal goal)
        {

            goal.IsVisible = !goal.IsVisible;

            //OnPropertyChanged("IsVisible");

        }

        void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;
            Goal goal = (Goal)e.Item;
            SetToVisible(goal);
            
            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }
    }
}
