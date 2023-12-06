using System;
using System.Collections.Generic;
using Italbytz.Ports.Algorithms.AI;
using Italbytz.Ports.Algorithms.AI.Search;

namespace Italbytz.Adapters.Algorithms.Search.Framework
{
    public class Metrics : IMetrics
    {
        private Dictionary<string, string> dict = new();

        public string Get(string name) => dict[name];
        public void Set(string name, int i)
        {
            dict[name] = i.ToString();
        }

        public void IncrementInt(string name)
        {
            throw new NotImplementedException();
        }

        public int GetInt(string name)
        {
            var value = dict[name];
            return int.Parse(value);
        }
    }
}

