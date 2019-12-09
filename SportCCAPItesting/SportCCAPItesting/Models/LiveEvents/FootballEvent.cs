using System;
using System.Collections.Generic;
using System.Text;

namespace SportCCAPItesting.Models.Events
{
   public class FootballEvent
    {
        public Player PlayerName { get; set; }

        public string Type { get; set; }
        public int Minute { get; set; }
        public int Half { get; set; }
        public Player SecondaryPlayer { get; set; }

        public string HomeOrAwayTeam { get; set; }


    }
}
