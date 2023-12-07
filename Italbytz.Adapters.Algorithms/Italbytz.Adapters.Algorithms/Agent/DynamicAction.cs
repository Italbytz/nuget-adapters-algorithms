// The original version of this file is part of <see href="https://github.com/aimacode/aima-java"/> which is released under
// MIT License
// Copyright (c) 2015 aima-java contributors

using System;
using Italbytz.Ports.Algorithms.AI;
using Italbytz.Ports.Algorithms.AI.Agent;

namespace Italbytz.Adapters.Algorithms.Agent
{
    public class DynamicAction : ObjectWithDynamicAttributes, IAction
    {
        internal static string ATTRIBUTE_NAME = "name";
        public string Name => (string)Attributes[ATTRIBUTE_NAME];


        public DynamicAction(String name)
        {
            Attributes[ATTRIBUTE_NAME] = name;
        }
    }
}

