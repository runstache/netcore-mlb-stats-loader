using MlbStatsLoader.ConsoleApp.DataObjects;
using System.Linq;

namespace MlbStatsLoader.ConsoleApp.Repositories
{
    public interface IRepository
    {
        #region Insert

        Player Insert(Player player);
        Team Insert(Team team);
        PlayerStat Insert(PlayerStat stat);
        PitcherStat Insert(PitcherStat stat);

        #endregion

        #region Update

        Player Update(Player player);
        Team Update(Team team);
        PlayerStat Update(PlayerStat stat);
        PitcherStat Update(PitcherStat stat);

        #endregion

        #region Retrieve

        IQueryable<Player> GetPlayers();
        Player GetPlayer(string url);
        Player GetPlayer(long id);

        IQueryable<Team> GetTeams();
        Team GetTeam(int id);
        Team GetTeam(string code);

        IQueryable<PlayerStat> GetStats();
        PlayerStat GetPlayerStat(long id);

        IQueryable<PitcherStat> GetPitcherStats();
        PitcherStat GetPitcherStat(long id);

        #endregion

        #region Delete

        void Delete(Player player);
        void Delete(PitcherStat stat);
        void Delete(PlayerStat stat);
        void Delete(Team team);

        #endregion

        #region Exists

        bool Exists(Team team);
        bool Exists(Player player);
        bool Exists(PlayerStat stat);

        bool Exists(PitcherStat stat);

        #endregion

    }
}
