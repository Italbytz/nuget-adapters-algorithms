using System;
using System.Collections.Generic;
using Italbytz.Adapters.Algorithms.Search.Framework;
using Italbytz.Adapters.Algorithms.Search.Framework.QSearch;
using Italbytz.Ports.Algorithms.AI.Search;
using Italbytz.Ports.Algorithms.AI.Search.Informed;

namespace Italbytz.Adapters.Algorithms.Search.Informed
{
    public class BestFirstSearch<TState, TAction> : QueueBasedSearch<TState, TAction>, IInformed<TState, TAction>
    {
        private Func<INode<TState, TAction>, double> _evalFn;
        public BestFirstSearch(QueueSearch<TState, TAction> impl, Func<INode<TState, TAction>, double> evalFn) : base(impl, QueueFactory
            .CreatePriorityQueue<INode<TState, TAction>>())
        {
            _evalFn = evalFn;
        }

        public Func<INode<TState, TAction>, double>? HeuristicFn { get; set; }
    }
}