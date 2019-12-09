using SportCCAPItesting.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Xamarin.Forms;

namespace SportCCAPItesting.Data
{
    public class DataManager
    {       
        private const string Url = "http://data.livescorelink.com/";
        private const string authID = "userID=vester&pass=vesterOff@3234!213";      

        private HttpClient GetClient()
        {
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Accept", "application/xml");
            return httpClient;
        }

        public async Task<Sportccbetdata> GetAllSports()
        {
            HttpClient client = GetClient();
            string result = await client.GetStringAsync(Url + "SportList.aspx?" + authID);
            XmlSerializer Deserializer = new XmlSerializer(typeof(Sportccbetdata), new XmlRootAttribute("sportccbetdata"));
            var reader = new StringReader(result);
            Sportccbetdata SportCollection = (Sportccbetdata)Deserializer.Deserialize(reader);
            return SportCollection;
        }

        public async Task<Sportccbetdata> GetAllCompetitorsByCountry(Country country, Sport _sport)
        {
            HttpClient client = GetClient();
            string result = await client.GetStringAsync(Url + "CompetitorsInCountrySport.aspx?cid=" + country.Id + "&sport_id=" + _sport.Id + "&" + authID);
            XmlSerializer Deserializer = new XmlSerializer(typeof(Sportccbetdata), new XmlRootAttribute("sportccbetdata"));
            var reader = new StringReader(result);
            Sportccbetdata SportCollection = (Sportccbetdata)Deserializer.Deserialize(reader);
            return SportCollection;
        }

        public async Task<Sportccbetdata> GetAllVenues()
        {
            HttpClient client = GetClient();
            string result = await client.GetStringAsync(Url + "VenueList.aspx?" + authID);
            XmlSerializer Deserializer = new XmlSerializer(typeof(Sportccbetdata), new XmlRootAttribute("sportccbetdata"));
            var reader = new StringReader(result);
            Sportccbetdata SportCollection = (Sportccbetdata)Deserializer.Deserialize(reader);
            return SportCollection;
        }

        public async Task<Sportccbetdata> GetAllCountries()
        {
            HttpClient client = GetClient();
            string result = await client.GetStringAsync(Url + "CountryList.aspx?" + authID);
            XmlSerializer Deserializer = new XmlSerializer(typeof(Sportccbetdata), new XmlRootAttribute("sportccbetdata"));
            var reader = new StringReader(result);
            Sportccbetdata SportCollection = (Sportccbetdata)Deserializer.Deserialize(reader);
            return SportCollection;
        }

        public async Task<Sportccbetdata> GetAllPlayersByCountry(Country country)
        {
            HttpClient client = GetClient();
            List<Player> players = new List<Player>();
        Sportccbetdata SportCollection = new Sportccbetdata();


            string te = country.Id;
            for (int i = 240; i < 260; i++)
            {
                string result = await client.GetStringAsync(Url + "PlayerList.aspx?tid=" + i + "&" + authID);
                if (result != null)
                {
                    XmlSerializer Deserializer = new XmlSerializer(typeof(Sportccbetdata), new XmlRootAttribute("sportccbetdata"));
                    var reader = new StringReader(result);
                    SportCollection = (Sportccbetdata)Deserializer.Deserialize(reader);

                    if (SportCollection.PlayerList != null && country.Id != null)
                    {
                        foreach (Player player in SportCollection.PlayerList.Player)
                        {
                            if (player.CountryId == country.Id)
                            {
                                players.Add(player);
                            }
                        }
                    }
                }
            }
            SportCollection.PlayerList.Player = players;
            return SportCollection;
        }

        public async Task<Sportccbetdata> GetAllMatchesForTodayForOneSport(Sport sport, DateTime dt)
        {
            HttpClient client = GetClient();
            
            string test = Url + "sportccfixtures.aspx?sport_id=" + sport.Id + "&" + authID + "&fromDate=" + dt.ToString("MM-dd-yy") + "&toDate=" + dt.ToString("MM-dd-yy");
            string result = await client.GetStringAsync(Url + "sportccfixtures.aspx?sport_id=" + sport.Id + "&" + authID + "&fromDate=" + dt.ToString("MM-dd-yy") + "&toDate=" + dt.ToString("MM-dd-yy"));
            XmlSerializer Deserializer = new XmlSerializer(typeof(Sportccbetdata), new XmlRootAttribute("sportccbetdata"));
            var reader = new StringReader(result);
            Sportccbetdata SportCollection = (Sportccbetdata)Deserializer.Deserialize(reader);
            return SportCollection;
        }

