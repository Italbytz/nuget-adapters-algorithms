using Italbytz.Adapters.Algorithms.Search.Local;
using Italbytz.Adapters.Algorithms.Tests.Environment.NQueens;

namespace Italbytz.Adapters.Algorithms.Tests;

public class NQueensHillClimbingTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        var alg = new HillClimbingSearch<NQueensBoard, QueenAction>(node => -NQueensFunctions.GetNumberOfAttackingPairs(node));
    }
}
