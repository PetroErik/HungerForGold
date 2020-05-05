using HFG.Display.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HFG.Display
{
    /// <summary>
    /// Model of our Game.
    /// </summary>
    public class GameModel
    {
        public int TotalPoints { get; set; }

        public int ActualPoints { get; set; }

        public Drill drill { get; set; }

        public SiloHouse SiloHouse { get; set; }

        public MachinistHouse MachinistHouse { get; set; }

        public List<Mineral> Minerals { get; set; }

        public List<Enemy> Enemies { get; set; }

        public List<Bomb> Bombs { get; set; }

        public double GameWidth { get; set; }

        public double GameHeight { get; set; }

        public double TileSize { get; set; }

        /*
         double array to set area for mouse click:
         index 0: X,
         index 1: Y,
         index 2: width,
         index 3: height
             */
        public double[] MenuButton { get; set; }

        public double[] StartButton { get; set; }

        public double[] ContinueButton { get; set;}

        public double[] HighscoreButton { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GameModel"/> class.
        /// Sets the values of game width and height.
        /// </summary>
        /// <param name="w">Width of the Game.</param>
        /// <param name="h">Height of the Game.</param>
        public GameModel(double w, double h)
        {
            this.GameWidth = w;
            this.GameHeight = h;
        }
    }
}
