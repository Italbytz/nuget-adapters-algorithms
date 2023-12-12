// The original version of this file is part of <see href="https://github.com/aimacode/aima-java"/> which is released under
// MIT License
// Copyright (c) 2015 aima-java contributors

using System.Collections.Generic;
using Italbytz.Adapters.Algorithms.Search.Framework.QSearch;
using Italbytz.Ports.Algorithms.AI.Problem;
using Italbytz.Ports.Algorithms.AI.Search;

namespace Italbytz.Adapters.Algorithms.Search.Framework
{
    public abstract class QueueBasedSearch<TState,TAction> : ISearchForActions<TState, TAction>, ISearchForStates<TState, TAction>
    {
        protected readonly QueueSearch<TState, TAction> Impl;
        private readonly PriorityQueue<INode<TState, TAction>,double> _frontier;

        protected QueueBasedSearch(QueueSearch<TState, TAction> impl, PriorityQueue<INode<TState, TAction>,double> queue) {
            this.Impl = impl;
            this._frontier = queue;
        }

        public IMetrics Metrics => Impl.Metrics;

        public IEnumerable<TAction>? FindActions(
            IProblem<TState, TAction> problem)
        {
            Impl.NodeFactory.UseParentLinks = true;
            _frontier.Clear();
            var node = Impl.FindNode(problem, _frontier);
            return SearchUtils.ToActions(node);
        }

        public TState? FindState(IProblem<TState, TAction> problem) => throw new System.NotImplementedException();
    }
}