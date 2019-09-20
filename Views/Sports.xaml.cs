using SportCCAPItesting.Data;
using SportCCAPItesting.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SportCCAPItesting.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Sports : ContentPage
    {
        private DataManager dataManager = new DataManager();
        private Sportccbetdata spbd;
        private Sport sport;
        private SportList sl;
        private IList<Sport> sports = new ObservableCollection<Sport>();
        private List<Sport> sportsList;
        private Country _country;
        public ObservableCollection<string> Items { get; set; }

        public Sports()
        {
            Update();
            BindingContext = sports;
            InitializeComponent();

            Items = new ObservableCollection<string>
            {
            };

            //MyListView.ItemsSource = Items;
        }

        //public  Sports(DataManager dataManager)
        //{
        //    this.dataManager = dataManager;
        //    Update();
        //    BindingContext = sports;
        //    InitializeComponent();

        //}

        public Sports(Country country)
        {
            _country = country;
            Update();
            BindingContext = sports;
            InitializeComponent();
        }

        private async void Update()
        {
            //IEnumerable<Sport> sportCollection = await dataManager.GetAllSports();

            //sport = await dataManager.GetAllSports();
            Sportccbetdata scc = await dataManager.GetAllSports();
            // SportList sportCollection = await dataManager.GetAllSports();
            foreach (Sport sport in scc.SportList.Sport)
            {
                sports.Add(sport);
            }
        }

        private async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;
            sport = (Sport)e.Item;
            await Navigation.PushModalAsync(
                new OptionsPage(_country, sport));

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }
    }
}