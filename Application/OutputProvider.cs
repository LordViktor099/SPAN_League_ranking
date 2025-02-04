using SPAN_League_ranking.Domain;
using SPAN_League_ranking.Infrastructure;

namespace SPAN_League_ranking.Application
{
    public interface IOutputProvider
    {
        void SendToOutput(Dictionary<ITeam, int> orderedRank);
    }
    public class OutputProvider : IOutputProvider
    {
        ITxtFileOuputFormatter formatter;

        public OutputProvider(ITxtFileOuputFormatter formatter)
        {
            this.formatter = formatter;
        }

        public void SendToOutput(Dictionary<ITeam, int> orderedRank)
        {
            const string outputFileName = "Output.txt";
            formatter.WriteToFile(outputFileName, orderedRank);
        }
    }
}
