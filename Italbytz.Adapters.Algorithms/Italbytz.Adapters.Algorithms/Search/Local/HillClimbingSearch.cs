/** 
 * The original version of this file is part of <see href="https://github.com/aimacode/aima-java"/> which is released under 
 * MIT License
 * Copyright (c) 2015 aima-java contributors
 */

using System;
using System.Collections.Generic;
using Italbytz.Ports.Algorithms;

namespace Italbytz.Adapters.Algorithms.Search.Local
{
    public class HillClimbingSearch<TState, TAction> : ISearchForActions<TState, TAction>, ISearchForStates<TState, TAction>
    {
        public HillClimbingSearch(Func<INode<TState, TAction>, double> evalFn)
        {
        }

        public List<TAction>? FindActions(IProblem<TState, TAction> problem)
        {
            throw new NotImplementedException();
        }

        public TState? FindState(IProblem<TState, TAction> problem)
        {
            throw new NotImplementedException();
        }
    }
}

