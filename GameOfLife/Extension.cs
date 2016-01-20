using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    public static class Extensions
    {
        public static Cell ToCell(this string stringCell)
        {
            int xCoordinate;
            int yCoordinate;
            bool writeToSecondCoordinate = false;
            string xCoordinateString = "";
            string yCoordinateString = "";

            foreach (char character in stringCell)
            {
                if (character == 'x')
                    writeToSecondCoordinate = true;
                else if (character != '{' && character != '}')
                {
                    if (writeToSecondCoordinate)
                        yCoordinateString += character;
                    else
                        xCoordinateString += character;
                }
            }
            bool isParsingXSuccessful = int.TryParse(xCoordinateString, out xCoordinate);
            bool isParsingYSuccessful = int.TryParse(yCoordinateString, out yCoordinate);

            if (!isParsingXSuccessful
            || !isParsingYSuccessful)
                throw new InvalidCellStringException("Invalid cell string.");

            return new Cell(xCoordinate, yCoordinate, true);
        }
    }
}
