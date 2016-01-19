using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    public class InvalidCellStringException : Exception
    {
        public InvalidCellStringException() { }
        public InvalidCellStringException(string message) : base(message) { }
        public InvalidCellStringException(string message, Exception inner) : base(message, inner) { }
    }
}
