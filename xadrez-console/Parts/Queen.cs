using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xadrez_console.tabuleiro;

namespace xadrez_console.Parts
{
    internal class Queen : Part
    {
        public Queen(Board board, Color color) : base(board, color) { }

        public override string ToString()
        {
            return "\u265B";
        }

        private bool CanMove(Position position)
        {
            Part p = Board.Part(position);
            return p == null || p.Color != Color;
        }

        public override bool[,] PossibleMovements()
        {
            bool[,] mat = new bool[Board.Rows, Board.Columns];
            Position pos = new Position(0, 0);

            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (i != 0 || j != 0)
                    {
                        int row = Position.Row + i;
                        int col = Position.Column + j;

                        while (Board.ValidPosition(new Position(row, col)) && CanMove(new Position(row, col)))
                        {
                            mat[row, col] = true;

                            if (Board.Part(new Position(row, col)) != null && Board.Part(new Position(row, col)).Color != Color)
                            {
                                break;
                            }

                            row += i;
                            col += j;
                        }
                    }
                }
            }

            return mat;
        }
    }
}
