using FluentAssertions;
using Moq;
using SPAN_League_ranking.Application;
using SPAN_League_ranking.Domain;

namespace SPAN_League_ranking_tests.Application
{
    public class RankProviderTests
    {
        [Test]
        public void GenerateRankForMatchday_ShouldCall_PointAwarderAssignPoints()
        {
            // Arrange
            Mock<IPointAwarder> pointAwarderMock = new Mock<IPointAwarder>();
            pointAwarderMock.Setup(x => x.AssignPoints(It.IsAny<IResult>())).
                Returns(CreatePointAssignation());

            List<IResult> results = CreateResults();
            HashSet<ITeam> teams = CreateTeams();
            Team teamA = CreateTeam("TeamA");

            var sut = new RankProvider(pointAwarderMock.Object);

            // Act
            var actualValue = sut.GenerateRankForMatchday(results, teams);

            // Assert
            pointAwarderMock.Verify(x => x.AssignPoints(It.IsAny<IResult>()), Times.Once());
            actualValue.Count.Should().Be(2);
            actualValue[teamA].Should().Be(1);
        }

        private PointAssignation CreatePointAssignation()
        {
            return new PointAssignation()
            {
                AwayTeam = CreateTeam("TeamA"),
                HomeTeam = CreateTeam("TeamB"),
                AwayTeamPointsAwarded = 1,
                HomeTeamPointsAwarded = 1
            };
        }

        private List<IResult> CreateResults()
        {
            return new List<IResult>() { 
                new Result {
                    AwayTeam = CreateTeam("TeamA"),
                    HomeTeam = CreateTeam("TeamB"),
                    Score = new Score() 
                    { AwayScore = 1, HomeScore = 1 } 
                } 
            };
        }

        private HashSet<ITeam> CreateTeams()
        {
            return new HashSet<ITeam>() { 
                CreateTeam("TeamA"), 
                CreateTeam("TeamB")  
            };

        }

        private Team CreateTeam(string name)
        {
            return new Team()
            {
                Name = name
            };
        }


    }

}
