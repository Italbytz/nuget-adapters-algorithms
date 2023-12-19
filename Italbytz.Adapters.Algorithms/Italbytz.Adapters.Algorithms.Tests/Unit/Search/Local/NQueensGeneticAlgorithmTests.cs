using Italbytz.Adapters.Algorithms.Search.Local;
using Italbytz.Adapters.Algorithms.Tests.Environment.NQueens;
using Italbytz.Adapters.Algorithms.Util.Datastructure;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace Italbytz.Adapters.Algorithms.Tests.Unit.Search.Local;

public class NQueensGeneticAlgorithmTests
{
    private ILoggerFactory _loggerFactory = NullLoggerFactory.Instance;

    [SetUp]
    public void Setup()
    {
        _loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
    }

    [Test]
    public void TestNQueens()
    {
        var alphabet = new List<int>
        {
            0,
            1,
            2,
            3,
            4,
            5,
            6,
            7
        };
        var algo = new GeneticAlgorithm<int>(8, alphabet, 0.3);
        var initPopulation = new List<Individual<int>>
        {
            new(new List<int>
            {
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0
            }),
            new(new List<int>
            {
                5,
                7,
                0,
                1,
                1,
                7,
                7,
                2
            }),
            new(new List<int>
            {
                4,
                5,
                6,
                3,
                4,
                5,
                6,
                5
            }),
            new(new List<int>
            {
                3,
                7,
                0,
                4,
                6,
                1,
                5,
                2
            })
        };
        Func<Individual<int>, double> fitnessFn = individual =>
        {
            var board = new NQueensBoard(8);
            var x = 0;
            foreach (var y in individual.Representation)
            {
                board.AddQueenAt(new XYLocation(x, y));
                x++;
            }

            return 1.0 / (1.0 + board.GetNumberOfAttackingPairs());
        };
        var result =
            algo.ExecuteGeneticAlgorithm(initPopulation, fitnessFn, 10000);
        var finalFitness = fitnessFn(result);

        Assert.That(finalFitness, Is.EqualTo(1.0));
    }
}