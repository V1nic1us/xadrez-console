using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xadrez_console.tabuleiro;

namespace xadrez_console.Parts
{
    internal class Horse: Part
    {
        public Horse(Board board, Color color) : base(board, color) { }

        public override string ToString()
        {
            return "H";
        }
    }
}
