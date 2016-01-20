using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    public interface IGameOfLife
    {
        void Initialize(IEnumerable<string> cells);
		//cells format: "{x}x{y}" example: "3x2"
        IList<string> GetLifeCells(uint iteration);
        //returns null when world wasn't initialized
        //iteration 0 - cells passed through initialized method
    }
}
