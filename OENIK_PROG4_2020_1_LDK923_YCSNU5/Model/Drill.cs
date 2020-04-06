using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OENIK_PROG4_2020_1_LDK923_YCSNU5.Model
{
    class Drill : Character
    {
        public int StorageLvl { get; set; }
        public int DrillLvl { get; set; }
        public int FuelTankLvl { get; set; }

        public int ActualStorageSize { get; set; }
        public int ActualFuelTankSize { get; set; }
        public int ActualDrillSize { get; set; }

        public int StorageFullness { get; set; }
        public int FuelTankFullness { get; set; }

        public Drill(double x, double y)
        {
            this.Location = new Point(x, y);
            this.StorageLvl = 1;
            this.FuelTankLvl = 1;
            this.DrillLvl = 1;
            this.ActualDrillSize = Config.DrillLvl1;
            this.ActualFuelTankSize = Config.FuelTankLvl1;
            this.ActualStorageSize = Config.StorageLvl1;
            this.StorageFullness = 0;
            this.FuelTankFullness = Config.FuelTankLvl1;
        }
    }
}
