using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife 
{
	//Tak jak pisałem w Cell.cs nazwy metod w C# piszemy zawsze dużą literą, nawet jeśli są prywatne
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
                for (int i = 1; i <= iteration; i++)
                {
                    GenerateDeadCells();
                    allCells.AddRange(livingCells); //zmiana kolejności tylko dla czytelności
					allCells.AddRange(deadCells);
                    livingCells.Clear();
                    deadCells.Clear();
                    
					//czym jest allCell? Wprowadza w błąd; allCell-> cell
                    foreach (var cell in allCells)
                    {
                        var neighbours = GetAliveNeighbours(cell);

                        if (!cell.IsAlive && neighbours == 3)
                        {
                            livingCells.Add(new Cell(cell.X, cell.Y, true));
                        }
                        else if (cell.IsAlive && (neighbours == 3 || neighbours == 2))
                        {
                            livingCells.Add(new Cell(cell.X, cell.Y, true));
                        }                        
                    }
                    allCells.Clear();
                }
				//przypominać użycie Select - transformuję jedną klasę X w inną klasę Y
				return livingCells.Select(c => c.ToCellString()).ToList();
            }
        }

		//zmieniłem nazwę komórki, bo mi myliła wszystko :P
        private int GetAliveNeighbours(Cell cell)
        {
            return allCells
							//1szy where można krócej zapisać
                            //.Where(c => c.isAlive == true)
							.Where(c => c.IsAlive) //zmiana z małej na dużą isAlive -> IsAlive patrz komentarz Cell.cs
							
							//Nie pojmuję 2giego Where'a, ale działa ;)
                            .Where(c => c.X >= cell.X - 1
                                     && c.X <= cell.X + 1
                                     && c.Y >= cell.Y - 1
                                     && c.Y <= cell.Y + 1)

							//3ci warunek - jest tricki ...
							//może działać, ale nie musi...
							//a co gdyby argumentem była nowa komórka?
							//domyślne porównanie REFERENCJI sprawdza czy jest to ta sama instancja
							//a to Cię nie iteresuje, tylko czy X i Y jest ten sam
							//proponuję przeciążyć Equals w Cell
                            .Where(c => c != cell)
                            .Count();
        }

        private void GenerateDeadCells()
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
