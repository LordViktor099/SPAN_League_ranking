namespace SPAN_League_ranking.Domain
{
    public interface IResult
    {
        ITeam HomeTeam { get; }
        ITeam AwayTeam { get; }
        IScore Score {  get; }
    }

    public class Result : IResult
    {
        public ITeam HomeTeam { init; get; }

        public ITeam AwayTeam { init; get; }

        public IScore Score { init; get; }
    }
}
