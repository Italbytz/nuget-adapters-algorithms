﻿using System;
using System.Collections.Generic;
using Italbytz.Ports.Algorithms;

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

