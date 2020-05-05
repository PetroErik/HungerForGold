// <copyright file="TickLogicTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HFG.Tests
{
    using HFG.Display;
    using HFG.Logic;
    using NUnit.Framework;

    /// <summary>
    /// Tests for the TickLogic.
    /// </summary>
    [TestFixture]
    public class TickLogicTests
    {
        /// <summary>
        /// Test the FuelTick method when the fuel tank is not empty.
        /// </summary>
        [Test]
        public void TestTickLogic_FuelTick_WhenFuelNotNull()
        {
            GameLogic logic = new GameLogic(new GameModel(500, 500));
            logic.InitialMap();
            logic.StartGame();
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
            GameLogic logic = new GameLogic(new GameModel(500, 500));
            logic.InitialMap();
            logic.GameModel.Drill.FuelTankFullness = 0;

            logic.TickLogic.FuelTick();

            Assert.That(logic.GameModel.Drill.FuelTankFullness, Is.EqualTo(0));
        }
    }
}
