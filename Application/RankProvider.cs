using SPAN_League_ranking.Domain;

namespace SPAN_League_ranking.Application
{
    public interface IRankProvider
    {
        List<string> GenerateRankForMatchday(List<IResult> results, HashSet<ITeam> teams);
    }

    public class RankProvider : IRankProvider
    {
        private Dictionary<ITeam, int> rank;

        public List<string> GenerateRankForMatchday(List<IResult> results, HashSet<ITeam> teams)
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

            var orderedRank = rank.OrderByDescending(t=>t.Value).ThenBy(t=>t.Key.Name).ToDictionary();

            List<string> output = new List<string>();
            foreach(var team in orderedRank.Keys)
            {
                output.Add($"{team.Name.ToString()}, {orderedRank[team].ToString()} pts");
            }

            return output;
        }
    }
}
