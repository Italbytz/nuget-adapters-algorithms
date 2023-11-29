using System;
using Italbytz.Ports.Algorithms;
using System.Net.NetworkInformation;
using System.Collections.Generic;

namespace Italbytz.Adapters.Algorithms.Search.Framework
{
    public class NodeFactory<TState, TAction> : INodeFactory<TState, TAction>
    {
        public bool UseParentLinks { get; set; } = true;

        public NodeFactory()
        {
        }

        public Node<TState, TAction> CreateNode(TState state)
        {
            return new Node<TState, TAction>(state);
        }

        public Node<TState, TAction> CreateNode(TState state, INode<TState, TAction> parent, TAction action, double stepCost)
        {
            var p = UseParentLinks ? parent : null;
            return new Node<TState, TAction>(state, p, action, parent.PathCost + stepCost);
        }

        public List<Node<TState, TAction>> GetSuccessors(INode<TState, TAction> node, IProblem<TState, TAction> problem)
        {
            List<Node<TState, TAction>> successors = new List<Node<TState, TAction>>();

            foreach (var action in problem.Actions(node.State))
            {
                var successorState = problem.Result(node.State, action);
                var stepCost = problem.StepCosts(node.State, action, successorState);
                successors.Add(CreateNode(successorState, node, action, stepCost));
            }
            NotifyListeners(node);
            return successors;
        }

        private void NotifyListeners(INode<TState, TAction> node)
        {

        }
    }
}

