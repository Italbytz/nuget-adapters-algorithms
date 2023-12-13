// The original version of this file is part of <see href="https://github.com/aimacode/aima-java"/> which is released under
// MIT License
// Copyright (c) 2015 aima-java contributors

using Italbytz.Adapters.Algorithms.Search.Agent;
using Italbytz.Adapters.Algorithms.Search.Framework.Problem;
using Italbytz.Adapters.Algorithms.Search.Framework.QSearch;
using Italbytz.Adapters.Algorithms.Search.Uninformed;
using Italbytz.Adapters.Algorithms.Tests.Environment.Map;
using Italbytz.Ports.Algorithms.AI.Agent;

namespace Italbytz.Adapters.Algorithms.Tests.Unit.Search.Uninformed;

public class UniformCostSearchTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestSimplifiedRoadMapOfRomaniaFromSibiu()
    {
        var search = new UniformCostSearch<string, MoveToAction>();
        var actions = TestSimplifiedRoadMapOfRomania(search,
            SimplifiedRoadMapOfPartOfRomania.SIBIU);
        Assert.That(actions,
            Is.EqualTo(
                "MoveToAction[name=moveTo, location=RimnicuVilcea], MoveToAction[name=moveTo, location=Pitesti], MoveToAction[name=moveTo, location=Bucharest]"));
        Assert.That(
            search.Metrics.Get(QueueSearch<string, MoveToAction>
                .MetricPathCost), Is.EqualTo("278"));
    }

    [Test]
    public void TestSimplifiedRoadMapOfRomaniaFromArad()
    {
        var search = new UniformCostSearch<string, MoveToAction>();
        var actions = TestSimplifiedRoadMapOfRomania(search,
            SimplifiedRoadMapOfPartOfRomania.ARAD);
        Assert.That(actions,
            Is.EqualTo(
                "MoveToAction[name=moveTo, location=Sibiu], MoveToAction[name=moveTo, location=RimnicuVilcea], MoveToAction[name=moveTo, location=Pitesti], MoveToAction[name=moveTo, location=Bucharest]"));
        Assert.That(
            search.Metrics.Get(QueueSearch<string, MoveToAction>
                .MetricPathCost), Is.EqualTo("418"));
    }

    private string TestSimplifiedRoadMapOfRomania(
        UniformCostSearch<string, MoveToAction> search, string initialState)
    {
        var romaniaMap = new SimplifiedRoadMapOfPartOfRomania();
        var problem = new GeneralProblem<string, MoveToAction>(initialState,
            MapFunctions.CreateActionsFunction(romaniaMap),
            MapFunctions.GetResult, MapFunctions.TestGoal,
            MapFunctions.CreateDistanceStepCostFunction(romaniaMap));
        var agent =
            new SearchAgent<IPercept, string, MoveToAction>(problem, search);
        var actions = agent.Actions;
        return string.Join(", ", actions);
    }
}