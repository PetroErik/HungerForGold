using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using HFG.Display;
using HFG.Repository;

namespace HFG.Logic
{
    public class GameLogic : IGameLogic
    {
        GameModel gameModel;
        IDrillRepository drillRepo;
        IBrickRepository brickRepo;
        IConnRepository connRepo;

        public GameLogic(GameModel model, IDrillRepository drillRepo, IBrickRepository brickRepo, IConnRepository connRepo)
        {
            this.gameModel = model;
            this.drillRepo = drillRepo;
            this.brickRepo = brickRepo;
            this.connRepo = connRepo;
            this.gameModel.TileSize = Math.Min(this.gameModel.GameWidth / CONFIG.MapWidth, this.gameModel.GameHeight / CONFIG.MapHeight);
        }

        static Random R = new Random();
        public void InitialMap()
        {
            this.gameModel.TileSize = Math.Min(this.gameModel.GameWidth / CONFIG.MapWidth, this.gameModel.GameHeight / CONFIG.MapHeight);
            this.gameModel.TotalPoints = 0;
            this.gameModel.ActualPoints = 0;
            this.gameModel.drill = new Drill(CONFIG.MapWidth * this.gameModel.TileSize, CONFIG.MapHeight / 3 * this.gameModel.TileSize);                                // Ground level is at GameHeight / 3
            this.gameModel.SiloHouse = new SiloHouse(CONFIG.MapWidth * 3 / 2 * this.gameModel.TileSize, CONFIG.MapHeight / 3 * this.gameModel.TileSize - 4 * this.gameModel.TileSize);     // Silo is 4 tile higher than the drill
            this.gameModel.MachinistHouse = new MachinistHouse(CONFIG.MapWidth / 4 * this.gameModel.TileSize, CONFIG.MapHeight / 3 * this.gameModel.TileSize - 4 * this.gameModel.TileSize);
            this.gameModel.Minerals = new List<Mineral>();

            for (int i = 0; i < 30; i++)
            {
                int typeSelector = R.Next(0, 3);
                if (typeSelector == 0)
                {
                    gameModel.Minerals.Add(new Mineral(R.Next(0, CONFIG.MapWidth * 2) * this.gameModel.TileSize, (R.Next(CONFIG.MapHeight / 3 + 2, CONFIG.MapHeight) * this.gameModel.TileSize), MineralsType.Bronze)); // + 2 to avoid gameModel.Mineralss on the ground level
                }
                if (typeSelector == 1)
                {
                    gameModel.Minerals.Add(new Mineral(R.Next(0, CONFIG.MapWidth * 2) * this.gameModel.TileSize, (R.Next(CONFIG.MapHeight / 3 + 2, CONFIG.MapHeight) * this.gameModel.TileSize), MineralsType.Silver));
                }
                if (typeSelector == 2)
                {
                    gameModel.Minerals.Add(new Mineral(R.Next(0, CONFIG.MapWidth * 2) * this.gameModel.TileSize, (R.Next(CONFIG.MapHeight / 3 + 2, CONFIG.MapHeight) * this.gameModel.TileSize), MineralsType.Gold));
                }
            }
        }

        // When calling the MoveDrill(dx,dy) method in GameControl ==> dx and dy are equal to mode.drill.DrillLvl
        public void MoveDrill(int dx, int dy)
        {
            double newX = (this.gameModel.drill.Location[0] + (dx * this.gameModel.TileSize));
            double newY = (this.gameModel.drill.Location[1] + (dy * this.gameModel.TileSize));

            if (newX >= 0 && newY >= 0 && newX < this.gameModel.GameWidth && newY < this.gameModel.GameHeight)
            {
                this.gameModel.drill.Location[0] = newX;
                this.gameModel.drill.Location[1] = newY;
            }
            if (CollisionWithSilo())
            {
                CalcTotalPoints();
                ClearStorage();
            }
            foreach (Mineral mineral in this.gameModel.Minerals)
            {
                CollectMinerals(mineral);
            }
        }

        public bool CollisionWithSilo()
        {
            return this.gameModel.drill.Location[0].Equals(this.gameModel.SiloHouse.Location[0]) && this.gameModel.drill.Location[1].Equals(this.gameModel.SiloHouse.Location[1]);
        }

        public void CalcTotalPoints()
        {
            this.gameModel.TotalPoints += this.gameModel.ActualPoints;
        }

        public void ClearStorage()
        {
            this.gameModel.drill.StorageFullness = 0;
            this.gameModel.ActualPoints = 0;
        }

        public void CollectMinerals(Mineral min)
        {
            if (this.gameModel.drill.Location.Equals(min.Location) && this.gameModel.drill.StorageFullness < this.gameModel.drill.StorageCapacity)
            {
                switch (min.Type)
                {
                    case MineralsType.Gold:
                        this.gameModel.ActualPoints += CONFIG.GoldPrice; this.gameModel.drill.StorageFullness++;
                        break;
                    case MineralsType.Silver:
                        this.gameModel.ActualPoints += CONFIG.SilverPrice; this.gameModel.drill.StorageFullness++;
                        break;
                    case MineralsType.Bronze:
                        this.gameModel.ActualPoints += CONFIG.BronzePrice; this.gameModel.drill.StorageFullness++;
                        break;
                    default:
                        break;
                }
            }
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
            if (this.gameModel.drill.Location[1] < ((this.gameModel.GameHeight / 3) - this.gameModel.TileSize))
            {
                int dy = 10;
                int newY = (int)(this.gameModel.drill.Location[1] + dy);
                dy += 10;
                this.gameModel.drill.Location = new double[2] { this.gameModel.drill.Location[0], newY };
            }
        }

        public void UpgradeDrill()
        {
            if (this.gameModel.drill.DrillLvl < CONFIG.MaxDrillLevel)
            {
                this.gameModel.drill.DrillLvl++;
            }
        }

        public void UpgradeFuelTank()
        {
            if (this.gameModel.drill.FuelTankLvl < CONFIG.MaxFuelTankLevel)
            {
                this.gameModel.drill.FuelTankLvl++;
                this.gameModel.drill.FuelCapacity = this.gameModel.drill.FuelTankLvl * 100;
            }
        }

        public void UpgradeStorage()
        {
            if (this.gameModel.drill.StorageLvl < CONFIG.MaxStorageLevel)
            {
                this.gameModel.drill.StorageLvl++;
                this.gameModel.drill.StorageCapacity = this.gameModel.drill.StorageLvl * 100;
                
            }
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

        // Not implemented yet
        // For upgrading I have to find out some better solution
        public bool Upgradeable()
        {
            throw new NotImplementedException();
        }

        public void LoadGame()
        {
            throw new NotImplementedException();
        }
    }
}
