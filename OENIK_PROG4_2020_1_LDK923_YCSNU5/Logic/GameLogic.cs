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
        }

        // If returns true ==> game is over
        public bool FuelUse()
        {
            if (model.drill.FuelTankFullness > 0)
            {
                model.drill.FuelTankFullness--;
            }
            return model.drill.FuelTankFullness == 0;
        }

        // Leveling system is bad... I have to find out something better.
        public void CollectMinerals(Minerals min)
        {
            foreach (Minerals mineral in model.Minerals)
            {
                if (model.drill.Location.Equals(mineral.Location) && model.drill.StorageFullness < Config.StorageLvl1)
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
        }

        // Not implemented yet
        // For upgrading I have to find out some better solution
        public bool Upgradeable()
        {
            throw new NotImplementedException();
        }

        public void UpgradeDrill()
        {
            if (model.drill.DrillLvl == 1)
            {
                model.drill.DrillLvl = 2;
                model.drill.ActualDrillSize = Config.DrillLvl2;
            }
            if (model.drill.DrillLvl == 2)
            {
                model.drill.DrillLvl = 3;
                model.drill.ActualDrillSize = Config.DrillLvl3;
            }
            else
            {
                model.drill.DrillLvl = 3;
                model.drill.ActualDrillSize = Config.DrillLvl3;
            }
        }

        public void UpgradeFuelTank()
        {
            throw new NotImplementedException();
        }

        public void UpgradeStorage()
        {
            throw new NotImplementedException();
        }
    }
}
