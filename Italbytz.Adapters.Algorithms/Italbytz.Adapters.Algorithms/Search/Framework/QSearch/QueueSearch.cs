// The original version of this file is part of <see href="https://github.com/aimacode/aima-java"/> which is released under
// MIT License
// Copyright (c) 2015 aima-java contributors

using System.Collections.Generic;
using Italbytz.Ports.Algorithms.AI.Problem;
using Italbytz.Ports.Algorithms.AI.Search;

namespace Italbytz.Adapters.Algorithms.Search.Framework.QSearch
{
    public abstract class QueueSearch<TState, TAction>
    {
        private const string MetricNodesExpanded = "nodesExpanded";
        private const string MetricQueueSize = "queueSize";
        private const string MetricMaxQueueSize = "maxQueueSize";
        public const string MetricPathCost = "pathCost";

        protected QueueSearch(NodeFactory<TState, TAction> nodeFactory)
        {
            NodeFactory = nodeFactory;
            NodeFactory.AddNodeListener(_ =>
                Metrics.IncrementInt(MetricNodesExpanded));
        }

        public NodeFactory<TState, TAction> NodeFactory { get; }
        protected bool EarlyGoalTest { get; } = false;
        public Metrics Metrics { get; } = new();

        public abstract INode<TState, TAction>? FindNode(
            IProblem<TState, TAction> problem,
            PriorityQueue<INode<TState, TAction>, double> frontier);

        protected void ClearMetrics()
        {
            Metrics.Set(MetricNodesExpanded, 0);
            Metrics.Set(MetricQueueSize, 0);
            Metrics.Set(MetricMaxQueueSize, 0);
            Metrics.Set(MetricPathCost, 0);
        }

        protected void UpdateMetrics(int queueSize)
        {
            Metrics.Set(MetricQueueSize, queueSize);
            var maxQSize = Metrics.GetInt(MetricMaxQueueSize);
            if (queueSize > maxQSize)
                Metrics.Set(MetricMaxQueueSize, queueSize);
        }
    }
}