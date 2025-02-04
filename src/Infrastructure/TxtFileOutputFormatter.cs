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
            int listNumber = 1;
            int lastPoints = 1;
            int idx = 0;
            foreach(var team in orderedRank.Keys)
            {
                idx++;
                if ( lastPoints != orderedRank[team])
                {
                    lastPoints = orderedRank[team];
                    listNumber = idx;
                }
                var ptTerminator = orderedRank[team] == 1 ? "pt" : "pts";
                output.Add($"{listNumber}.{team.Name}, {orderedRank[team]} {ptTerminator}");
            }
            File.WriteAllLines(filePath, output);
        }
    }
}
