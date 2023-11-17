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
                ChessMatch match = new ChessMatch();
                Console.OutputEncoding = System.Text.Encoding.UTF8;

                while (!match.Finished)
                {
                    try
                    {
                        Console.Clear();
                        Screen.PrintMatch(match);
                        Console.WriteLine();
                        Console.WriteLine("Origin: ");
                        Position originPosition = Screen.ReadChessPosition().ToPosition();
                        match.ValidateOriginPosition(originPosition);

                        bool[,] possiblePositions = match.Board.Part(originPosition).PossibleMovements();
                        Console.Clear();
                        Screen.PrintBoard(match.Board, possiblePositions);

                        Console.WriteLine();
                        Console.WriteLine("Destiny: ");
                        Position destinyPosition = Screen.ReadChessPosition().ToPosition();
                        match.ValidateDestinyPosition(originPosition, destinyPosition);

                        match.PerformMove(originPosition, destinyPosition);
                    }
                    catch (BoardException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadLine();
                    }
                }
            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Press any key to continue...");
                Console.ReadLine();
            }
        }
    }
}

