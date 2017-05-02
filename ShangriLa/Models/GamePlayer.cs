using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShangriLa.Models
{
    public class GamePlayer
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public int PlayerId { get; set; }
        public string PlayerName { get; set; }
        public int TotalScore { get; set; }
        public int TwoSetsOneRun { get; set; }
        public int TwoRunsOneSet { get; set; }
        public int ThreeSets { get; set; }
        public int ThreeRuns { get; set; }
        public int ThreeSetsOneRun { get; set; }
        public int TwoSetsTwoRuns { get; set; }
        public int FourSets { get; set; }
    }
}