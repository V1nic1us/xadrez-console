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

                while (!match.Finished)
                {
                    Console.Clear();
                    Screen.PrintBoard(match.Board);

                    Console.WriteLine("Origin: ");
                    Position originPosition = Screen.ReadChessPosition().ToPosition();

                    bool[,] possiblePositions = match.Board.Part(originPosition).PossibleMovements();
                    Console.Clear();
                    Screen.PrintBoard(match.Board, possiblePositions);

                    Console.WriteLine("Destiny: ");
                    Position destinyPosition = Screen.ReadChessPosition().ToPosition();

                    match.ExecuteMovement(originPosition, destinyPosition);

                }
            }
            catch (BoardException e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}

