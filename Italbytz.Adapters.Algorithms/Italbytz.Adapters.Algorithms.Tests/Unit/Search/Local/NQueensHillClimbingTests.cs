using Italbytz.Adapters.Algorithms.Search.Agent;
using Italbytz.Adapters.Algorithms.Search.Framework.Problem;
using Italbytz.Adapters.Algorithms.Search.Local;
using Italbytz.Adapters.Algorithms.Tests.Environment.NQueens;
using Italbytz.Adapters.Algorithms.Util.Datastructure;
using Italbytz.Ports.Algorithms.AI.Agent;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace Italbytz.Adapters.Algorithms.Tests.Unit.Search.Local;

public class NQueensHillClimbingTests
{
    private ILoggerFactory _loggerFactory = NullLoggerFactory.Instance;

    [SetUp]
    public void Setup()
    {
        _loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
    }

    [Test]
    public void TestNQueensBoard1()
    {
        var board = new NQueensBoard(8);
        for (var i = 0; i < board.Size; i++)
            board.AddQueenAt(new XYLocation(i, 0));
        var env = TestNQueens(board);
        Assert.That(env.Board.GetNumberOfAttackingPairs(), Is.EqualTo(28));
    }

    private NQueensEnvironment TestNQueens(NQueensBoard board)
    {
        var problem = new GeneralProblem<NQueensBoard, QueenAction>(board,
            NQueensFunctions.GetCSFActions, NQueensFunctions.GetResult,
            NQueensFunctions.TestGoal);
        var search = new HillClimbingSearch<NQueensBoard, QueenAction>(node =>
            -NQueensFunctions.GetNumberOfAttackingPairs(node));
        var agent = new SearchAgent<IPercept, NQueensBoard, QueenAction>(
            problem, search, _loggerFactory);
        var env = new NQueensEnvironment(board) { Agent = agent };
        while (!agent.Done) env.Step();
        return env;
    }
}