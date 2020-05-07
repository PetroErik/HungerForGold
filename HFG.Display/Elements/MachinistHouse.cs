// <copyright file="MachinistHouse.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HFG.Display
{
    /// <summary>
    /// Machinist House of the Game.
    /// </summary>
    public class MachinistHouse : Character
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MachinistHouse"/> class.
        /// Sets the location of the Machinist house.
        /// </summary>
        /// <param name="x">X coordinate of the house.</param>
        /// <param name="y">Y coordinate of the house.</param>
        public MachinistHouse(double x, double y)
        {
            this.Location = new double[2] { x, y };
        }
    }
}