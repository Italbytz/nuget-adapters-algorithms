// The original version of this file is part of <see href="https://github.com/aimacode/aima-java"/> which is released under
// MIT License
// Copyright (c) 2015 aima-java contributors

using System;
using System.Collections.Generic;
using Italbytz.Ports.Algorithms.AI;
using Italbytz.Ports.Algorithms.AI.Search;

namespace Italbytz.Adapters.Algorithms.Search.Framework
{
    public class SearchUtils
    {
        public static IEnumerable<TAction>? ToActions<TState, TAction>(INode<TState, TAction> node)
        {
            return node != null ? GetSequenceOfActions(node) : null;
        }

        private static IEnumerable<TAction>? GetSequenceOfActions<TState, TAction>(INode<TState, TAction> node)
        {
            var actions = new LinkedList<TAction>();
            while (!node.IsRootNode())
            {
                actions.AddFirst(node.Action);
                node = node.Parent;
            }
            return actions;
        }
    }
}

