// The original version of this file is part of <see href="https://github.com/aimacode/aima-java"/> which is released under
// MIT License
// Copyright (c) 2015 aima-java contributors

using System.Linq;
using Italbytz.Adapters.Algorithms.Search.Framework;
using Italbytz.Ports.Algorithms.AI.Search;
using Italbytz.Ports.Algorithms.AI.Search.Adversarial;

namespace Italbytz.Adapters.Algorithms.Search.Adversarial;

/// <summary>
///     An algorithm for calculating minimax decisions. It returns the
///     action corresponding to the best possible move, that is, the move that
///     leads
///     to the outcome with the best utility, under the assumption that the
///     opponent
///     plays to minimize utility.
/// </summary>
/// <typeparam name="TState">Type which is used for states in the game.</typeparam>
/// <typeparam name="TAction">Type which is used for actions in the game.</typeparam>
/// <typeparam name="TPlayer">Type which is used for players in the game.</typeparam>
public class
    MinimaxSearch<TState, TAction, TPlayer> : IAdversarialSearch<TState,
        TAction>
{
    public const string MetricNodesExpanded = "nodesExpanded";

    private readonly IGame<TState, TAction, TPlayer> game;

    public MinimaxSearch(IGame<TState, TAction, TPlayer> game) =>
        this.game = game;

    public IMetrics Metrics { get; private set; } = new Metrics();

    public TAction MakeDecision(TState state)
    {
        Metrics = new Metrics();
        Metrics.Set(MetricNodesExpanded, 0);
        var result = default(TAction);
        var resultValue = double.NegativeInfinity;
        var player = game.Player(state);
        foreach (var action in game.Actions(state))
        {
            var value = MinValue(game.Result(state, action), player);
            if (!(value > resultValue)) continue;
            result = action;
            resultValue = value;
        }

        return result;
    }

    private double MinValue(TState state, TPlayer player)
    {
        Metrics.IncrementInt(MetricNodesExpanded);
        if (game.Terminal(state)) return game.Utility(state, player);
        var actionValues = game.Actions(state).Select(action =>
            MaxValue(game.Result(state, action), player)).ToList();
        return actionValues.Any()
            ? actionValues.Min()
            : double.PositiveInfinity;
    }

    private double MaxValue(TState state, TPlayer player)
    {
        Metrics.IncrementInt(MetricNodesExpanded);
        if (game.Terminal(state)) return game.Utility(state, player);
        var actionValues = game.Actions(state).Select(action =>
            MinValue(game.Result(state, action), player)).ToList();
        return actionValues.Any()
            ? actionValues.Max()
            : double.NegativeInfinity;
    }


    public static MinimaxSearch<TState, TAction, TPlayer> CreateFor(
        IGame<TState, TAction, TPlayer> game) =>
        new(game);
}