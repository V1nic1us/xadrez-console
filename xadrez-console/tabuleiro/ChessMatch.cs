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
        public HashSet<Part> Parts;
        public HashSet<Part> CapturedParts;

        public ChessMatch()
        {
            Board = new Board(8, 8);
            Turn = 1;
            CurrentPlayer = Color.White;
            Finished = false;
            Parts = new HashSet<Part>();
            CapturedParts = new HashSet<Part>();
            PutPieces();
        }

        public void ExecuteMovement(Position origin, Position destiny)
        {
            Part p = Board.RemovePart(origin);
            p.IncrementMovementQuantity();
            Part capturedPart = Board.RemovePart(destiny);
            Board.PutPart(p, destiny);
            if (capturedPart != null)
            {
                CapturedParts.Add(capturedPart);
            }
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
            _ = CurrentPlayer == Color.White ? CurrentPlayer = Color.Black : CurrentPlayer = Color.White; // _ = means that the variable will not be used
        }

        public void PutNewPart(Part part, char column, int row)
        {
            Board.PutPart(part, new ChessPosition(column, row).ToPosition());
            Parts.Add(part);
        }

        public void ValidateCapturedPart(Part capturedPart)
        {
            if (capturedPart == null)
            {
                throw new BoardException("There is no part to be captured!");
            }
        }

        public HashSet<Part> CapturedPieces(Color color)
        {
            HashSet<Part> aux = new HashSet<Part>();
            foreach (Part x in CapturedParts)
            {
                if (x.Color == color)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Part> PiecesInGame(Color color)
        {
            HashSet<Part> aux = new HashSet<Part>();
            foreach (Part x in Parts)
            {
                if (x.Color == color)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(CapturedPieces(color));
            return aux;
        }

        public void PutPieces()
        {
            PutNewPart(new Rook(Board, Color.White), 'a', 1);
            PutNewPart(new Rook(Board, Color.Black), 'a', 8);
            PutNewPart(new Rook(Board, Color.White), 'h', 1);
            PutNewPart(new Rook(Board, Color.Black), 'h', 8);
            PutNewPart(new King(Board, Color.White), 'e', 1);
            PutNewPart(new King(Board, Color.Black), 'e', 8);
            PutNewPart(new Knight(Board, Color.White), 'b', 1);
            PutNewPart(new Knight(Board, Color.Black), 'b', 8);
            PutNewPart(new Knight(Board, Color.White), 'g', 1);
            PutNewPart(new Knight(Board, Color.Black), 'g', 8);
            PutNewPart(new Bishop(Board, Color.White), 'c', 1);
            PutNewPart(new Bishop(Board, Color.Black), 'c', 8);
            PutNewPart(new Bishop(Board, Color.White), 'f', 1);
            PutNewPart(new Bishop(Board, Color.Black), 'f', 8);
            PutNewPart(new Queen(Board, Color.White), 'd', 1);
            PutNewPart(new Queen(Board, Color.Black), 'd', 8);
        }
    }
}
