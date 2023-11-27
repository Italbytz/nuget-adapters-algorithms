/** 
 * The original version of this file is part of <see href="https://github.com/aimacode/aima-java"/> which is released under 
 * MIT License
 * Copyright (c) 2015 aima-java contributors
 */

using System;
using Italbytz.Ports.Algorithms;

namespace Italbytz.Adapters.Algorithms.Search.Framework
{
    public class Node<TState, TAction> : INode<TState, TAction>
    {

        public TState State { get; }

        public Node()
        {
        }


    }
}

