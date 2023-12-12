// The original version of this file is part of <see href="https://github.com/aimacode/aima-java"/> which is released under
// MIT License
// Copyright (c) 2015 aima-java contributors

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

        private UniformCostSearch(QueueSearch<TState, TAction> impl) : base(impl,
            QueueFactory
                .CreatePriorityQueue<INode<TState, TAction>>()) 

        {
        }
    }
}