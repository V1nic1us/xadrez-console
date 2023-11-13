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

        public Part Part(int line, int column)
        {
            return Parts[line, column];
        }

        public Part Part(Position position)
        {
            return Parts[position.Line, position.Column];
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
            Parts[position.Line, position.Column] = part;
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
            Parts[position.Line, position.Column] = null;
            return aux;
        }

        public bool ValidPosition(Position position)
        {
            if (position.Line < 0 || position.Line >= Lines || position.Column < 0 || position.Column >= Columns)
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
