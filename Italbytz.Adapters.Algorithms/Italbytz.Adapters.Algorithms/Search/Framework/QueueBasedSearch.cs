using System.Collections.Generic;
using Italbytz.Adapters.Algorithms.Search.Framework.QSearch;
using Italbytz.Ports.Algorithms.AI.Problem;
using Italbytz.Ports.Algorithms.AI.Search;

namespace Italbytz.Adapters.Algorithms.Search.Framework
{
    public abstract class QueueBasedSearch<TState,TAction> : ISearchForActions<TState, TAction>, ISearchForStates<TState, TAction>
    {
        protected QueueSearch<TState, TAction> Impl;
        private Queue<Node<TState, TAction>> _frontier;

        protected QueueBasedSearch(QueueSearch<TState, TAction> impl, Queue<Node<TState, TAction>> queue) {
            this.Impl = impl;
            this._frontier = queue;
        }
        public IMetrics Metrics { get; }
        public IEnumerable<TAction>? FindActions(IProblem<TState, TAction> problem) => throw new System.NotImplementedException();

        public TState? FindState(IProblem<TState, TAction> problem) => throw new System.NotImplementedException();
    }
}