// <copyright file="DbLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HFG.Logic
{
    using System.Collections.Generic;
    using System.Linq;
    using HFG.Display;
    using HFG.Repository;

    /// <summary>
    /// Logic which related with the database.
    /// </summary>
    public class DbLogic : IDbLogic
    {
        private GameModel gameModel;
        private IDrillRepository drillRepo;
        private IBrickRepository brickRepo;
        private IConnRepository connRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="DbLogic"/> class.
        /// Sets the intial values of the properties.
        /// </summary>
        /// <param name="model">Initial GameModel.</param>
        /// <param name="drillRepo">Initial DrillRepository.</param>
        /// <param name="brickRepo">Initial BrickRepository.</param>
        /// <param name="connRepo">Initial ConnRepository.</param>
        public DbLogic(GameModel model, IDrillRepository drillRepo, IBrickRepository brickRepo, IConnRepository connRepo)
        {
            this.gameModel = model;
            this.drillRepo = drillRepo;
            this.brickRepo = brickRepo;
            this.connRepo = connRepo;
        }

        /// <summary>
        /// Modify THIS - repo is always not null
        /// Bool type to verify if there's a prev game or not . If false show a notification.
        /// </summary>
        /// <returns>True if there is a previously saved game.</returns>
        public bool LoadGame()
        {
            if (this.drillRepo.GetAll().Any() && this.brickRepo.GetAll().Any())
            {
                int max = this.drillRepo.GetAll().Select(x => x.drill_id).Max();
                var lastDrill = this.drillRepo.GetOne(max);

                this.gameModel.Drill.Location[0] = (int)lastDrill.drill_x;
                this.gameModel.Drill.Location[1] = (int)lastDrill.drill_y;
                this.gameModel.Drill.DrillLvl = (int)lastDrill.drill_speed;
                this.gameModel.Drill.FuelTankLvl = (int)lastDrill.drill_fuel;
                this.gameModel.Drill.StorageLvl = (int)lastDrill.drill_storage;

                var bricks = this.connRepo.GetAll().Where(x => x.conn_drill_id == lastDrill.drill_id).Select(x => x.conn_brick_id);
                int minID = (int)bricks.Min();

                foreach (Mineral mineral in this.gameModel.Minerals)
                {
                    var brick = this.brickRepo.GetOne(minID);
                    mineral.Location[0] = (int)brick.brick_x;
                    mineral.Location[1] = (int)brick.brick_y;
                    mineral.Type = ConvertToMineralsType(brick.brick_type.ToString());
                    minID++;
                }

                return true;
            }

            return false;
        }

        /// <summary>
        /// Save the actual state of the game.
        /// </summary>
        /// <param name="drill">Drill that has to be saved.</param>
        /// <param name="minerals">List of minerals that are have to be saved.</param>
        public void SaveGame(Drill drill, List<Mineral> minerals)
        {
            Database.drill newDrill = new Database.drill()
            {
                drill_x = (int)this.gameModel.Drill.Location[0],
                drill_y = (int)this.gameModel.Drill.Location[1],
                drill_score = this.gameModel.TotalPoints,
                drill_fuel = this.gameModel.Drill.FuelTankLvl,
                drill_storage = this.gameModel.Drill.StorageLvl,
                drill_speed = this.gameModel.Drill.DrillLvl,
            };
            this.drillRepo.Addnew(newDrill);
            foreach (Mineral mineral in minerals)
            {
                Database.brick newBrick = new Database.brick()
                {
                    brick_type = mineral.Type.ToString(),
                    brick_x = (int)mineral.Location[0],
                    brick_y = (int)mineral.Location[1],
                };
                this.brickRepo.Addnew(newBrick);
                this.connRepo.Addnew(new Database.conn()
                {
                    conn_brick_id = newBrick.brick_id,
                    conn_drill_id = newDrill.drill_id,
                });
            }
        }

        /// <summary>
        /// Lists HighScores.
        /// </summary>
        /// <returns>List of the top 5 highest score.</returns>
        public List<int?> Highscore()
        {
            List<int?> highScore = new List<int?>();
            if (this.drillRepo.GetAll().Any())
            {
                var scores = this.drillRepo.GetAll().Select(x => x.drill_score).Distinct().OrderByDescending(x => x);

                foreach (var score in scores)
                {
                    highScore.Add(score);
                }
            }

            return highScore;
        }

        /// <summary>
        /// Converting strings to MineralType.
        /// </summary>
        /// <param name="type">String that has to be converted.</param>
        /// <returns>Result MineralType of the convertion.</returns>
        private static MineralsType ConvertToMineralsType(string type)
        {
            if (type.ToLower() == "gold")
            {
                return MineralsType.Gold;
            }
            else if (type.ToLower() == "silver")
            {
                return MineralsType.Silver;
            }
            else
            {
                return MineralsType.Bronze;
            }
        }
    }
}
