using System;
using System.Collections.Generic;
using Italbytz.Ports.Algorithms.AI.Learning;

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
        if (attributeName == null)
            throw new ArgumentNullException(nameof(attributeName));
        _nodes = new Dictionary<string, DecisionTree>();
    }

    private string? AttributeName { get; }

    public void AddLeaf(string attributeValue, string decision)
    {
        _nodes[attributeValue] = new ConstantDecisionTree(decision);
    }

    public void AddNode(string attributeValue, DecisionTree tree)
    {
        _nodes[attributeValue] = tree;
    }

    public virtual object Predict(IExample e)
    {
        var attrValue = e.GetAttributeValueAsString(AttributeName);
        if (_nodes.ContainsKey(attrValue))
            return _nodes[attrValue].Predict(e);
        throw new Exception($"no node exists for attribute value {attrValue}");
    }
}