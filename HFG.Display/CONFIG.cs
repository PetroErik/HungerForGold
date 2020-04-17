using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HFG.Display
{
    public static class CONFIG
    {

        public static int BronzePrice = 100;
        public static int SilverPrice = 200;
        public static int GoldPrice = 300;

        // Number of Tiles
        public static int MapWidth = 20;
        public static int MapHeight = 20;

        // Fixed upgrade price for all elements for all levels.
        // Later we can make it more complex if we want.
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

        // These values will set according to the practise.
        // public static int StorageLvl3 = 300;
        // public static int StorageLvl2 = 200;
        // public static int StorageLvl1 = 100;
        // 
        // public static int FuelTankLvl3 = 300;
        // public static int FuelTankLvl2 = 200;
        // public static int FuelTankLvl1 = 100;
        // 
        // public static int DrillLvl3 = 300;
        // public static int DrillLvl2 = 200;
        // public static int DrillLvl1 = 100;
    }
}
