using MlbStatsLoader.ConsoleApp.Contexts;
using MlbStatsLoader.ConsoleApp.DataObjects;
using System.Linq;

namespace MlbStatsLoader.ConsoleApp.Repositories
{
    public class SqlRepository : IRepository
    {
        private readonly SqlContext ctx;

        public SqlRepository(string connectionString)
        {
            ctx = new SqlContext(connectionString);
        }

        public SqlRepository(SqlContext ctx)
        {
            this.ctx = ctx;
        }

        public void Delete(Player player)
        {
            ctx.Players.Remove(player);
            ctx.SaveChanges();
        }

        public void Delete(PitcherStat stat)
        {
            ctx.PitchingStats.Remove(stat);
            ctx.SaveChanges();
        }

        public void Delete(PlayerStat stat)
        {
            ctx.PlayerStats.Remove(stat);
            ctx.SaveChanges();
        }

        public void Delete(Team team)
        {
            ctx.Teams.Remove(team);
            ctx.SaveChanges();
        }

        public bool Exists(Team team)
        {
            return ctx.Teams.Where(c => c.Code == team.Code).FirstOrDefault() != null;
        }

        public bool Exists(Player player)
        {
            return ctx.Players.Where(c => c.Url == player.Url).FirstOrDefault() != null;
        }

        public bool Exists(PlayerStat stat)
        {
            return ctx.PlayerStats.Any(c => c.PlayerId == stat.PlayerId 
                && c.GameDate == stat.GameDate 
                && c.OpponentId == stat.OpponentId);
        }

        public bool Exists(PitcherStat stat)
        {
            return ctx.PitchingStats.Any(c => c.PlayerId == stat.PlayerId
                && c.OpponentId == stat.OpponentId
                && c.GameDate == stat.GameDate);
        }

        public PitcherStat GetPitcherStat(long id)
        {
            return ctx.PitchingStats.Where(c => c.Id == id).FirstOrDefault();
        }

        public IQueryable<PitcherStat> GetPitcherStats()
        {
            return ctx.PitchingStats;
        }

        public Player GetPlayer(string url)
        {
            return ctx.Players.Where(c => c.Url == url).FirstOrDefault();
        }

        public Player GetPlayer(long id)
        {
            return ctx.Players.Where(c => c.Id == id).FirstOrDefault();
        }

        public IQueryable<Player> GetPlayers()
        {
            return ctx.Players;
        }

        public PlayerStat GetPlayerStat(long id)
        {
            return ctx.PlayerStats.Where(c => c.Id == id).FirstOrDefault();
        }

        public IQueryable<PlayerStat> GetStats()
        {
            return ctx.PlayerStats;
        }

        public Team GetTeam(int id)
        {
            return ctx.Teams.Where(c => c.Id == id).FirstOrDefault();
        }

        public Team GetTeam(string code)
        {
            return ctx.Teams.Where(c => c.Code == code).FirstOrDefault();
        }

        public IQueryable<Team> GetTeams()
        {
            return ctx.Teams;
        }

        public Player Insert(Player player)
        {
            var entity = ctx.Players.Add(player);
            ctx.SaveChanges();
            return entity.Entity;
        }

        public Team Insert(Team team)
        {
            var entity = ctx.Teams.Add(team);
            ctx.SaveChanges();
            return entity.Entity;
        }

        public PlayerStat Insert(PlayerStat stat)
        {
            var entity = ctx.PlayerStats.Add(stat);
            ctx.SaveChanges();
            return entity.Entity;
        }

        public PitcherStat Insert(PitcherStat stat)
        {
            var entity = ctx.PitchingStats.Add(stat);
            ctx.SaveChanges();
            return entity.Entity;
        }

        public Player Update(Player player)
        {
            var original = GetPlayer(player.Id);
            if (original != null)
            {
                if (!original.Equals(player))
                {
                    ctx.Entry(original).CurrentValues.SetValues(player);
                }
                ctx.SaveChanges();
                return GetPlayer(player.Id);
            }
            else
            {
                return Insert(player);
            }
        }

        public Team Update(Team team)
        {
            var original = GetTeam(team.Id);
            if (original != null)
            {
                if (!original.Equals(team))
                {
                    ctx.Entry(original).CurrentValues.SetValues(team);
                }
                ctx.SaveChanges();
                return GetTeam(team.Id);
            }
            else
            {
                return Insert(team);
            }
        }

        public PlayerStat Update(PlayerStat stat)
        {
            var original = GetPlayerStat(stat.Id);
            if (original != null)
            {
                if (!original.Equals(stat))
                {
                    ctx.Entry(original).CurrentValues.SetValues(stat);
                }
                ctx.SaveChanges();
                return GetPlayerStat(stat.Id);
            }
            else
            {
                return Insert(stat);
            }
        }

        public PitcherStat Update(PitcherStat stat)
        {
            var original = GetPitcherStat(stat.Id);
            if (original != null)
            {
                if (!original.Equals(stat))
                {
                    ctx.Entry(original).CurrentValues.SetValues(stat);                   
                }
                ctx.SaveChanges();
                return GetPitcherStat(stat.Id);
            }
            else
            {
                return Insert(stat);
            }
        }
    }
}
