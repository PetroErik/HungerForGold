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
                this.changeEnemyLocation(enemy);
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

        private void changeEnemyLocation(Enemy enemy)
        {
            if (enemy.Location[0] >= (CONFIG.MapWidth - 1) * 2 * this.gameModel.TileSize ||
                enemy.Location[0] <= 0)
            {
                enemy.Dx = -enemy.Dx;
            }

            enemy.Location[0] += enemy.Dx * this.gameModel.TileSize;
        }

        private static Random r = new Random();

        /// <summary>
        /// Time decreases and bomb will explode .
        /// </summary>
        public void BoomTick()
        {
            this.tickCount++;

            foreach (var bomb in this.gameModel.Bombs)
            {
                if (this.tickCount % CONFIG.BombExplodeTime == 0)
                {
                    this.changeLocationBomb(bomb);
                }
            }
        }

        /// <summary>
        /// Method to change the bomb's location .
        /// </summary>
        /// <param name="bomb">the chosen bomb .</param>
        private void changeLocationBomb(Bomb bomb)
        {
            bomb.Location[0] = (double)r.Next(0, CONFIG.MapWidth * 2) * this.gameModel.TileSize;
            bomb.Location[1] = (double)r.Next((CONFIG.MapHeight / 3) + 2, CONFIG.MapHeight) * this.gameModel.TileSize;
        }
    }
}
