// <copyright file="ControlExtension.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace OENIK_PROG4_2020_1_LDK923_YCSNU5
{
    using HFG.Logic;

    /// <summary>
    /// Extension class for GameControl to avoid "God Class".
    /// </summary>
    public class ControlExtension
    {
        private GameLogic gameLogic;

        /// <summary>
        /// Initializes a new instance of the <see cref="ControlExtension"/> class.
        /// </summary>
        /// <param name="logic">GameLogic instance</param>
        public ControlExtension(GameLogic logic)
        {
            this.gameLogic = logic;
        }

        /// <summary>
        /// Method to check is the mouse click was on the menu button.
        /// </summary>
        /// <param name="x">X coordinate of the click.</param>
        /// <param name="y">Y coordinate of the click.</param>
        /// <param name="gameMode">Current window that is displayed.</param>
        /// <returns>True if the click was on the menu button.</returns>
        public bool ClickOnMenu(double x, double y, string gameMode)
        {
            if (x >= this.gameLogic.GameModel.MenuButton[0] && y >= this.gameLogic.GameModel.MenuButton[1] &&
                x <= this.gameLogic.GameModel.MenuButton[0] + this.gameLogic.GameModel.MenuButton[2] &&
                y <= this.gameLogic.GameModel.MenuButton[1] + this.gameLogic.GameModel.MenuButton[3] &&
                gameMode == "game")
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Method to check is the mouse click was on the start button.
        /// </summary>
        /// <param name="x">X coordinate of the click.</param>
        /// <param name="y">Y coordinate of the click.</param>
        /// <param name="gameMode">Current window that is displayed.</param>
        /// <returns>True if the click was on the start button.</returns>
        public bool ClickOnStart(double x, double y, string gameMode)
        {
            if (x >= this.gameLogic.GameModel.StartButton[0] && y >= this.gameLogic.GameModel.StartButton[1] &&
                x <= this.gameLogic.GameModel.StartButton[0] + this.gameLogic.GameModel.StartButton[2] &&
                y <= this.gameLogic.GameModel.StartButton[1] + this.gameLogic.GameModel.StartButton[3] &&
                gameMode == "menu")
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Method to check is the mouse click was on the continue button.
        /// </summary>
        /// <param name="x">X coordinate of the click.</param>
        /// <param name="y">Y coordinate of the click.</param>
        /// <param name="gameMode">Current window that is displayed.</param>
        /// <returns>True if the click was on the continue button.</returns>
        public bool ClickOnContinue(double x, double y, string gameMode)
        {
            if (x >= this.gameLogic.GameModel.ContinueButton[0] && y >= this.gameLogic.GameModel.ContinueButton[1] &&
                x <= this.gameLogic.GameModel.ContinueButton[0] + this.gameLogic.GameModel.ContinueButton[2] &&
                y <= this.gameLogic.GameModel.ContinueButton[1] + this.gameLogic.GameModel.ContinueButton[3] &&
                gameMode == "menu")
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Method to check is the mouse click was on the highscore button.
        /// </summary>
        /// <param name="x">X coordinate of the click.</param>
        /// <param name="y">Y coordinate of the click.</param>
        /// <param name="gameMode">Current window that is displayed.</param>
        /// <returns>True if the click was on the highscore button.</returns>
        public bool ClickOnHighscore(double x, double y, string gameMode)
        {
            if (x >= this.gameLogic.GameModel.HighscoreButton[0] && y >= this.gameLogic.GameModel.HighscoreButton[1] &&
                x <= this.gameLogic.GameModel.HighscoreButton[0] + this.gameLogic.GameModel.HighscoreButton[2] &&
                y <= this.gameLogic.GameModel.HighscoreButton[1] + this.gameLogic.GameModel.HighscoreButton[3] &&
                gameMode == "menu")
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Method to check is the mouse click was on the back button.
        /// </summary>
        /// <param name="x">X coordinate of the click.</param>
        /// <param name="y">Y coordinate of the click.</param>
        /// <param name="gameMode">Current window that is displayed.</param>
        /// <returns>True if the click was on the back button.</returns>
        public bool ClickOnBack(double x, double y, string gameMode)
        {
            if (x >= this.gameLogic.GameModel.MenuButton[0] && y >= this.gameLogic.GameModel.MenuButton[1] &&
                x <= this.gameLogic.GameModel.MenuButton[0] + this.gameLogic.GameModel.MenuButton[2] &&
                y <= this.gameLogic.GameModel.MenuButton[1] + this.gameLogic.GameModel.MenuButton[3] &&
                gameMode == "highscore")
            {
                return true;
            }

            return false;
        }
    }
}
