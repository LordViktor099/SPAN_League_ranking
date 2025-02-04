using SPAN_League_ranking.Domain;

namespace SPAN_League_ranking.Application
{
    public interface IRankProvider
    {
        Dictionary<ITeam, int> GenerateRankForMatchday(List<IResult> results, HashSet<ITeam> teams);
        Dictionary<ITeam, int> GetOrderedRank(Dictionary<ITeam, int> unordedRank);
    }

    public class RankProvider : IRankProvider
    {
        private Dictionary<ITeam, int> rank;

        public Dictionary<ITeam, int> GenerateRankForMatchday(List<IResult> results, HashSet<ITeam> teams)
        {
            rank = new Dictionary<ITeam, int>();
            foreach (var team in teams) {
                rank.Add(team, 0);
            }

            var pointAwarder = new PointAwarder();
            foreach (var result in results)
            {
                var pointsAssignation = pointAwarder.AssignPoints(result);
                rank[pointsAssignation.HomeTeam] = rank[pointsAssignation.HomeTeam] + pointsAssignation.HomeTeamPointsAwarded;
                rank[pointsAssignation.AwayTeam] = rank[pointsAssignation.AwayTeam] + pointsAssignation.AwayTeamPointsAwarded;
            }

            return rank;
        }

        public Dictionary<ITeam, int> GetOrderedRank(Dictionary<ITeam, int> unordedRank)
        {
            var orderedRank = rank.OrderByDescending(t=>t.Value).ThenBy(t=>t.Key.Name).ToDictionary();
            return orderedRank;
        }

    }
}
