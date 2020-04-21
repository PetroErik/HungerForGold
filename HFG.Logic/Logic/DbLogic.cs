using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HFG.Display;
using HFG.Repository;

namespace HFG.Logic
{
    /// <summary>
    /// LOGIC WHICH RELATED WHICH THE DATABASE
    /// </summary>
    public class DbLogic : IDbLogic
    {
        GameModel gameModel;
        IDrillRepository drillRepo;
        IBrickRepository brickRepo;
        IConnRepository connRepo;

        public DbLogic(GameModel model, IDrillRepository drillRepo, IBrickRepository brickRepo, IConnRepository connRepo)
        {
            this.gameModel = model;
            this.drillRepo = drillRepo;
            this.brickRepo = brickRepo;
            this.connRepo = connRepo;
        }

        // Loads the last saved state of the game.

        /// <summary>
        /// Modify THIS - repo is always not null
        /// bool type to verify if there's a prev game or not . If false show a notification  
        /// </summary>
        public bool LoadGame()
        {
            if (drillRepo.GetAll().Any() && brickRepo.GetAll().Any())
            {
                int max = drillRepo.GetAll().Select(x => x.drill_id).Max();
                var lastDrill = drillRepo.GetOne(max);

                gameModel.drill.Location[0] = (int)lastDrill.drill_x;
                gameModel.drill.Location[1] = (int)lastDrill.drill_y;
                gameModel.drill.DrillLvl = (int)lastDrill.drill_speed;
                gameModel.drill.FuelTankLvl = (int)lastDrill.drill_fuel;
                gameModel.drill.StorageLvl = (int)lastDrill.drill_storage;

                var bricks = connRepo.GetAll().Where(x => x.conn_drill_id == lastDrill.drill_id).Select(x => x.conn_brick_id);
                int minID = (int)bricks.Min();

                foreach (Mineral mineral in gameModel.Minerals)
                {
                    var brick = brickRepo.GetOne(minID);
                    mineral.Location[0] = (int)brick.brick_x;
                    mineral.Location[1] = (int)brick.brick_y;
                    mineral.Type = ConvertToMineralsType(brick.brick_type.ToString());
                    minID++;
                }
                return true;
            }
            return false;
        }

        public void SaveGame(Drill drill, List<Mineral> minerals)
        {
            Database.drill newDrill = new Database.drill()
            {
                drill_x = (int)gameModel.drill.Location[0],
                drill_y = (int)gameModel.drill.Location[1],
                drill_score = gameModel.TotalPoints,
                drill_fuel = gameModel.drill.FuelTankLvl,
                drill_storage = gameModel.drill.StorageLvl,
                drill_speed = gameModel.drill.DrillLvl
            };
            drillRepo.Addnew(newDrill);
            foreach (Mineral mineral in minerals)
            {
                Database.brick newBrick = new Database.brick()
                {
                    brick_type = mineral.Type.ToString(),
                    brick_x = (int)mineral.Location[0],
                    brick_y = (int)mineral.Location[1]
                };
                brickRepo.Addnew(newBrick);
                connRepo.Addnew(new Database.conn()
                {
                    conn_brick_id = newBrick.brick_id,
                    conn_drill_id = newDrill.drill_id,
                });
            }
        }

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

        public List<int?> Highscore()
        {
            List<int?> highScore = new List<int?>();
            if (drillRepo.GetAll().Any())
            {
                var scores = drillRepo.GetAll().Select(x => x.drill_score).Distinct().OrderByDescending(x => x);

                foreach (var score in scores)
                {
                    highScore.Add(score);
                }

            }
            return highScore;
        }
    }
}
