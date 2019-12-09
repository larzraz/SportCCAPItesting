using SportCCAPItesting.Models.Events;
using SportCCAPItesting.Models.Matches;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportCCAPItesting.Data
{
    public class EventMockData
    {
        public List<FootballEvent> FirstHalfEvents = new List<FootballEvent>()
        {
            new FootballEvent
            {
                PlayerName = new Models.Player{Name = "Paul Pogba"},
                Half = 1,
                Minute = 2,
                Type = "Goal",
                SecondaryPlayer = new Models.Player{Name = "Jesse Lingard"},
                HomeOrAwayTeam = "Home"

            },

            new FootballEvent
            {
                PlayerName = new Models.Player{Name = "Michael Carrick"},
                Half = 1,
                Minute = 24,
                Type = "Goal",
                HomeOrAwayTeam = "Home"
            },
             new FootballEvent
            {
                PlayerName = new Models.Player{Name = "Angel Di Maria"},
                Half = 1,
                Minute = 37,
                Type = "YellowCard",
                HomeOrAwayTeam = "Away"
            },

        };

        public List<FootballEvent> SecondHalfEvents = new List<FootballEvent>()
        {
            new FootballEvent
            {
                PlayerName = new Models.Player{Name = "Paul Pogba"},
                Half = 2,
                Minute = 52,
                Type = "Goal",
                SecondaryPlayer = new Models.Player{Name = "Jesse Lingard"},
                HomeOrAwayTeam = "Home"

            },

            new FootballEvent
            {
                PlayerName = new Models.Player{Name = "Michael Carrick"},
                Half = 2,
                Minute = 64,
                Type = "Goal",
                HomeOrAwayTeam = "Home"
            },
             new FootballEvent
            {
                PlayerName = new Models.Player{Name = "Angel Di Maria"},
                Half = 2,
                Minute = 67,
                Type = "RedCard",
                HomeOrAwayTeam = "Away"
            },

        };

        public Stats Stats = new Stats { Possesion = new double[2] { 60, 40 }, Fouls = new double[2] { 14, 5 }, Offsides = new double[2] { 1, 5 }, Shots = new double[2] { 0, 5 } };
    }
}
