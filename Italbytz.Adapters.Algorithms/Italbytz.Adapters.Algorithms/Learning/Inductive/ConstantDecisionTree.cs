namespace Italbytz.Adapters.Algorithms.Learning.Inductive;

public class ConstantDecisionTree : DecisionTree
{
    public ConstantDecisionTree(string value)
    {
        Value = value;
    }

    public string Value { get; set; }
}