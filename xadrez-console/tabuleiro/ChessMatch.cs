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
        public int Turn { get; set; }
        public Color CurrentPlayer { get; set; }
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

        public void PerformMove(Position origin, Position destiny)
        {
            ExecuteMovement(origin, destiny);
            Turn++;
            ChangePlayer();
        }

        public void ValidateOriginPosition(Position position)
        {
            if (Board.Part(position) == null)
            {
                throw new BoardException("There is no part in the chosen origin position!");
            }

            if (CurrentPlayer != Board.Part(position).Color)
            {
                throw new BoardException("The chosen origin part is not yours!");
            }

            if (!Board.Part(position).ExistPossibleMovements())
            {
                throw new BoardException("There are no possible movements for the chosen origin part!");
            }
        }

        public void ValidateDestinyPosition(Position origin, Position destiny)
        {
            if (!Board.Part(origin).CanMoveTo(destiny))
            {
                throw new BoardException("Invalid destiny position!");
            }
        }

        public void ChangePlayer()
        {
            if (CurrentPlayer == Color.White)
            {
                CurrentPlayer = Color.Black;
            }
            else
            {
                CurrentPlayer = Color.White;
            }
        }

        public void PutPieces()
        {
            Board.PutPart(new Rook(Board, Color.White), new ChessPosition('a', 1).ToPosition());
            Board.PutPart(new Rook(Board, Color.Black), new ChessPosition('a', 8).ToPosition());
            Board.PutPart(new Rook(Board, Color.White), new ChessPosition('h', 1).ToPosition());
            Board.PutPart(new Rook(Board, Color.Black), new ChessPosition('h', 8).ToPosition());
            Board.PutPart(new King(Board, Color.White), new ChessPosition('e', 1).ToPosition());
            Board.PutPart(new King(Board, Color.Black), new ChessPosition('e', 8).ToPosition());
            Board.PutPart(new Knight(Board, Color.White), new ChessPosition('b', 1).ToPosition());
            Board.PutPart(new Knight(Board, Color.Black), new ChessPosition('b', 8).ToPosition());
            Board.PutPart(new Knight(Board, Color.White), new ChessPosition('g', 1).ToPosition());
            Board.PutPart(new Knight(Board, Color.Black), new ChessPosition('g', 8).ToPosition());
            Board.PutPart(new Bishop(Board, Color.White), new ChessPosition('c', 1).ToPosition());
            Board.PutPart(new Bishop(Board, Color.Black), new ChessPosition('c', 8).ToPosition());
            Board.PutPart(new Bishop(Board, Color.White), new ChessPosition('f', 1).ToPosition());
            Board.PutPart(new Bishop(Board, Color.Black), new ChessPosition('f', 8).ToPosition());
            Board.PutPart(new Queen(Board, Color.White), new ChessPosition('d', 1).ToPosition());
            Board.PutPart(new Queen(Board, Color.Black), new ChessPosition('d', 8).ToPosition());
        }
    }
}
