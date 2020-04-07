using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OENIK_PROG4_2020_1_LDK923_YCSNU5.Model
{
    class GameModel
    {
        public int TotalPoints { get; set; }
        public int ActualPoints { get; set; }

        public Drill drill { get; private set; }    // Tile Size
        public Point SiloHouse{ get; set; }         // Tile Size
        public Point MachinistHouse { get; set; }   // Tile Size
        public List<Minerals> Minerals{ get; set; } // Tile Size

        public double GameWidth { get; set; }       // Pixel Size
        public double GameHeight { get; set; }      // Pixel Size
        public double TileSize { get; set; }        // Pixel Size

        static Random r = new Random();

        public GameModel(double w, double h)
        {
            this.GameWidth = w;
            this.GameHeight = h;
            this.TileSize = Math.Min(GameWidth / Config.MapWidth, GameHeight / Config.MapHeight);
            this.TotalPoints = 0;
            this.ActualPoints = 0;
            this.drill = new Drill(GameWidth / 2, GameHeight / 3);              // Ground level is at GameHeight / 3
            this.SiloHouse = new Point(GameWidth * 3 / 4, GameHeight / 3);
            this.MachinistHouse = new Point(GameWidth / 4, GameHeight / 3);
            Minerals = new List<Minerals>();
            for (int i = 0; i < 10; i++)
            {
                int typeSelector = r.Next(0, 3);
                if (typeSelector == 0)
                {
                    Minerals.Add(new Minerals(r.Next(0, (int)GameWidth), r.Next((int)GameHeight / 3, (int)GameHeight), MineralsType.Bronze));
                }
                if (typeSelector == 1)
                {
                    Minerals.Add(new Minerals(r.Next(0, (int)GameWidth), r.Next((int)GameHeight / 3, (int)GameHeight), MineralsType.Silver));
                }
                if (typeSelector == 2)
                {
                    Minerals.Add(new Minerals(r.Next(0, (int)GameWidth), r.Next((int)GameHeight / 3, (int)GameHeight), MineralsType.Gold));
                }
            }
        }
    }
}
