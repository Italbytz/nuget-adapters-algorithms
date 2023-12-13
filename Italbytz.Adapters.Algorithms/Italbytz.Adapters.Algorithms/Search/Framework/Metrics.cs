// The original version of this file is part of <see href="https://github.com/aimacode/aima-java"/> which is released under
// MIT License
// Copyright (c) 2015 aima-java contributors

using System.Collections.Generic;
using Italbytz.Ports.Algorithms.AI.Search;

namespace Italbytz.Adapters.Algorithms.Search.Framework
{
    public class Metrics : IMetrics
    {
        private readonly Dictionary<string, string> _dict = new();

        public string Get(string name) => _dict[name];

        public void Set(string name, int i)
        {
            _dict[name] = i.ToString();
        }

        public void IncrementInt(string name)
        {
            Set(name, GetInt(name) + 1);
        }

        public int GetInt(string name)
        {
            var value = _dict[name];
            return int.Parse(value);
        }
    }
}