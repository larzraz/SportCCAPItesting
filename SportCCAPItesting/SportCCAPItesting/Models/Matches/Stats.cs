using System;
using System.Collections.Generic;
using System.Text;

namespace SportCCAPItesting.Models.Matches
{
   public class Stats
    {
        public List<Card> Cards { get; set; }
        public List<Corners> Corners { get; set; }
        public Goal Goals { get; set; }
        public double[] Possesion { get; set; }
        public double[] Shots { get; set; }
        public double[] Fouls { get; set; }
        public double[] Offsides { get; set; }

        public int[]ActualPossesion { get; set; }

        public int[] ActualShots { get; set; }
        public int[] ActualFouls { get; set; }
        public int[] ActualOffsides { get; set; }
    }
}
