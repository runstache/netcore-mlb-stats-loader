using Newtonsoft.Json;
using System.Collections.Generic;

namespace MlbStatsLoader.ConsoleApp.Models
{
    public class GameModel
    {
        [JsonProperty(PropertyName = "awayname")]
        public string AwayName { get; set; }

        [JsonProperty(PropertyName = "awaycode")]
        public string AwayCode { get; set; }

        [JsonProperty(PropertyName = "homename")]
        public string HomeName { get; set; }

        [JsonProperty(PropertyName = "homecode")]
        public string HomeCode { get; set; }

        [JsonProperty(PropertyName = "gamedate")]
        public string GameDate { get; set; }

        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }

        [JsonProperty(PropertyName = "awayHitting")]
        public List<PlayerStatModel> AwayHitting { get; set; }

        [JsonProperty(PropertyName = "awayPitching")]
        public List<PitcherStatModel> AwayPitching { get; set; }

        [JsonProperty(PropertyName = "homeHitting")]
        public List<PlayerStatModel> HomeHitting { get; set; }

        [JsonProperty(PropertyName = "homePitching")]
        public List<PitcherStatModel> HomePitching { get; set; }

        public GameModel()
        {
            AwayHitting = new List<PlayerStatModel>();
            AwayPitching = new List<PitcherStatModel>();
            HomeHitting = new List<PlayerStatModel>();
            HomePitching = new List<PitcherStatModel>();
        }

    }
}
