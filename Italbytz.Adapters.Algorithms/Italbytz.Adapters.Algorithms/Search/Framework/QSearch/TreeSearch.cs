// The original version of this file is part of <see href="https://github.com/aimacode/aima-java"/> which is released under
// MIT License
// Copyright (c) 2015 aima-java contributors

using System;
using System.Collections.Generic;
using Italbytz.Ports.Algorithms.AI.Problem;
using Italbytz.Ports.Algorithms.AI.Search;

namespace Italbytz.Adapters.Algorithms.Search.Framework.QSearch
{
    public class TreeSearch<TState, TAction> : QueueSearch<TState, TAction>
    {
        
        protected PriorityQueue<INode<TState, TAction>,double> Frontier;
        
        public TreeSearch() : this(new NodeFactory<TState, TAction>())
        {
            
        }
        public TreeSearch(NodeFactory<TState, TAction> nodeFactory) : base (nodeFactory) 
        {
            
        }

        /// <summary>
        /// Receives a problem and a queue implementing the search strategy and
        /// computes a node referencing a goal state, if such a state was found.
        /// This template method provides a base for tree and graph search
        /// implementations. It can be customized by overriding some primitive
        /// operations.
        /// </summary>
        /// <param name="problem">the search problem</param>
        /// <param name="frontier">the data structure for nodes that are waiting to be expanded</param>
        /// <returns>a node referencing a goal state, if the goal was found, otherwise empty</returns>
        public override INode<TState, TAction>? FindNode(
            IProblem<TState, TAction> problem,
            PriorityQueue<INode<TState, TAction>,double> frontier)
        {
            Frontier = frontier;
            ClearMetrics();
            var root = NodeFactory.CreateNode(problem.InitialState);
            AddToFrontier(root);
            if (EarlyGoalTest && problem.TestSolution(root))
            {
                Metrics.Set(METRIC_PATH_COST, (int)root.PathCost);
                return root;
            }
            while (Frontier.Count > 0)
            {
                var node = RemoveFromFrontier();
                if (!EarlyGoalTest && problem.TestSolution(node))
                {
                    Metrics.Set(METRIC_PATH_COST, (int)node.PathCost);
                    return node;
                }
                var successors = NodeFactory.GetSuccessors(node, problem);
                foreach (var successor in successors)
                {
                    AddToFrontier(successor);
                    if (EarlyGoalTest && problem.TestSolution(successor))
                    {
                        Metrics.Set(METRIC_PATH_COST, (int)successor.PathCost);
                        return successor;
                    }
                }
            }
            return null;
        }

        private INode<TState,TAction> RemoveFromFrontier()
        {
            var result = Frontier.Dequeue();
            UpdateMetrics(Frontier.Count);
            return result;
        }

        private void AddToFrontier(INode<TState,TAction> node)
        {
            Frontier.Enqueue(node,node.PathCost);
            UpdateMetrics(Frontier.Count);
        }
        
    }
}