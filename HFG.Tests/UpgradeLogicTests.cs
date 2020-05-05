using HFG.Display;
using HFG.Logic;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HFG.Tests
{
    /// <summary>
    /// Tests for UpgradeLogic.
    /// </summary>
    [TestFixture]
    class UpgradeLogicTests
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
            logic.gameModel.TotalPoints = 5000;

            logic.moveLogic.UpgradeFuelTank();

            Assert.That(logic.gameModel.drill.FuelTankLvl, Is.EqualTo(2));
        }

        /// <summary>
        /// Test the UpgradeFuelTank method when FuelTank is on max level.
        /// </summary>
        [Test]
        public void TestUpgradeLogic_UpgradeFuelTank_WhenMaxLevel()
        {
            GameLogic logic = new GameLogic(new GameModel(500, 500));
            logic.InitialMap();
            logic.gameModel.drill.FuelTankLvl = 3;

            logic.moveLogic.UpgradeFuelTank();

            Assert.That(logic.gameModel.drill.FuelTankLvl, Is.EqualTo(3));
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
            logic.gameModel.TotalPoints = 5000;

            logic.moveLogic.UpgradeDrill();

            Assert.That(logic.gameModel.drill.DrillLvl, Is.EqualTo(2));
        }

        /// <summary>
        /// Test the UpgradeDrill method when Drill is on max level.
        /// </summary>
        [Test]
        public void TestUpgradeLogic_UpgradeDrill_WhenMaxLevel()
        {
            GameLogic logic = new GameLogic(new GameModel(500, 500));
            logic.InitialMap();
            logic.gameModel.drill.DrillLvl = 3;

            logic.moveLogic.UpgradeFuelTank();

            Assert.That(logic.gameModel.drill.DrillLvl, Is.EqualTo(3));
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
            logic.gameModel.TotalPoints = 5000;

            logic.moveLogic.UpgradeStorage();

            Assert.That(logic.gameModel.drill.StorageLvl, Is.EqualTo(2));
        }

        /// <summary>
        /// Test the UpgradeStorage method when Storage is on max level.
        /// </summary>
        [Test]
        public void TestUpgradeLogic_UpgradeStorage_WhenMaxLevel()
        {
            GameLogic logic = new GameLogic(new GameModel(500, 500));
            logic.InitialMap();
            logic.gameModel.drill.StorageLvl = 3;

            logic.moveLogic.UpgradeFuelTank();

            Assert.That(logic.gameModel.drill.StorageLvl, Is.EqualTo(3));
        }
    }
}
