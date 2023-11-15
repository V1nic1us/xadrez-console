using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xadrez_console.tabuleiro
{
    internal abstract class Part
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int AmtMovements { get; protected set; }
        public Board Board { get; protected set; }

        public Part(Board board, Color color)
        {
            Position = null;
            Color = color;
            Board = board;
            AmtMovements = 0;
        }

        public abstract bool[,] PossibleMovements();

        public void IncrementMovementQuantity()
        {
            AmtMovements++;
        }

        public void DecrementMovementQuantity()
        {
            AmtMovements--;
        }

        public bool ExistPossibleMovements()
        {
            bool[,] mat = PossibleMovements();
            for (int i = 0; i < Board.Rows; i++)
            {
                for (int j = 0; j < Board.Columns; j++)
                {
                    if (mat[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool CanMoveTo(Position position)
        {
            return PossibleMovements()[position.Row, position.Column];
        }
    }
}
