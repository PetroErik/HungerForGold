// <copyright file="MoveLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HFG.Logic
{
    using System;
    using HFG.Display;
    using HFG.Display.Elements;

    /// <summary>
    /// Contain all move logic include what happends if the drill colliedes with other elements.
    /// </summary>
    public class MoveLogic : IMoveLogic
    {
        private GameModel gameModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="MoveLogic"/> class.
        /// </summary>
        /// <param name="model">GameModel instance.</param>
        public MoveLogic(GameModel model)
        {
            this.gameModel = model;
        }

        /// <summary>
        /// Defines the movement of the drill.
        /// </summary>
        /// <param name="dx">Movement vector to the x direction.</param>
        /// <param name="dy">Movement vector to the y direction.</param>
        public void MoveDrill(int dx, int dy)
        {
            for (int i = 0; i < this.gameModel.Drill.DrillLvl; i++)
            {
                double newX = this.gameModel.Drill.Location[0] + (dx * this.gameModel.TileSize);
                double newY = this.gameModel.Drill.Location[1] + (dy * this.gameModel.TileSize);
                double startingPointToDrill = (this.gameModel.GameHeight / 2) - (this.gameModel.TileSize * 4);
                if (newX >= -1 && newY >= startingPointToDrill - 10 && newX <= this.gameModel.GameWidth && newY <= this.gameModel.GameHeight)
                {
                    this.gameModel.Drill.Location[0] = newX;
                    this.gameModel.Drill.Location[1] = newY;
                }

                if (this.CollisionWithSilo())
                {
                    this.CalcTotalPoints();
                    this.ClearStorage();
                }

                foreach (Mineral mineral in this.gameModel.Minerals)
                {
                    this.CollectMinerals(mineral);
                }

            }
        }

        /// <summary>
        /// Checks if the drill hits the Silo.
        /// </summary>
        /// <returns>True if the drill is colliding with the Silo.</returns>
        public bool CollisionWithSilo()
        {
            double siloX = this.gameModel.SiloHouse.Location[0];
            double siloY = this.gameModel.SiloHouse.Location[1];
            double siloHeight = this.gameModel.SiloHouse.Location[1] + (5 * this.gameModel.TileSize) - 10;
            double siloWidth = this.gameModel.SiloHouse.Location[0] + (3 * this.gameModel.TileSize);

            return siloX < this.gameModel.Drill.Location[0] && siloWidth > this.gameModel.Drill.Location[0]
                && siloY < this.gameModel.Drill.Location[1] && siloHeight > this.gameModel.Drill.Location[1];
        }

        /// <summary>
        /// Add the actual points to the TotalPoints.
        /// </summary>
        public void CalcTotalPoints()
        {
            this.gameModel.TotalPoints += this.gameModel.ActualPoints;
        }

        /// <summary>
        /// Sets the Storage and FuelTank element to the initial state.
        /// </summary>
        public void ClearStorage()
        {
            this.gameModel.Drill.StorageFullness = 0;
            this.gameModel.ActualPoints = 0;
            this.gameModel.Drill.FuelTankFullness = this.gameModel.Drill.FuelCapacity;
        }

        /// <summary>
        /// When the drill hits a mineral item, then it collects it.
        /// </summary>
        /// <param name="min">Mineral that the drill is colliding with.</param>
        public void CollectMinerals(Mineral min)
        {
            double minX = this.gameModel.Drill.Location[0] - 10;
            double maxX = minX + this.gameModel.TileSize;
            double minY = this.gameModel.Drill.Location[1] - 10;
            double maxY = minY + this.gameModel.TileSize;

            Random r = new Random();

            if (minX <= min.Location[0] && maxX >= min.Location[0] && minY <= min.Location[1] && maxY >= min.Location[1]
                && this.gameModel.Drill.StorageFullness < this.gameModel.Drill.StorageCapacity)
            {
                switch (min.Type)
                {
                    case MineralsType.Gold:
                        this.gameModel.ActualPoints += CONFIG.GoldPrice; this.gameModel.Drill.StorageFullness++;
                        break;
                    case MineralsType.Silver:
                        this.gameModel.ActualPoints += CONFIG.SilverPrice; this.gameModel.Drill.StorageFullness++;
                        break;
                    case MineralsType.Bronze:
                        this.gameModel.ActualPoints += CONFIG.BronzePrice; this.gameModel.Drill.StorageFullness++;
                        break;
                }

                min.Location[0] = r.Next(0, CONFIG.MapWidth * 2) * this.gameModel.TileSize;
                min.Location[1] = r.Next((CONFIG.MapHeight / 3) + 2, CONFIG.MapHeight) * this.gameModel.TileSize;
            }
        }

        /// <summary>
        /// Checks if the drill hits the Machinist.
        /// </summary>
        /// <returns>True if the drill is colliding with the Machinist.</returns>
        public bool CollisionWithMachinist()
        {
            double machX = this.gameModel.MachinistHouse.Location[0];
            double machY = this.gameModel.MachinistHouse.Location[1];
            double machHeight = this.gameModel.MachinistHouse.Location[1] + (5 * this.gameModel.TileSize) - 10;
            double machWidth = this.gameModel.MachinistHouse.Location[0] + (3 * this.gameModel.TileSize);

            return machX <= this.gameModel.Drill.Location[0] && machWidth >= this.gameModel.Drill.Location[0]
                && machY <= this.gameModel.Drill.Location[1] && machHeight >= this.gameModel.Drill.Location[1];
        }

        /// <summary>
        /// Check if the drill collieded with any of the enemies.
        /// </summary>
        /// <returns>True if the drill hit any of the enemies.</returns>
        public bool CollisionWithEnemy()
        {
            double minX = this.gameModel.Drill.Location[0] - 10;
            double maxX = minX + this.gameModel.TileSize - 10;
            double minY = this.gameModel.Drill.Location[1] - 10;
            double maxY = minY + this.gameModel.TileSize - 10;

            foreach (Enemy enemy in this.gameModel.Enemies)
            {
                if (minX <= enemy.Location[0] && maxX >= enemy.Location[0] && minY <= enemy.Location[1] && maxY >= enemy.Location[1])
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Check if the drill collieded with any of the bombs.
        /// </summary>
        /// <returns>True if the drill hit any of the bombs.</returns>
        public bool CollisionWithBomb()
        {
            double minX = this.gameModel.Drill.Location[0] - 10;
            double maxX = minX + this.gameModel.TileSize;
            double minY = this.gameModel.Drill.Location[1] - 10;
            double maxY = minY + this.gameModel.TileSize;

            foreach (Bomb bomb in this.gameModel.Bombs)
            {
                if (minX <= bomb.Location[0] + 2 * this.gameModel.TileSize - 10
                    && maxX >= bomb.Location[0] - 2 * this.gameModel.TileSize - 10
                    && minY <= bomb.Location[1] + 2 * this.gameModel.TileSize - 10
                    && maxY >= bomb.Location[1] - 2 * this.gameModel.TileSize - 10)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Upgrade the drill element.
        /// </summary>
        public void UpgradeDrill()
        {
            if (this.gameModel.Drill.DrillLvl < CONFIG.MaxDrillLevel && this.gameModel.TotalPoints >= 5000)
            {
                this.gameModel.Drill.DrillLvl++;
                this.gameModel.TotalPoints = this.gameModel.TotalPoints - 5000;
            }
        }

        /// <summary>
        /// Upgrade the FuelTank element.
        /// </summary>
        public void UpgradeFuelTank()
        {
            if (this.gameModel.Drill.FuelTankLvl < CONFIG.MaxFuelTankLevel && this.gameModel.TotalPoints >= 5000)
            {
                this.gameModel.Drill.FuelTankLvl++;
                this.gameModel.Drill.FuelCapacity = this.gameModel.Drill.FuelTankLvl * 100;
                this.gameModel.TotalPoints = this.gameModel.TotalPoints - 5000;
            }
        }

        /// <summary>
        /// Upgrade the Storage element.
        /// </summary>
        public void UpgradeStorage()
        {
            if (this.gameModel.Drill.StorageLvl < CONFIG.MaxStorageLevel && this.gameModel.TotalPoints >= 5000)
            {
                this.gameModel.Drill.StorageLvl++;
                this.gameModel.Drill.StorageCapacity = this.gameModel.Drill.StorageLvl * 10;
                this.gameModel.TotalPoints = this.gameModel.TotalPoints - 5000;
            }
        }
    }
}
