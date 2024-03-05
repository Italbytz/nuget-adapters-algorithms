// The original version of this file is part of <see href="https://github.com/aimacode/aima-java"/> which is released under
// MIT License
// Copyright (c) 2015 aima-java contributors

using Italbytz.Adapters.Algorithms.Learning.Inductive;
using Italbytz.Adapters.Algorithms.Learning.Learners;

namespace Italbytz.Adapters.Algorithms.Tests.Unit.Learning.Learners;

public class DecisionTreeTest
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestActualDecisionTreeClassifiesRestaurantDataSetCorrectly()
    {
        var learner = new DecisionTreeLearner(
            CreateActualRestaurantDecisionTree(), "Unable to clasify");
    }

    private static DecisionTree CreateActualRestaurantDecisionTree()
    {
        throw new NotImplementedException();
    }
}