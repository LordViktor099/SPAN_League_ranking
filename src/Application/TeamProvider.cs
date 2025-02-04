using SPAN_League_ranking.Domain;

namespace SPAN_League_ranking.Application
{
    public interface ITeamProvider
    {
        HashSet<ITeam> LoadTeamsInMemory(List<IResult> result);
        HashSet<ITeam> GetAllLoadedTeams(IResult result);
    }
    public class TeamProvider : ITeamProvider
    {
        private HashSet<ITeam> _teams;

        public HashSet<ITeam> LoadTeamsInMemory(List<IResult> results)
        {
            _teams = new HashSet<ITeam>();
            foreach (var result in results) {
                AddIfNewTeam(result.HomeTeam);
                AddIfNewTeam(result.AwayTeam);
            }
            return _teams;
        }
        public HashSet<ITeam> GetAllLoadedTeams(IResult result)
        {
            return _teams;
        }

        private void AddIfNewTeam(ITeam team)
        {
            if ( !_teams.Contains(team))
            {
                _teams.Add(team);
            }
        }

    }
}
