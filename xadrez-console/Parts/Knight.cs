using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xadrez_console.tabuleiro;

namespace xadrez_console.Parts
{
    internal class Knight: Part
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
            throw new NotImplementedException();
        }
    }
}
