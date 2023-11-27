/** 
 * The original version of this file is part of <see href="https://github.com/aimacode/aima-java"/> which is released under 
 * MIT License
 * Copyright (c) 2015 aima-java contributors
 */

using System;
using System.Drawing;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Italbytz.Adapters.Algorithms.Tests.Environment.NQueens
{
    public class NQueensBoard
    {
        private bool[,] squares;
        public int Size { get; }

        public NQueensBoard(int size)
        {
            Size = size;
            squares = new bool[Size, Size];
            Clear();
        }

        public void Clear()
        {
            for (int col = 0; col < Size; col++)
            {
                for (int row = 0; row < Size; row++)
                {
                    squares[col, row] = false;
                }
            }
        }

        public int GetNumberOfAttackingPairs()
        {
            return 42;
        }
    }
}

