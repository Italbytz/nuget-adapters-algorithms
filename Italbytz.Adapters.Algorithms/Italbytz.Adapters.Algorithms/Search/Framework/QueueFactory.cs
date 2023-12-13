// The original version of this file is part of <see href="https://github.com/aimacode/aima-java"/> which is released under
// MIT License
// Copyright (c) 2015 aima-java contributors

using System.Collections.Generic;

namespace Italbytz.Adapters.Algorithms.Search.Framework
{
    public static class QueueFactory
    {
        public static PriorityQueue<TElement, double>
            CreatePriorityQueue<TElement>() =>
            new(11);
    }
}