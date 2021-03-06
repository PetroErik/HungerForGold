﻿// <copyright file="GameControl.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace OENIK_PROG4_2020_1_LDK923_YCSNU5
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure;
    using System.Windows;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Threading;
    using HFG.Display;
    using HFG.Logic;

    /// <summary>
    /// Control class for the game.
    /// </summary>
    public class GameControl : FrameworkElement
    {
        private GameModel model;
        private GameLogic gameLogic;
        private VisualRenderer renderer;
        private Window win;
        private ControlExtension extension;
        private string gameMode;
        private DispatcherTimer timer;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameControl"/> class.
        /// </summary>
        public GameControl()
        {
            this.Loaded += this.GameControl_Loaded;
        }

        /// <summary>
        /// Renders the game.
        /// </summary>
        /// <param name="drawingContext">DrawingContext for drawing the game.</param>
        protected override void OnRender(DrawingContext drawingContext)
        {
            if (this.gameMode == "menu" && this.renderer != null)
            {
                drawingContext.DrawDrawing(this.renderer.MenuDrawing());
            }

            if (this.gameMode == "game" && this.renderer != null)
            {
                drawingContext.DrawDrawing(this.renderer.GameDrawing(this.gameLogic.GameOver()));
            }

            if (this.gameMode == "highscore" && this.renderer != null)
            {
                List<int?> highscore;
                string message = CONFIG.HighscoreMessage;
                try
                {
                    highscore = this.gameLogic.DbLogic.Highscore();
                }
                catch (DbUpdateException ex)
                {
                    highscore = new List<int?>();
                    message = ex.Message;
                }

                drawingContext.DrawDrawing(this.renderer.HighscoreDrawing(highscore, message));
            }
        }

        private Point GetMousePos()
        {
            return this.win.PointToScreen(Mouse.GetPosition(this.win));
        }

        private void GameControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.model = new GameModel(this.ActualWidth, this.ActualHeight);
            this.gameLogic = new GameLogic(this.model);
            this.gameLogic.InitialMap();
            this.gameMode = "menu";

            this.renderer = new VisualRenderer(this.model);
            this.extension = new ControlExtension(this.gameLogic);

            this.win = Window.GetWindow(this);
            if (this.win != null)
            {
                this.win.KeyDown += this.Win_KeyDown;
                this.win.MouseDown += this.Win_MouseDown;
                this.timer = new DispatcherTimer();
                this.timer.Interval = TimeSpan.FromMilliseconds(200);
                this.timer.Tick += this.Timer_Tick;
                this.timer.Start();
            }

            this.InvalidateVisual();
        }

        private void Win_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (this.extension.ClickOnMenu(e.GetPosition(this).X, e.GetPosition(this).Y, this.gameMode))
            {
                this.gameMode = "menu";
            }

            if (this.extension.ClickOnStart(e.GetPosition(this).X, e.GetPosition(this).Y, this.gameMode))
            {
                this.StartGame();
            }

            if (this.extension.ClickOnContinue(e.GetPosition(this).X, e.GetPosition(this).Y, this.gameMode))
            {
                this.GameContinues();
            }

            if (this.extension.ClickOnHighscore(e.GetPosition(this).X, e.GetPosition(this).Y, this.gameMode))
            {
                this.gameMode = "highscore";
            }

            if (this.extension.ClickOnBack(e.GetPosition(this).X, e.GetPosition(this).Y, this.gameMode))
            {
                this.gameMode = "menu";
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (!this.gameLogic.GameOver())
            {
                this.gameLogic.TickLogic.FuelTick();
                this.gameLogic.TickLogic.EnemyTick();
                this.gameLogic.TickLogic.BoomTick();
            }

            this.InvalidateVisual();
        }

        private void SaveIntoDB()
        {
            try
            {
                this.gameLogic.DbLogic.SaveGame(this.model.Drill, this.model.Minerals);
            }
            catch (DbUpdateException ex)
            {
                MessageBox.Show($"DATABASE ERROR {ex.Message}", string.Empty, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void GameContinues()
        {
            try
            {
                if (this.gameLogic.DbLogic.LoadGame())
                {
                    this.gameMode = "game";
                }
                else
                {
                    MessageBox.Show("There is no Save Game!", string.Empty, MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (DbUpdateException ex)
            {
                MessageBox.Show($"DATABASE ERROR {ex.Message}", string.Empty, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void GameExit()
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to quit?", CONFIG.QuitGameText, MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                this.SaveIntoDB();

                this.gameMode = "menu";
            }
        }

        private void Move(string move)
        {
            if (!this.gameLogic.GameOver())
            {
                switch (move)
                {
                    case "LEFT": this.gameLogic.MoveLogic.MoveDrill(-1, 0); break;
                    case "RIGHT": this.gameLogic.MoveLogic.MoveDrill(1, 0); break;
                    case "UP": this.gameLogic.MoveLogic.MoveDrill(0, -1); break;
                    case "DOWN": this.gameLogic.MoveLogic.MoveDrill(0, 1); break;
                }
            }

            if (this.gameLogic.GameOver() == true)
            {
                this.SaveIntoDB();
            }
        }

        private void StartGame()
        {
            this.gameMode = "game";
            try
            {
                this.gameLogic.StartGame();
                this.gameLogic.GameOver();
            }
            catch (DbUpdateException ex)
            {
                MessageBox.Show($"DATABASE ERROR {ex.Message}", string.Empty, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Win_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.A: this.Move("LEFT"); break;
                case Key.D: this.Move("RIGHT"); break;
                case Key.W: this.Move("UP"); break;
                case Key.S: this.Move("DOWN"); break;
                case Key.D0: this.gameMode = "menu"; break;
                case Key.D1: this.StartGame(); break;
                case Key.D2: this.GameContinues(); break;
                case Key.D3: this.gameMode = "highscore"; break;
                case Key.F1: this.gameLogic.MoveLogic.UpgradeDrill(); break;
                case Key.F2: this.gameLogic.MoveLogic.UpgradeStorage(); break;
                case Key.F3: this.gameLogic.MoveLogic.UpgradeFuelTank(); break;
                case Key.Escape: this.GameExit(); break;
            }

            this.InvalidateVisual();
        }
    }
}
