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
    [TestFixture]
    class UpgradeLogicTests
    {
        [Test]
        public void TestUpgradeLogic_UpgradeFuelTank_WhenNotMaxLevel()
        {
            GameLogic logic = new GameLogic(new GameModel(500, 500));
            logic.InitialMap();

            logic.upgradeLogic.UpgradeFuelTank();

            Assert.That(logic.gameModel.drill.FuelTankLvl, Is.EqualTo(2));
        }

        [Test]
        public void TestUpgradeLogic_UpgradeFuelTank_WhenMaxLevel()
        {
            GameLogic logic = new GameLogic(new GameModel(500, 500));
            logic.InitialMap();
            logic.gameModel.drill.FuelTankLvl = 3;

            logic.upgradeLogic.UpgradeFuelTank();

            Assert.That(logic.gameModel.drill.FuelTankLvl, Is.EqualTo(3));
        }

        [Test]
        public void TestUpgradeLogic_UpgradeDrill_WhenNotMaxLevel()
        {
            GameLogic logic = new GameLogic(new GameModel(500, 500));
            logic.InitialMap();

            logic.upgradeLogic.UpgradeDrill();

            Assert.That(logic.gameModel.drill.DrillLvl, Is.EqualTo(2));
        }

        [Test]
        public void TestUpgradeLogic_UpgradeDrill_WhenMaxLevel()
        {
            GameLogic logic = new GameLogic(new GameModel(500, 500));
            logic.InitialMap();
            logic.gameModel.drill.DrillLvl = 3;

            logic.upgradeLogic.UpgradeFuelTank();

            Assert.That(logic.gameModel.drill.DrillLvl, Is.EqualTo(3));
        }

        [Test]
        public void TestUpgradeLogic_UpgradeStorage_WhenNotMaxLevel()
        {
            GameLogic logic = new GameLogic(new GameModel(500, 500));
            logic.InitialMap();

            logic.upgradeLogic.UpgradeStorage();

            Assert.That(logic.gameModel.drill.StorageLvl, Is.EqualTo(2));
        }

        [Test]
        public void TestUpgradeLogic_UpgradeStorage_WhenMaxLevel()
        {
            GameLogic logic = new GameLogic(new GameModel(500, 500));
            logic.InitialMap();
            logic.gameModel.drill.StorageLvl = 3;

            logic.upgradeLogic.UpgradeFuelTank();

            Assert.That(logic.gameModel.drill.StorageLvl, Is.EqualTo(3));
        }
    }
}
