using OENIK_PROG4_2020_1_LDK923_YCSNU5.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OENIK_PROG4_2020_1_LDK923_YCSNU5.Logic
{
    class GameLogic : IGameLogic
    {
        GameModel model;

        public GameLogic(GameModel model)
        {
            this.model = model;
            model.TileSize = Math.Min(model.GameWidth / Config.MapWidth, model.GameHeight / Config.MapHeight);
        }

        // When calling the MoveDrill(dx,dy) method in GameControl ==> dx and dy are equal to mode.drill.DrillLvl
        public void MoveDrill(int dx, int dy)
        {
            int newX = (int)(model.drill.Location.X + dx);
            int newY = (int)(model.drill.Location.Y + dy);
            if (newX >= 0 && newY >= 0 && newX < model.GameWidth && newY < model.GameHeight)
            {
                model.drill.Location = new Point(newX, newY);
            }
            if (CollisionWithSilo())
            {
                CalcTotalPoints();
                ClearStorage();
            }
            foreach (Minerals mineral in model.Minerals)
            {
                CollectMinerals(mineral);
            }
        }

        public bool CollisionWithSilo()
        {
            return model.drill.Location.X.Equals(model.SiloHouse.X) && model.drill.Location.Y.Equals(model.SiloHouse.Y);
        }

        public void CalcTotalPoints()
        {
            model.TotalPoints += model.ActualPoints;
        }

        public void ClearStorage()
        {
            model.drill.StorageFullness = 0;
            model.ActualPoints = 0;
        }

        public void CollectMinerals(Minerals min)
        {
            if (model.drill.Location.Equals(min.Location) && model.drill.StorageFullness < model.drill.StorageCapacity)
            {
                switch (min.Type)
                {
                    case MineralsType.Gold:
                        model.ActualPoints += Config.GoldPrice; model.drill.StorageFullness++;
                            break;
                    case MineralsType.Silver:
                        model.ActualPoints += Config.SilverPrice; model.drill.StorageFullness++;
                            break;
                    case MineralsType.Bronze:
                        model.ActualPoints += Config.BronzePrice; model.drill.StorageFullness++;
                            break;
                    default:
                            break;
                }
            }
        }

        // If returns true ==> game is over
        public bool FuelTick()
        {
            if (model.drill.FuelTankFullness > 0)
            {
                model.drill.FuelTankFullness--;
            }
            return model.drill.FuelTankFullness <= 0;
        }

        // If drill is above ground level it falls down.
        public void GravityTick()
        {
            if (model.drill.Location.Y < model.GameHeight / 3)
            {
                int dy = 1;
                int newY = (int)(model.drill.Location.Y + dy);
                dy++;
                model.drill.Location = new Point(model.drill.Location.X, newY);
            }
        }

        public void UpgradeDrill()
        {
            if (model.drill.DrillLvl < Config.MaxDrillLevel)
            {
                model.drill.DrillLvl++;
            }
        }

        public void UpgradeFuelTank()
        {
            if (model.drill.FuelTankLvl < Config.MaxFuelTankLevel)
            {
                model.drill.FuelTankLvl++;
                model.drill.FuelCapacity = model.drill.FuelTankLvl * 100;
            }
        }

        public void UpgradeStorage()
        {
            if (model.drill.StorageLvl < Config.MaxStorageLevel)
            {
                model.drill.StorageLvl++;
                model.drill.StorageCapacity = model.drill.StorageLvl * 100;
            }
        }

        // Not implemented yet
        // For upgrading I have to find out some better solution
        public bool Upgradeable()
        {
            throw new NotImplementedException();
        }
    }
}
