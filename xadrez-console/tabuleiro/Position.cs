﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xadrez_console.tabuleiro
{
    internal class Position
    {
        public int Linha { get; set; }
        public int Coluna { get; set; }

        public Position(int linha, int coluna)
        {
            Linha = linha;
            Coluna = coluna;
        }

        public override string ToString() => $"{Linha}, {Coluna}";
    }
}
