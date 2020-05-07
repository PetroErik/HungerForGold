// <copyright file="Mineral.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HFG.Display
{
    /// <summary>
    /// Mineral of the game.
    /// </summary>
    public class Mineral : Character
    {
        /// <summary>
        /// Gets or sets the Type of the mineral.
        /// </summary>
        public MineralsType Type { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the mineral is collected.
        /// </summary>
        public bool Collapse { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Mineral"/> class.
        /// Sets the location and the type of the mineral.
        /// </summary>
        /// <param name="x">X coordinate of the mineral.</param>
        /// <param name="y">Y coordinate of the mineral.</param>
        /// <param name="type">Type of the mineral.</param>
        public Mineral(double x, double y, MineralsType type)
        {
            this.Location = new double[2] { x, y };
            this.Type = type;
        }
    }
}
