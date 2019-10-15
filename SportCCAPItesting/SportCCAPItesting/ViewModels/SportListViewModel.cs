using SportCCAPItesting.Data;
using SportCCAPItesting.Models;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SportCCAPItesting.ViewModels
{
    public class SportListViewModel : BaseViewModel
    {
        private DataManager dataManager = new DataManager();
        private ObservableCollection<Sport> _sportsCollection;

        public Country Country { get; set; }
        public Sport Sport { get; set; }
        public ObservableCollection<Sport> SportsCollection
        {
            get { return _sportsCollection; }
            set
            {
                _sportsCollection = value;

                Action FillSportsCollection = async () =>
        {
            await Update();
        }; 

                FillSportsCollection();
            }
        }
        public Command LoadSportsCommand { get; set; }
        public SportListViewModel()
        {
            
            SportsCollection = new ObservableCollection<Sport>();
            LoadSportsCommand = new Command(async () => await ExecuteLoadSportsCommand());
        }

        private async Task Update()
        {
            Sportccbetdata scc = await dataManager.GetAllSports();

            foreach (Sport sport in scc.SportList.Sport)
            {
                SportsCollection.Add(sport);
            }
        }

        private async Task ExecuteLoadSportsCommand()
        {
            await Update();
        }
    }
}