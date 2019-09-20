using SportCCAPItesting.Data;
using SportCCAPItesting.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SportCCAPItesting.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlayersView : ContentPage
    {
        private readonly DataManager dataManager = new DataManager();
        private readonly Country _country;
        private readonly IList<Player> players = new ObservableCollection<Player>();
        private Player _player = new Player();
        
        public PlayersView()
        {
            InitializeComponent();

           
        }

        public PlayersView(Country country)
        {
            _country = country; 
            Update();
            BindingContext = players;

            InitializeComponent();
        }

        private async void Update()
        {

            Sportccbetdata scc = await dataManager.GetAllPlayersByCountry(_country);
            if (scc.PlayerList != null)
            {
                foreach (Player player in scc.PlayerList.Player)
                {
                    players.Add(player);
                }
            }
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;
            _player = (Player)e.Item;
            await DisplayAlert(_player.Firstname + " " + _player.Surname, "Position: "+ _player.Position + "\n Trøjenummer: " + _player.ShirtNumber + "\n Alder: " + _player.Age, "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }
    }
}
