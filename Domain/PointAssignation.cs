namespace SPAN_League_ranking.Domain
{
    public interface IPointAssignation
    {
        ITeam HomeTeam { get; }
        int HomeTeamPointsAwarded { get; }
        ITeam AwayTeam { get; }
        int AwayTeamPointsAwarded { get; }
    }

    public class PointAssignation : IPointAssignation
    {
        public ITeam HomeTeam { init; get; }
        public int HomeTeamPointsAwarded { set; get; }
        public ITeam AwayTeam { init; get; }
        public int AwayTeamPointsAwarded { set; get; }
    }
}
