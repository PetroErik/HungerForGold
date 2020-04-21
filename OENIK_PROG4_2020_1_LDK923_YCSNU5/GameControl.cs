using HFG.Display;
using HFG.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace OENIK_PROG4_2020_1_LDK923_YCSNU5
{
    class GameControl : FrameworkElement
    {
        GameModel model;

        GameLogic gameLogic;

        VisualRenderer renderer;

        Window win;

        string gameMode;

        DispatcherTimer timer;

        public GameControl()
        {
            Loaded += GameControl_Loaded;
        }

        Point GetMousePos()
        {
            return win.PointToScreen(Mouse.GetPosition(win));
        }
        private void GameControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.model = new GameModel(ActualWidth, ActualHeight);
            this.gameLogic = new GameLogic(model);
            this.gameLogic.InitialMap();
            this.gameMode = "menu";

            this.renderer = new VisualRenderer(model);

            win = Window.GetWindow(this);
            if (win != null)
            {
                win.KeyDown += Win_KeyDown;
                //win.MouseDown += Win_MouseDown;
                timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromMilliseconds(100);
                timer.Tick += Timer_Tick;
                timer.Start();
            }

            InvalidateVisual();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            //gameLogic.tickLogic.GravityTick();
            //logic.FuelTick();
            gameLogic.tickLogic.FuelTick();
            InvalidateVisual();
        }

        private void gameContinues()
        {
            try
            {
                if (this.gameLogic.dbLogic.LoadGame())
                {
                    gameMode = "game";
                }
                else
                {
                    MessageBox.Show("There is no Save Game!", "", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }catch(Exception ex)
            {
                MessageBox.Show($"DATABASE ERROR {ex.Message}", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void gameExit()
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to quit?","QUIT GAME",
               MessageBoxButton.YesNo, MessageBoxImage.Question);

            
             if (result == MessageBoxResult.Yes)
            {
                try
                {
                    this.gameLogic.dbLogic.SaveGame(this.model.drill, this.model.Minerals);
                }
                catch(Exception ex)
                {
                    MessageBox.Show($"DATABASE ERROR {ex.Message}", "", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                    gameMode = "menu";
                
            }
        }

        private void Move(string move)
        {
            if (!this.gameLogic.GameOver())
            {
                switch (move)
                {
                    case "LEFT": gameLogic.moveLogic.MoveDrill(-model.drill.DrillLvl, 0); break;
                    case "RIGHT": gameLogic.moveLogic.MoveDrill(model.drill.DrillLvl, 0); break;
                    case "UP": gameLogic.moveLogic.MoveDrill(0, -model.drill.DrillLvl); break;
                    case "DOWN": gameLogic.moveLogic.MoveDrill(0, model.drill.DrillLvl); break;
                }
            }
            if(this.gameLogic.GameOver() == true)
            {
                this.gameLogic.dbLogic.SaveGame(this.model.drill, this.model.Minerals);
            }
        }

        private void Win_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                
                case Key.A: Move("LEFT"); break;
                case Key.D: Move("RIGHT"); break;
                case Key.W: Move("UP"); break;
                case Key.S: Move("DOWN"); break;
                case Key.D0: gameMode = "menu"; break;
                case Key.D1: gameMode = "game"; this.gameLogic.startGame(); break;
                case Key.D2: gameContinues(); break;
                case Key.D3: gameMode = "highscore"; break;
                case Key.Escape: gameExit();break;
            }
            InvalidateVisual();
        }
        
        protected override void OnRender(DrawingContext drawingContext)
        {
            if (gameMode == "menu" && renderer != null)
            {
                drawingContext.DrawDrawing((renderer.MenuDrawing()));
            }
            if (gameMode == "game" && renderer != null)
            {             
                drawingContext.DrawDrawing(renderer.GameDrawing(this.gameLogic.GameOver()));
            }
            if (gameMode == "highscore" && renderer != null)
            {
                List<int?> highscore;
                string message = "Done";
                try
                {
                    highscore = this.gameLogic.dbLogic.Highscore();
                }
                catch (Exception ex)
                {
                    highscore = new List<int?>();
                    message = ex.Message;
                }
                drawingContext.DrawDrawing(renderer.HighscoreDrawing(highscore, message));
            }
        }
    }
}
