using System;
using Italbytz.Adapters.Algorithms.Learning.Inductive;
using Italbytz.Ports.Algorithms.AI.Learning;

namespace Italbytz.Adapters.Algorithms.Learning.Learners;

public class DecisionTreeLearner : ILearner
{
    public DecisionTreeLearner(DecisionTree decisionTree, string defaultValue)
    {
        Tree = decisionTree;
        DefaultValue = defaultValue;
    }

    public DecisionTree Tree { get; set; }
    public string DefaultValue { get; set; }

    public void Train(IDataSet ds)
    {
        throw new NotImplementedException();
    }

    public string Predict(IExample e)
    {
        throw new NotImplementedException();
    }

    public int[] Test(IDataSet ds)
    {
        throw new NotImplementedException();
    }
}