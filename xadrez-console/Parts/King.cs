using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xadrez_console.tabuleiro;

namespace xadrez_console.Parts
{
    internal class King : Part
    {
        private ChessMatch Match;
        public King(Board board, Color color, ChessMatch match) : base(board, color)
        {
            Match = match;
        }

        public override string ToString()
        {
            return "\u265A";
        }

        private bool CanMove(Position position)
        {
            Part p = Board.Part(position);
            return p == null || p.Color != Color;
        }

        private bool CanCastle(Position position)
        {
            Part p = Board.Part(position);
            return p != null && p is Rook && p.Color == Color && p.AmtMovements == 0;
        }

        public override bool[,] PossibleMovements()
        {
            bool[,] mat = new bool[Board.Rows, Board.Columns];

            Position pos = new(0, 0);

            // Above
            pos.SetValues(Position.Row - 1, Position.Column);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }

            // Northeast
            pos.SetValues(Position.Row - 1, Position.Column + 1);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }

            // Right
            pos.SetValues(Position.Row, Position.Column + 1);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }

            // Southeast
            pos.SetValues(Position.Row + 1, Position.Column + 1);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }

            // Below
            pos.SetValues(Position.Row + 1, Position.Column);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }

            // Southwest
            pos.SetValues(Position.Row + 1, Position.Column - 1);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }

            // Left
            pos.SetValues(Position.Row, Position.Column - 1);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }

            // Northwest
            pos.SetValues(Position.Row - 1, Position.Column - 1);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }

            //rook pequeno
            if (AmtMovements == 0 && !Match.Check)
            {
                Position posT1 = new(Position.Row, Position.Column + 3);
                if (CanCastle(posT1))
                {
                    Position p1 = new(Position.Row, Position.Column + 1);
                    Position p2 = new(Position.Row, Position.Column + 2);
                    if (Board.Part(p1) == null && Board.Part(p2) == null)
                    {
                        mat[Position.Row, Position.Column + 2] = true;
                    }
                }
                Position posT2 = new(Position.Row, Position.Column - 4);
                if (CanCastle(posT2))
                {
                    Position p1 = new(Position.Row, Position.Column - 1);
                    Position p2 = new (Position.Row, Position.Column - 2);
                    Position p3 = new (Position.Row, Position.Column - 3);
                    if (Board.Part(p1) == null && Board.Part(p2) == null && Board.Part(p3) == null)
                    {
                        mat[Position.Row, Position.Column - 2] = true;
                    }
                }
            }
            return mat;
        }
    }
}
