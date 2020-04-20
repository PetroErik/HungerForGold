using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HFG.Display
{
    public class Drill : Character
    {
        public int StorageLvl { get; set; }
        public int DrillLvl { get; set; }
        public int FuelTankLvl { get; set; }

        public int StorageCapacity { get; set; }
        public int FuelCapacity { get; set; }

        public int StorageFullness { get; set; }
        public int FuelTankFullness { get; set; }

        public void initialValue()
        {
            this.StorageLvl = 1;
            this.FuelTankLvl = 1;
            this.DrillLvl = 1;
            this.FuelCapacity = FuelTankLvl * CONFIG.FuelCapacity;
            this.StorageCapacity = StorageLvl * CONFIG.StorageCapacity;
            this.StorageFullness = 0;
            this.FuelTankFullness = FuelCapacity;
        }

        public Drill(double x, double y)
        {
            this.Location = new double[2] {x, y};          
        }
    }
}
