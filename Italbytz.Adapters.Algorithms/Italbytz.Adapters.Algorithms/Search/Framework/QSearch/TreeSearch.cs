using System.Collections.Generic;
using Italbytz.Ports.Algorithms.AI.Problem;
using Italbytz.Ports.Algorithms.AI.Search;

namespace Italbytz.Adapters.Algorithms.Search.Framework.QSearch
{
    public class TreeSearch<TState, TAction> : QueueSearch<TState, TAction>
    {
        
        protected PriorityQueue<INode<TState, TAction>,double> Frontier;
        
        public TreeSearch() : this(new NodeFactory<TState, TAction>())
        {
            
        }
        public TreeSearch(NodeFactory<TState, TAction> nodeFactory) : base (nodeFactory) 
        {
            
        }

        public override INode<TState, TAction>? FindNode(
            IProblem<TState, TAction> problem,
            PriorityQueue<INode<TState, TAction>,double> frontier)
        {
            Frontier = frontier;
            ClearMetrics();
            var root = NodeFactory.CreateNode(problem.InitialState);
            AddToFrontier(root);
            if (EarlyGoalTest && problem.TestSolution(root))
                return root;
            while (Frontier.Count > 0)
            {
                var node = RemoveFromFrontier();
                // TODO
            }
            return null;
        }

        private INode<TState,TAction> RemoveFromFrontier()
        {
            var result = Frontier.Dequeue();
            UpdateMetrics(Frontier.Count);
            return result;
        }

        private void AddToFrontier(INode<TState,TAction> node)
        {
            Frontier.Enqueue(node,node.PathCost);
            UpdateMetrics(Frontier.Count);
        }
        
    }
}