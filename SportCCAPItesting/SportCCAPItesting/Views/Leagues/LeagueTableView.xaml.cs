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
    public partial class LeagueTableView : ContentPage
    {
        private IList<Competitor> clubs = new ObservableCollection<Competitor>();
        private List<Competitor> SortedList = new List<Competitor>();
        private readonly DataManager dataManager = new DataManager();
        private Sport _sport = new Sport();
        private string _tournamentID;
      

        public LeagueTableView(string tournamentId)
        {
            _tournamentID = tournamentId;
            BindingContext = clubs;
            Update();
            InitializeComponent();
        }

        private async void Update()
        {
            Sportccbetdata scc = await dataManager.GetLeagueTableByLeagueID(_tournamentID);

            foreach (Tournament tour in scc.Category.Tournament)
            {
                
                
                foreach (Competitor com in tour.Competitor)
                {
                    
                    Int32.TryParse(com.Place, out int a);
                    com.PlaceInt = a;
                    
                }
                SortedList = tour.Competitor.OrderBy(o => o.PlaceInt).ToList();
                foreach (Competitor com in SortedList)
                {
                    clubs.Add(com);
                }
            }
         

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
