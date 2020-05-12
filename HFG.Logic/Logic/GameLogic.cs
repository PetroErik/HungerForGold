// <copyright file="GameLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HFG.Logic
{
    using System;
    using System.Collections.Generic;
    using HFG.Database;
    using HFG.Display;
    using HFG.Display.Elements;
    using HFG.Repository;
    using HFG.Repository.Repository;

    /// <summary>
    /// OVERALL LOGIC FOR GAME. INITIAL MAP, START NEW GAME, DETECT WHEN GAME IS OVER.
    /// </summary>
    public class GameLogic : IGameLogic
    {
        /// <summary>
        /// GameModel instance for the logic.
        /// </summary>
        public GameModel GameModel;

        /// <summary>
        /// MoveLogic instance for the logic.
        /// </summary>
        public MoveLogic MoveLogic;

        /// <summary>
        /// Database logic instance for the logic.
        /// </summary>
        public DbLogic DbLogic;

        /// <summary>
        /// TickLogic instance for the logic.
        /// </summary>
        public TickLogic TickLogic;

        private static Random r = new Random();

        /// <summary>
        /// Initializes a new instance of the <see cref="GameLogic"/> class.
        /// Initiates properties of logics and model.
        /// </summary>
        /// <param name="model">GameModel parameter help the initialization of properties.</param>
        public GameLogic(GameModel model)
        {
            HFGEntities entities = new HFGEntities();
            this.GameModel = model;
            this.MoveLogic = new MoveLogic(model);
            this.DbLogic = new DbLogic(model, new DrillRepository(entities), new BrickRepository(entities), new ConnRepository(entities));
            this.TickLogic = new TickLogic(model);
            this.GameModel.TileSize = Math.Min(this.GameModel.GameWidth / CONFIG.MapWidth, this.GameModel.GameHeight / CONFIG.MapHeight);
            this.GameModel.MenuButton = new double[] { 0, 0, 50, 30 };
            this.GameModel.StartButton = new double[] { (this.GameModel.GameWidth / 2) - 180, this.GameModel.GameHeight / 2, 400, 40 };
            this.GameModel.ContinueButton = new double[] { (this.GameModel.GameWidth / 2) - 180, (this.GameModel.GameHeight / 2) + 60, 400, 40 };
            this.GameModel.HighscoreButton = new double[] { (this.GameModel.GameWidth / 2) - 180, (this.GameModel.GameHeight / 2) + 120, 400, 40 };
            this.GameModel.Bombs = new List<Bomb>();
            for (int i = 0; i < CONFIG.NmbOfBombs; i++)
            {
                this.GameModel.Bombs.Add(new Bomb((double)(r.Next(0, CONFIG.MapWidth * 2) * this.GameModel.TileSize), (double)(r.Next((CONFIG.MapHeight / 3) + 2, CONFIG.MapHeight) * this.GameModel.TileSize)));
            }

            this.GameModel.Enemies = new List<Enemy>();
            for (int i = 0; i < CONFIG.NmbOfEnemies; i++)
            {
                this.GameModel.Enemies.Add(new Enemy((double)(CONFIG.MapWidth / 2 * this.GameModel.TileSize), (double)(r.Next((CONFIG.MapHeight / 3) + 2, CONFIG.MapHeight) * this.GameModel.TileSize)));
            }
        }

        /// <summary>
        /// Sets the initial state of the game.
        /// </summary>
        public void StartGame()
        {
            this.GameModel.Drill.Location[0] = CONFIG.MapWidth * this.GameModel.TileSize;
            this.GameModel.Drill.Location[1] = CONFIG.MapHeight / 3 * this.GameModel.TileSize;
            this.GameModel.Drill.InitialValue();
            this.GameModel.TotalPoints = 0;
            this.GameModel.ActualPoints = 0;
            this.GameModel.Minerals = new List<Mineral>();
            for (int i = 0; i < CONFIG.NmbOfMinerals; i++)
            {
                int typeSelector = r.Next(0, 3);
                if (typeSelector == 0)
                {
                    this.GameModel.Minerals.Add(new Mineral(r.Next(0, CONFIG.MapWidth * 2) * this.GameModel.TileSize, r.Next((CONFIG.MapHeight / 3) + 2, CONFIG.MapHeight) * this.GameModel.TileSize, MineralsType.Bronze)); // + 2 to avoid gameModel.Mineralss on the ground level
                }

                if (typeSelector == 1)
                {
                    this.GameModel.Minerals.Add(new Mineral(r.Next(0, CONFIG.MapWidth * 2) * this.GameModel.TileSize, r.Next((CONFIG.MapHeight / 3) + 2, CONFIG.MapHeight) * this.GameModel.TileSize, MineralsType.Silver));
                }

                if (typeSelector == 2)
                {
                    this.GameModel.Minerals.Add(new Mineral(r.Next(0, CONFIG.MapWidth * 2) * this.GameModel.TileSize, r.Next((CONFIG.MapHeight / 3) + 2, CONFIG.MapHeight) * this.GameModel.TileSize, MineralsType.Gold));
                }
            }
        }

        /// <summary>
        /// Sets the initial state of the map.
        /// </summary>
        public void InitialMap()
        {
            this.GameModel.TileSize = Math.Min(this.GameModel.GameWidth / CONFIG.MapWidth, this.GameModel.GameHeight / CONFIG.MapHeight);

            this.GameModel.Drill = new Drill(CONFIG.MapWidth * this.GameModel.TileSize, CONFIG.MapHeight / 3 * this.GameModel.TileSize);
            this.GameModel.SiloHouse = new SiloHouse(CONFIG.MapWidth * 3 / 2 * this.GameModel.TileSize, ((CONFIG.MapHeight / 3) * this.GameModel.TileSize) - (4 * this.GameModel.TileSize));
            this.GameModel.MachinistHouse = new MachinistHouse(CONFIG.MapWidth / 4 * this.GameModel.TileSize, ((CONFIG.MapHeight / 3) * this.GameModel.TileSize) - (4 * this.GameModel.TileSize));
        }

        /// <summary>
        /// Check game state.
        /// </summary>
        /// <param name="active">Change state game.</param>
        /// <returns>True if over.</returns>
        public bool GameOver(bool active = false)
        {
            if (active)
            {
                return false;
            }

            return this.GameModel.Drill.FuelTankFullness <= 0 || this.MoveLogic.CollisionWithEnemy() || this.MoveLogic.CollisionWithBomb();
        }
    }
}
