using System;

namespace MlbStatsLoader.ConsoleApp.DataObjects
{
    public class PlayerStat
    {
        public long Id { get; set; }
        public long PlayerId { get; set; }
        public int AtBats { get; set; }
        public int Runs { get; set; }
        public int Hits { get; set; }
        public int Rbi { get; set; }
        public int Walks { get; set; }
        public int Strikeouts { get; set; }
        public double BattingAverage { get; set; }
        public double Obp { get; set; }
        public double Slg { get; set; }
        public int OpponentId { get; set; }
        public DateTime GameDate { get; set; }
        public int TeamId { get; set; }

    }
}
