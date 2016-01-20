using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
	//Hmmm widzę, że spodobało Ci się ExtensionMethods
	//jednakże nie poparłbym tego zastosowania tutaj
	//extension jest rozszerzeniem klasy o nową rzecz - SUPER
	//JEDNAKŻE extension powinien być ADEKWATNY dla KAŻDEJ instancji tej klasy
	//a nie z każdego stringa, który istnieje chcemy robić Cell

	//we wcześniejszym przypadku - naszej własnej implementacji XPath - dla każdego XElementu jaki by on nie był
	//ma sens próba wyszukania elementu po XPath
	
	//proponuję stworzyć zwykłą klasę
    public static class Extensions
    {
        public static Cell ToCell(this string stringCell)
        {
			//przez nasze nieporozumienie z zapisem formatu w IGameOfLife utrudniłeś sobie pracę :)
			//poprawię to ^^
            int xCoordinate;
            int yCoordinate;
			var values = stringCell.Split('x');
			if(values.Length == expectedCountValuesAfterSplit)
			{
				bool isParsingXSuccessful = int.TryParse(values[0], out xCoordinate);
				bool isParsingYSuccessful = int.TryParse(values[1], out yCoordinate);
				if (isParsingXSuccessful && isParsingYSuccessful)
					return new Cell(xCoordinate, yCoordinate, true);
			}
			//ponawiam komentarz, zazwyczaj warto wypisać co było nie tak
			//czyli dorzucić jaki dokładnie stan spowodował wyjątek
			throw new InvalidCellStringException("Invalid cell string.");            
			//czyli oczekiwałbym komunikatu w stylu
			//"Invalid cell format: 'bluybsdfy12'"
        }
		
		private static int expectedCountValuesAfterSplit = 2;
    }
}
