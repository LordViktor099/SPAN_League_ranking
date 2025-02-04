using SPAN_League_ranking.Domain;

namespace SPAN_League_ranking.Infrastructure
{
    public interface ITxtFileOuputFormatter
    {
        void WriteToFile(string filePath, Dictionary<ITeam, int> orderedRank);

    }
    public class TxtFileOutputFormatter : ITxtFileOuputFormatter
    {
        public void WriteToFile(string filePath, Dictionary<ITeam, int> orderedRank)
        {
            List<string> output = new List<string>();
            foreach(var team in orderedRank.Keys)
            {
                var ptTerminator = orderedRank[team] == 1 ? "pt" : "pts";
                output.Add($"{team.Name}, {orderedRank[team]} {ptTerminator}");
            }
            File.WriteAllLines(filePath, output);
        }
    }
}
