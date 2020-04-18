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
    public class GameLogicTest
    {
        [Test]
        public void TestGameLogic_Ctor()
        {
            GameLogic logic = new GameLogic(new GameModel(500, 500));

            Assert.That(logic.dbLogic, Is.Not.EqualTo(null));
            Assert.That(logic.gameModel.TileSize, Is.Not.EqualTo(0));
        }

        [Test]
        public void TestGameLogic_InitialMap()
        {
            GameLogic logic = new GameLogic(new GameModel(500, 500));
            logic.InitialMap();

            Assert.That(logic.gameModel.Minerals, Is.Not.EqualTo(null));
            Assert.That(logic.gameModel.Minerals.Count, Is.EqualTo(30));
            Assert.That(logic.gameModel.ActualPoints, Is.EqualTo(0));
            Assert.That(logic.gameModel.TotalPoints, Is.EqualTo(0));
        }
    }
}
