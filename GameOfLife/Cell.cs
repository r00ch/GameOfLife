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
		
		//Konwencja C# metody piszemy z dużych liter, Java ma dokładnie odwrotnie
		//To poniżej nazywamy Property - ale przyglądając się bliżej to jest metoda, a nawet dwie
		//Po przekompilowaniu Twojego kodu do języka IL (Intermediate Language)
		//możesz zauważyć, że twoja klasa "Cell" ma 2 metody get_isAlive oraz set_isAlive
        public bool IsAlive { get; set; }

        public Cell(int xCoordinate, int yCoordinate, bool alive)
        {
            X = xCoordinate;
            Y = yCoordinate;
            IsAlive = alive;
        }

		//podoba mi się, że stworzyłeś dedykowaną metodę, a nie przeciążyłeś ToString
		//dzięki temu będzie można bardzo szybko i ładnie wyszukać użycia tej metody
		//wynikło nieporozumienie z interpretacji patrz: IGameOfLife format
        public string ToCellString()
        {
            return this.X.ToString() + "x" + this.Y.ToString();
        }
    }
}
