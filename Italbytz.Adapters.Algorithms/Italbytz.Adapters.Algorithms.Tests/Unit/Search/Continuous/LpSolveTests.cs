using Italbytz.Adapters.Algorithms.Search.Continuous;
using Italbytz.Ports.Algorithms.AI.Search.Continuous;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace Italbytz.Adapters.Algorithms.Tests.Unit.Search.Continuous;

public class LpSolveTests
{
    private static ILoggerFactory _loggerFactory = NullLoggerFactory.Instance;
    private LPSolver? _lpsolve;

    [SetUp]
    public void Setup()
    {
        _loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
        _lpsolve = new LPSolver(_loggerFactory);
    }

    [Test]
    public void TestSimpleLPWithIntegerSolution()
    {
        var model = new LPModel
        {
            Maximization = true,
            ObjectiveFunction = new[] { 6.0, 5.0 },
            Bounds =
                new (double, double)[]
                {
                    (0.0, double.PositiveInfinity),
                    (0.0, double.PositiveInfinity)
                },
            Constraints = new List<ILPConstraint>
            {
                new LPConstraint
                {
                    Coefficients = new[] { 1.0, 1.0 },
                    ConstraintType = ConstraintType.LE,
                    RHS = 5.0
                },
                new LPConstraint
                {
                    Coefficients = new[] { 3.0, 2.0 },
                    ConstraintType = ConstraintType.LE,
                    RHS = 12.0
                }
            },
            IntegerVariables = new[] { false, false }
        };
        var solution = _lpsolve!.Solve(model);
        Assert.Multiple(() =>
        {
            Assert.That(solution.Objective, Is.EqualTo(27.0));
            Assert.That(solution.Solution[0], Is.EqualTo(2.0));
            Assert.That(solution.Solution[1], Is.EqualTo(3.0));
        });
    }


    [Test]
    public void TestSimpleLPWithIntegerSolutionNative()
    {
        const string lp = """
                          // Objective function
                          max: + 6*x0 + 5*x1;
                          // constraints
                           + 1*x0 + 1*x1 <= 5;
                           + 3*x0 + 2*x1 <= 12;
                          """;
        var solution = _lpsolve!.Solve(lp, LPFileFormat.lp_solve);
        Assert.Multiple(() =>
        {
            Assert.That(solution.Objective, Is.EqualTo(27.0));
            Assert.That(solution.Solution[0], Is.EqualTo(2.0));
            Assert.That(solution.Solution[1], Is.EqualTo(3.0));
        });
    }

    [Test]
    public void TestSimpleLPWithNoIntegerSolution()
    {
        var model = new LPModel
        {
            Maximization = true,
            ObjectiveFunction = new[] { 5.0, 6.0 },
            Bounds =
                new (double, double)[]
                {
                    (0.0, double.PositiveInfinity),
                    (0.0, double.PositiveInfinity)
                },
            Constraints = new List<ILPConstraint>
            {
                new LPConstraint
                {
                    Coefficients = new[] { 1.0, 1.0 },
                    ConstraintType = ConstraintType.LE,
                    RHS = 5.0
                },
                new LPConstraint
                {
                    Coefficients = new[] { 4.0, 7.0 },
                    ConstraintType = ConstraintType.LE,
                    RHS = 28.0
                }
            },
            IntegerVariables = new[] { false, false }
        };

        var solution = _lpsolve!.Solve(model);
        Assert.Multiple(() =>
        {
            Assert.That(solution.Objective, Is.EqualTo(27.66).Within(0.01));
            Assert.That(solution.Solution[0], Is.EqualTo(2.33).Within(0.01));
            Assert.That(solution.Solution[1], Is.EqualTo(2.66).Within(0.01));
        });
    }

    [Test]
    public void TestSimpleLPWithNoIntegerSolutionNative()
    {
        const string lp = """
                          // Objective function
                          max: + 5*x0 + 6*x1;
                          // constraints
                           + 1*x0 + 1*x1 <= 5;
                           + 4*x0 + 7*x1 <= 28;
                          """;
        var solution = _lpsolve!.Solve(lp, LPFileFormat.lp_solve);
        Assert.Multiple(() =>
        {
            Assert.That(solution.Objective, Is.EqualTo(27.66).Within(0.01));
            Assert.That(solution.Solution[0], Is.EqualTo(2.33).Within(0.01));
            Assert.That(solution.Solution[1], Is.EqualTo(2.66).Within(0.01));
        });
    }

    [Test]
    public void TestSimpleILP()
    {
        var model = new LPModel
        {
            Maximization = true,
            ObjectiveFunction = new[] { 5.0, 6.0 },
            Bounds =
                new (double, double)[]
                {
                    (0.0, double.PositiveInfinity),
                    (0.0, double.PositiveInfinity)
                },
            Constraints = new List<ILPConstraint>
            {
                new LPConstraint
                {
                    Coefficients = new[] { 1.0, 1.0 },
                    ConstraintType = ConstraintType.LE,
                    RHS = 5.0
                },
                new LPConstraint
                {
                    Coefficients = new[] { 4.0, 7.0 },
                    ConstraintType = ConstraintType.LE,
                    RHS = 28.0
                }
            },
            IntegerVariables = new[] { true, true }
        };
        var solution = _lpsolve!.Solve(model);
        Assert.Multiple(() =>
        {
            Assert.That(solution.Objective, Is.EqualTo(27.0));
            Assert.That(solution.Solution[0], Is.EqualTo(3.0));
            Assert.That(solution.Solution[1], Is.EqualTo(2.0));
        });
    }

    [Test]
    public void TestSimpleILPNative()
    {
        const string lp = """
                          // Objective function
                          max: + 5*x0 + 6*x1;
                          // constraints
                           + 1*x0 + 1*x1 <= 5;
                           + 4*x0 + 7*x1 <= 28;
                          // declaration
                          int x0, x1;
                          """;
        var solution = _lpsolve!.Solve(lp, LPFileFormat.lp_solve);
        Assert.Multiple(() =>
        {
            Assert.That(solution.Objective, Is.EqualTo(27.0));
            Assert.That(solution.Solution[0], Is.EqualTo(3.0));
            Assert.That(solution.Solution[1], Is.EqualTo(2.0));
        });
    }
}