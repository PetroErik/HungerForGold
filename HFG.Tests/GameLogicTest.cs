// <copyright file="GameLogicTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HFG.Tests
{
    using HFG.Display;
    using HFG.Logic;
    using NUnit.Framework;

    /// <summary>
    /// Tests for GameLogic.
    /// </summary>
    [TestFixture]
    public class GameLogicTest
    {
        /// <summary>
        /// Tests if the constructor work properly.
        /// </summary>
        [Test]
        public void TestGameLogic_Ctor()
        {
            GameLogic logic = new GameLogic(new GameModel(500, 500));

            Assert.That(logic.DbLogic, Is.Not.EqualTo(null));
            Assert.That(logic.GameModel.TileSize, Is.Not.EqualTo(0));
        }

        /// <summary>
        /// Tests of the StartGame method works.
        /// </summary>
        [Test]
        public void TestGameLogic_StartGame()
        {
            GameLogic logic = new GameLogic(new GameModel(500, 500));
            logic.InitialMap();
            logic.StartGame();

            Assert.That(logic.GameModel.Minerals, Is.Not.EqualTo(null));
            Assert.That(logic.GameModel.Minerals.Count, Is.EqualTo(30));
            Assert.That(logic.GameModel.ActualPoints, Is.EqualTo(0));
            Assert.That(logic.GameModel.TotalPoints, Is.EqualTo(0));
        }
    }
}
