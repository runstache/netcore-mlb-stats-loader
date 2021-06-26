using MlbStatsLoader.ConsoleApp.DataObjects;
using MlbStatsLoader.ConsoleApp.Models;
using System;

namespace MlbStatsLoader.ConsoleApp.Transformers
{
    public class StatTransformer
    {
        public static PlayerStat Transform(PlayerStatModel model, long playerId, int opponentId, int teamId, string gameDate)
        {
            return new PlayerStat()
            {
                OpponentId = opponentId,
                AtBats = ConvertInteger(model.AtBats),
                BattingAverage = ConvertDouble(model.BattingAverage),
                Hits = ConvertInteger(model.Hits),
                Obp = ConvertDouble(model.Obp),
                PlayerId = playerId,
                Rbi = ConvertInteger(model.Rbi),
                Runs = ConvertInteger(model.Runs),
                Slg = ConvertDouble(model.Slg),
                Strikeouts = ConvertInteger(model.Strikeouts),
                Walks = ConvertInteger(model.Walks),
                GameDate = ConvertDateTime(gameDate),
                TeamId = teamId
            };
        }

        public static PitcherStat Transform(PitcherStatModel model, long playerId, int opponentId, int teamId, string gameDate)
        {
            string[] parts = model.Pcst.Split("-");
            return new PitcherStat()
            {
                OpponentId = opponentId,
                PlayerId = playerId,
                EarnedRunAverage = ConvertDouble(model.Era),
                EarnedRuns = ConvertInteger(model.EarnedRuns),
                Hits = ConvertInteger(model.Hits),
                HomeRuns = ConvertInteger(model.Homeruns),
                Innings = ConvertDouble(model.Innings),
                Pitches = ConvertInteger(model.PitchCount),
                PitchesForStrikes = ConvertInteger(parts[1]),
                Runs = ConvertInteger(model.Runs),
                Strikeouts = ConvertInteger(model.Strikeouts),
                Walks = ConvertInteger(model.Walks),
                GameDate = ConvertDateTime(gameDate),
                TeamId = teamId
            };

        }

        private static int ConvertInteger(string value)
        {
            if (int.TryParse(value, out int result))
            {
                return result;
            }
            return 0;
        }

        private static double ConvertDouble(string value)
        {
            if (double.TryParse(value, out double result))
            {
                return result;
            }
            return 0;
        }

        private static DateTime ConvertDateTime(string value)
        {
            if (DateTime.TryParseExact(value, "yyyyMMdd",null, System.Globalization.DateTimeStyles.None, out DateTime result))
            {
                return result;
            }
            return DateTime.Now;
            
        }
    }


}
