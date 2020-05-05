// <copyright file="MoveLogicTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HFG.Tests
{
    using HFG.Display;
    using HFG.Display.Elements;
    using HFG.Logic;
    using NUnit.Framework;

    /// <summary>
    /// Tests the MoveLogic.
    /// </summary>
    [TestFixture]
    public class MoveLogicTests
    {
        /// <summary>
        /// Test if the MoveDrill method works well.
        /// </summary>
        [Test]
        public void TestMoveLogic_MoveDrill()
        {
            GameLogic logic = new GameLogic(new GameModel(500, 500));
            logic.InitialMap();
            logic.StartGame();
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
            GameLogic logic = new GameLogic(new GameModel(500, 500));
            logic.InitialMap();
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
            GameLogic logic = new GameLogic(new GameModel(500, 500));
            logic.InitialMap();
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
            GameLogic logic = new GameLogic(new GameModel(500, 500));
            logic.InitialMap();
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
            GameLogic logic = new GameLogic(new GameModel(500, 500));
            logic.InitialMap();
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
            GameModel model = new GameModel(500, 500);
            GameLogic logic = new GameLogic(model);
            logic.InitialMap();
            logic.StartGame();
            model.Drill.Location = new double[] { 15, 15 };
            model.SiloHouse.Location = new double[] { 0, 0 };

            bool result = logic.MoveLogic.CollisionWithSilo();

            Assert.That(result, Is.EqualTo(true));
        }

        /// <summary>
        /// Test the collisionWithMachinist method.
        /// </summary>
        [Test]
        public void TestMoveLogic_CollisionWithMachinsit()
        {
            GameModel model = new GameModel(500, 500);
            GameLogic logic = new GameLogic(model);
            logic.InitialMap();
            logic.StartGame();
            model.Drill.Location = new double[] { 15, 15 };
            model.MachinistHouse.Location = new double[] { 15, 15 };

            bool result = logic.MoveLogic.CollisionWithMachinist();

            Assert.That(result, Is.EqualTo(true));
        }

        /// <summary>
        /// Test the CalcTotalPoints method.
        /// </summary>
        [Test]
        public void TestMoveLogic_CalcTotalPoints()
        {
            GameLogic logic = new GameLogic(new GameModel(500, 500));
            logic.InitialMap();
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
            GameLogic logic = new GameLogic(new GameModel(500, 500));
            logic.InitialMap();
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
            GameLogic logic = new GameLogic(new GameModel(500, 500));
            Mineral min = new Mineral(5, 5, MineralsType.Gold);
            logic.InitialMap();
            logic.StartGame();
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
            GameLogic logic = new GameLogic(new GameModel(500, 500));
            Mineral min = new Mineral(5, 5, MineralsType.Gold);
            logic.InitialMap();
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
            GameLogic logic = new GameLogic(new GameModel(500, 500));
            Enemy enemy = new Enemy(10, 10);
            logic.InitialMap();
            logic.GameModel.Drill.Location = new double[] { 10, 10 };
            logic.GameModel.Enemies.Add(enemy);

            bool result = logic.MoveLogic.CollisionWithEnemy();

            Assert.That(result, Is.True);
        }

        /// <summary>
        /// Tests if the collision with bomb method works properly.
        /// </summary>
        [Test]
        public void TestMoveLogic_CollisionWithBomb()
        {
            GameLogic logic = new GameLogic(new GameModel(500, 500));
            Bomb bomb = new Bomb(10, 10);
            logic.InitialMap();
            logic.GameModel.Drill.Location = new double[] { 10, 10 };
            logic.GameModel.Bombs.Add(bomb);

            bool result = logic.MoveLogic.CollisionWithBomb();

            Assert.That(result, Is.True);
        }
    }
}
