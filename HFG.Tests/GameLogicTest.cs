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
        private GameLogic logic;
        private GameModel gameModel;

        private Mineral min;
        private Enemy enemy;
        private Bomb bomb;

        /// <summary>
        /// Set up is an attribute used inside a [TestFixture]
        /// to provide a common set of functions that are performed
        /// just before each test method is called. Can only have 1 setup,
        /// if more than 1 the tests will not run .
        /// </summary>
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
            this.logic.GameModel.Drill.FuelTankFullness = 40;

            this.logic.TickLogic.FuelTick();

            Assert.That(this.logic.GameModel.Drill.FuelTankFullness, Is.EqualTo(39));
        }

        /// <summary>
        /// Test the FuelTick method when the fuel tank is empty.
        /// </summary>
        [Test]
        public void TestTickLogic_FuelTick_WhenFuelNull()
        {
            this.logic.GameModel.Drill.FuelTankFullness = 0;

            this.logic.TickLogic.FuelTick();

            Assert.That(this.logic.GameModel.Drill.FuelTankFullness, Is.EqualTo(0));
        }

        /// <summary>
        /// Test the UpgradeFuelTank method when FuelTank is not on max level.
        /// </summary>
        [Test]
        public void TestUpgradeLogic_UpgradeFuelTank_WhenNotMaxLevel()
        {
            this.logic.GameModel.TotalPoints = 5000;

            this.logic.MoveLogic.UpgradeFuelTank();

            Assert.That(this.logic.GameModel.Drill.FuelTankLvl, Is.EqualTo(2));
        }

        /// <summary>
        /// Test the UpgradeFuelTank method when FuelTank is on max level.
        /// </summary>
        [Test]
        public void TestUpgradeLogic_UpgradeFuelTank_WhenMaxLevel()
        {
            this.logic.GameModel.Drill.FuelTankLvl = 3;

            this.logic.MoveLogic.UpgradeFuelTank();

            Assert.That(this.logic.GameModel.Drill.FuelTankLvl, Is.EqualTo(3));
        }

        /// <summary>
        /// Test the UpgradeDrill method when Drill is not on max level.
        /// </summary>
        [Test]
        public void TestUpgradeLogic_UpgradeDrill_WhenNotMaxLevel()
        {
            this.logic.GameModel.TotalPoints = 5000;

            this.logic.MoveLogic.UpgradeDrill();

            Assert.That(this.logic.GameModel.Drill.DrillLvl, Is.EqualTo(2));
        }

        /// <summary>
        /// Test the UpgradeDrill method when Drill is on max level.
        /// </summary>
        [Test]
        public void TestUpgradeLogic_UpgradeDrill_WhenMaxLevel()
        {
            this.logic.GameModel.Drill.DrillLvl = 3;

            this.logic.MoveLogic.UpgradeFuelTank();

            Assert.That(this.logic.GameModel.Drill.DrillLvl, Is.EqualTo(3));
        }

        /// <summary>
        /// Test the UpgradeStorage method when Storage is not on max level.
        /// </summary>
        [Test]
        public void TestUpgradeLogic_UpgradeStorage_WhenNotMaxLevel()
        {
            this.logic.GameModel.TotalPoints = 5000;

            this.logic.MoveLogic.UpgradeStorage();

            Assert.That(this.logic.GameModel.Drill.StorageLvl, Is.EqualTo(2));
        }

        /// <summary>
        /// Test the UpgradeStorage method when Storage is on max level.
        /// </summary>
        [Test]
        public void TestUpgradeLogic_UpgradeStorage_WhenMaxLevel()
        {
            this.logic.GameModel.Drill.StorageLvl = 3;

            this.logic.MoveLogic.UpgradeFuelTank();

            Assert.That(this.logic.GameModel.Drill.StorageLvl, Is.EqualTo(3));
        }

        /// <summary>
        /// Test if the MoveDrill method works well.
        /// </summary>
        [Test]
        public void TestMoveLogic_MoveDrill()
        {
            this.logic.GameModel.Drill.Location = new double[] { 300, 300 };

            this.logic.MoveLogic.MoveDrill(1, 1);

            Assert.That(this.logic.GameModel.Drill.Location[0], Is.EqualTo(300 + this.logic.GameModel.TileSize));
            Assert.That(this.logic.GameModel.Drill.Location[1], Is.EqualTo(300 + this.logic.GameModel.TileSize));
        }

        /// <summary>
        /// Test the MoveLogic if the drill is on the left border of the screen.
        /// </summary>
        [Test]
        public void TestMoveLogic_MoveDrill_ToLeftBorder()
        {
            this.logic.GameModel.Drill.Location = new double[] { 5, 5 };

            this.logic.MoveLogic.MoveDrill(-1, 0);

            Assert.That(this.logic.GameModel.Drill.Location[0], Is.EqualTo(5));
            Assert.That(this.logic.GameModel.Drill.Location[1], Is.EqualTo(5));
        }

        /// <summary>
        /// Test the MoveLogic if the drill is on the upper border of the screen.
        /// </summary>
        [Test]
        public void TestMoveLogic_MoveDrill_ToUpBorder()
        {
            this.logic.GameModel.Drill.Location = new double[] { 5, 5 };

            this.logic.MoveLogic.MoveDrill(0, -1);

            Assert.That(this.logic.GameModel.Drill.Location[0], Is.EqualTo(5));
            Assert.That(this.logic.GameModel.Drill.Location[1], Is.EqualTo(5));
        }

        /// <summary>
        /// Test the MoveLogic if the drill is on the right border of the screen.
        /// </summary>
        [Test]
        public void TestMoveLogic_MoveDrill_ToRightBorder()
        {
            this.logic.GameModel.Drill.Location = new double[] { 490, 490 };

            this.logic.MoveLogic.MoveDrill(1, 0);

            Assert.That(this.logic.GameModel.Drill.Location[0], Is.EqualTo(490));
            Assert.That(this.logic.GameModel.Drill.Location[1], Is.EqualTo(490));
        }

        /// <summary>
        /// Test the MoveLogic if the drill is on the bottom border of the screen.
        /// </summary>
        [Test]
        public void TestMoveLogic_MoveDrill_ToDownBorder()
        {
            this.logic.GameModel.Drill.Location = new double[] { 490, 490 };

            this.logic.MoveLogic.MoveDrill(0, 1);

            Assert.That(this.logic.GameModel.Drill.Location[0], Is.EqualTo(490));
            Assert.That(this.logic.GameModel.Drill.Location[1], Is.EqualTo(490));
        }

        /// <summary>
        /// Test the collisionWithSilo method.
        /// </summary>
        [Test]
        public void TestMoveLogic_CollisionWithSilo()
        {
            this.gameModel.Drill.Location = new double[] { 15, 15 };
            this.gameModel.SiloHouse.Location = new double[] { 0, 0 };

            bool result = this.logic.MoveLogic.CollisionWithSilo();

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

            bool result = this.logic.MoveLogic.CollisionWithMachinist();

            Assert.That(result, Is.EqualTo(true));
        }

        /// <summary>
        /// Test the CalcTotalPoints method.
        /// </summary>
        [Test]
        public void TestMoveLogic_CalcTotalPoints()
        {
            this.logic.GameModel.ActualPoints = 100;
            this.logic.GameModel.TotalPoints = 0;

            this.logic.MoveLogic.CalcTotalPoints();

            Assert.That(this.logic.GameModel.TotalPoints, Is.EqualTo(100));
        }

        /// <summary>
        /// Test the ClearStorage method.
        /// </summary>
        [Test]
        public void TestMoveLogic_ClearStorage()
        {
            this.logic.GameModel.Drill.StorageFullness = 50;
            this.logic.GameModel.ActualPoints = 300;

            this.logic.MoveLogic.ClearStorage();

            Assert.That(this.logic.GameModel.Drill.StorageFullness, Is.EqualTo(0));
            Assert.That(this.logic.GameModel.ActualPoints, Is.EqualTo(0));
        }

        /// <summary>
        /// Test the collection of minerals when the storage is not full.
        /// </summary>
        [Test]
        public void TestMoveLogic_CollectMineral_WhenStorageNotFull()
        {
            this.logic.GameModel.Drill.Location = new double[] { 5, 5 };

            this.logic.MoveLogic.CollectMinerals(this.min);

            Assert.That(this.logic.GameModel.ActualPoints, Is.EqualTo(300));
            Assert.That(this.logic.GameModel.Drill.StorageFullness, Is.EqualTo(1));
        }

        /// <summary>
        /// Test the collection of a mineral when the storage is full.
        /// </summary>
        [Test]
        public void TestMoveLogic_CollectMineral_WhenStorageFull()
        {
            this.logic.GameModel.Drill.Location = new double[] { 5, 5 };
            this.logic.GameModel.Drill.StorageFullness = this.logic.GameModel.Drill.StorageCapacity;
            this.logic.GameModel.ActualPoints = 100;

            this.logic.MoveLogic.CollectMinerals(this.min);

            Assert.That(this.logic.GameModel.ActualPoints, Is.EqualTo(100));
            Assert.That(this.logic.GameModel.Drill.StorageFullness, Is.EqualTo(this.logic.GameModel.Drill.StorageCapacity));
        }

        /// <summary>
        /// Tests if the collision with enemy method works properly.
        /// </summary>
        [Test]
        public void TestMoveLogic_CollisionWithEnemy()
        {
            this.logic.GameModel.Drill.Location = new double[] { 10, 10 };
            this.logic.GameModel.Enemies.Add(this.enemy);

            bool result = this.logic.MoveLogic.CollisionWithEnemy();

            Assert.That(result, Is.True);
        }

        /// <summary>
        /// Tests if the collision with bomb method works properly.
        /// </summary>
        public void TestMoveLogic_CollisionWithBomb()
        {
            this.logic.GameModel.Drill.Location = new double[] { 10, 10 };
            this.logic.GameModel.Bombs.Add(this.bomb);

            bool result = this.logic.MoveLogic.CollisionWithBomb();

            Assert.That(result, Is.True);
        }
    }
}
