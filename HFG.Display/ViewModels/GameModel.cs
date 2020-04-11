using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HFG.Display
{
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

        public GameModel(double w, double h)
        {
            this.GameWidth = w;
            this.GameHeight = h;
        }
    }
}
