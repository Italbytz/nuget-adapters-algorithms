/** 
 * The original version of this file is part of <see href="https://github.com/aimacode/aima-java"/> which is released under 
 * MIT License
 * Copyright (c) 2015 aima-java contributors
 */

using System;
using Italbytz.Ports.Algorithms.AI;
using Italbytz.Ports.Algorithms.AI.Agent;
using static System.Collections.Specialized.BitVector32;

namespace Italbytz.Adapters.Algorithms.Agent
{
    public class SimpleAgent<TPercept, TAction> : IAgent<TPercept, TAction>
    {
        public bool Alive { get; } = true;

        public SimpleAgent()
        {
        }

        public virtual TAction? Act(TPercept? percept)
        {
            return default(TAction);
        }
    }
}

