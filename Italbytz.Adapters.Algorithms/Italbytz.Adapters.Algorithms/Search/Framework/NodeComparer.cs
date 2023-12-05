using System.Collections.Generic;

namespace Italbytz.Adapters.Algorithms.Search.Framework
{
    public class NodeComparer<TState, TAction> : Comparer<Node<TState, TAction>>
    {
        public override int Compare(Node<TState, TAction>? x, Node<TState, TAction>? y) => x.PathCost.CompareTo(y.PathCost);
    }
}