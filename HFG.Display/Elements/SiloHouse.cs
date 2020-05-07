// <copyright file="SiloHouse.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HFG.Display
{
    /// <summary>
    /// Silo House of the game.
    /// </summary>
    public class SiloHouse : Character
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SiloHouse"/> class.
        /// Sets the location of the house.
        /// </summary>
        /// <param name="x">X coordinate of the house.</param>
        /// <param name="y">Y coordinate of the house.</param>
        public SiloHouse(double x, double y)
        {
            this.Location = new double[2] { x, y };
        }
    }
}
