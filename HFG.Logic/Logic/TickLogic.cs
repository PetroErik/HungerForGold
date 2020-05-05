using HFG.Display;
using HFG.Display.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HFG.Logic
{
    /// <summary>
    /// DECREASE THE FUEL TANKS.
    /// </summary>
    public class TickLogic : ITickLogic
    {

        private int tickCount;

        private GameModel gameModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="TickLogic"/> class.
        /// Initialize the GameModel property.
        /// </summary>
        /// <param name="model">GameModel parameter to set the value of gameModel.</param>
        public TickLogic(GameModel model)
        {
            this.gameModel = model;
        }

        /// <summary>
        /// Moves enemies at every tick.
        /// </summary>
        public void EnemyTick()
        {
            this.tickCount++;
            foreach (Enemy enemy in this.gameModel.Enemies)
            {
                if (this.tickCount % 3 == 0)
                {
                    enemy.dx = -enemy.dx;
                }

                enemy.Location[0] += enemy.dx * this.gameModel.TileSize;
            }
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
