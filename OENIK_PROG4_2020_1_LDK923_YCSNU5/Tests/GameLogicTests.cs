using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using NUnit.Framework;
using OENIK_PROG4_2020_1_LDK923_YCSNU5.Logic;
using OENIK_PROG4_2020_1_LDK923_YCSNU5.Model;

namespace OENIK_PROG4_2020_1_LDK923_YCSNU5.Tests
{
    [TestFixture]
    class GameLogicTests
    {
        static Drill drill = new Drill(1, 1);
        static GameModel model = new GameModel(500, 500);
        static GameLogic logic = new GameLogic(model);

        [Test]
        public void TestDrillCtor()
        {
            Assert.That(drill.Location.X, Is.EqualTo(1));
            Assert.That(drill.Location.Y, Is.EqualTo(1));
            Assert.That(drill.FuelTankLvl, Is.EqualTo(1));
            Assert.That(drill.FuelCapacity, Is.EqualTo(drill.FuelTankLvl * 100));
            Assert.That(drill.FuelTankFullness, Is.EqualTo(drill.FuelCapacity));
        }

        [Test]
        public void TestGameModelCtor()
        {
            Assert.That(model.Minerals, Is.Not.Null);
            Assert.That(model.GameWidth, Is.EqualTo(500));
        }

        [Test]
        public void TestGameLogic_MoveDrill()
        {
            model.drill.Location = new Point(1, 1);

            logic.MoveDrill(1, 1);
            Assert.That(model.drill.Location.X, Is.EqualTo(model.TileSize + 1));
            Assert.That(model.drill.Location.Y, Is.EqualTo(model.TileSize + 1));
        }

        [Test]
        public void TestGameLogic_CollisionWithSilo()
        {
            model.drill = drill;
            model.SiloHouse = new Point(1, 1);

            bool result = logic.CollisionWithSilo();

            Assert.That(result, Is.True);
        }

        [Test]
        public void TestGameLogic_CalcTotalPoints()
        {
            model.ActualPoints = 300;
            model.TotalPoints = 100;

            logic.CalcTotalPoints();

            Assert.That(model.TotalPoints, Is.EqualTo(400));
        }

        [Test]
        public void TestGameLogic_ClearStorage()
        {
            model.drill.StorageFullness = 40;
            model.ActualPoints = 100;

            logic.ClearStorage();
            
            Assert.That(model.drill.StorageFullness, Is.EqualTo(0));
            Assert.That(model.ActualPoints, Is.EqualTo(0));
        }

        [Test]
        public void TestGameLogic_CollectMineral_WhenStorageNotFull()
        {
            Minerals min = new Minerals(1, 1, MineralsType.Gold);
            model.drill.Location = new Point(1, 1);
            model.ActualPoints = 0;
            model.drill.StorageFullness = 40;

            logic.CollectMinerals(min);

            Assert.That(model.ActualPoints, Is.EqualTo(300));
            Assert.That(model.drill.StorageFullness, Is.EqualTo(41));
        }

        [Test]
        public void TestGameLogic_CollectMineral_WhenStorageFull()
        {
            Minerals min = new Minerals(1, 1, MineralsType.Gold);
            model.drill.Location = new Point(1, 1);
            model.ActualPoints = 100;
            model.drill.StorageFullness = model.drill.StorageCapacity;

            logic.CollectMinerals(min);

            Assert.That(model.ActualPoints, Is.EqualTo(100));
            Assert.That(model.drill.StorageFullness, Is.EqualTo(model.drill.StorageCapacity));
        }

        [Test]
        public void GameLogic_UpgrageStorage_WhenLessThanMaxLevel()
        {
            logic.UpgradeStorage();

            Assert.That(model.drill.StorageLvl, Is.EqualTo(2));
            Assert.That(model.drill.StorageCapacity, Is.EqualTo(200));
        }

        public void GameLogic_UpgrageStorage_WhenMaxLevel()
        {
            model.drill.StorageLvl = 3;
            logic.UpgradeStorage();

            Assert.That(model.drill.StorageLvl, Is.EqualTo(3));
            Assert.That(model.drill.StorageCapacity, Is.EqualTo(300));
        }

        [Test]
        public void TestGameLogic_FuelTick_WhenNotNull()
        {
            model.drill.FuelTankFullness = 50;

            bool result = logic.FuelTick();

            Assert.That(result, Is.False);
            Assert.That(model.drill.FuelTankFullness, Is.EqualTo(49));
        }

        [Test]
        public void TestGameLogic_FuelTick_WhenNull()
        {
            model.drill.FuelTankFullness = 0;

            bool result = logic.FuelTick();

            Assert.That(result, Is.True);
            Assert.That(model.drill.FuelTankFullness, Is.EqualTo(0));
        }

        [Test]
        public void TestGameLogic_GravityTick_WhenNotOnGround()
        {
            model.drill.Location = new Point(1, 1);

            logic.GravityTick();

            Assert.That(model.drill.Location.Y, Is.EqualTo(11));
            Assert.That(model.drill.Location.X, Is.EqualTo(1));
        }

        [Test]
        public void TestGameLogic_GravityTick_WhenOnGround()
        {
            model.drill.Location = new Point(5, model.GameHeight / 3);

            logic.GravityTick();

            Assert.That(model.drill.Location.Y, Is.EqualTo(model.GameHeight / 3));
            Assert.That(model.drill.Location.X, Is.EqualTo(5));
        }

        [Test]
        public void TestGameLogic_GravityTick_WhenBelowGround()
        {
            model.drill.Location = new Point(5, (model.GameHeight / 3) + 10);

            logic.GravityTick();

            Assert.That(model.drill.Location.Y, Is.EqualTo((model.GameHeight / 3) + 10));
            Assert.That(model.drill.Location.X, Is.EqualTo(5));
        }
    }
}
