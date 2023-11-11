using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xadrez_console.tabuleiro
{
    internal class Part
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
    }
}
