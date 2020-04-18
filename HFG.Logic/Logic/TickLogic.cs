using HFG.Display;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HFG.Logic
{
    public class TickLogic : ITickLogic
    {
        GameModel gameModel;

        public TickLogic(GameModel model)
        {
            this.gameModel = model;
        }
        // If returns true ==> game is over
        public bool FuelTick()
        {
            if (this.gameModel.drill.FuelTankFullness > 0)
            {
                this.gameModel.drill.FuelTankFullness--;
            }
            return this.gameModel.drill.FuelTankFullness <= 0;
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
