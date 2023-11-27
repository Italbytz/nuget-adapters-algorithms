using System;
using Italbytz.Adapters.Algorithms.Agent;
using Italbytz.Adapters.Algorithms.Search.Agent;
using Italbytz.Ports.Algorithms;

namespace Italbytz.Adapters.Algorithms.Tests.Environment.NQueens
{
    public class NQueensEnvironment : AbstractEnvironment<IPercept, QueenAction>
    {
        public NQueensBoard Board { get; }

        public NQueensEnvironment(NQueensBoard board)
        {
            this.Board = board;
        }

        protected override void Execute(IAgent<IPercept, QueenAction> agent, QueenAction? anAction)
        {
            throw new NotImplementedException();
        }

        protected override IPercept GetPerceptSeenBy(IAgent<IPercept, QueenAction> agent)
        {
            throw new NotImplementedException();
        }
    }
}

