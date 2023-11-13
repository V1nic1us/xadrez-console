using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xadrez_console.Parts;

namespace xadrez_console.tabuleiro
{
    internal class ChessMatch
    {
        public Board Board { get; private set; }
        private int Turn { get; set; }
        private Color CurrentPlayer { get; set; }
        public bool Finished { get; private set; }

        public ChessMatch()
        {
            Board = new Board(8, 8);
            Turn = 1;
            CurrentPlayer = Color.White;
            Finished = false;
            PutPieces();
        }

        public void ExecuteMovement(Position origin, Position destiny)
        {
            Part p = Board.RemovePart(origin);
            p.IncrementMovementQuantity();
            Part capturedPart = Board.RemovePart(destiny);
            Board.PutPart(p, destiny);
        }

        public void PutPieces()
        {
            Board.PutPart(new Tower(Board, Color.White), new ChessPosition('a', 1).ToPosition());
            Board.PutPart(new Tower(Board, Color.Black), new ChessPosition('a', 8).ToPosition());
            Board.PutPart(new Tower(Board, Color.White), new ChessPosition('h', 1).ToPosition());
            Board.PutPart(new Tower(Board, Color.Black), new ChessPosition('h', 8).ToPosition());
            Board.PutPart(new King(Board, Color.White), new ChessPosition('e', 1).ToPosition());
            Board.PutPart(new King(Board, Color.Black), new ChessPosition('e', 8).ToPosition());
        }


    }
}
