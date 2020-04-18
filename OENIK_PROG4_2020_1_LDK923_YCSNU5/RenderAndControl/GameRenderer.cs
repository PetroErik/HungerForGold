using HFG.Display;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace OENIK_PROG4_2020_1_LDK923_YCSNU5
{
    class GameRenderer
    {
        GameModel model;

        Drawing oldBackground;
        Drawing oldGround;
        Drawing oldGroundLevel;
        Drawing oldGolds;
        Drawing oldSilvers;
        Drawing oldBronzes;
        Drawing oldDrill;
        Drawing oldSilo;
        Drawing oldMachinist;
        Drawing DeletingBlock;
        Point oldPlayerPosition;
        Point currentPos;

        double startingPointToDrill;


        Dictionary<string, Brush> brushes = new Dictionary<string, Brush>();

        public GameRenderer(GameModel model)
        {
            this.model = model;

            startingPointToDrill = model.GameHeight / 2 - model.TileSize * 4; //Starting point to drill - draw black box
        }

        public void Reset()
        {
            oldBackground = null;
            oldGolds = null;
            oldSilvers = null;
            oldDrill = null;
            oldPlayerPosition = new Point(-1, -1);
            brushes.Clear();
        }

        Brush GetBrush(string fname, bool isTiled)
        {
            if (!brushes.ContainsKey(fname))
            {
                //ImageBrush ib = new ImageBrush(new BitmapImage(new Uri()))
                BitmapImage img = new BitmapImage();
                img.BeginInit();
                img.StreamSource = Assembly.GetExecutingAssembly().GetManifestResourceStream(fname);
                img.EndInit();
                ImageBrush ib = new ImageBrush(img);
                if (isTiled)
                {
                    ib.TileMode = TileMode.Tile;
                    ib.Viewport = new Rect(0, 0, model.TileSize, model.TileSize);
                    ib.ViewportUnits = BrushMappingMode.Absolute;
                }

                brushes.Add(fname, ib);
            }
            return brushes[fname];
        }

        Brush BackgroundBrush { get { return GetBrush(CONFIG.BackgroundBrush, false); } }
        Brush DrillBrush { get { return GetBrush(CONFIG.DrillBrush, false); } }
        Brush GroundBrush { get { return GetBrush(CONFIG.GroundBrush, true); } }
        Brush GroundLevelBrush { get { return GetBrush(CONFIG.GroundLevelBrush, true); } }
        Brush GoldBrush { get { return GetBrush(CONFIG.GoldBrush, true); } }
        Brush SilverBrush { get { return GetBrush(CONFIG.SilverBrush, true); } }
        Brush BronzeBrush { get { return GetBrush(CONFIG.BronzeBrush, true); } }
        Brush SiloBrush { get { return GetBrush(CONFIG.SiloBrush, false); } }
        Brush MachinistBrush { get { return GetBrush(CONFIG.MachinistBrush, false); } }

        Brush DeletingBrush { get { return new SolidColorBrush(Colors.Black); } }

        [Obsolete]
        public Drawing BuildDrawing()
        {
            DrawingGroup dg = new DrawingGroup();
            dg.Children.Add(GetBackground());
            dg.Children.Add(GetGround());
            //dg.Children.Add(GetGroundLevel()); // We dont need this anymore
            //dg.Children.Add(GetGolds());
            //dg.Children.Add(GetSilvers());
            //dg.Children.Add(GetBronzes());
            dg.Children.Add(GetSilo());
            dg.Children.Add(GetMachinist());
            dg.Children.Add(GetDrill());
            dg.Children.Add(GetFuelTank());
            dg.Children.Add(GetStorage());
            dg.Children.Add(GetActualPoints());
            dg.Children.Add(GetTotalPoints());
            dg.Children.Add(GetMenuText());
           //dg.Children.Add(Debug());

            return dg;
        }

        DrawingGroup groundAndDeleting = new DrawingGroup();

        private Drawing GetGround()
        {
            if (oldGround == null)
            {
                // Pixel  coordinates!!!!

                GeometryGroup g = new GeometryGroup();
                for (int i = 0; i < CONFIG.MapWidth * 2; i++)
                {
                    for (int j = CONFIG.MapHeight / 3 + 2; j < CONFIG.MapHeight; j++)
                    {
                        Geometry box = new RectangleGeometry(new Rect(i * model.TileSize, j * model.TileSize, model.TileSize, model.TileSize));
                        g.Children.Add(box);
                    }
                }

                oldGround = new GeometryDrawing(GroundBrush, null, g);
                groundAndDeleting.Children.Add(oldGround);
            }

            GetGroundLevel();
            GetBronzes();
            GetSilvers();
            GetGolds();

            return groundAndDeleting;
        }

        private void GetGroundLevel()
        {
            if (oldGroundLevel == null)
            {
                // Pixel  coordinates!!!!
                GeometryGroup g = new GeometryGroup();
                for (int j = 0; j < CONFIG.MapWidth * 2; j++)
                {
                    int i = (CONFIG.MapHeight / 3 + 1);
                    Geometry box = new RectangleGeometry(new Rect(j * model.TileSize, i * model.TileSize, model.TileSize, model.TileSize));
                    g.Children.Add(box);
                }
                oldGroundLevel = new GeometryDrawing(GroundLevelBrush, null, g);
                groundAndDeleting.Children.Add(oldGroundLevel);
            }
        }

        private Drawing GetDrill()
        {
            currentPos = new Point(model.drill.Location[0], model.drill.Location[1]);
            if (oldDrill == null || (oldPlayerPosition != currentPos))
            {

                // Pixel  coordinates!!!!
                Geometry g = new RectangleGeometry(new Rect(this.model.drill.Location[0], model.drill.Location[1], model.TileSize, model.TileSize));
                oldDrill = new GeometryDrawing(DrillBrush, null, g);

                if (oldPlayerPosition.Y >= startingPointToDrill)
                {
                    Geometry blackbox = new RectangleGeometry(new Rect(oldPlayerPosition.X, oldPlayerPosition.Y, model.TileSize, model.TileSize));
                    GeometryDrawing drawingBlackBox = new GeometryDrawing(DeletingBrush, null, blackbox);
                    groundAndDeleting.Children.Add(drawingBlackBox);
                }

                oldPlayerPosition = currentPos;

            }
            return oldDrill;
        }


        private Drawing GetMachinist()
        {
            if (oldMachinist == null)
            {
                Geometry machGeometry = new RectangleGeometry(new Rect(model.MachinistHouse.Location[0], model.MachinistHouse.Location[1], model.TileSize * 3, model.TileSize * 5));
                oldMachinist = new GeometryDrawing(MachinistBrush, null, machGeometry);
            }
            return oldMachinist;
        }

        private Drawing GetSilo()
        {
            if (oldSilo == null)
            {
                Geometry siloGeometry = new RectangleGeometry(new Rect(model.SiloHouse.Location[0], model.SiloHouse.Location[1], model.TileSize * 3, model.TileSize * 5));
                oldSilo = new GeometryDrawing(SiloBrush, null, siloGeometry);
            }
            return oldSilo;
        }

        private void GetBronzes()
        {
            if (oldBronzes == null)
            {
                // Pixel  coordinates!!!!
                GeometryGroup g = new GeometryGroup();
                for (int i = 0; i < model.Minerals.Count(); i++)
                {
                    if (model.Minerals[i].Type == MineralsType.Bronze)
                    {
                        Geometry box = new RectangleGeometry(new Rect(model.Minerals[i].Location[0], model.Minerals[i].Location[1], model.TileSize, model.TileSize));
                        g.Children.Add(box);
                    }
                }
                oldBronzes = new GeometryDrawing(BronzeBrush, null, g);
                groundAndDeleting.Children.Add(oldBronzes);
            }          
        }

        private void GetSilvers()
        {
            if (oldSilvers == null)
            {
                // Pixel  coordinates!!!!
                GeometryGroup g = new GeometryGroup();
                for (int i = 0; i < model.Minerals.Count(); i++)
                {
                    if (model.Minerals[i].Type == MineralsType.Silver)
                    {
                        Geometry box = new RectangleGeometry(new Rect(model.Minerals[i].Location[0], model.Minerals[i].Location[1], model.TileSize, model.TileSize));
                        g.Children.Add(box);
                    }
                }
                oldSilvers = new GeometryDrawing(SilverBrush, null, g);
                groundAndDeleting.Children.Add(oldSilvers);
            }
        }

        private void GetGolds()
        {
            if (oldGolds == null)
            {
                // Pixel  coordinates!!!!
                GeometryGroup g = new GeometryGroup();
                for (int i = 0; i < model.Minerals.Count(); i++)
                {
                    if (model.Minerals[i].Type == MineralsType.Gold)
                    {
                        Geometry box = new RectangleGeometry(new Rect(model.Minerals[i].Location[0], model.Minerals[i].Location[1], model.TileSize, model.TileSize));
                        g.Children.Add(box);
                    }
                }
                oldGolds = new GeometryDrawing(GoldBrush, null, g);
                groundAndDeleting.Children.Add(oldGolds);
            }
        }

        private Drawing GetBackground()
        {
            if (oldBackground == null)
            {
                Geometry bgGeometry = new RectangleGeometry(new Rect(0, 0, model.GameWidth, model.GameHeight));
                oldBackground = new GeometryDrawing(BackgroundBrush, null, bgGeometry);
            }
            return oldBackground;
        }

        [Obsolete]
        private Drawing GetFuelTank()
        {
            DrawingGroup g = new DrawingGroup();
            GeometryDrawing background = new GeometryDrawing(Brushes.White, new Pen(Brushes.White, 1), new RectangleGeometry(new Rect(model.GameWidth - 100, model.GameHeight - 20, model.drill.FuelCapacity * 0.3, 10)));
            GeometryDrawing fuelfullnes = new GeometryDrawing(Brushes.Red, new Pen(Brushes.Red, 1), new RectangleGeometry(new Rect(model.GameWidth - 100, model.GameHeight - 20, model.drill.FuelTankFullness * 0.3, 10)));

            FormattedText textFuelTank = new FormattedText("TuelTank", System.Globalization.CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface("Arial"), 8, Brushes.Black);
            GeometryDrawing fuel = new GeometryDrawing(Brushes.Black, new Pen(Brushes.Black, 1), textFuelTank.BuildGeometry(new Point(model.GameWidth - 70, model.GameHeight - 30)));

            FormattedText textFuelCapacity = new FormattedText($"{model.drill.FuelTankFullness}/{model.drill.FuelCapacity}", System.Globalization.CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface("Arial"), 8, Brushes.Black);
            GeometryDrawing cap = new GeometryDrawing(Brushes.Black, new Pen(Brushes.Black, 1), textFuelCapacity.BuildGeometry(new Point(model.GameWidth - 68, model.GameHeight - 20)));

            g.Children.Add(background);
            g.Children.Add(fuelfullnes);
            g.Children.Add(fuel);
            g.Children.Add(cap);
            return g;
        }

        [Obsolete]
        private Drawing GetStorage()
        {
            DrawingGroup g = new DrawingGroup();
            GeometryDrawing background = new GeometryDrawing(Brushes.White, new Pen(Brushes.White, 1), new RectangleGeometry(new Rect(10, model.GameHeight - 20, model.drill.StorageCapacity * 0.3, 10)));
            GeometryDrawing storagefullnes = new GeometryDrawing(Brushes.Green, new Pen(Brushes.Green, 1), new RectangleGeometry(new Rect(10, model.GameHeight - 20, model.drill.StorageFullness * 0.3, 10)));

            FormattedText textStorage = new FormattedText("Storage", System.Globalization.CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface("Arial"), 8, Brushes.Black);
            GeometryDrawing storage = new GeometryDrawing(Brushes.Black, new Pen(Brushes.Black, 1), textStorage.BuildGeometry(new Point(40, model.GameHeight - 30)));

            FormattedText textStorageCapacity = new FormattedText($"{model.drill.StorageFullness}/{model.drill.StorageCapacity}", System.Globalization.CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface("Arial"), 8, Brushes.Black);
            GeometryDrawing cap = new GeometryDrawing(Brushes.Black, new Pen(Brushes.Black, 1), textStorageCapacity.BuildGeometry(new Point(42, model.GameHeight - 20)));

            g.Children.Add(background);
            g.Children.Add(storagefullnes);
            g.Children.Add(storage);
            g.Children.Add(cap);
            return g;
        }

        [Obsolete]
        private Drawing GetActualPoints()
        {
            FormattedText textActual = new FormattedText($"Actual Points: {model.ActualPoints}", System.Globalization.CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface("Arial"), 10, Brushes.Black);
            GeometryDrawing actual = new GeometryDrawing(Brushes.Black, new Pen(Brushes.Black, 1), textActual.BuildGeometry(new Point(model.GameWidth / 3, 5)));

            return actual;
        }

        [Obsolete]
        private Drawing GetTotalPoints()
        {
            FormattedText textTotal = new FormattedText($"Total Points: {model.TotalPoints}", System.Globalization.CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface("Arial"), 10, Brushes.Black);
            GeometryDrawing total = new GeometryDrawing(Brushes.Black, new Pen(Brushes.Black, 1), textTotal.BuildGeometry(new Point(model.GameWidth * 2 / 3, 5)));

            return total;
        }

        private Drawing Debug()
        {
            FormattedText textTotal = new FormattedText($"OldplayerPostition: {oldPlayerPosition.Y} {this.model.GameHeight}"
                , System.Globalization.CultureInfo.CurrentCulture, FlowDirection.LeftToRight, 
                new Typeface("Arial"), 20, Brushes.Black);
            GeometryDrawing total = new GeometryDrawing(Brushes.Black, new Pen(Brushes.Black, 1), 
                textTotal.BuildGeometry(new Point(model.GameWidth * 2 / 3, 5)));

            return total;
        }

        [Obsolete]
        private Drawing GetMenuText()
        {
            DrawingGroup g = new DrawingGroup();

            GeometryDrawing button = new GeometryDrawing(Brushes.AliceBlue, new Pen(Brushes.Blue, 1), new RectangleGeometry(new Rect(2.5, 2.5, 31, 16)));
            FormattedText textMenu = new FormattedText("Menu", System.Globalization.CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface("Arial"), 10, Brushes.Black);
            GeometryDrawing menu = new GeometryDrawing(Brushes.Black, new Pen(Brushes.Black, 1), textMenu.BuildGeometry(new Point(5, 5)));

            g.Children.Add(button);
            g.Children.Add(menu);

            return g;
        }
    }
}
