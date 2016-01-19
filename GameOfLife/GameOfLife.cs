using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife 
{
    class GameOfLife : IGameOfLife
    {
        private List<Cell> livingCells = new List<Cell>();

        public void Initialize(IEnumerable<string> cells)
        {
            foreach (var cell in cells)
            {
                livingCells.Add(cell.ToCell());
            }
        }
        public IList<string> GetLifeCells(uint iteration)
        {
            if (iteration == 0)
            {
                var lifeCells = new List<string>();
                foreach (var cell in livingCells)
                {
                    lifeCells.Add(cell.ToCellString());
                }
                return lifeCells;
            }
            else return null;
        }
    }
}
