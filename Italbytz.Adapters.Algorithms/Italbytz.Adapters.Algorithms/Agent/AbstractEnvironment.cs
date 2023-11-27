using System;
using Italbytz.Adapters.Algorithms.Search.Agent;
using Italbytz.Ports.Algorithms;

namespace Italbytz.Adapters.Algorithms.Agent
{
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
                Execute(Agent, anAction);
            }
            System.Console.WriteLine("Step");
        }

        protected abstract void Execute(IAgent<TPercept, TAction> agent, TAction? anAction);
        protected abstract TPercept GetPerceptSeenBy(IAgent<TPercept, TAction> agent);
    }
}

