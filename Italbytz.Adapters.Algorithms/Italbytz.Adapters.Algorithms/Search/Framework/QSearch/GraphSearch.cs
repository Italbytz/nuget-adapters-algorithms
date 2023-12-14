// The original version of this file is part of <see href="https://github.com/aimacode/aima-java"/> which is released under
// MIT License
// Copyright (c) 2015 aima-java contributors

using System.Collections.Generic;
using Italbytz.Ports.Algorithms.AI.Problem;
using Italbytz.Ports.Algorithms.AI.Search;

namespace Italbytz.Adapters.Algorithms.Search.Framework.QSearch
{
    public class GraphSearch<TState, TAction> : TreeSearch<TState, TAction>
    {
        private readonly HashSet<TState> _explored = new();

        public GraphSearch() : this(new NodeFactory<TState, TAction>())
        {
        }

        private GraphSearch(NodeFactory<TState, TAction> nodeFactory) : base(
            nodeFactory)
        {
        }

        public override INode<TState, TAction>? FindNode(
            IProblem<TState, TAction> problem,
            PriorityQueue<INode<TState, TAction>, double> frontier)
        {
            _explored.Clear();
            return base.FindNode(problem, frontier);
        }

        protected override void AddToFrontier(
            PriorityQueue<INode<TState, TAction>, double> frontier,
            INode<TState, TAction> node)
        {
            if (_explored.Contains(node.State)) return;
            base.AddToFrontier(frontier, node);
        }

        protected override INode<TState, TAction> RemoveFromFrontier(
            PriorityQueue<INode<TState, TAction>, double> frontier)
        {
            var result = frontier.Dequeue();
            _explored.Add(result.State);
            UpdateMetrics(frontier.Count);
            return result;
        }

        protected override bool IsFrontierEmpty(
            PriorityQueue<INode<TState, TAction>, double> frontier)
        {
            CleanUpFrontier(frontier);
            UpdateMetrics(frontier.Count);
            return base.IsFrontierEmpty(frontier);
        }

        /// <summary>
        ///     Helper method which removes nodes of already explored states from the head
        ///     of the frontier.
        /// </summary>
        /// <param name="frontier"></param>
        private void CleanUpFrontier(
            PriorityQueue<INode<TState, TAction>, double> frontier)
        {
            while (frontier.Count > 0 &&
                   _explored.Contains(frontier.Peek().State))
                frontier.Dequeue();
        }
    }
}