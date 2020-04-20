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
    class TickLogicTests
    {
        [Test]
        public void TestTickLogic_GravityTick()
        {
            GameLogic logic = new GameLogic(new GameModel(500, 500));
            logic.InitialMap();
            logic.gameModel.drill.Location = new double[] { 15, 15 };
            
            logic.tickLogic.GravityTick();

            Assert.That(logic.gameModel.drill.Location[0], Is.EqualTo(15));
            Assert.That(logic.gameModel.drill.Location[1], Is.EqualTo(16));
        }

        [Test]
        public void TestTickLogic_FuelTick_WhenFuelNotNull()
        {
            GameLogic logic = new GameLogic(new GameModel(500, 500));
            logic.InitialMap();
            logic.gameModel.drill.FuelTankFullness = 40;

            //bool result = logic.tickLogic.FuelTick();

            Assert.That(logic.gameModel.drill.FuelTankFullness, Is.EqualTo(39));
           // Assert.That(result, Is.False);
        }

        [Test]
        public void TestTickLogic_FuelTick_WhenFuelNull()
        {
            GameLogic logic = new GameLogic(new GameModel(500, 500));
            logic.InitialMap();
            logic.gameModel.drill.FuelTankFullness = 0;

            //bool result = logic.tickLogic.FuelTick();

            Assert.That(logic.gameModel.drill.FuelTankFullness, Is.EqualTo(0));
            //Assert.That(result, Is.True);
        }
    }
}
