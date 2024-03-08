// The original version of this file is part of <see href="https://github.com/aimacode/aima-java"/> which is released under
// MIT License
// Copyright (c) 2015 aima-java contributors

using Italbytz.Adapters.Algorithms.Learning.Learners;
using Italbytz.Adapters.Algorithms.Tests.Unit.Learning.Framework;

namespace Italbytz.Adapters.Algorithms.Tests.Unit.Learning.Learners;

public class LearnerTest
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestMajorityLearner()
    {
        var learner = new MajorityLearner();
        var ds = TestDataSetFactory.GetRestaurantDataSet();
        learner.Train(ds);
        var result = learner.Test(ds);
        Assert.Multiple(() =>
        {
            Assert.That(result[0], Is.EqualTo(6));
            Assert.That(result[1], Is.EqualTo(6));
        });
    }

    [Test]
    public void TestDefaultUsedWhenTrainingDataSetHasNoExamples()
    {
        // tests RecursionBaseCase#1
        var ds = TestDataSetFactory.GetRestaurantDataSet();
        var learner = new DecisionTreeLearner();

        var ds2 = ds.EmptyDataSet();
        Assert.That(ds2.Examples, Is.Empty);

        learner.Train(ds2);
        Assert.That(learner.Predict(ds.Examples[0]),
            Is.EqualTo("Unable To Classify"));
    }
}