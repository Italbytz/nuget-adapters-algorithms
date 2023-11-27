﻿/** 
 * The original version of this file is part of <see href="https://github.com/aimacode/aima-java"/> which is released under 
 * MIT License
 * Copyright (c) 2015 aima-java contributors
 */

using System;
using Italbytz.Adapters.Algorithms.Agent;
using Italbytz.Adapters.Algorithms.Util.Datastructure;

namespace Italbytz.Adapters.Algorithms.Tests.Environment.NQueens
{
    public class QueenAction : DynamicAction
    {
        internal const string MOVE_QUEEN = "moveQueenTo";
        internal const string PLACE_QUEEN = "placeQueenAt";
        internal const string REMOVE_QUEEN = "removeQueenAt";

        internal const string ATTRIBUTE_QUEEN_LOC = "location";
        public XYLocation Location => (XYLocation)Attributes[ATTRIBUTE_QUEEN_LOC];
        public int X => Location.X;
        public int Y => Location.Y;

        public QueenAction(string type, XYLocation loc) : base(type)
        {
            Attributes[ATTRIBUTE_QUEEN_LOC] = loc;
        }
    }
}

