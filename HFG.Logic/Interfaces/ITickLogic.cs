using HFG.Display.Elements;
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
    public interface ITickLogic
    {
        /// <summary>
        /// Decreases the FuelTankFullness by 1.
        /// </summary>
        void FuelTick();

        /// <summary>
        /// Moves enemies.
        /// </summary>
        void EnemyTick();
    }
}
