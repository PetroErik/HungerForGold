// <copyright file="DbLogicTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HFG.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using HFG.Database;
    using HFG.Display;
    using HFG.Logic;
    using HFG.Repository;
    using Moq;
    using NUnit.Framework;

    /// <summary>
    /// Tests for Database logic.
    /// </summary>
    [TestFixture]
    public class DbLogicTests
    {
        /// <summary>
        /// drillRepo instance.
        /// </summary>
        private Mock<IDrillRepository> drillRepo;

        /// <summary>
        /// brickRepo instance.
        /// </summary>
        private Mock<IBrickRepository> brickRepo;

        /// <summary>
        /// connRepo instance.
        /// </summary>
        private Mock<IConnRepository> connRepo;

        /// <summary>
        /// Testing List of drill instances.
        /// </summary>
        private List<drill> testDrills;

        /// <summary>
        /// Testing List of brick instances.
        /// </summary>
        private List<brick> testBricks;

        /// <summary>
        /// Testing List of connection instances.
        /// </summary>
        private List<conn> testConnections;

        /// <summary>
        /// gameModel Instance.
        /// </summary>
        private GameModel gameModel;

        /// <summary>
        /// DbLogic.
        /// </summary>
        private DbLogic dbLogic;

        /// <summary>
        /// single drill instance.
        /// </summary>
        private drill testDrill;

        private brick testBrick;

        private conn testConn;

        /// <summary>
        /// Set up is an attribute used inside a [TestFixture]
        /// to provide a common set of functions that are performed
        /// just before each test method is called. Can only have 1 setup,
        /// if more than 1 the tests will not run .
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            this.testDrills = new List<drill>()
            {
                new drill() { drill_id = 1, drill_fuel = 3, drill_score = 11, drill_speed = 20, drill_storage = 10, drill_x = 3, drill_y = 3 },
                new drill() { drill_id = 2, drill_fuel = 4, drill_score = 12, drill_speed = 21, drill_storage = 11, drill_x = 4, drill_y = 5 },
                new drill() { drill_id = 3, drill_fuel = 5, drill_score = 13, drill_speed = 22, drill_storage = 12, drill_x = 6, drill_y = 6 },
                new drill() { drill_id = 4, drill_fuel = 6, drill_score = 14, drill_speed = 23, drill_storage = 13, drill_x = 14, drill_y = 13 },
                new drill() { drill_id = 5, drill_fuel = 7, drill_score = 15, drill_speed = 25, drill_storage = 17, drill_x = 15, drill_y = 12 },
            };

            this.testBricks = new List<brick>()
            {
                new brick() { brick_id = 1, brick_type = "gold", brick_x = 10, brick_y = 10 },
                new brick() { brick_id = 2, brick_type = "silver", brick_x = 15, brick_y = 22 },
                new brick() { brick_id = 3, brick_type = "bronze", brick_x = 24, brick_y = 11 },
                new brick() { brick_id = 4, brick_type = "gold", brick_x = 16, brick_y = 24 },
                new brick() { brick_id = 5, brick_type = "silver", brick_x = 11, brick_y = 34 },
            };

            this.testConnections = new List<conn>()
            {
                new conn() { conn_id = 1, conn_drill_id = 1, conn_brick_id = 1 },
                new conn() { conn_id = 2, conn_drill_id = 2, conn_brick_id = 2 },
                new conn() { conn_id = 3, conn_drill_id = 3, conn_brick_id = 3 },
                new conn() { conn_id = 4, conn_drill_id = 4, conn_brick_id = 4 },
                new conn() { conn_id = 5, conn_drill_id = 5, conn_brick_id = 5 },
            };

            this.testDrill = new drill() { drill_id = 2, drill_fuel = 3, drill_score = 10, drill_speed = 20, drill_storage = 10, drill_x = 3, drill_y = 3 };
            this.testBrick = new brick() { brick_id = 2, brick_type = "gold", brick_x = 5, brick_y = 6 };
            this.testConn = new conn() { conn_id = 1, conn_brick_id = 2, conn_drill_id = 2 };

            this.drillRepo = new Mock<IDrillRepository>(MockBehavior.Loose);
            this.drillRepo.Setup(c => c.GetAll()).Returns(this.testDrills.AsQueryable());

            this.brickRepo = new Mock<IBrickRepository>(MockBehavior.Loose);
            this.brickRepo.Setup(c => c.GetAll()).Returns(this.testBricks.AsQueryable());

            this.connRepo = new Mock<IConnRepository>(MockBehavior.Loose);
            this.connRepo.Setup(c => c.GetAll()).Returns(this.testConnections.AsQueryable());

            this.gameModel = new GameModel(500, 500);

            this.dbLogic = new DbLogic(this.gameModel, this.drillRepo.Object, this.brickRepo.Object, this.connRepo.Object);
        }

        /// <summary>
        /// Test to see if add new drill is successful .
        /// </summary>
        [Test]
        public void TestAddNewDrill()
        {
            this.drillRepo.Setup(c => c.Addnew(this.testDrill)).Callback(() => this.testDrills.Add(this.testDrill));
            this.dbLogic.AddNewDrill(this.testDrill);
            Assert.That(this.dbLogic.GetDrills().Count(), Is.EqualTo(6));
        }

        /// <summary>
        /// Test to see if add new brick is successful .
        /// </summary>
        [Test]
        public void TestAddNewBrick()
        {
            this.brickRepo.Setup(c => c.Addnew(this.testBrick)).Callback(() => this.testBricks.Add(this.testBrick));
            this.dbLogic.AddNewBrick(this.testBrick);
            Assert.That(this.dbLogic.GetBricks().Count(), Is.EqualTo(6));
        }

        /// <summary>
        /// Test to see if add new connection is successful .
        /// </summary>
        [Test]
        public void TestAddNewConn()
        {
            this.connRepo.Setup(c => c.Addnew(this.testConn)).Callback(() => this.testConnections.Add(this.testConn));
            this.dbLogic.AddNewConnection(this.testConn);
            Assert.That(this.dbLogic.GetConns().Count(), Is.EqualTo(6));
        }

        /// <summary>
        /// TestGetOneDrill to make sure that the drill and the score is correct .
        /// </summary>
        /// <param name="id">index of the drill.</param>
        /// <param name="drill_score">the scores of the drill .</param>
        [TestCase(1, 11)]
        [TestCase(2, 12)]
        [TestCase(3, 13)]
        [TestCase(4, 14)]
        [TestCase(5, 15)]

        public void TestGetOneDrill(int id, int drill_score)
        {
            this.drillRepo.Setup(c => c.GetOne(id)).Returns(this.testDrills.Find(d => d.drill_id == id));
            Assert.That(this.dbLogic.GetDrillInstance(id).drill_score, Is.EqualTo(drill_score));
        }

        /// <summary>
        /// Tests the get one brick method.
        /// </summary>
        /// <param name="id">Id of brick that we would like to recieve.</param>
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        public void TestGetOneBrick(int id)
        {
            this.brickRepo.Setup(c => c.GetOne(id)).Returns(this.testBricks.Find(b => b.brick_id == id));
            Assert.That(this.dbLogic.GetBrickInstance(id).brick_id, Is.EqualTo(id));
        }

        /// <summary>
        /// Tests the get one connection method.
        /// </summary>
        /// <param name="id">Id of the connection we would like to recieve.</param>
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        public void TestGetOneConnection(int id)
        {
            this.connRepo.Setup(c => c.GetOne(id)).Returns(this.testConnections.Find(c => c.conn_id == id));
            Assert.That(this.dbLogic.GetConnInstance(id).conn_id, Is.EqualTo(id));
        }

        /// <summary>
        /// TestHighscore to make sure that the highscore is placed from highest to lowest .
        /// </summary>
        /// <param name="index">index of the highscore.</param>
        /// <param name="score">the scores of the game .</param>
        [TestCase(0, 15)]
        [TestCase(1, 14)]
        [TestCase(2, 13)]
        [TestCase(3, 12)]
        [TestCase(4, 11)]
        public void TestHighscore(int index, int score)
        {
            Assert.That(this.dbLogic.Highscore()[index], Is.EqualTo(score));
        }
    }
}