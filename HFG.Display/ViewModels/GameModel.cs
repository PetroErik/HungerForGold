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

        public Drill drill { get; set; }            // Tile Size
        public SiloHouse SiloHouse { get; set; }         // Tile Size
        public MachinistHouse MachinistHouse { get; set; }   // Tile Size
        public List<Mineral> Minerals { get; set; } // Tile Size

        public double GameWidth { get; set; }       // Pixel Size
        public double GameHeight { get; set; }      // Pixel Size
        public double TileSize { get; set; }        // Pixel Size

        /*
         double array to set area for mouse click:
         index 0: X,
         index 1: Y,
         index 2: width,
         index 3: height
             */
        public double[] MenuButton { get; set; }
        public double[] StartButton { get; set; }
        public double[] ContinueButton { get; set; }
        public double[] HighscoreButton { get; set; }

        /// <summary>
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
