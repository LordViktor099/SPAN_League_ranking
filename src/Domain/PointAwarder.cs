namespace SPAN_League_ranking.Domain
{
    public interface IPointAwarder
    {
        IPointAssignation AssignPoints(IResult result);
    }

    public class PointAwarder : IPointAwarder
    {
        public IPointAssignation AssignPoints(IResult result)
        {
            var pointAssignation = new PointAssignation() { HomeTeam = result.HomeTeam, AwayTeam = result.AwayTeam };
            
            const int PointsAwardedOnWin = 3;
            const int PointsAwardedOnDraw = 1;
            const int PointsAwardedOnLose = 0;

            if (result.Score.HomeScore > result.Score.AwayScore)
            {
                pointAssignation.HomeTeamPointsAwarded = PointsAwardedOnWin;
                pointAssignation.AwayTeamPointsAwarded = PointsAwardedOnLose;
                return pointAssignation;
            }

            if (result.Score.AwayScore > result.Score.HomeScore)
            {
                pointAssignation.HomeTeamPointsAwarded = PointsAwardedOnLose;
                pointAssignation.AwayTeamPointsAwarded = PointsAwardedOnWin;
                return pointAssignation;
            }

            pointAssignation.HomeTeamPointsAwarded = PointsAwardedOnDraw;
            pointAssignation.AwayTeamPointsAwarded = PointsAwardedOnDraw;
            return pointAssignation;

        }
    }
}
