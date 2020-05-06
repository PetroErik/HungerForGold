// <copyright file="Bomb.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Collections.Generic;

namespace HFG.Display.Elements
{
    /// <summary>
    /// Bomb element of the Game.
    /// </summary>
    public class Bomb : Character
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Bomb"/> class.
        /// Declare the location of the Bomb.
        /// </summary>
        /// <param name="x">X coordinate of the Bomb.</param>
        /// <param name="y">Y coordinate of the Bomb.</param>
        public Bomb(double x, double y)
        {
            this.Location = new double[] { x, y };
        }

    }
}
