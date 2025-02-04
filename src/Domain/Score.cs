namespace SPAN_League_ranking.Domain
{
    public interface IScore
    {
        int HomeScore { get; }
        int AwayScore { get; }
    }

    public class Score : IScore
    {
        public int HomeScore { init; get; }
        public int AwayScore { init; get; }
    }
}
