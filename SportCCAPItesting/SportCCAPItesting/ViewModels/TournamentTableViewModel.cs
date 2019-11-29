using SportCCAPItesting.Data;
using SportCCAPItesting.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportCCAPItesting.ViewModels
{
    public class TournamentTableViewModel : BaseViewModel
    {
        private ObservableCollection<Competitor> _clubs;
        private List<Competitor> SortedList = new List<Competitor>();

        public Match Match { get; set; }
        public DataManager dm;
        public ObservableCollection<Competitor> Clubs
        {
            get
            {
                return _clubs;
            }
            set
            {
                Action setClubs = async () =>
                {
                    await SetClubsForTournament();
                };
                _clubs = value;
                setClubs();
            }
        }
        


        public TournamentTableViewModel(Match m)
        {
            Match = m;
            dm = new DataManager();
            Clubs = new ObservableCollection<Competitor>();
        }

      
        private async Task SetClubsForTournament()
        {
           
            Sportccbetdata scc = await dm.GetLeagueTableByLeagueID(Match.TournamentId);

            foreach (Tournament tour in scc.Category.Tournaments)
            {


                foreach (Competitor com in tour.Competitor)
                {

                    Int32.TryParse(com.Place, out int a);
                    com.PlaceInt = a;

                }
                //  Clubs = tour.Competitor.OrderBy(o => o.PlaceInt).ToList();
                var var = tour.Competitor.OrderBy(o => o.PlaceInt).ToList();
                SortedList = tour.Competitor.OrderBy(o => o.PlaceInt).ToList();
                foreach (Competitor com in var)
                {
                    Clubs.Add(com);
                }
            }

        }
    }
}
