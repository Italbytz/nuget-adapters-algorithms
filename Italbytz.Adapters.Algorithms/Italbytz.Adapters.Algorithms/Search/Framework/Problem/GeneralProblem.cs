/** 
 * The original version of this file is part of <see href="https://github.com/aimacode/aima-java"/> which is released under 
 * MIT License
 * Copyright (c) 2015 aima-java contributors
 */

using System;
using System.Collections.Generic;
using Italbytz.Ports.Algorithms;

namespace Italbytz.Adapters.Algorithms.Search.Framework.Problem
{
    public class GeneralProblem<TState, TAction> : IProblem<TState, TAction>
    {
        public GeneralProblem()
        {
        }

        public TState InitialState => throw new NotImplementedException();

        public List<TAction> GetActions(TState state)
        {
            throw new NotImplementedException();
        }

        public TState GetResult(TState state, TAction action)
        {
            throw new NotImplementedException();
        }

        public double GetStepCosts(TState state, TAction action, TState stateDelta)
        {
            throw new NotImplementedException();
        }

        public bool TestGoal(TState state)
        {
            throw new NotImplementedException();
        }
    }
}

