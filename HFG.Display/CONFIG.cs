using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HFG.Display
{
    /// <summary>
    /// Containing the constants of our Game.
    /// </summary>
    public static class CONFIG
    {

        public static int BronzePrice = 100;
        public static int SilverPrice = 200;
        public static int GoldPrice = 300;

        public static int FuelCapacity = 100;
        public static int StorageCapacity = 10;

        // Number of Tiles
        public static int MapWidth = 20;
        public static int MapHeight = 20;

        public static int NmbOfBombs = 3;
        public static int NmbOfEnemies = 3;
        public static int NmbOfMinerals = 30;

        // Fixed upgrade price for all elements for all levels.
        public static int UpgradePrice = 5000;

        public static int MaxFuelTankLevel = 3;
        public static int MaxStorageLevel = 3;
        public static int MaxDrillLevel = 3;

        public static string BackgroundBrush = "OENIK_PROG4_2020_1_LDK923_YCSNU5.IMG.background.jpg";
        public static string DrillBrush = "OENIK_PROG4_2020_1_LDK923_YCSNU5.IMG.Drill.png";
        public static string GroundBrush = "OENIK_PROG4_2020_1_LDK923_YCSNU5.IMG.Ground.png";
        public static string GroundLevelBrush = "OENIK_PROG4_2020_1_LDK923_YCSNU5.IMG.GroundLevel.png";
        public static string GoldBrush = "OENIK_PROG4_2020_1_LDK923_YCSNU5.IMG.Gold.png";
        public static string SilverBrush = "OENIK_PROG4_2020_1_LDK923_YCSNU5.IMG.Silver.png";
        public static string BronzeBrush = "OENIK_PROG4_2020_1_LDK923_YCSNU5.IMG.Bronze.png";
        public static string SiloBrush = "OENIK_PROG4_2020_1_LDK923_YCSNU5.IMG.Silo.png";
        public static string MachinistBrush = "OENIK_PROG4_2020_1_LDK923_YCSNU5.IMG.Machinist.png";
        public static string EnemyBrush = "OENIK_PROG4_2020_1_LDK923_YCSNU5.IMG.Enemy.png";
        public static string BombBrush = "OENIK_PROG4_2020_1_LDK923_YCSNU5.IMG.Bomb.png";
    }
}
