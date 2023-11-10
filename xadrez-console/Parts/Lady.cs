using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xadrez_console.tabuleiro;

namespace xadrez_console.Parts
{
    internal class Lady: Part
    {
        public Lady(Board board, Color color) : base(board, color) { }

        public override string ToString()
        {
            return "L";
        }
    }
}
