// The original version of this file is part of <see href="https://github.com/aimacode/aima-java"/> which is released under
// MIT License
// Copyright (c) 2015 aima-java contributors

using System;
using System.Collections.Generic;
using Italbytz.Ports.Algorithms.AI.Problem;
using Italbytz.Ports.Algorithms.AI.Search;

namespace Italbytz.Adapters.Algorithms.Search.Framework.QSearch
{
    public abstract class QueueSearch<TState, TAction>
    {
        public static string METRIC_NODES_EXPANDED = "nodesExpanded";
        public static string METRIC_QUEUE_SIZE = "queueSize";
        public static string METRIC_MAX_QUEUE_SIZE = "maxQueueSize";
        public static string METRIC_PATH_COST = "pathCost";
        public NodeFactory<TState, TAction> NodeFactory { get; }
        protected bool EarlyGoalTest { get; } = false;
        public Metrics Metrics { get; } = new Metrics();

        protected QueueSearch(NodeFactory<TState, TAction> nodeFactory) {
            NodeFactory = nodeFactory;
            NodeFactory.AddNodeListener((node) => Metrics.IncrementInt(METRIC_NODES_EXPANDED));
            NodeFactory.AddNodeListener((node) => Console.WriteLine(node));
        }
        
        public abstract INode<TState, TAction>? FindNode(
            IProblem<TState, TAction> problem,
            PriorityQueue<INode<TState, TAction>,double> frontier);
        
        protected void ClearMetrics()
        {
            Metrics.Set(METRIC_NODES_EXPANDED, 0);
            Metrics.Set(METRIC_QUEUE_SIZE, 0);
            Metrics.Set(METRIC_MAX_QUEUE_SIZE, 0);
            Metrics.Set(METRIC_PATH_COST, 0);
        }
        
        protected void UpdateMetrics(int queueSize)
        {
            Metrics.Set(METRIC_QUEUE_SIZE, queueSize);
            int maxQSize = Metrics.GetInt(METRIC_MAX_QUEUE_SIZE);
            if (queueSize > maxQSize) {
                Metrics.Set(METRIC_MAX_QUEUE_SIZE, queueSize);
            }
        }

    }
}