// <copyright file="Enemy.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HFG.Display.Elements
{
    using System;

    /// <summary>
    /// Enemy component of the game.
    /// </summary>
    public class Enemy : Character
    {
        private static Random r = new Random();

        /// <summary>
        /// Initializes a new instance of the <see cref="Enemy"/> class.
        /// Declares the location of the enemy.
        /// </summary>
        /// <param name="x">X coordinate of the enemy.</param>
        /// <param name="y">Y coordinate of the enemy.</param>
        public Enemy(double x, double y)
        {
            this.Location = new double[] { x, y };

            // this.Dx = -1;
            if (r.Next(0, 2) == 0)
            {
                this.Dx = -1;
            }
            else
            {
                this.Dx = 1;
            }
        }

        /// <summary>
        /// Gets or sets the movement vector in the X direction.
        /// </summary>
        public int Dx { get; set; }
    }
}
