using Moq;
using NUnit.Framework.Internal;
using SPAN_League_ranking.Application;
using SPAN_League_ranking.Domain;
using SPAN_League_ranking.Infrastructure;

namespace SPAN_League_ranking_tests.Application
{
    public class OutputProviderTests
    {
        [Test]
        public void WhenSentToOutputCalled_ShouldCall_WriteToFile()
        {
            Mock<ITxtFileOuputFormatter> txtFileOutoutFormatterMock = new Mock<ITxtFileOuputFormatter>();

            var sut = new OutputProvider(txtFileOutoutFormatterMock.Object);

            sut.SendToOutput(new Dictionary<ITeam, int>());

            txtFileOutoutFormatterMock.Verify(x => x.WriteToFile(It.IsAny<string>(), It.IsAny<Dictionary<ITeam, int>>()), Times.Once());
        }
    }
}
