// <copyright file="GameLogicTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HFG.Tests
{
    using HFG.Display;
    using HFG.Display.Elements;
    using HFG.Logic;
    using NUnit.Framework;

    /// <summary>
    /// Tests for GameLogic.
    /// </summary>
    [TestFixture]
    public class GameLogicTest
    {
        GameLogic logic;
        GameModel gameModel;

        Mineral min;
        Enemy enemy;
        Bomb bomb;

       [SetUp]
        public void SetUp()
        {
            this.gameModel = new GameModel(500, 500);
            this.logic = new GameLogic(this.gameModel);
            this.logic.InitialMap();
            this.logic.StartGame();
            this.min = new Mineral(5, 5, MineralsType.Gold);
            this.enemy = new Enemy(10, 10);
            this.bomb = new Bomb(10, 10);
        }

        /// <summary>
        /// Tests if the constructor work properly.
        /// </summary>
        [Test]
        public void TestGameLogic_Ctor()
        {
            Assert.That(this.logic.DbLogic, Is.Not.EqualTo(null));
            Assert.That(this.logic.GameModel.TileSize, Is.Not.EqualTo(0));
        }

        /// <summary>
        /// Tests of the StartGame method works.
        /// </summary>
        [Test]
        public void TestGameLogic_StartGame()
        {
            Assert.That(this.logic.GameModel.Minerals, Is.Not.EqualTo(null));
            Assert.That(this.logic.GameModel.Minerals.Count, Is.EqualTo(CONFIG.NmbOfMinerals));
            Assert.That(this.logic.GameModel.ActualPoints, Is.EqualTo(0));
            Assert.That(this.logic.GameModel.TotalPoints, Is.EqualTo(0));
        }

        /// <summary>
        /// Test the FuelTick method when the fuel tank is not empty.
        /// </summary>
        /// 

        [Test]
        public void TestTickLogic_FuelTick_WhenFuelNotNull()
        {
            logic.GameModel.Drill.FuelTankFullness = 40;

            logic.TickLogic.FuelTick();

            Assert.That(logic.GameModel.Drill.FuelTankFullness, Is.EqualTo(39));
        }

        /// <summary>
        /// Test the FuelTick method when the fuel tank is empty.
        /// </summary>
        [Test]
        public void TestTickLogic_FuelTick_WhenFuelNull()
        {
            logic.GameModel.Drill.FuelTankFullness = 0;

            logic.TickLogic.FuelTick();

            Assert.That(logic.GameModel.Drill.FuelTankFullness, Is.EqualTo(0));
        }

        /// <summary>
        /// Test the UpgradeFuelTank method when FuelTank is not on max level.
        /// </summary>
        [Test]
        public void TestUpgradeLogic_UpgradeFuelTank_WhenNotMaxLevel()
        {
            logic.GameModel.TotalPoints = 5000;

            logic.MoveLogic.UpgradeFuelTank();

            Assert.That(logic.GameModel.Drill.FuelTankLvl, Is.EqualTo(2));
        }

        /// <summary>
        /// Test the UpgradeFuelTank method when FuelTank is on max level.
        /// </summary>
        [Test]
        public void TestUpgradeLogic_UpgradeFuelTank_WhenMaxLevel()
        {
            logic.GameModel.Drill.FuelTankLvl = 3;

            logic.MoveLogic.UpgradeFuelTank();

            Assert.That(logic.GameModel.Drill.FuelTankLvl, Is.EqualTo(3));
        }

        /// <summary>
        /// Test the UpgradeDrill method when Drill is not on max level.
        /// </summary>
        [Test]
        public void TestUpgradeLogic_UpgradeDrill_WhenNotMaxLevel()
        {
            logic.GameModel.TotalPoints = 5000;

            logic.MoveLogic.UpgradeDrill();

            Assert.That(logic.GameModel.Drill.DrillLvl, Is.EqualTo(2));
        }

        /// <summary>
        /// Test the UpgradeDrill method when Drill is on max level.
        /// </summary>
        [Test]
        public void TestUpgradeLogic_UpgradeDrill_WhenMaxLevel()
        {
            logic.GameModel.Drill.DrillLvl = 3;

            logic.MoveLogic.UpgradeFuelTank();

            Assert.That(logic.GameModel.Drill.DrillLvl, Is.EqualTo(3));
        }

        /// <summary>
        /// Test the UpgradeStorage method when Storage is not on max level.
        /// </summary>
        [Test]
        public void TestUpgradeLogic_UpgradeStorage_WhenNotMaxLevel()
        {
            logic.GameModel.TotalPoints = 5000;

            logic.MoveLogic.UpgradeStorage();

            Assert.That(logic.GameModel.Drill.StorageLvl, Is.EqualTo(2));
        }

        /// <summary>
        /// Test the UpgradeStorage method when Storage is on max level.
        /// </summary>
        [Test]
        public void TestUpgradeLogic_UpgradeStorage_WhenMaxLevel()
        {
            logic.GameModel.Drill.StorageLvl = 3;

            logic.MoveLogic.UpgradeFuelTank();

            Assert.That(logic.GameModel.Drill.StorageLvl, Is.EqualTo(3));
        }

        /// <summary>
        /// Test if the MoveDrill method works well.
        /// </summary>
        [Test]
        public void TestMoveLogic_MoveDrill()
        {
            logic.GameModel.Drill.Location = new double[] { 300, 300 };

            logic.MoveLogic.MoveDrill(1, 1);

            Assert.That(logic.GameModel.Drill.Location[0], Is.EqualTo(300 + logic.GameModel.TileSize));
            Assert.That(logic.GameModel.Drill.Location[1], Is.EqualTo(300 + logic.GameModel.TileSize));
        }

        /// <summary>
        /// Test the MoveLogic if the drill is on the left border of the screen.
        /// </summary>
        [Test]
        public void TestMoveLogic_MoveDrill_ToLeftBorder()
        {
            logic.GameModel.Drill.Location = new double[] { 5, 5 };

            logic.MoveLogic.MoveDrill(-1, 0);

            Assert.That(logic.GameModel.Drill.Location[0], Is.EqualTo(5));
            Assert.That(logic.GameModel.Drill.Location[1], Is.EqualTo(5));
        }

        /// <summary>
        /// Test the MoveLogic if the drill is on the upper border of the screen.
        /// </summary>
        [Test]
        public void TestMoveLogic_MoveDrill_ToUpBorder()
        {
            logic.GameModel.Drill.Location = new double[] { 5, 5 };

            logic.MoveLogic.MoveDrill(0, -1);

            Assert.That(logic.GameModel.Drill.Location[0], Is.EqualTo(5));
            Assert.That(logic.GameModel.Drill.Location[1], Is.EqualTo(5));
        }

        /// <summary>
        /// Test the MoveLogic if the drill is on the right border of the screen.
        /// </summary>
        [Test]
        public void TestMoveLogic_MoveDrill_ToRightBorder()
        {
            logic.GameModel.Drill.Location = new double[] { 490, 490 };

            logic.MoveLogic.MoveDrill(1, 0);

            Assert.That(logic.GameModel.Drill.Location[0], Is.EqualTo(490));
            Assert.That(logic.GameModel.Drill.Location[1], Is.EqualTo(490));
        }

        /// <summary>
        /// Test the MoveLogic if the drill is on the bottom border of the screen.
        /// </summary>
        [Test]
        public void TestMoveLogic_MoveDrill_ToDownBorder()
        {
            logic.GameModel.Drill.Location = new double[] { 490, 490 };

            logic.MoveLogic.MoveDrill(0, 1);

            Assert.That(logic.GameModel.Drill.Location[0], Is.EqualTo(490));
            Assert.That(logic.GameModel.Drill.Location[1], Is.EqualTo(490));
        }

        /// <summary>
        /// Test the collisionWithSilo method.
        /// </summary>
        [Test]
        public void TestMoveLogic_CollisionWithSilo()
        {
            this.gameModel.Drill.Location = new double[] { 15, 15 };
            this.gameModel.SiloHouse.Location = new double[] { 0, 0 };

            bool result = logic.MoveLogic.CollisionWithSilo();

            Assert.That(result, Is.EqualTo(true));
        }

        /// <summary>
        /// Test the collisionWithMachinist method.
        /// </summary>
        [Test]
        public void TestMoveLogic_CollisionWithMachinsit()
        {
            this.gameModel.Drill.Location = new double[] { 15, 15 };
            this.gameModel.MachinistHouse.Location = new double[] { 15, 15 };

            bool result = logic.MoveLogic.CollisionWithMachinist();

            Assert.That(result, Is.EqualTo(true));
        }

        /// <summary>
        /// Test the CalcTotalPoints method.
        /// </summary>
        [Test]
        public void TestMoveLogic_CalcTotalPoints()
        {
            logic.GameModel.ActualPoints = 100;
            logic.GameModel.TotalPoints = 0;

            logic.MoveLogic.CalcTotalPoints();

            Assert.That(logic.GameModel.TotalPoints, Is.EqualTo(100));
        }

        /// <summary>
        /// Test the ClearStorage method.
        /// </summary>
        [Test]
        public void TestMoveLogic_ClearStorage()
        {
            logic.GameModel.Drill.StorageFullness = 50;
            logic.GameModel.ActualPoints = 300;

            logic.MoveLogic.ClearStorage();

            Assert.That(logic.GameModel.Drill.StorageFullness, Is.EqualTo(0));
            Assert.That(logic.GameModel.ActualPoints, Is.EqualTo(0));
        }

        /// <summary>
        /// Test the collection of minerals when the storage is not full.
        /// </summary>
        [Test]
        public void TestMoveLogic_CollectMineral_WhenStorageNotFull()
        {
            logic.GameModel.Drill.Location = new double[] { 5, 5 };

            logic.MoveLogic.CollectMinerals(min);

            Assert.That(logic.GameModel.ActualPoints, Is.EqualTo(300));
            Assert.That(logic.GameModel.Drill.StorageFullness, Is.EqualTo(1));
        }

        /// <summary>
        /// Test the collection of a mineral when the storage is full.
        /// </summary>
        [Test]
        public void TestMoveLogic_CollectMineral_WhenStorageFull()
        {
            logic.GameModel.Drill.Location = new double[] { 5, 5 };
            logic.GameModel.Drill.StorageFullness = logic.GameModel.Drill.StorageCapacity;
            logic.GameModel.ActualPoints = 100;

            logic.MoveLogic.CollectMinerals(min);

            Assert.That(logic.GameModel.ActualPoints, Is.EqualTo(100));
            Assert.That(logic.GameModel.Drill.StorageFullness, Is.EqualTo(logic.GameModel.Drill.StorageCapacity));
        }

        /// <summary>
        /// Tests if the collision with enemy method works properly.
        /// </summary>
        [Test]
        public void TestMoveLogic_CollisionWithEnemy()
        {
            logic.GameModel.Drill.Location = new double[] { 10, 10 };
            logic.GameModel.Enemies.Add(enemy);

            bool result = logic.MoveLogic.CollisionWithEnemy();

            Assert.That(result, Is.True);
        }

        /// <summary>
        /// Tests if the collision with bomb method works properly.
        /// </summary>
        public void TestMoveLogic_CollisionWithBomb()
        {
            logic.GameModel.Drill.Location = new double[] { 10, 10 };
            logic.GameModel.Bombs.Add(bomb);

            bool result = logic.MoveLogic.CollisionWithBomb();

            Assert.That(result, Is.True);
        }
    }
}
