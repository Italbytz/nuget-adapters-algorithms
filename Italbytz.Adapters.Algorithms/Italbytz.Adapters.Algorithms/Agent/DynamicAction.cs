using System;
using Italbytz.Ports.Algorithms;

namespace Italbytz.Adapters.Algorithms.Agent
{
    public class DynamicAction : ObjectWithDynamicAttributes, IAction
    {
        internal static string ATTRIBUTE_NAME = "name";

        public DynamicAction(String name)
        {
            Attributes[ATTRIBUTE_NAME] = name;
        }
    }
}

