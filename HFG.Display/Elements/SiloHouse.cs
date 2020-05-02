using HFG.Display;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HFG.Display
{
    /// <summary>
    /// Silo House of the game.
    /// </summary>
    public class SiloHouse : Character
    {
        /// <summary>
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
