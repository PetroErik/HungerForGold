// <copyright file="Drill.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HFG.Display
{
    /// <summary>
    /// Drill character.
    /// </summary>
    public class Drill : Character
    {
        /// <summary>
        /// Gets or sets the level of the Storage element.
        /// </summary>
        public int StorageLvl { get; set; }

        /// <summary>
        /// Gets or sets the level of the Drill element.
        /// </summary>
        public int DrillLvl { get; set; }

        /// <summary>
        /// Gets or sets the level of the Fuel Tank element.
        /// </summary>
        public int FuelTankLvl { get; set; }

        /// <summary>
        /// Gets or sets the capacity of the storage element.
        /// </summary>
        public int StorageCapacity { get; set; }

        /// <summary>
        /// Gets or sets the capacity of the fuel tank element.
        /// </summary>
        public int FuelCapacity { get; set; }

        /// <summary>
        /// Gets or sets the fullness of the storage element.
        /// </summary>
        public int StorageFullness { get; set; }

        /// <summary>
        /// Gets or sets the fullness of the fuel tank element.
        /// </summary>
        public int FuelTankFullness { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Drill"/> class.
        /// Sets the location of the drill.
        /// </summary>
        /// <param name="x">X location of the drill.</param>
        /// <param name="y">Y location of the drill.</param>
        public Drill(double x, double y)
        {
            this.Location = new double[2] { x, y };
        }

        /// <summary>
        /// Sets the intial values of the drill components.
        /// </summary>
        public void InitialValue()
        {
            this.StorageLvl = 1;
            this.FuelTankLvl = 1;
            this.DrillLvl = 1;
            this.FuelCapacity = this.FuelTankLvl * CONFIG.FuelCapacity;
            this.StorageCapacity = this.StorageLvl * CONFIG.StorageCapacity;
            this.StorageFullness = 0;
            this.FuelTankFullness = this.FuelCapacity;
        }
    }
}
