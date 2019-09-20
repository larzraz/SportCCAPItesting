using SportCCAPItesting.Models;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SportCCAPItesting.Data
{
    public class DataManager
    {
        private const string Url = "http://data.livescorelink.com/";
        private const string authID = "userID=jasons&pass=jas@331";
        private List<Player> players = new List<Player>();

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
    }
}