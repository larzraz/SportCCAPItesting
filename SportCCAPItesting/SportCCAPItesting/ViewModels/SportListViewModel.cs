using SportCCAPItesting.Data;
using SportCCAPItesting.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SportCCAPItesting.ViewModels
{
    public class SportListViewModel : BaseViewModel
    {
        private DataManager dataManager = new DataManager();
        public Country Country { get; set; }
        public Sport Sport { get; set; }
        public ObservableCollection<Sport> SportsCollection { get; set; }
        public Command LoadSportsCommand { get; set; }
        public SportListViewModel()
        {
            Update();
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