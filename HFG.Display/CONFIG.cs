// <copyright file="CONFIG.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HFG.Display
{
    /// <summary>
    /// Containing the constants of our Game.
    /// </summary>
    public static class CONFIG
    {
        /// <summary>
        /// Price of the bronze mineral.
        /// </summary>
        public static int BronzePrice = 100;

        /// <summary>
        /// Price of the silver mineral.
        /// </summary>
        public static int SilverPrice = 200;

        /// <summary>
        /// Price of the gold mineral.
        /// </summary>
        public static int GoldPrice = 300;

        /// <summary>
        /// Multiplier for the fuel tank capacity at a given fuel tank level.
        /// </summary>
        public static int FuelCapacity = 100;

        /// <summary>
        /// Multiplier for the storage capacity at a given storage level.
        /// </summary>
        public static int StorageCapacity = 10;

        /// <summary>
        /// Number of tiles in the X direction.
        /// </summary>
        public static int MapWidth = 20;

        /// <summary>
        /// Number of tiles in the Y direction.
        /// </summary>
        public static int MapHeight = 20;

        /// <summary>
        /// Number of bombs in the game.
        /// </summary>
        public static int NmbOfBombs = 10;

        /// <summary>
        /// Number of enemies in the game.
        /// </summary>
        public static int NmbOfEnemies = 6;

        /// <summary>
        /// Number of minerals of the game.
        /// </summary>
        public static int NmbOfMinerals = 30;

        /// <summary>
        /// Fixed price to upgrade an element.
        /// </summary>
        private static int upgradePrice = 5000;

        /// <summary>
        /// Maximum level of the fuel tank element.
        /// </summary>
        public static int MaxFuelTankLevel = 3;

        /// <summary>
        /// Maximum levele of the storage element.
        /// </summary>
        public static int MaxStorageLevel = 3;

        /// <summary>
        /// Maximum level of the drill element.
        /// </summary>
        public static int MaxDrillLevel = 3;

        /// <summary>
        /// Brush for the background.
        /// </summary>
        public static string BackgroundBrush = "OENIK_PROG4_2020_1_LDK923_YCSNU5.IMG.background.jpg";

        /// <summary>
        /// Brush for the drill.
        /// </summary>
        public static string DrillBrush = "OENIK_PROG4_2020_1_LDK923_YCSNU5.IMG.Drill.png";

        /// <summary>
        /// Brush for the ground.
        /// </summary>
        public static string GroundBrush = "OENIK_PROG4_2020_1_LDK923_YCSNU5.IMG.Ground.png";

        /// <summary>
        /// Brush for the grass.
        /// </summary>
        public static string GroundLevelBrush = "OENIK_PROG4_2020_1_LDK923_YCSNU5.IMG.GroundLevel.png";

        /// <summary>
        /// Brush for the gold mineral type.
        /// </summary>
        public static string GoldBrush = "OENIK_PROG4_2020_1_LDK923_YCSNU5.IMG.Gold.png";

        /// <summary>
        /// Brush for the silver mineral type.
        /// </summary>
        public static string SilverBrush = "OENIK_PROG4_2020_1_LDK923_YCSNU5.IMG.Silver.png";

        /// <summary>
        /// Brush for the bronze mineral type.
        /// </summary>
        public static string BronzeBrush = "OENIK_PROG4_2020_1_LDK923_YCSNU5.IMG.Bronze.png";

        /// <summary>
        /// Brush for the Silo.
        /// </summary>
        public static string SiloBrush = "OENIK_PROG4_2020_1_LDK923_YCSNU5.IMG.Silo.png";

        /// <summary>
        /// Brush for the Machinist.
        /// </summary>
        public static string MachinistBrush = "OENIK_PROG4_2020_1_LDK923_YCSNU5.IMG.Machinist.png";

        /// <summary>
        /// Brush for the enemy.
        /// </summary>
        public static string EnemyBrush = "OENIK_PROG4_2020_1_LDK923_YCSNU5.IMG.Enemy.png";

        /// <summary>
        /// Brush for the bomb.
        /// </summary>
        public static string BombBrush = "OENIK_PROG4_2020_1_LDK923_YCSNU5.IMG.Bomb.png";

        /// <summary>
        /// Bomb explode time.
        /// </summary>
        private static int bombExplodeTime = 30;

        /// <summary>
        /// highscore text.
        /// </summary>
        private static string highscoreMessage = "No data yet!";

        /// <summary>
        /// Gets or sets bomb exlode time.
        /// </summary>
        public static int BombExplodeTime { get => bombExplodeTime; set => bombExplodeTime = value; }

        /// <summary>
        /// Gets or sets highscore text.
        /// </summary>
        public static string HighscoreMessage { get => highscoreMessage; set => highscoreMessage = value; }

        /// <summary>
        /// Gets or sets the mineral prices.
        /// </summary>
        public static int UpgradePrice { get => upgradePrice; set => upgradePrice = value; }
    }
}
