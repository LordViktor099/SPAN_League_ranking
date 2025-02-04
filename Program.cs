using SPAN_League_ranking.Application;
using SPAN_League_ranking.Infrastructure;
using SPAN_League_ranking.Parser;

var resultProvider = new ResultProvider();
var textParser = new TxtFileParser();
var results = resultProvider.GetResults(textParser);

var teamProvider = new TeamProvider();
var teams = teamProvider.LoadTeamsInMemory(results);

var rankProvider = new RankProvider(new SPAN_League_ranking.Domain.PointAwarder());
var rank = rankProvider.GenerateRankForMatchday(results, teams);
var orderedRank = rankProvider.GetOrderedRank(rank);

var outputProvider = new OutputProvider(new TxtFileOutputFormatter());
outputProvider.SendToOutput(orderedRank);

