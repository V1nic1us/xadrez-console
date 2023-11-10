﻿using System;
using xadrez_console.tabuleiro;

namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board(8, 8);

            Screen.PrintBoard(board);

            Console.ReadLine();
        }
    }
}
