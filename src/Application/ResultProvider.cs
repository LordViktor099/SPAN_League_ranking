using SPAN_League_ranking.Domain;
using SPAN_League_ranking.Parser;

namespace SPAN_League_ranking.Application
{
    public interface IResultProvider
    {
        List<IResult> GetResults(ITxtFileParser text);
    }
    public class ResultProvider : IResultProvider
    {
        public List<IResult> GetResults(ITxtFileParser text)
        {
            return text.ParseResultsFromTxtFile("Input.txt");
        }
    }
}
