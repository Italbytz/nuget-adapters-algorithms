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
            return GetQueenPositions().Select(l => GetNumberOfAttacksOn(l)).Sum() / 2;
        }

        public int GetNumberOfAttacksOn(XYLocation l)
        {
            int x = l.X;
            int y = l.Y;
            return NumberOfHorizontalAttacksOn(x, y) + NumberOfVerticalAttacksOn(x, y) + NumberOfDiagonalAttacksOn(x, y);
        }

        private int NumberOfDiagonalAttacksOn(int x, int y)
        {
            int result = 0;
            int col;
            int row;
            // forward up diagonal
            for (col = (x + 1), row = (y - 1); (col < Size && (row > -1)); col++, row--)
                if (QueenExistsAt(col, row))
                    result++;

            // forward down diagonal
            for (col = (x + 1), row = (y + 1); ((col < Size) && (row < Size)); col++, row++)
                if (QueenExistsAt(col, row))
                    result++;

            // backward up diagonal
            for (col = (x - 1), row = (y - 1); ((col > -1) && (row > -1)); col--, row--)
                if (QueenExistsAt(col, row))
                    result++;

            // backward down diagonal
            for (col = (x - 1), row = (y + 1); ((col > -1) && (row < Size)); col--, row++)
                if (QueenExistsAt(col, row))
                    result++;

            return result;
        }

        private int NumberOfVerticalAttacksOn(int x, int y)
        {
            int result = 0;
            for (int row = 0; row < Size; row++)
            {
                if ((QueenExistsAt(x, row)))
                    if (row != y)
                        result++;
            }
            return result;
        }

        private int NumberOfHorizontalAttacksOn(int x, int y)
        {
            int result = 0;
            for (int col = 0; col < Size; col++)
            {
                if ((QueenExistsAt(col, y)))
                    if (col != x)
                        result++;
            }
            return result;
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

        internal void AddQueenAt(XYLocation xylocation)
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

        internal int GetNumberOfQueensOnBoard()
        {
            int count = 0;
            for (int col = 0; col < Size; col++)
            {
                for (int row = 0; row < Size; row++)
                {
                    if (squares[col, row])
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        internal void RemoveQueenFrom(XYLocation loc)
        {
            squares[loc.X, loc.Y] = false;
        }
    }
}


