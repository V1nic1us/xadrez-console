using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xadrez_console.tabuleiro;

namespace xadrez_console.Parts
{
    internal class Rook: Part
    {
        public Rook(Board board, Color color) : base(board, color) { }

        public override string ToString()
        {
            return "T";
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

            pos.SetValues(Position.Row - 1, Position.Column);
            while (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
                if (Board.Part(pos) != null && Board.Part(pos).Color != Color)
                {
                    break;
                }
                pos.Row = pos.Row - 1;
            }

            pos.SetValues(Position.Row + 1, Position.Column);
            while (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
                if (Board.Part(pos) != null && Board.Part(pos).Color != Color)
                {
                    break;
                }
                pos.Row = pos.Row + 1;
            }

            pos.SetValues(Position.Row, Position.Column + 1);
            while (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
                if (Board.Part(pos) != null && Board.Part(pos).Color != Color)
                {
                    break;
                }
                pos.Column = pos.Column + 1;
            }

            pos.SetValues(Position.Row, Position.Column - 1);
            while (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
                if (Board.Part(pos) != null && Board.Part(pos).Color != Color)
                {
                    break;
                }
                pos.Column = pos.Column - 1;
            }
            return mat;
        }
    }
}
