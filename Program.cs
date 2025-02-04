using SPAN_League_ranking.Application;
using SPAN_League_ranking.Parser;

var resultProvider = new ResultProvider();
var textParser = new TxtFileParser();
var results = resultProvider.GetResults(textParser);

var teamProvider = new TeamProvider();
var teams = teamProvider.LoadTeamsInMemory(results);

var rankProvider = new RankProvider();
var output = rankProvider.GenerateRankForMatchday(results, teams);
File.WriteAllLines("Output.txt", output);
