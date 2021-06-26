using System;

namespace MlbStatsLoader.ConsoleApp.DataObjects
{
    public class PitcherStat
    {
        public long Id { get; set; }
        public long PlayerId { get; set; }
        public int OpponentId { get; set; }
        public double Innings { get; set; }
        public int Hits { get; set; }
        public int Runs { get; set; }
        public int EarnedRuns { get; set; }
        public int Walks { get; set; }
        public int Strikeouts { get; set; }
        public int HomeRuns { get; set; }
        public int Pitches { get; set; }
        public int PitchesForStrikes { get; set; }
        public double EarnedRunAverage { get; set; }
        public DateTime GameDate { get; set; }
    }
}
