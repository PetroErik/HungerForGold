// <copyright file="TickLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HFG.Logic
{
    using System;
    using HFG.Display;
    using HFG.Display.Elements;

    /// <summary>
    /// Moves elements in every tick.
    /// </summary>
    public class TickLogic : ITickLogic
    {
        private static Random r = new Random();
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
            foreach (Enemy enemy in this.gameModel.Enemies)
            {
                this.ChangeEnemyLocation(enemy);
            }
        }

        /// <summary>
        /// If fuel tank is not empty, then decrease it's value by 1.
        /// </summary>
        public void FuelTick()
        {
            if (this.gameModel.Drill.FuelTankFullness > 0)
            {
                this.gameModel.Drill.FuelTankFullness--;
            }
        }

        /// <summary>
        /// Time decreases and bomb will explode .
        /// </summary>
        public void BoomTick()
        {
            this.tickCount++;
            if (this.tickCount % CONFIG.BombExplodeTime == 0)
            {
                this.gameModel.IsExplode = true;
                foreach (var bomb in this.gameModel.Bombs)
                {
                    this.ChangeLocationBomb(bomb);
                }
            }
        }

        private void ChangeEnemyLocation(Enemy enemy)
        {
            if (enemy.Location[0] >= (CONFIG.MapWidth - 1) * 2 * this.gameModel.TileSize ||
                enemy.Location[0] <= 0)
            {
                enemy.Dx = -enemy.Dx;
            }

            enemy.Location[0] += enemy.Dx * this.gameModel.TileSize;
        }

        /// <summary>
        /// Method to change the bomb's location .
        /// </summary>
        /// <param name="bomb">the chosen bomb .</param>
        private void ChangeLocationBomb(Bomb bomb)
        {
            bomb.Location[0] = (double)r.Next(0, CONFIG.MapWidth * 2) * this.gameModel.TileSize;
            bomb.Location[1] = (double)r.Next((CONFIG.MapHeight / 3) + 2, CONFIG.MapHeight) * this.gameModel.TileSize;
        }
    }
}
