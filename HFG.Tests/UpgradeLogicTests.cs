// <copyright file="UpgradeLogicTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HFG.Tests
{
    using HFG.Display;
    using HFG.Logic;
    using NUnit.Framework;

    /// <summary>
    /// Tests for UpgradeLogic.
    /// </summary>
    [TestFixture]
    public class UpgradeLogicTests
    {
       
        /// <summary>
        /// Test the UpgradeFuelTank method when FuelTank is not on max level.
        /// </summary>
        [Test]
        public void TestUpgradeLogic_UpgradeFuelTank_WhenNotMaxLevel()
        {
            GameLogic logic = new GameLogic(new GameModel(500, 500));
            logic.InitialMap();
            logic.StartGame();
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
            GameLogic logic = new GameLogic(new GameModel(500, 500));
            logic.InitialMap();
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
            GameLogic logic = new GameLogic(new GameModel(500, 500));
            logic.InitialMap();
            logic.StartGame();
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
            GameLogic logic = new GameLogic(new GameModel(500, 500));
            logic.InitialMap();
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
            GameLogic logic = new GameLogic(new GameModel(500, 500));
            logic.InitialMap();
            logic.StartGame();
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
            GameLogic logic = new GameLogic(new GameModel(500, 500));
            logic.InitialMap();
            logic.GameModel.Drill.StorageLvl = 3;

            logic.MoveLogic.UpgradeFuelTank();

            Assert.That(logic.GameModel.Drill.StorageLvl, Is.EqualTo(3));
        }
    }
}
