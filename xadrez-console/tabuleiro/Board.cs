using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xadrez_console.tabuleiro
{
    internal class Board
    {
        public int Lines { get; set; }
        public int Columns { get; set; }
        private Part[,] Parts;

        public Board(int lines, int columns)
        {
            Lines = lines;
            Columns = columns;
            Parts = new Part[lines, columns];
        }
    }
}
