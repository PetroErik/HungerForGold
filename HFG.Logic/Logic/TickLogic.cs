using HFG.Display;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HFG.Logic
{
    /// <summary>
    /// DECREASE THE FUEL TANKS
    /// </summary>
    public class TickLogic : ITickLogic
    {
        GameModel gameModel;

        /// <summary>
        /// Initialize the GameModel property
        /// </summary>
        /// <param name="model">GameModel parameter to set the value of gameModel.</param>
        public TickLogic(GameModel model)
        {
            this.gameModel = model;
        }
        
        /// <summary>
        /// If fuel tank is not empty, then decrease it's value by 1.
        /// </summary>
        public void FuelTick()
        {
            if (this.gameModel.drill.FuelTankFullness > 0)
            {
                this.gameModel.drill.FuelTankFullness--; 
            }
        }
    }
}
