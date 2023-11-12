using System;
using xadrez_console.tabuleiro;
using xadrez_console.Parts;

namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Board board = new Board(8, 8);

                board.PutPart(new Tower(board, Color.Black), new Position(0, 0));
                board.PutPart(new Tower(board, Color.Black), new Position(1, 3));
                board.PutPart(new King(board, Color.Black), new Position(0, 2));
                board.PutPart(new Tower(board, Color.White), new Position(3, 5));
                board.PutPart(new Tower(board, Color.White), new Position(4, 5));
                board.PutPart(new King(board, Color.White), new Position(3, 4));
                board.PutPart(new Tower(board, Color.White), new Position(3, 7));

                Screen.PrintBoard(board);

                Console.ReadLine();
            }
            catch (BoardException e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}

