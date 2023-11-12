using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xadrez_console.tabuleiro
{
    internal class BoardException : Exception
    {
        public BoardException()
        {
        }

        public BoardException(string message) : base(message)
        {
        }

        public BoardException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
