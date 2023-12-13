// The original version of this file is part of <see href="https://github.com/aimacode/aima-java"/> which is released under
// MIT License
// Copyright (c) 2015 aima-java contributors

namespace Italbytz.Adapters.Algorithms.Search.Framework.QSearch
{
    public class GraphSearch<TState, TAction> : TreeSearch<TState, TAction>
    {
        public GraphSearch() : this(new NodeFactory<TState, TAction>())
        {
        }

        private GraphSearch(NodeFactory<TState, TAction> nodeFactory) : base(
            nodeFactory)
        {
        }
    }
}