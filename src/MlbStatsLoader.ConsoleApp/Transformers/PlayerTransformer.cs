using MlbStatsLoader.ConsoleApp.DataObjects;
using MlbStatsLoader.ConsoleApp.Models;

namespace MlbStatsLoader.ConsoleApp.Transformers
{
    public class PlayerTransformer
    {
        public static Player Transform(PlayerStatModel stat, int teamId)
        {
            return new Player()
            {
                Name = stat.Name,
                Url = stat.Url,
                TeamId = teamId,
                IsPitcher = false
            };
        }

        public static Player Transform(PitcherStatModel stat, int teamId)
        {
            return new Player()
            {
                Name = stat.Name,
                Url = stat.Url,
                TeamId = teamId,
                IsPitcher = true
            };
        }
    }
}
