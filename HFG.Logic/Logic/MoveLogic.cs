using HFG.Display;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HFG.Logic
{
    /// <summary>
    /// CONTAIN ALL MOVE LOGIC INCLUDE WHAT HAPPEND IF IT COLLISION TO BOTH OF THE HOUSES
    /// </summary>
    public class MoveLogic : IMoveLogic
    {
        GameModel gameModel;

        public MoveLogic(GameModel model)
        {
            this.gameModel = model;
        }

        // When calling the MoveDrill(dx,dy) method in GameControl ==> dx and dy are equal to mode.drill.DrillLvl
        /// <summary>
        /// modifed move method, if colide with silo then plus actual point, and if collide with machinist then clear storage.
        /// </summary>
        /// <param name="dx"></param>
        /// <param name="dy"></param>
        public void MoveDrill(int dx, int dy)
        {
            for (int i = 0; i < this.gameModel.drill.DrillLvl; i++)
            {
                double newX = this.gameModel.drill.Location[0] + (dx * this.gameModel.TileSize);
                double newY = this.gameModel.drill.Location[1] + (dy * this.gameModel.TileSize);
                double startingPointToDrill = this.gameModel.GameHeight / 2 - this.gameModel.TileSize * 4;
                if (newX >= -1 && newY >= startingPointToDrill - 10 && newX <= this.gameModel.GameWidth && newY <= this.gameModel.GameHeight)
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

        }

        public bool CollisionWithSilo()
        {
            double siloX = gameModel.SiloHouse.Location[0];
            double siloY = gameModel.SiloHouse.Location[1];
            double siloHeight = gameModel.SiloHouse.Location[1] + 5 * gameModel.TileSize -10;
            double siloWidth = gameModel.SiloHouse.Location[0] + 3 * gameModel.TileSize;

            return siloX < gameModel.drill.Location[0] && siloWidth > gameModel.drill.Location[0]
                && siloY < gameModel.drill.Location[1] && siloHeight > gameModel.drill.Location[1];
        }

        public void CalcTotalPoints()
        {
            this.gameModel.TotalPoints += this.gameModel.ActualPoints;
        }

        public void ClearStorage()
        {
            this.gameModel.drill.StorageFullness = 0;
            this.gameModel.ActualPoints = 0;
            this.gameModel.drill.FuelTankFullness = this.gameModel.drill.FuelCapacity;
        }

        public void CollectMinerals(Mineral min)
        {
            double minX = gameModel.drill.Location[0] - 10;
            double maxX = minX + gameModel.TileSize;
            double minY = gameModel.drill.Location[1] - 10;
            double maxY = minY + gameModel.TileSize;

            Random R = new Random();

            if (minX <= min.Location[0] && maxX >= min.Location[0] && minY <= min.Location[1] && maxY >= min.Location[1]
                && this.gameModel.drill.StorageFullness < this.gameModel.drill.StorageCapacity)
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
                }
                min.Location[0] = R.Next(0, CONFIG.MapWidth * 2) * this.gameModel.TileSize;
                min.Location[1] = R.Next(CONFIG.MapHeight / 3 + 2, CONFIG.MapHeight) * this.gameModel.TileSize;
            }
        }

        public bool CollisionWithMachinist()
        {
            double machX = gameModel.MachinistHouse.Location[0];
            double machY = gameModel.MachinistHouse.Location[1];
            double machHeight = gameModel.MachinistHouse.Location[1] + 5 * gameModel.TileSize - 10;
            double machWidth = gameModel.MachinistHouse.Location[0] + 3 * gameModel.TileSize;

            return machX <= gameModel.drill.Location[0] && machWidth >= gameModel.drill.Location[0]
                && machY <= gameModel.drill.Location[1] && machHeight >= gameModel.drill.Location[1];
        }

        public void UpgradeDrill()
        {
            if (this.gameModel.drill.DrillLvl < CONFIG.MaxDrillLevel && this.gameModel.TotalPoints >= 5000)
            {
                this.gameModel.drill.DrillLvl++;
                this.gameModel.TotalPoints = this.gameModel.TotalPoints - 5000;
            }
        }

        public void UpgradeFuelTank()
        {
            if (this.gameModel.drill.FuelTankLvl < CONFIG.MaxFuelTankLevel && this.gameModel.TotalPoints >= 5000)
            {
                this.gameModel.drill.FuelTankLvl++;
                this.gameModel.drill.FuelCapacity = this.gameModel.drill.FuelTankLvl * 100;
                this.gameModel.TotalPoints = this.gameModel.TotalPoints - 5000;
            }
        }

        public void UpgradeStorage()
        {
            if (this.gameModel.drill.StorageLvl < CONFIG.MaxStorageLevel && this.gameModel.TotalPoints >= 5000)
            {
                this.gameModel.drill.StorageLvl++;
                this.gameModel.drill.StorageCapacity = this.gameModel.drill.StorageLvl * 10;
                this.gameModel.TotalPoints = this.gameModel.TotalPoints - 5000;

            }
        }
    }
}
