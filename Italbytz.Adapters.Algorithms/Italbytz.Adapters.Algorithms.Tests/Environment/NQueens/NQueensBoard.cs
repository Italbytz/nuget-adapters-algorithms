/** 
 * The original version of this file is part of <see href="https://github.com/aimacode/aima-java"/> which is released under 
 * MIT License
 * Copyright (c) 2015 aima-java contributors
 */

using System;
using System.Drawing;
using Italbytz.Adapters.Algorithms.Util.Datastructure;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Italbytz.Adapters.Algorithms.Tests.Environment.NQueens
{
    public class NQueensBoard
    {
        private readonly bool[,] squares;
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

        public bool QueenExistsAt(XYLocation l)
        {
            return (QueenExistsAt(l.X, l.Y));
        }

        private bool QueenExistsAt(int x, int y)
        {
            return squares[x, y];
        }

        public int GetNumberOfAttackingPairs()
        {
            return 42;
        }

        internal List<XYLocation> GetQueenPositions()
        {
            var result = new List<XYLocation>();
            for (int col = 0; col < Size; col++)
            {
                for (int row = 0; row < Size; row++)
                {
                    if (QueenExistsAt(col, row))
                        result.Add(new XYLocation(col, row));
                }
            }
            return result;
        }

        internal void SetQueensAt(List<XYLocation> xylocations)
        {
            Clear();
            foreach (var xylocation in xylocations)
            {
                AddQueenAt(xylocation);
            }
        }

        private void AddQueenAt(XYLocation xylocation)
        {
            squares[xylocation.X, xylocation.Y] = true;
        }

        internal void MoveQueenTo(XYLocation location)
        {
            for (int row = 0; row < Size; row++)
            {
                squares[location.X, row] = false;
            }
            squares[location.X, location.Y] = true;
        }
    }
}


