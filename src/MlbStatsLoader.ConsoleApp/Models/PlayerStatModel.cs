using Newtonsoft.Json;

namespace MlbStatsLoader.ConsoleApp.Models
{
    public class PlayerStatModel
    {
        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "ab")]
        public string AtBats { get; set; }

        [JsonProperty(PropertyName = "run")]
        public string Runs { get; set; }

        [JsonProperty(PropertyName = "hit")]
        public string Hits { get; set; }

        [JsonProperty(PropertyName = "rbi")]
        public string Rbi { get; set; }

        [JsonProperty(PropertyName = "walk")]
        public string Walks { get; set; }

        [JsonProperty(PropertyName = "strikeout")]
        public string Strikeouts { get; set; }

        [JsonProperty(PropertyName = "avg")]
        public string BattingAverage { get; set; }

        [JsonProperty(PropertyName = "obp")]
        public string Obp { get; set; }

        [JsonProperty(PropertyName = "slg")]
        public string Slg { get; set; }
    }
}
