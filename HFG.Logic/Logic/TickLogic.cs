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

        public TickLogic(GameModel model)
        {
            this.gameModel = model;
        }
        // If returns true ==> game is over
        // I move this gameover detect to game logic. It looks more "clear". 
        // clean code: one function should only handle 1 thing. 
        public void FuelTick()
        {
            if (this.gameModel.drill.FuelTankFullness > 0)
            {
                this.gameModel.drill.FuelTankFullness--; 
            }
        }

        // If drill is above ground level it falls down.
        public void GravityTick()
        {
            if (this.gameModel.drill.Location[1] + 1 < (this.gameModel.GameHeight / 3))
            {
                int dy = 1;
                int newY = (int)(this.gameModel.drill.Location[1] + dy);
                dy += 1;
                this.gameModel.drill.Location = new double[2] { this.gameModel.drill.Location[0], newY };
            }
        }
    }
}
