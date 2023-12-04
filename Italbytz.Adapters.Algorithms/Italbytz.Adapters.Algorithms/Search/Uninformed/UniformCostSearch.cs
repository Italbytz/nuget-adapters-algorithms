using System.Collections.Generic;
using Italbytz.Ports.Algorithms.AI.Problem;
using Italbytz.Ports.Algorithms.AI.Search;

namespace Italbytz.Adapters.Algorithms.Search.Uninformed
{
    public class UniformCostSearch<TState,TAction> : ISearchForActions<TState,TAction>
    {
        public IMetrics Metrics { get; }

        public IEnumerable<TAction>? FindActions(
            IProblem<TState, TAction> problem)
        {
            throw new System.NotImplementedException();
        }
    }
}