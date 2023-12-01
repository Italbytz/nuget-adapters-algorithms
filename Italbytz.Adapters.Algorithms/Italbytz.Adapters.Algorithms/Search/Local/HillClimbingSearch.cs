/** 
 * The original version of this file is part of <see href="https://github.com/aimacode/aima-java"/> which is released under 
 * MIT License
 * Copyright (c) 2015 aima-java contributors
 */

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Italbytz.Adapters.Algorithms.Search.Framework;
using Italbytz.Ports.Algorithms.AI;
using Italbytz.Ports.Algorithms.AI.Problem;
using Italbytz.Ports.Algorithms.AI.Search;

namespace Italbytz.Adapters.Algorithms.Search.Local
{
    public class HillClimbingSearch<TState, TAction> : ISearchForActions<TState, TAction>, ISearchForStates<TState, TAction>
    {
        private Func<INode<TState, TAction>, double> evalFn;
        private INodeFactory<TState, TAction> nodeFactory;
        private TState? lastState = default;

        public HillClimbingSearch(Func<INode<TState, TAction>, double> evalFn) : this(evalFn, new NodeFactory<TState, TAction>())
        {
        }

        public HillClimbingSearch(Func<INode<TState, TAction>, double> evalFn, INodeFactory<TState, TAction> nodeFactory)
        {
            this.evalFn = evalFn;
            this.nodeFactory = nodeFactory;
        }

        public IMetrics Metrics { get; } = new Metrics();

        public IEnumerable<TAction>? FindActions(IProblem<TState, TAction> problem)
        {
            nodeFactory.UseParentLinks = true;
            return SearchUtils.ToActions<TState, TAction>(FindNode(problem));
        }

        public TState? FindState(IProblem<TState, TAction> problem)
        {
            throw new NotImplementedException();
        }

        public INode<TState, TAction>? FindNode(IProblem<TState, TAction> p)
        {
            //ClearMetrics();
            INode<TState, TAction> current = nodeFactory.CreateNode(p.InitialState);
            INode<TState, TAction> neighbor;
            //while (!Tasks.currIsCancelled())
            //{
            //    metrics.set(METRIC_NODE_VALUE, getValue(current));
            while (true)
            {

                var children = nodeFactory.GetSuccessors(current, p);
                neighbor = GetHighestValuedNodeFrom(children);

                if (neighbor == null || evalFn(neighbor) <= evalFn(current))
                {
                    lastState = current.State;
                    return p.TestSolution(current) ? current : null;
                }
                current = neighbor;
                Console.WriteLine(current.State);
            }
            lastState = current.State;
            return null;
        }

        private INode<TState, TAction> GetHighestValuedNodeFrom(List<INode<TState, TAction>> children)
        {
            double highestValue = Double.NegativeInfinity;
            INode<TState, TAction>? nodeWithHighestValue = null;
            foreach (var child in children)
            {
                double value = evalFn(child);
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

