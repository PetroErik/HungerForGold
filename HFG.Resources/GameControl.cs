//using OENIK_PROG4_2020_1_LDK923_YCSNU5.Logic;
//using OENIK_PROG4_2020_1_LDK923_YCSNU5.Model;
//using OENIK_PROG4_2020_1_LDK923_YCSNU5.Renderer;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows;
//using System.Windows.Input;
//using System.Windows.Media;
//using System.Windows.Threading;

//namespace OENIK_PROG4_2020_1_LDK923_YCSNU5
//{
//    class GameControl : FrameworkElement
//    {
//        GameModel model;
//        GameLogic logic;
//        GameRenderer renderer;
//        DispatcherTimer timer;

//        public GameControl()
//        {
//            Loaded += GameControl_Loaded;
//        }

//        private void GameControl_Loaded(object sender, RoutedEventArgs e)
//        {
//            this.model = new GameModel(ActualWidth, ActualHeight);
//            this.logic = new GameLogic(model);
//            this.renderer = new GameRenderer(model);

//            GameWindow win = new GameWindow();
//            //Window win = Window.GetWindow();
//            if (win != null)
//            {
//                win.KeyDown += Win_KeyDown;
//                win.MouseDown += Win_MouseDown;
//                timer = new DispatcherTimer();
//                timer.Interval = TimeSpan.FromMilliseconds(100);
//                timer.Tick += Timer_Tick;
//                timer.Start();
//            }

//            InvalidateVisual();
//        }

//        private void Timer_Tick(object sender, EventArgs e)
//        {
//            logic.GravityTick();
//            //logic.FuelTick();
//            bool finished = logic.FuelTick();
//            if (finished)
//            {
//                //MessageBox.Show("Game Is Over", "", MessageBoxButton.OK, MessageBoxImage.Error);
//            }
//            InvalidateVisual();
//        }

//        private void Win_MouseDown(object sender, MouseButtonEventArgs e)
//        {
//            throw new NotImplementedException();
//        }

//        private void Win_KeyDown(object sender, KeyEventArgs e)
//        {
//            switch (e.Key)
//            {
//                case Key.A: logic.MoveDrill(-model.drill.DrillLvl, 0); break;
//                case Key.D: logic.MoveDrill(model.drill.DrillLvl, 0); break;
//                case Key.W: logic.MoveDrill(0, -model.drill.DrillLvl); break;
//                case Key.S: logic.MoveDrill(0, model.drill.DrillLvl); break;
//            }
//            InvalidateVisual();
//        }

//        protected override void OnRender(DrawingContext drawingContext)
//        {
//            if (renderer != null)
//            {
//                drawingContext.DrawDrawing(renderer.BuildDrawing());
//            }
//        }
//    }
//}
