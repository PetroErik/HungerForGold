using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OENIK_PROG4_2020_1_LDK923_YCSNU5.Model
{
    class Config
    {
        public static int BronzePrice = 100;
        public static int SilverPrice = 200;
        public static int GoldPrice = 300;

        // Number of Tiles
        public static int MapWidth = 20;
        public static int MapHeight = 15;

        // Fixed upgrade price for all elements for all levels.
        // Later we can make it more complex if we want.
        public static int UpgradePrice = 5000;  

        public static int MaxFuelTankLevel = 3;
        public static int MaxStorageLevel = 3;
        public static int MaxDrillLevel = 3;

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
