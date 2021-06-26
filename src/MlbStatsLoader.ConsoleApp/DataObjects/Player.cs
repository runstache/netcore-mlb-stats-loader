namespace MlbStatsLoader.ConsoleApp.DataObjects
{
    public class Player
    {
        public long Id { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
        public int TeamId { get; set; }
        public bool IsPitcher { get; set; }
    }
}
