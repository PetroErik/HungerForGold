﻿using HFG.Display;
using HFG.Logic;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HFG.Tests
{
    [TestFixture]
    class MoveLogicTests
    {
        [Test]
        public void TestMoveLogic_MoveDrill()
        {
            GameLogic logic = new GameLogic(new GameModel(500,500));
            logic.InitialMap();
            logic.startGame();
            logic.gameModel.drill.Location = new double[] { 300, 300 };

            logic.moveLogic.MoveDrill(1, 1);

            Assert.That(logic.gameModel.drill.Location[0], Is.EqualTo(300 + logic.gameModel.TileSize));
            Assert.That(logic.gameModel.drill.Location[1], Is.EqualTo(300 + logic.gameModel.TileSize));
        }

        [Test]
        public void TestMoveLogic_MoveDrill_ToLeftBorder()
        {
            GameLogic logic = new GameLogic(new GameModel(500, 500));
            logic.InitialMap();
            logic.gameModel.drill.Location = new double[] { 5, 5 };

            logic.moveLogic.MoveDrill(-1, 0);

            Assert.That(logic.gameModel.drill.Location[0], Is.EqualTo(5));
            Assert.That(logic.gameModel.drill.Location[1], Is.EqualTo(5));
        }

        [Test]
        public void TestMoveLogic_MoveDrill_ToUpBorder()
        {
            GameLogic logic = new GameLogic(new GameModel(500, 500));
            logic.InitialMap();
            logic.gameModel.drill.Location = new double[] { 5, 5 };

            logic.moveLogic.MoveDrill(0, -1);

            Assert.That(logic.gameModel.drill.Location[0], Is.EqualTo(5));
            Assert.That(logic.gameModel.drill.Location[1], Is.EqualTo(5));
        }

        [Test]
        public void TestMoveLogic_MoveDrill_ToRightBorder()
        {
            GameLogic logic = new GameLogic(new GameModel(500, 500));
            logic.InitialMap();
            logic.gameModel.drill.Location = new double[] { 490, 490 };

            logic.moveLogic.MoveDrill(1, 0);

            Assert.That(logic.gameModel.drill.Location[0], Is.EqualTo(490));
            Assert.That(logic.gameModel.drill.Location[1], Is.EqualTo(490));
        }

        [Test]
        public void TestMoveLogic_MoveDrill_ToDownBorder()
        {
            GameLogic logic = new GameLogic(new GameModel(500, 500));
            logic.InitialMap();
            logic.gameModel.drill.Location = new double[] { 490, 490 };

            logic.moveLogic.MoveDrill(0, 1);

            Assert.That(logic.gameModel.drill.Location[0], Is.EqualTo(490));
            Assert.That(logic.gameModel.drill.Location[1], Is.EqualTo(490));
        }

        [Test]
        public void TestMoveLogic_CollisionWithSilo()
        {
            GameModel model = new GameModel(500, 500);
            GameLogic logic = new GameLogic(model);
            logic.InitialMap();
            logic.startGame();
            model.drill.Location = new double[] { 15, 15 };
            model.SiloHouse.Location = new double[] { 15, 15 };

            bool result = logic.moveLogic.CollisionWithSilo();

            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public void TestMoveLogic_CalcTotalPoints()
        {
            GameLogic logic = new GameLogic(new GameModel(500, 500));
            logic.InitialMap();
            logic.gameModel.ActualPoints = 100;
            logic.gameModel.TotalPoints = 0;

            logic.moveLogic.CalcTotalPoints();

            Assert.That(logic.gameModel.TotalPoints, Is.EqualTo(100));
        }

        [Test]
        public void TestMoveLogic_ClearStorage()
        {
            GameLogic logic = new GameLogic(new GameModel(500, 500));
            logic.InitialMap();
            logic.gameModel.drill.StorageFullness = 50;
            logic.gameModel.ActualPoints = 300;

            logic.moveLogic.ClearStorage();

            Assert.That(logic.gameModel.drill.StorageFullness, Is.EqualTo(0));
            Assert.That(logic.gameModel.ActualPoints, Is.EqualTo(0));
        }

        [Test]
        public void TestMoveLogic_CollectMineral_WhenStorageNotFull()
        {
            GameLogic logic = new GameLogic(new GameModel(500, 500));
            Mineral min = new Mineral(5, 5, MineralsType.Gold);
            logic.InitialMap();
            logic.startGame();
            logic.gameModel.drill.Location = new double[] { 5, 5 };

            logic.moveLogic.CollectMinerals(min);

            Assert.That(logic.gameModel.ActualPoints, Is.EqualTo(300));
            Assert.That(logic.gameModel.drill.StorageFullness, Is.EqualTo(1));
        }

        [Test]
        public void TestMoveLogic_CollectMineral_WhenStorageFull()
        {
            GameLogic logic = new GameLogic(new GameModel(500, 500));
            Mineral min = new Mineral(5, 5, MineralsType.Gold);
            logic.InitialMap();
            logic.gameModel.drill.Location = new double[] { 5, 5 };
            logic.gameModel.drill.StorageFullness = logic.gameModel.drill.StorageCapacity;
            logic.gameModel.ActualPoints = 100;

            logic.moveLogic.CollectMinerals(min);

            Assert.That(logic.gameModel.ActualPoints, Is.EqualTo(100));
            Assert.That(logic.gameModel.drill.StorageFullness, Is.EqualTo(logic.gameModel.drill.StorageCapacity));
        }
    }
}
