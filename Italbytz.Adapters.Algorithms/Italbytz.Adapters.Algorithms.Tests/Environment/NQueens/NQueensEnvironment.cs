using System;
using Italbytz.Adapters.Algorithms.Agent;
using Italbytz.Adapters.Algorithms.Search.Agent;
using Italbytz.Adapters.Algorithms.Util.Datastructure;
using Italbytz.Ports.Algorithms.AI;
using Italbytz.Ports.Algorithms.AI.Agent;
using static System.Collections.Specialized.BitVector32;

namespace Italbytz.Adapters.Algorithms.Tests.Environment.NQueens
{
    public class NQueensEnvironment : AbstractEnvironment<IPercept, QueenAction>
    {
        public NQueensBoard Board { get; }

        public NQueensEnvironment(NQueensBoard board)
        {
            this.Board = board;
        }

        protected override void Execute(IAgent<IPercept, QueenAction> agent, QueenAction? action)
        {
            var loc = new XYLocation(action.X, action.Y);
            if (action.Name == QueenAction.PLACE_QUEEN)
                Board.AddQueenAt(loc);
            else if (action.Name == QueenAction.REMOVE_QUEEN)
                Board.RemoveQueenFrom(loc);
            else if (action.Name == QueenAction.MOVE_QUEEN)
                Board.MoveQueenTo(loc);
        }

        protected override IPercept? GetPerceptSeenBy(IAgent<IPercept, QueenAction> agent)
        {
            return null;
        }
    }
}

