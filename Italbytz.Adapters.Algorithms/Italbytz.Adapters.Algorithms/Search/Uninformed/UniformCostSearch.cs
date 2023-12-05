using System.Collections.Generic;
using Italbytz.Adapters.Algorithms.Search.Framework;
using Italbytz.Ports.Algorithms.AI.Problem;
using Italbytz.Ports.Algorithms.AI.Search;
using Italbytz.Adapters.Algorithms.Search.Framework.QSearch;

namespace Italbytz.Adapters.Algorithms.Search.Uninformed
{
    public class
        UniformCostSearch<TState, TAction> : QueueBasedSearch<TState, TAction>
    {
        public UniformCostSearch() : this(new GraphSearch<TState, TAction>()) {
        }

        public UniformCostSearch(QueueSearch<TState, TAction> impl) : base(impl,
            QueueFactory
                .CreatePriorityQueue<Node<TState, TAction>>()) //new NodeComparer<TState, TAction>()))

        {
        }
    }
}