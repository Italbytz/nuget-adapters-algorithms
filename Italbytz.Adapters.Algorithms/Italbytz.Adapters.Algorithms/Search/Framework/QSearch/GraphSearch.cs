namespace Italbytz.Adapters.Algorithms.Search.Framework.QSearch
{
    public class GraphSearch<TState, TAction> : TreeSearch<TState, TAction>
    {
        public GraphSearch() : this(new NodeFactory<TState, TAction>())
        {
            
        }
        public GraphSearch(NodeFactory<TState, TAction> nodeFactory) : base (nodeFactory) 
        {
            
        }
    }
}