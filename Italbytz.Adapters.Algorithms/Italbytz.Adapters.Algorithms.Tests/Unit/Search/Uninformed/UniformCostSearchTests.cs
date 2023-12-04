using Italbytz.Adapters.Algorithms.Search.Agent;
using Italbytz.Adapters.Algorithms.Search.Framework.Problem;
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
        var problem = new GeneralProblem<string, MoveToAction>(SimplifiedRoadMapOfPartOfRomania.SIBIU, MapFunctions.CreateActionsFunction(romaniaMap), MapFunctions.CreateResultFunction(), MapFunctions.TestGoal,MapFunctions.CreateDistanceStepCostFunction(romaniaMap));
        var search = new UniformCostSearch<string, MoveToAction>();
        var agent = new SearchAgent<IPercept, string, MoveToAction>(problem, search);
        //var actions = agent.GetActions();
    }

}