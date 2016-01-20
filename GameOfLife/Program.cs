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
                "{0}x{0}",
                "{1}x{0}",
                "{2}x{-1}",
                "{2}x{1}",
                "{3}x{0}",
                "{4}x{0}",  // Lifespan of these cycles at 15 
                "{5}x{0}",
                "{6}x{0}",
                "{7}x{-1}",
                "{7}x{1}",
                "{8}x{0}",
                "{9}x{0}",
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
