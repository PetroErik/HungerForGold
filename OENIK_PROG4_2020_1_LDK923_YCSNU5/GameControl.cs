// <copyright file="GameControl.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace OENIK_PROG4_2020_1_LDK923_YCSNU5
{
    using System;
    using System.Collections.Generic;
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
                string message = "Done";
                try
                {
                    highscore = this.gameLogic.DbLogic.Highscore();
                }
                catch (Exception ex)
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
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            this.gameLogic.TickLogic.FuelTick();
            this.gameLogic.TickLogic.EnemyTick();
            this.InvalidateVisual();
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
            catch (Exception ex)
            {
                MessageBox.Show($"DATABASE ERROR {ex.Message}", string.Empty, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void GameExit()
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to quit?", "QUIT GAME", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    this.gameLogic.DbLogic.SaveGame(this.model.Drill, this.model.Minerals);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"DATABASE ERROR {ex.Message}", string.Empty, MessageBoxButton.OK, MessageBoxImage.Error);
                }

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
                this.gameLogic.DbLogic.SaveGame(this.model.Drill, this.model.Minerals);
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
                case Key.D1: this.gameMode = "game"; this.gameLogic.StartGame(); break;
                case Key.D2: this.GameContinues(); break;
                case Key.D3: this.gameMode = "highscore"; break;
                case Key.F1: this.gameLogic.MoveLogic.UpgradeDrill(); break;
                case Key.F2: this.gameLogic.MoveLogic.UpgradeFuelTank(); break;
                case Key.F3: this.gameLogic.MoveLogic.UpgradeStorage(); break;
                case Key.Escape: this.GameExit(); break;
            }

            this.InvalidateVisual();
        }
    }
}
