//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows;

//namespace OENIK_PROG4_2020_1_LDK923_YCSNU5.Model
//{
//    class GameModel
//    {
//        public int TotalPoints { get; set; }
//        public int ActualPoints { get; set; }

//        public Drill drill { get; set; }            // Tile Size
//        public Point SiloHouse{ get; set; }         // Tile Size
//        public Point MachinistHouse { get; set; }   // Tile Size
//        public List<Minerals> Minerals{ get; set; } // Tile Size

//        public double GameWidth { get; set; }       // Pixel Size
//        public double GameHeight { get; set; }      // Pixel Size
//        public double TileSize { get; set; }        // Pixel Size

//        static Random r = new Random();

//        public GameModel(double w, double h)
//        {
//            this.GameWidth = w;
//            this.GameHeight = h;
//            this.TileSize = Math.Min(GameWidth / Config.MapWidth, GameHeight / Config.MapHeight);
//            this.TotalPoints = 0;
//            this.ActualPoints = 0;
//            this.drill = new Drill(Config.MapWidth * TileSize, Config.MapHeight / 3 * TileSize);                                // Ground level is at GameHeight / 3
//            this.SiloHouse = new Point(Config.MapWidth * 3 / 2 * TileSize, Config.MapHeight / 3 * TileSize - 4 * TileSize);     // Silo is 4 tile higher than the drill
//            this.MachinistHouse = new Point(Config.MapWidth * 2 / 3 * TileSize, Config.MapHeight / 3 * TileSize - 4 * TileSize);
//            Minerals = new List<Minerals>();
//            for (int i = 0; i < 30; i++)
//            {
//                int typeSelector = r.Next(0, 3);
//                if (typeSelector == 0)
//                {
//                    Minerals.Add(new Minerals(r.Next(0, Config.MapWidth * 2) * TileSize, (r.Next(Config.MapHeight / 3 + 2, Config.MapHeight) * TileSize), MineralsType.Bronze)); // + 2 to avoid minerals on the ground level
//                }
//                if (typeSelector == 1)
//                {
//                    Minerals.Add(new Minerals(r.Next(0, Config.MapWidth*2) * TileSize, (r.Next(Config.MapHeight / 3 + 2, Config.MapHeight) * TileSize), MineralsType.Silver));                    
//                }
//                if (typeSelector == 2)
//                {
//                    Minerals.Add(new Minerals(r.Next(0, Config.MapWidth*2) * TileSize, (r.Next(Config.MapHeight / 3 + 2, Config.MapHeight) * TileSize), MineralsType.Gold));
//                }
//            }
//        }
//    }
//}
