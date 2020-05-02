using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HFG.Display
{
    /// <summary>
    /// Drill character.
    /// </summary>
    public class Drill : Character
    {
        public int StorageLvl { get; set; }
        public int DrillLvl { get; set; }
        public int FuelTankLvl { get; set; }

        public int StorageCapacity { get; set; }
        public int FuelCapacity { get; set; }

        public int StorageFullness { get; set; }
        public int FuelTankFullness { get; set; }

        /// <summary>
        /// Sets the intial values of the drill components.
        /// </summary>
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

        /// <summary>
        /// Sets the location of the drill.
        /// </summary>
        /// <param name="x">X location of the drill.</param>
        /// <param name="y">Y location of the drill.</param>
        public Drill(double x, double y)
        {
            this.Location = new double[2] {x, y};
        }
    }
}
