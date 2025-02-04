using System.Diagnostics.CodeAnalysis;
using System.Drawing;

namespace SPAN_League_ranking.Domain
{
    public interface ITeam
    {
        string Name { get; }
    }

    public class Team : ITeam
    {
        public string Name { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is Team team &&
                   Name == team.Name;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name);
        }
    }
}
