using System.Collections.Generic;

namespace Italbytz.Adapters.Algorithms.Learning.Inductive;

public class DecisionTree
{
    private readonly Dictionary<string, DecisionTree> _nodes;

    protected DecisionTree()
    {
    }

    public DecisionTree(string attributeName)
    {
        AttributeName = attributeName;
        _nodes = new Dictionary<string, DecisionTree>();
    }

    public string AttributeName { get; set; }

    public void AddLeaf(string attributeValue, string decision)
    {
        _nodes[attributeValue] = new ConstantDecisionTree(decision);
    }

    public void AddNode(string attributeValue, DecisionTree tree)
    {
        _nodes[attributeValue] = tree;
    }
}