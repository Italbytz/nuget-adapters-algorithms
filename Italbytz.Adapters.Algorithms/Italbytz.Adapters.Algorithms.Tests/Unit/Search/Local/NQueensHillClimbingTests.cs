using Italbytz.Adapters.Algorithms.Search.Agent;
using Italbytz.Adapters.Algorithms.Search.Framework.Problem;
using Italbytz.Adapters.Algorithms.Search.Local;
using Italbytz.Adapters.Algorithms.Tests.Environment.NQueens;
using Italbytz.Adapters.Algorithms.Util.Datastructure;
using Italbytz.Ports.Algorithms.AI.Agent;

namespace Italbytz.Adapters.Algorithms.Tests.Unit.Search.Local;

public class NQueensHillClimbingTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestNQueens() 
    {
        var board = new NQueensBoard(8);
        for (var i = 0; i < board.Size; i++)
            board.AddQueenAt(new XYLocation(i, 0));
        var problem = new GeneralProblem<NQueensBoard, QueenAction>(board, NQueensFunctions.GetCSFActions, NQueensFunctions.GetResult, NQueensFunctions.TestGoal);
        var search = new HillClimbingSearch<NQueensBoard, QueenAction>(node => -NQueensFunctions.GetNumberOfAttackingPairs(node));
        var agent = new SearchAgent<IPercept, NQueensBoard, QueenAction>(problem, search);
        var env = new NQueensEnvironment(board)
        {
            Agent = agent
        };
        while (!agent.Done)
        {
            env.Step();
        }
        Assert.That(env.Board.GetNumberOfAttackingPairs(), Is.EqualTo(28));
    }
}
