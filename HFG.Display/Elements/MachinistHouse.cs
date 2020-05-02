using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HFG.Display
{
    /// <summary>
    /// Machinist House of the Game.
    /// </summary>
    public class MachinistHouse : Character
    {
        /// <summary>
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