using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xadrez_console.tabuleiro
{
    internal class Board
    {
        public int Rows { get; set; }
        public int Columns { get; set; }
        private Part[,] Parts;

        public Board(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            Parts = new Part[rows, columns];
        }

        public Part Part(int line, int column)
        {
            return Parts[line, column];
        }

        public Part Part(Position position)
        {
            return Parts[position.Row, position.Column];
        }

        public bool PartExists(Position position)
        {
            ValidatePosition(position);
            return Part(position) != null;
        }

        public void PutPart(Part part, Position position)
        {
            if (PartExists(position))
            {
                throw new BoardException("There is already a part in this position!");
            }
            Parts[position.Row, position.Column] = part;
            part.Position = position;
        }

        public Part RemovePart(Position position)
        {
            if (Part(position) == null)
            {
                return null;
            }
            Part aux = Part(position);
            aux.Position = null;
            Parts[position.Row, position.Column] = null;
            return aux;
        }

        public bool ValidPosition(Position position)
        {
            if (position.Row < 0 || position.Row >= Rows || position.Column < 0 || position.Column >= Columns)
            {
                return false;
            }
            return true;
        }

        public void ValidatePosition(Position position)
        {
            if (!ValidPosition(position))
            {
                throw new BoardException("Invalid position!");
            }
        }
    }
}
