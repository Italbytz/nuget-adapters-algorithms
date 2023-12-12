// The original version of this file is part of <see href="https://github.com/aimacode/aima-java"/> which is released under
// MIT License
// Copyright (c) 2015 aima-java contributors

using System;
using Italbytz.Ports.Algorithms.AI;
using Italbytz.Ports.Algorithms.AI.Search;

namespace Italbytz.Adapters.Algorithms.Search.Framework
{
    public class Node<TState, TAction> : INode<TState, TAction>
    {

        public TState State { get; }

        public double PathCost { get; }

        public int Depth { get; }

        public TAction Action { get; }

        public INode<TState, TAction> Parent { get; }

        public Node(TState state) : this(state, null, default, 0.0)
        {

        }


        public Node(TState state, INode<TState, TAction>? parent, TAction? action, double pathCost)
        {
            State = state;
            this.Parent = parent;
            this.Action = action;
            PathCost = pathCost;
            Depth = parent != null ? parent.Depth + 1 : 0;
        }

        public bool IsRootNode()
        {
            return Parent == null;
        }

        public override string ToString() => $"[parent={Parent}, action={Action}, state={State}, pathCost={PathCost}]";
    }
}

