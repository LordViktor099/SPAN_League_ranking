using SPAN_League_ranking.Domain;

namespace SPAN_League_ranking.Parser
{
    public interface ITxtFileParser
    {
        List<IResult> ParseResultsFromTxtFile(string textFile);
    }
    public class TxtFileParser : ITxtFileParser
    {
        public List<IResult> ParseResultsFromTxtFile(string textFile)
        {
            var results =  new List<IResult>();
            var lines = File.ReadAllLines(textFile);
            foreach (var line in lines)
            {
                var tokens = line.Split(',');
                var teamAndScoreA = GetTeamAndScoreFromToken(tokens[0]);
                var teamAndScoreB = GetTeamAndScoreFromToken(tokens[1]);
                var result = new Result()
                {
                    HomeTeam = new Team() { Name = teamAndScoreA.Key },
                    AwayTeam = new Team() { Name = teamAndScoreB.Key },
                    Score = new Score { HomeScore = teamAndScoreA.Value, AwayScore = teamAndScoreB.Value}
                };
                results.Add(result);
            }
            return results;
        }

        private KeyValuePair<string, int> GetTeamAndScoreFromToken(string token)
        {
            int idx = token.Length - 1;
            while ( Char.IsDigit(token[idx]))
            {
                idx--;
            }
            var teamName = token.Substring(0, idx).Trim();
            return new KeyValuePair<string, int>(teamName, int.Parse(token.Substring(idx)));
        }

    }
}