        public async Task<Sportccbetdata> GetAllCoaches()
        {
            HttpClient client = GetClient();
            string result = await client.GetStringAsync(Url + "CoachList.aspx?" + authID);
            XmlSerializer Deserializer = new XmlSerializer(typeof(Sportccbetdata), new XmlRootAttribute("sportccbetdata"));
            var reader = new StringReader(result);
            Sportccbetdata SportCollection = (Sportccbetdata)Deserializer.Deserialize(reader);
            return SportCollection;
        }

        public async Task<Sportccbetdata> GetAllBookmaker()
        {
            HttpClient client = GetClient();
            string result = await client.GetStringAsync(Url + "BookmakerList.aspx?" + authID);
            XmlSerializer Deserializer = new XmlSerializer(typeof(Sportccbetdata), new XmlRootAttribute("sportccbetdata"));
            var reader = new StringReader(result);
            Sportccbetdata SportCollection = (Sportccbetdata)Deserializer.Deserialize(reader);
            return SportCollection;
        }

        public async Task<Sportccbetdata> GetAllOfficials()
        {
            HttpClient client = GetClient();
            string result = await client.GetStringAsync(Url + "OfficalsList.aspx?" + authID);
            XmlSerializer Deserializer = new XmlSerializer(typeof(Sportccbetdata), new XmlRootAttribute("sportccbetdata"));
            var reader = new StringReader(result);
            Sportccbetdata SportCollection = (Sportccbetdata)Deserializer.Deserialize(reader);
            return SportCollection;
        }

        public async Task<Sportccbetdata> GetLeagueTableByLeagueID(string sub)
        {
            HttpClient client = GetClient();
            string result = await client.GetStringAsync(Url + "SportccLeagueTable.aspx?lid="+sub+"&" + authID);
            XmlSerializer Deserializer = new XmlSerializer(typeof(Sportccbetdata), new XmlRootAttribute("sportccbetdata"));
            var reader = new StringReader(result);
            Sportccbetdata SportCollection = (Sportccbetdata)Deserializer.Deserialize(reader);
            return SportCollection;
        }
        public async Task<Sportccbetdata> GetAllLeaguesByCountry(Country country)
        {
            HttpClient client = GetClient();
                List<Subcontest> subC = new List<Subcontest>();
            Sportccbetdata SportCollection = new Sportccbetdata();

           
                string result = await client.GetStringAsync(Url + "SubContests.aspx?sport_id=1&" + authID);
                if (result != null)
                {
                    XmlSerializer Deserializer = new XmlSerializer(typeof(Sportccbetdata), new XmlRootAttribute("sportccbetdata"));
                    var reader = new StringReader(result);
                    SportCollection = (Sportccbetdata)Deserializer.Deserialize(reader);

                    if (SportCollection.SubContests!= null && country.Id != null)
                    {
                        foreach (Subcontest SubC in SportCollection.SubContests.Subcontest)
                        {
                            if (SubC.Countryid == country.Id && SubC.Season == "2019/20")
                            {
                            subC.Add(SubC);
                            }
                        }
                    }
                }
            
            SportCollection.SubContests.Subcontest = subC;
            return SportCollection;
        }

        public async Task<Sportccbetdata> GetAllLiveMatchesForTodayForOneSport(Sport sport)
        {
            Sportccbetdata SportCollection = new Sportccbetdata();
            HttpClient client = GetClient();
            try
            {
                string result = await client.GetStringAsync(Url + "SportccLive.aspx?sport_id=" + sport.Id + "&" + authID);
                XmlSerializer Deserializer = new XmlSerializer(typeof(Sportccbetdata), new XmlRootAttribute("sportccbetdata"));
                var reader = new StringReader(result);
                SportCollection = (Sportccbetdata)Deserializer.Deserialize(reader);
                return SportCollection;
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            return SportCollection;





        }

        public async Task<Sportccbetdata> GetAllEvents()
        {
            HttpClient client = GetClient();
            string result = await client.GetStringAsync(Url + "Eventlist.aspx?" + authID);
            XmlSerializer Deserializer = new XmlSerializer(typeof(Sportccbetdata), new XmlRootAttribute("sportccbetdata"));
            var reader = new StringReader(result);
            Sportccbetdata SportCollection = (Sportccbetdata)Deserializer.Deserialize(reader);


            return SportCollection;
        }

        public EventMockData GetEventMock()
        {
            return new EventMockData();
        }
        public DataManager()
        {
            
        }
    }

    
}