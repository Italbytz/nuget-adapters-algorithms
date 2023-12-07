﻿// The original version of this file is part of <see href="https://github.com/aimacode/aima-java"/> which is released under
// MIT License
// Copyright (c) 2015 aima-java contributors

using Italbytz.Ports.Algorithms.AI.Agent;

namespace Italbytz.Adapters.Algorithms.Agent
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TPercept">Type which is used to represent percepts</typeparam>
    /// <typeparam name="TAction">Type which is used to represent actions</typeparam>
    public abstract class AbstractEnvironment<TPercept, TAction> : IEnvironment<TPercept, TAction>
    {
        public IAgent<TPercept, TAction>? Agent { get; set; }

        public AbstractEnvironment()
        {
        }

        public void Step()
        {
            if (Agent.Alive)
            {
                var percept = GetPerceptSeenBy(Agent);
                var anAction = Agent.Act(percept);
                if (anAction != null) Execute(Agent, anAction);
            }
        }

        protected abstract void Execute(IAgent<TPercept, TAction> agent, TAction? anAction);
        protected abstract TPercept? GetPerceptSeenBy(IAgent<TPercept, TAction> agent);
    }
}

