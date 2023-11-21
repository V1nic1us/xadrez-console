using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xadrez_console.tabuleiro;

namespace xadrez_console.Parts
{
    internal class Pawn : Part
    {
        private ChessMatch Match;
        public Pawn(Board board, Color color, ChessMatch match) : base(board, color)
        {
            Match = match;
        }

        public override string ToString()
        {
            return "\u265F";
        }

        private bool CanMove(Position position)
        {
            Part p = Board.Part(position);
            return p == null || p.Color != Color;
        }

        private bool existEnemy(Position position)
        {
            Part p = Board.Part(position);
            return p != null && p.Color != Color;
        }

        public override bool[,] PossibleMovements()
        {
            bool[,] mat = new bool[Board.Rows, Board.Columns];
            Position pos = new Position(0, 0);

            if (Color == Color.White)
            {
                pos.SetValues(Position.Row - 1, Position.Column);
                if (Board.ValidPosition(pos) && CanMove(pos))
                {
                    mat[pos.Row, pos.Column] = true;
                }

                pos.SetValues(Position.Row - 2, Position.Column);
                Position p2 = new Position(Position.Row - 1, Position.Column);
                if (Board.ValidPosition(p2) && CanMove(p2) && Board.ValidPosition(pos) && CanMove(pos) && AmtMovements == 0)
                {
                    mat[pos.Row, pos.Column] = true;
                }

                pos.SetValues(Position.Row - 1, Position.Column - 1);
                if (Board.ValidPosition(pos) && existEnemy(pos))
                {
                    mat[pos.Row, pos.Column] = true;
                }

                pos.SetValues(Position.Row - 1, Position.Column + 1);
                if (Board.ValidPosition(pos) && existEnemy(pos))
                {
                    mat[pos.Row, pos.Column] = true;
                }

                if (Position.Row == 3)
                {
                    Position left = new Position(Position.Row, Position.Column - 1);
                    if (Board.ValidPosition(left) && existEnemy(left) && Board.Part(left) == Match.EnPassantVulnerable)
                    {
                        mat[left.Row - 1, left.Column] = true;
                    }
                    Position right = new Position(Position.Row, Position.Column + 1);
                    if (Board.ValidPosition(right) && existEnemy(right) && Board.Part(right) == Match.EnPassantVulnerable)
                    {
                        mat[right.Row - 1, right.Column] = true;
                    }
                }
            }
            else
            {
                pos.SetValues(Position.Row + 1, Position.Column);
                if (Board.ValidPosition(pos) && CanMove(pos))
                {
                    mat[pos.Row, pos.Column] = true;
                }

                pos.SetValues(Position.Row + 2, Position.Column);
                Position p2 = new Position(Position.Row + 1, Position.Column);
                if (Board.ValidPosition(p2) && CanMove(p2) && Board.ValidPosition(pos) && CanMove(pos) && AmtMovements == 0)
                {
                    mat[pos.Row, pos.Column] = true;
                }

                pos.SetValues(Position.Row + 1, Position.Column - 1);
                if (Board.ValidPosition(pos) && existEnemy(pos))
                {
                    mat[pos.Row, pos.Column] = true;
                }

                pos.SetValues(Position.Row + 1, Position.Column + 1);
                if (Board.ValidPosition(pos) && existEnemy(pos))
                {
                    mat[pos.Row, pos.Column] = true;
                }

                if (Position.Row == 4)
                {
                    Position left = new Position(Position.Row, Position.Column - 1);
                    if (Board.ValidPosition(left) && existEnemy(left) && Board.Part(left) == Match.EnPassantVulnerable)
                    {
                        mat[left.Row + 1, left.Column] = true;
                    }
                    Position right = new Position(Position.Row, Position.Column + 1);
                    if (Board.ValidPosition(right) && existEnemy(right) && Board.Part(right) == Match.EnPassantVulnerable)
                    {
                        mat[right.Row + 1, right.Column] = true;
                    }
                }
            }
            return mat;
        }
    }
}
