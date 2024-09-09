using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.models;

namespace ConsoleRunner
{
    public class Runner
    {
        public GameBoard BuildBoard()
        {
            Crown p1Crown = null;
            Wall p1Wall = null;
            List<Figure> p1Figures = null;
            Spinner p1Spinner = null;
            Player player1 = new Player(p1Crown, p1Wall, p1Figures, p1Spinner);


            Player player2 = null;




            return new GameBoard(player1, player2);
        }
    }
}
