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
        private List<Cell> deadCells = new List<Cell>();
        private List<Cell> allCells = new List<Cell>();

        public void Initialize(IEnumerable<string> cells)
        {
            foreach (var cell in cells)
            {
                livingCells.Add(cell.ToCell());
            }
        }
        public IList<string> GetLifeCells(uint iteration)
        {
            var lifeCells = new List<string>();

            if (iteration == 0)
            {
                foreach (var livingCell in livingCells)
                {
                    lifeCells.Add(livingCell.ToCellString());
                }
                return lifeCells;
            }
            else
            {
                generateDeadCells();
                allCells.AddRange(livingCells);
                livingCells.Clear();
                allCells.AddRange(deadCells);
                deadCells.Clear();
                
                foreach (var allCell in allCells)
                {                  
                    var neighbours = getAliveNeighbours(allCell);
                    
                    if (!allCell.isAlive && neighbours == 3)
                    {
                        livingCells.Add(new Cell(allCell.X,allCell.Y,true));           
                    }
                    else if (allCell.isAlive && (neighbours == 3 || neighbours == 2))
                    {
                        livingCells.Add(new Cell(allCell.X, allCell.Y, true));
                    }
                }

                foreach (var livingCell in livingCells)
                {
                    lifeCells.Add(livingCell.ToCellString());
                }
                return lifeCells;
            }
        }

        private int getAliveNeighbours(Cell allCell)
        {
            return allCells
                            .Where(c => c.isAlive == true)
                            .Where(c => c.X >= allCell.X - 1
                                     && c.X <= allCell.X + 1
                                     && c.Y >= allCell.Y - 1
                                     && c.Y <= allCell.Y + 1)
                            .Where(c => c != allCell)
                            .Count();
        }

        private void generateDeadCells()
        {
            foreach (var livingCell in livingCells)
            {
                for (int i = livingCell.X-1; i <= livingCell.X+1; i++)
                {
                    for (int j = livingCell.Y - 1; j <= livingCell.Y + 1; j++)
                    {
                        if (livingCells
                            .Exists(c => c.X == i && c.Y ==j)
                           
                            || deadCells
                            .Exists(c => c.X == i && c.Y == j)) ;
                        else
                        {
                            deadCells.Add(new Cell(i, j, false));
                        }
                    }
                }
            }
        }
    }
}
