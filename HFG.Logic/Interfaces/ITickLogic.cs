using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HFG.Logic
{
    /// <summary>
    /// Interface for tick logic.
    /// </summary>
    interface ITickLogic
    {
        /// <summary>
        /// Decreases the FuelTankFullness by 1.
        /// </summary>
        void FuelTick();
    }
}
