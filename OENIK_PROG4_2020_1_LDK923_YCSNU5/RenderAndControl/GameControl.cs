using HFG.Display;
using HFG.Logic;
using HFG.Repository;
using HFG.Repository.Repository;
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
        GameRenderer renderer;
<<<<<<< HEAD
        DispatcherTimer timer;
        
        DrillRepository drillRepo;
        BrickRepository brickRepo;
        ConnRepository connRepo;
        
=======
        DispatcherTimer timer;        
>>>>>>> e3cf611770f60e51d276080b1e5511f3ca607e67

        public GameControl()
        {
            Loaded += GameControl_Loaded;
        }

        private void GameControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.model = new GameModel(ActualWidth, ActualHeight);
            this.gameLogic = new GameLogic(model);
            this.gameLogic.InitialMap();
            this.renderer = new GameRenderer(model);

            Window win = Window.GetWindow(this);
            if (win != null)
            {
                win.KeyDown += Win_KeyDown;
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
            bool finished = gameLogic.tickLogic.FuelTick();
            if (finished)
            {
                //MessageBox.Show("Game Is Over", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            InvalidateVisual();
        }

        private void Win_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.A: gameLogic.moveLogic.MoveDrill(-model.drill.DrillLvl, 0); break;
                case Key.D: gameLogic.moveLogic.MoveDrill(model.drill.DrillLvl, 0); break;
                case Key.W: gameLogic.moveLogic.MoveDrill(0, -model.drill.DrillLvl); break;
                case Key.S: gameLogic.moveLogic.MoveDrill(0, model.drill.DrillLvl); break;
            }
            InvalidateVisual();
        }

        
        protected override void OnRender(DrawingContext drawingContext)
        {
            if (renderer != null)
            {
                drawingContext.DrawDrawing(renderer.BuildDrawing());
            }
        }
    }
}
