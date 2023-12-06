using Italbytz.Adapters.Algorithms.Search.Agent;
using Italbytz.Adapters.Algorithms.Search.Framework.Problem;
using Italbytz.Adapters.Algorithms.Search.Framework.QSearch;
using Italbytz.Adapters.Algorithms.Search.Uninformed;
using Italbytz.Adapters.Algorithms.Tests.Environment.Map;
using Italbytz.Adapters.Algorithms.Tests.Environment.NQueens;
using Italbytz.Ports.Algorithms.AI.Agent;

namespace Italbytz.Adapters.Algorithms.Tests.Unit.Search.Uninformed;

public class UniformCostSearchTests
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
        var search = new UniformCostSearch<string, MoveToAction>();
        var agent = new SearchAgent<IPercept, string, MoveToAction>(problem, search);
        var actions = agent.Actions;
        var actionsString = string.Join(", ", actions); 
        Assert.That(actionsString, Is.EqualTo("MoveToAction[name=moveTo, location=RimnicuVilcea], MoveToAction[name=moveTo, location=Pitesti], MoveToAction[name=moveTo, location=Bucharest]"));
        Assert.That(search.Metrics.Get(QueueSearch<string, MoveToAction>.METRIC_PATH_COST), Is.EqualTo("278"));
    }

}