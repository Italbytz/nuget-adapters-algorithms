using System;
using System.Collections.Generic;

namespace Italbytz.Adapters.Algorithms.Agent
{
    public abstract class ObjectWithDynamicAttributes
    {
        public Dictionary<Object, Object> Attributes { get; set; } = new Dictionary<Object, Object>();

        public ObjectWithDynamicAttributes()
        {
        }
    }
}

