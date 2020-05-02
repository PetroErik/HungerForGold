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
    /// Tests for the TickLogic.
    /// </summary>
    [TestFixture]
    class TickLogicTests
    {
        /// <summary>
        /// Test the FuelTick method when the fuel tank is not empty.
        /// </summary>
        [Test]
        public void TestTickLogic_FuelTick_WhenFuelNotNull()
        {
            GameLogic logic = new GameLogic(new GameModel(500, 500));
            logic.InitialMap();
            logic.startGame();
            logic.gameModel.drill.FuelTankFullness = 40;

            logic.tickLogic.FuelTick();

            Assert.That(logic.gameModel.drill.FuelTankFullness, Is.EqualTo(39));
        }

        /// <summary>
        /// Test the FuelTick method when the fuel tank is empty.
        /// </summary>
        [Test]
        public void TestTickLogic_FuelTick_WhenFuelNull()
        {
            GameLogic logic = new GameLogic(new GameModel(500, 500));
            logic.InitialMap();
            logic.gameModel.drill.FuelTankFullness = 0;

            logic.tickLogic.FuelTick();

            Assert.That(logic.gameModel.drill.FuelTankFullness, Is.EqualTo(0));
        }
    }
}
