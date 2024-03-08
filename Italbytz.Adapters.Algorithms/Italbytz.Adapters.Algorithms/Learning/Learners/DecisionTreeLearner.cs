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
        var results = new[] { 0, 0 };

        foreach (var e in ds.Examples)
            if (e.TargetValue().Equals(Tree.Predict(e)))
                results[0] = results[0] + 1;
            else
                results[1] = results[1] + 1;

        return results;
    }
}