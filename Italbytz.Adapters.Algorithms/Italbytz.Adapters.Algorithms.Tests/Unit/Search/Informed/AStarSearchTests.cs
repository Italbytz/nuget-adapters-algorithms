using Italbytz.Adapters.Algorithms.Search.Agent;
using Italbytz.Adapters.Algorithms.Search.Framework.Problem;
using Italbytz.Adapters.Algorithms.Search.Framework.QSearch;
using Italbytz.Adapters.Algorithms.Search.Informed;
using Italbytz.Adapters.Algorithms.Search.Uninformed;
using Italbytz.Adapters.Algorithms.Tests.Environment.Map;
using Italbytz.Ports.Algorithms.AI.Agent;

namespace Italbytz.Adapters.Algorithms.Tests.Unit.Search.Informed;

public class AStarSearchTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestSimplifiedRoadMapOfRomania()
    {
        var romaniaMap = new SimplifiedRoadMapOfPartOfRomania();
        var problem = new GeneralProblem<string, MoveToAction>(SimplifiedRoadMapOfPartOfRomania.SIBIU, MapFunctions.CreateActionsFunction(romaniaMap), MapFunctions.GetResult, MapFunctions.TestGoal, MapFunctions.CreateDistanceStepCostFunction(romaniaMap));
        var search = new AStarSearch<string, MoveToAction>(new GraphSearch<string, MoveToAction>(),MapFunctions.CreateSLDHeuristicFunction(SimplifiedRoadMapOfPartOfRomania.BUCHAREST, romaniaMap));
        var agent = new SearchAgent<IPercept, string, MoveToAction>(problem, search);
        var actions = agent.Actions;
        var actionsString = string.Join(", ", actions); 
        Assert.That(actionsString, Is.EqualTo("MoveToAction[name=moveTo, location=RimnicuVilcea], MoveToAction[name=moveTo, location=Pitesti], MoveToAction[name=moveTo, location=Bucharest]"));
        Assert.That(search.Metrics.Get(QueueSearch<string, MoveToAction>.METRIC_PATH_COST), Is.EqualTo("278"));
    }
}