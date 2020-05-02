using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HFG.Display
{
    /// <summary>
    /// Mineral of the game.
    /// </summary>
    public class Mineral : Character
    {
        public MineralsType Type { get; set; }
        public bool Collapse { get; set; } 

        /// <summary>
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
