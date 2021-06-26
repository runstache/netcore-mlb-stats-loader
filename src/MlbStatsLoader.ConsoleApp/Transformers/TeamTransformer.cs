using MlbStatsLoader.ConsoleApp.DataObjects;
using MlbStatsLoader.ConsoleApp.Models;

namespace MlbStatsLoader.ConsoleApp.Transformers
{
    public class TeamTransformer
    {
        public static Team TransformerHome(GameModel model)
        {
            return new Team()
            {
                Name = model.HomeName,
                Code = model.HomeCode
            };
        }

        public static Team TransformAway(GameModel model)
        {
            return new Team()
            {
                Name = model.AwayName,
                Code = model.AwayCode
            };
        }
    }
}
