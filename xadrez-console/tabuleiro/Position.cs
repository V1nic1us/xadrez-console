using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xadrez_console.tabuleiro
{
    internal class Position
    {
        public int Row { get; set; }
        public int Column { get; set; }

        public Position(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public void SetValues(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public override string ToString() => $"{Row}, {Column}";
    }
}
