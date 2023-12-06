using System;
using System.Collections.Generic;
using Italbytz.Adapters.Algorithms.Search.Framework.QSearch;
using Italbytz.Ports.Algorithms.AI.Search;

namespace Italbytz.Adapters.Algorithms.Search.Informed
{
    public class AStarSearch<TState, TAction> : BestFirstSearch<TState, TAction>
    {
        public AStarSearch(QueueSearch<TState, TAction> impl, Func<INode<TState, TAction>, double> heuristicFn) : base(impl, CreateEvalFn(heuristicFn))
        {
        }

        private static Func<INode<TState,TAction>,double> CreateEvalFn(Func<INode<TState,TAction>,double> heuristicFn)
        {
            return node => node.PathCost + heuristicFn(node);
        }
    }
}