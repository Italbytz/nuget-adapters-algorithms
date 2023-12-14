// The original version of this file is part of <see href="https://github.com/aimacode/aima-java"/> which is released under
// MIT License
// Copyright (c) 2015 aima-java contributors

using System;
using System.Collections.Generic;
using Italbytz.Adapters.Algorithms.Search.Framework;
using Italbytz.Adapters.Algorithms.Util;
using Italbytz.Ports.Algorithms.AI.Problem;
using Italbytz.Ports.Algorithms.AI.Search;
using Microsoft.Extensions.Logging;

namespace Italbytz.Adapters.Algorithms.Search.Local
{
    public class HillClimbingSearch<TState, TAction> :
        ISearchForActions<TState, TAction>, ISearchForStates<TState, TAction>
    {
        private readonly Func<INode<TState, TAction>, double> _evalFn;
        private readonly INodeFactory<TState, TAction> _nodeFactory;
        private TState? _lastState;

        public HillClimbingSearch(Func<INode<TState, TAction>, double> evalFn) :
            this(evalFn, new NodeFactory<TState, TAction>())
        {
        }

        public HillClimbingSearch(Func<INode<TState, TAction>, double> evalFn,
            INodeFactory<TState, TAction> nodeFactory)
        {
            _evalFn = evalFn;
            _nodeFactory = nodeFactory;
        }

        public IMetrics Metrics { get; } = new Metrics();

        public IEnumerable<TAction>? FindActions(
            IProblem<TState, TAction> problem)
        {
            _nodeFactory.UseParentLinks = true;
            return SearchUtils.ToActions(FindNode(problem));
        }

        public TState? FindState(IProblem<TState, TAction> problem) =>
            throw new NotImplementedException();

        public INode<TState, TAction>? FindNode(IProblem<TState, TAction> p)
        {
            //ClearMetrics();
            var current = _nodeFactory.CreateNode(p.InitialState);
            INode<TState, TAction> neighbor;
            //while (!Tasks.currIsCancelled())
            //{
            //    metrics.set(METRIC_NODE_VALUE, getValue(current));
            while (true)
            {
                var children = _nodeFactory.GetSuccessors(current, p);
                neighbor = GetHighestValuedNodeFrom(children);

                if (neighbor == null || _evalFn(neighbor) <= _evalFn(current))
                {
                    _lastState = current.State;
                    return p.TestSolution(current) ? current : null;
                }

                current = neighbor;
                this.Log(LogLevel.Information, current.State.ToString());
            }

            _lastState = current.State;
            return null;
        }

        private INode<TState, TAction> GetHighestValuedNodeFrom(
            List<INode<TState, TAction>> children)
        {
            var highestValue = double.NegativeInfinity;
            INode<TState, TAction>? nodeWithHighestValue = null;
            foreach (var child in children)
            {
                var value = _evalFn(child);
                if (value > highestValue)
                {
                    highestValue = value;
                    nodeWithHighestValue = child;
                }
            }

            return nodeWithHighestValue!;
        }
    }
}