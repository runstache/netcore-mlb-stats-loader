using Newtonsoft.Json;

namespace MlbStatsLoader.ConsoleApp.Models
{
    public class PitcherStatModel
    {
        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "ip")]
        public string Innings { get; set; }

        [JsonProperty(PropertyName = "hits")]
        public string Hits { get; set; }

        [JsonProperty(PropertyName = "runs")]
        public string Runs { get; set; }

        [JsonProperty(PropertyName = "earnedRuns")]
        public string EarnedRuns { get; set; }

        [JsonProperty(PropertyName = "walks")]
        public string Walks { get; set; }

        [JsonProperty(PropertyName = "strikeout")]
        public string Strikeouts { get; set; }

        [JsonProperty(PropertyName = "homerun")]
        public string Homeruns { get; set; }

        [JsonProperty(PropertyName = "pcst")]
        public string Pcst { get; set; }

        [JsonProperty(PropertyName = "era")]
        public string Era { get; set; }

        [JsonProperty(PropertyName = "pc")]
        public string PitchCount { get; set; }

    }
}
