// The original version of this file is part of <see href="https://github.com/aimacode/aima-java"/> which is released under
// MIT License
// Copyright (c) 2015 aima-java contributors

using System.Collections.Generic;

namespace Italbytz.Adapters.Algorithms.Search.Framework
{
    public class NodeComparer<TState, TAction> : Comparer<Node<TState, TAction>>
    {
        public override int Compare(Node<TState, TAction>? x, Node<TState, TAction>? y) => x.PathCost.CompareTo(y.PathCost);
    }
}