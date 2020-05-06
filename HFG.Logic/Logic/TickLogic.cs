// <copyright file="TickLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HFG.Logic
{
    using HFG.Display;
    using HFG.Display.Elements;
    using System;

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
            this.tickCount++;
            foreach (Enemy enemy in this.gameModel.Enemies)
            {
                this.changeEnemyLocation(enemy);
            }
        }

        private void changeEnemyLocation(Enemy enemy)
        {
            if (this.tickCount % CONFIG.MapWidth/2 == 0)
            {
                enemy.Dx = -enemy.Dx;
            }

            enemy.Location[0] += enemy.Dx * this.gameModel.TileSize;
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
        
        private static Random r = new Random();
        public void BoomTick()
        {
            this.tickCount++;
            
            foreach (var bomb in this.gameModel.Bombs)
            {
                if (tickCount % CONFIG.bombExplodeTime == 0)
                {
                    this.changeLocationBomb(bomb);
                }
            }
        }

        private void changeLocationBomb(Bomb bomb)
        {
            bomb.Location[0] = (double)r.Next(0, CONFIG.MapWidth * 2) * this.gameModel.TileSize;
            bomb.Location[1] = (double)r.Next((CONFIG.MapHeight / 3) + 2, CONFIG.MapHeight) * this.gameModel.TileSize;

        }
    }
}
