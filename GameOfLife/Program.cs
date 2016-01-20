using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            var initialCells = new List<string>()
                {
                "0x0",
                "1x0",
                "2x-1",
                "2x1",
                "3x0",
                "4x0",  // Lifespan of these cycles at 15 
                "5x0",
                "6x0",
                "7x-1",
                "7x1",
                "8x0",
                "9x0",
                };

            var gameOfLife = new GameOfLife();
            gameOfLife.Initialize(initialCells);
            //foreach (var cell in gameOfLife.GetLifeCells(0))
            //{
            //    Console.WriteLine(cell);
            //}
            foreach (var cell in gameOfLife.GetLifeCells(3000))
            {
                Console.WriteLine(cell);
            }
            Console.ReadLine();
        }
    }
}
