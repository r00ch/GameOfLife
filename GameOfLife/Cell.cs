using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    public class Cell
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Cell(int xCoordinate, int yCoordinate)
        {
            X = xCoordinate;
            Y = yCoordinate;
        }
        public string ToCellString()
        {
            return "{" + this.X.ToString() + "}x{" + this.Y.ToString() + "}";
        }
    }
}
