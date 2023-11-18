using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xadrez_console.tabuleiro;

namespace xadrez_console.Parts
{
    internal class Knight : Part
    {
        public Knight(Board board, Color color) : base(board, color) { }

        public override string ToString()
        {
            return "\u265E";
        }

        private bool CanMove(Position position)
        {
            Part p = Board.Part(position);
            return p == null || p.Color != Color;
        }

        public override bool[,] PossibleMovements()
        {
            bool[,] mat = new bool[Board.Rows, Board.Columns];

            int[] rowMoves = { -2, -1, 1, 2, 2, 1, -1, -2 };
            int[] colMoves = { 1, 2, 2, 1, -1, -2, -2, -1 };

            for (int i = 0; i < 8; i++)
            {
                int newRow = Position.Row + rowMoves[i];
                int newCol = Position.Column + colMoves[i];

                Position pos = new Position(newRow, newCol);

                if (Board.ValidPosition(pos) && CanMove(pos))
                {
                    mat[pos.Row, pos.Column] = true;
                }
            }

            return mat;
        }
    }
}
