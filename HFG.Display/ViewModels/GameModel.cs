// <copyright file="GameModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HFG.Display
{
    using System.Collections.Generic;
    using HFG.Display.Elements;

    /// <summary>
    /// Model of our Game.
    /// </summary>
    public class GameModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GameModel"/> class.
        /// Sets the values of game width and height.
        /// </summary>
        /// <param name="w">Width of the Game.</param>
        /// <param name="h">Height of the Game.</param>
        public GameModel(double w, double h)
        {
            this.GameWidth = w;
            this.GameHeight = h;
        }

        /// <summary>
        /// Gets or sets the total points that are collected.
        /// </summary>
        public int TotalPoints { get; set; }

        /// <summary>
        /// Gets or sets the current points that are collected.
        /// </summary>
        public int ActualPoints { get; set; }

        /// <summary>
        /// Gets or sets the drill element of the game.
        /// </summary>
        public Drill Drill { get; set; }

        /// <summary>
        /// Gets or sets the Silo element of the game.
        /// </summary>
        public SiloHouse SiloHouse { get; set; }

        /// <summary>
        /// Gets or sets the Machinist element of the game.
        /// </summary>
        public MachinistHouse MachinistHouse { get; set; }

        /// <summary>
        /// Gets or sets the list of the minerals of the game.
        /// </summary>
        public List<Mineral> Minerals { get; set; }

        /// <summary>
        /// Gets or sets the list of enemies of the game.
        /// </summary>
        public List<Enemy> Enemies { get; set; }

        /// <summary>
        /// Gets or sets the list of the  bombs of the game.
        /// </summary>
        public List<Bomb> Bombs { get; set; }

        /// <summary>
        /// Gets or sets the width of the game.
        /// </summary>
        public double GameWidth { get; set; }

        /// <summary>
        /// Gets or sets the height of the game.
        /// </summary>
        public double GameHeight { get; set; }

        /// <summary>
        /// Gets or sets the size of tiles of the game.
        /// </summary>
        public double TileSize { get; set; }

        /*
         double array to set area for mouse click:
         index 0: X,
         index 1: Y,
         index 2: width,
         index 3: height
             */

        /// <summary>
        /// Gets or sets the area of the Menu button.
        /// </summary>
        public double[] MenuButton { get; set; }

        /// <summary>
        /// Gets or sets the area of the Start button.
        /// </summary>
        public double[] StartButton { get; set; }

        /// <summary>
        /// Gets or sets the area of the continue button.
        /// </summary>
        public double[] ContinueButton { get; set; }

        /// <summary>
        /// Gets or sets the area of the highscore button.
        /// </summary>
        public double[] HighscoreButton { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets the bomb's explosion state .
        /// </summary>
        public bool IsExplode { get; set; }
    }
}
