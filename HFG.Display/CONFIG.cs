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
        private static int bronzePrice = 100;

        /// <summary>
        /// Price of the silver mineral.
        /// </summary>
        private static int silverPrice = 200;

        /// <summary>
        /// Price of the gold mineral.
        /// </summary>
        private static int goldPrice = 300;

        /// <summary>
        /// Multiplier for the fuel tank capacity at a given fuel tank level.
        /// </summary>
        private static int fuelCapacity = 100;

        /// <summary>
        /// Multiplier for the storage capacity at a given storage level.
        /// </summary>
        private static int storageCapacity = 10;

        /// <summary>
        /// Number of tiles in the X direction.
        /// </summary>
        private static int mapWidth = 20;

        /// <summary>
        /// Number of tiles in the Y direction.
        /// </summary>
        private static int mapHeight = 20;

        /// <summary>
        /// Number of bombs in the game.
        /// </summary>
        private static int nmbOfBombs = 10;

        /// <summary>
        /// Number of enemies in the game.
        /// </summary>
        private static int nmbOfEnemies = 6;

        /// <summary>
        /// Number of minerals of the game.
        /// </summary>
        private static int nmbOfMinerals = 30;

        /// <summary>
        /// Maximum level of the fuel tank element.
        /// </summary>
        private static int maxFuelTankLevel = 3;

        /// <summary>
        /// Maximum level of the storage element.
        /// </summary>
        private static int maxStorageLevel = 3;

        /// <summary>
        /// Maximum level of the drill element.
        /// </summary>
        private static int maxDrillLevel = 3;

        /// <summary>
        /// Fixed price to upgrade an element.
        /// </summary>
        private static int upgradePrice = 5000;

        /// <summary>
        /// Brush for the background.
        /// </summary>
        private static string backgroundBrush = "OENIK_PROG4_2020_1_LDK923_YCSNU5.IMG.background.jpg";

        /// <summary>
        /// Brush for the drill.
        /// </summary>
        private static string drillBrush = "OENIK_PROG4_2020_1_LDK923_YCSNU5.IMG.Drill.png";

        /// <summary>
        /// Brush for the ground.
        /// </summary>
        private static string groundBrush = "OENIK_PROG4_2020_1_LDK923_YCSNU5.IMG.Ground.png";

        /// <summary>
        /// Brush for the grass.
        /// </summary>
        private static string groundLevelBrush = "OENIK_PROG4_2020_1_LDK923_YCSNU5.IMG.GroundLevel.png";

        /// <summary>
        /// Brush for the gold mineral type.
        /// </summary>
        private static string goldBrush = "OENIK_PROG4_2020_1_LDK923_YCSNU5.IMG.Gold.png";

        /// <summary>
        /// Brush for the silver mineral type.
        /// </summary>
        private static string silverBrush = "OENIK_PROG4_2020_1_LDK923_YCSNU5.IMG.Silver.png";

        /// <summary>
        /// Brush for the bronze mineral type.
        /// </summary>
        private static string bronzeBrush = "OENIK_PROG4_2020_1_LDK923_YCSNU5.IMG.Bronze.png";

        /// <summary>
        /// Brush for the Silo.
        /// </summary>
        private static string siloBrush = "OENIK_PROG4_2020_1_LDK923_YCSNU5.IMG.Silo.png";

        /// <summary>
        /// Brush for the Machinist.
        /// </summary>
        private static string machinistBrush = "OENIK_PROG4_2020_1_LDK923_YCSNU5.IMG.Machinist.png";

        /// <summary>
        /// Brush for the enemy.
        /// </summary>
        private static string enemyBrush = "OENIK_PROG4_2020_1_LDK923_YCSNU5.IMG.Enemy.png";

        /// <summary>
        /// Brush for the bomb.
        /// </summary>
        private static string bombBrush = "OENIK_PROG4_2020_1_LDK923_YCSNU5.IMG.Bomb.png";

        /// <summary>
        /// Bomb explode time.
        /// </summary>
        private static int bombExplodeTime = 30;

        /// <summary>
        /// highscore text.
        /// </summary>
        private static string highscoreMessage = "No data yet!";

        /// <summary>
        /// game over text.
        /// </summary>
        private static string gameOverText = "GAME OVER!";

        /// <summary>
        /// highscore text.
        /// </summary>
        private static string highscoreText = "HIGHSCORE";

        /// <summary>
        /// game name text.
        /// </summary>
        private static string gameNameText = "Hunger for Gold";

        /// <summary>
        /// menu text 1.
        /// </summary>
        private static string menuText1 = "1. Start Game";

        /// <summary>
        /// menu text 2.
        /// </summary>
        private static string menuText2 = "2. Continues";

        /// <summary>
        /// menu text 3.
        /// </summary>
        private static string menuText3 = "3. Highscore";

        /// <summary>
        /// Quick game text.
        /// </summary>
        private static string quitGameText = "QUIT GAME";

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

        /// <summary>
        /// Gets or Sets the Brush for the bomb.
        /// </summary>
        public static string BombBrush { get => bombBrush; set => bombBrush = value; }

        /// <summary>
        /// Gets or Sets the Price of the bronze mineral.
        /// </summary>
        public static int BronzePrice { get => bronzePrice; set => bronzePrice = value; }

        /// <summary>
        /// Gets or Sets the Price of the silver mineral.
        /// </summary>
        public static int SilverPrice { get => silverPrice; set => silverPrice = value; }

        /// <summary>
        /// Gets or Sets the Price of the Gold mineral.
        /// </summary>
        public static int GoldPrice { get => goldPrice; set => goldPrice = value; }

        /// <summary>
        /// Gets or sets the Multiplier for the fuel tank capacity at a given fuel tank level.
        /// </summary>
        public static int FuelCapacity { get => fuelCapacity; set => fuelCapacity = value; }

        /// <summary>
        /// Gets or sets the multiplier for the storage capacity at a given storage level.
        /// </summary>
        public static int StorageCapacity { get => storageCapacity; set => storageCapacity = value; }

        /// <summary>
        /// gets or sets the number of tiles in the X direction.
        /// </summary>
        public static int MapWidth { get => mapWidth; set => mapWidth = value; }

        /// <summary>
        /// gets or sets the number of tiles in the Y direction.
        /// </summary>
        public static int MapHeight { get => mapHeight; set => mapHeight = value; }

        /// <summary>
        /// gets or sets the number of bombs in the game.
        /// </summary>
        public static int NmbOfBombs { get => nmbOfBombs; set => nmbOfBombs = value; }

        /// <summary>
        /// gets or sets the number of enemies in the game.
        /// </summary>
        public static int NmbOfEnemies { get => nmbOfEnemies; set => nmbOfEnemies = value; }

        /// <summary>
        /// gets or sets the number of minerals of the game.
        /// </summary>
        public static int NmbOfMinerals { get => nmbOfMinerals; set => nmbOfMinerals = value; }

        /// <summary>
        /// gets or sets the maximum level of the fuel tank element.
        /// </summary>
        public static int MaxFuelTankLevel { get => maxFuelTankLevel; set => maxFuelTankLevel = value; }

        /// <summary>
        /// gets or sets the maximum level of the storage element.
        /// </summary>
        public static int MaxStorageLevel { get => maxStorageLevel; set => maxStorageLevel = value; }

        /// <summary>
        /// GetS OR sets the maximum level of the drill element.
        /// </summary>
        public static int MaxDrillLevel { get => maxDrillLevel; set => maxDrillLevel = value; }

        /// <summary>
        /// gets or sets the brush for the background.
        /// </summary>
        public static string BackgroundBrush { get => backgroundBrush; set => backgroundBrush = value; }

        /// <summary>
        /// gets or sets the brush for the drill.
        /// </summary>
        public static string DrillBrush { get => drillBrush; set => drillBrush = value; }

        /// <summary>
        /// gets or sets the brush for the ground.
        /// </summary>
        public static string GroundBrush { get => groundBrush; set => groundBrush = value; }

        /// <summary>
        /// gets or sets the brush for the grass.
        /// </summary>
        public static string GroundLevelBrush { get => groundLevelBrush; set => groundLevelBrush = value; }

        /// <summary>
        /// gets or sets the brush for the gold mineral type.
        /// </summary>
        public static string GoldBrush { get => goldBrush; set => goldBrush = value; }

        /// <summary>
        /// gets or sets the brush for the silver mineral type.
        /// </summary>
        public static string SilverBrush { get => silverBrush; set => silverBrush = value; }

        /// <summary>
        /// gets or sets the brush for the bronze mineral type.
        /// </summary>
        public static string BronzeBrush { get => bronzeBrush; set => bronzeBrush = value; }

        /// <summary>
        /// gets or sets the brush for Silo.
        /// </summary>
        public static string SiloBrush { get => siloBrush; set => siloBrush = value; }

        /// <summary>
        /// gets or sets the brush for Machinist.
        /// </summary>
        public static string MachinistBrush { get => machinistBrush; set => machinistBrush = value; }

        /// <summary>
        /// gets or sets the brush for the enemy.
        /// </summary>
        public static string EnemyBrush { get => enemyBrush; set => enemyBrush = value; }

        /// <summary>
        /// Gets or sets game over text.
        /// </summary>
        public static string GameOverText { get => gameOverText; set => gameOverText = value; }

        /// <summary>
        /// Gets or sets highscore text.
        /// </summary>
        public static string HighscoreText { get => highscoreText; set => highscoreText = value; }

        /// <summary>
        /// Gets or sets game name text.
        /// </summary>
        public static string GameNameText { get => gameNameText; set => gameNameText = value; }

        /// <summary>
        /// Gets or sets menu text.
        /// </summary>
        public static string MenuText1 { get => menuText1; set => menuText1 = value; }

        /// <summary>
        /// Gets or sets menu text.
        /// </summary>
        public static string MenuText2 { get => menuText2; set => menuText2 = value; }

        /// <summary>
        /// Gets or sets menu text.
        /// </summary>
        public static string MenuText3 { get => menuText3; set => menuText3 = value; }

        /// <summary>
        /// Gets or sets quit game text.
        /// </summary>
        public static string QuitGameText { get => quitGameText; set => quitGameText = value; }
    }
}
