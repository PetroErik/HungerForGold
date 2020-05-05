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

            Assert.That(logic.dbLogic, Is.Not.EqualTo(null));
            Assert.That(logic.gameModel.TileSize, Is.Not.EqualTo(0));
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

            Assert.That(logic.gameModel.Minerals, Is.Not.EqualTo(null));
            Assert.That(logic.gameModel.Minerals.Count, Is.EqualTo(30));
            Assert.That(logic.gameModel.ActualPoints, Is.EqualTo(0));
            Assert.That(logic.gameModel.TotalPoints, Is.EqualTo(0));
        }
    }
}
