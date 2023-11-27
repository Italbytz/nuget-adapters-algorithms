/** 
 * The original version of this file is part of <see href="https://github.com/aimacode/aima-java"/> which is released under 
 * MIT License
 * Copyright (c) 2015 aima-java contributors
 */

using System;
using Italbytz.Adapters.Algorithms.Search.Framework;
using Italbytz.Ports.Algorithms;

namespace Italbytz.Adapters.Algorithms.Tests.Environment.NQueens
{
    public class NQueensFunctions
    {
        public NQueensFunctions()
        {
        }

        public static double GetNumberOfAttackingPairs(INode<NQueensBoard, QueenAction> node)
        {
            return node.State.GetNumberOfAttackingPairs();
        }

        internal static List<QueenAction> GetCSFActions(NQueensBoard board)
        {
            throw new NotImplementedException();
        }

        internal static NQueensBoard GetResult(NQueensBoard board, QueenAction action)
        {
            throw new NotImplementedException();
        }

        internal static bool GetTestGoal(NQueensBoard board)
        {
            throw new NotImplementedException();
        }
    }
}

