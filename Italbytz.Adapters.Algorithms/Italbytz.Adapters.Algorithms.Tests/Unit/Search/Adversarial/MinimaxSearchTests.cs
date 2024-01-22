// The original version of this file is part of <see href="https://github.com/aimacode/aima-java"/> which is released under
// MIT License
// Copyright (c) 2015 aima-java contributors

using Italbytz.Adapters.Algorithms.Search.Adversarial;
using Italbytz.Adapters.Algorithms.Tests.Environment.Map;
using Italbytz.Adapters.Algorithms.Tests.Environment.TwoPly;
using Italbytz.Ports.Algorithms.AI.Search.Adversarial;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace Italbytz.Adapters.Algorithms.Tests.Unit.Search.Adversarial;

public class MinimaxSearchTests
{
    private static ILoggerFactory _loggerFactory = NullLoggerFactory.Instance;
    private IGame<TwoPlyGameState, MoveToAction, string> _game;
    private MinimaxSearch<TwoPlyGameState, MoveToAction, string> _minimaxSearch;

    [SetUp]
    public void Setup()
    {
        _loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
        _game = new TwoPlyGame();
        _minimaxSearch =
            new MinimaxSearch<TwoPlyGameState, MoveToAction, string>(_game);
    }

    [Test]
    public void TestUtilities()
    {
        var state = new TwoPlyGameState("E");
        Assert.That(_game.Utility(state, _game.Player(state)), Is.EqualTo(3));
        state = new TwoPlyGameState("I");
        Assert.That(_game.Utility(state, _game.Player(state)), Is.EqualTo(4));
        state = new TwoPlyGameState("K");
        Assert.That(_game.Utility(state, _game.Player(state)), Is.EqualTo(14));
    }

    [Test]
    public void TestMinimaxDecision()
    {
        Assert.That(_game.InitialState.ToString(), Is.EqualTo("A"));
        Assert.That(_game.Player(_game.InitialState), Is.EqualTo("MAX"));
        Assert.That(_minimaxSearch.MakeDecision(_game.InitialState).ToString(),
            Is.EqualTo("MoveToAction[name=moveTo, location=B]"));
    }
}