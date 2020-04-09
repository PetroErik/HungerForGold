using OENIK_PROG4_2020_1_LDK923_YCSNU5.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace OENIK_PROG4_2020_1_LDK923_YCSNU5.Renderer
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
        Point oldPlayerPosition;
        Dictionary<string, Brush> brushes = new Dictionary<string, Brush>();

        public GameRenderer(GameModel model)
        {
            this.model = model;
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

        Brush BackgroundBrush {  get { return GetBrush("OENIK_PROG4_2020_1_LDK923_YCSNU5.IMG.background.jpg", false); } }
        Brush DrillBrush {  get { return GetBrush("OENIK_PROG4_2020_1_LDK923_YCSNU5.IMG.Drill.png", false); } }
        Brush GroundBrush { get { return GetBrush("OENIK_PROG4_2020_1_LDK923_YCSNU5.IMG.Ground.png", true); } }
        Brush GroundLevelBrush {  get { return GetBrush("OENIK_PROG4_2020_1_LDK923_YCSNU5.IMG.GroundLevel.png", true); } }
        Brush GoldBrush {  get { return GetBrush("OENIK_PROG4_2020_1_LDK923_YCSNU5.IMG.Gold.png", true); } }
        Brush SilverBrush { get { return GetBrush("OENIK_PROG4_2020_1_LDK923_YCSNU5.IMG.Silver.png", true); } }
        Brush BronzeBrush {  get { return GetBrush("OENIK_PROG4_2020_1_LDK923_YCSNU5.IMG.Bronze.png", true); } }
        Brush SiloBrush { get { return GetBrush("OENIK_PROG4_2020_1_LDK923_YCSNU5.IMG.Silo.png", false); } }
        Brush MachinistBrush { get { return GetBrush("OENIK_PROG4_2020_1_LDK923_YCSNU5.IMG.Machinist.png", false); } }

        public Drawing BuildDrawing()
        {
            DrawingGroup dg = new DrawingGroup();
            dg.Children.Add(GetBackground());
            dg.Children.Add(GetGround());
            dg.Children.Add(GetGroundLevel());
            dg.Children.Add(GetGolds());
            dg.Children.Add(GetSilvers());
            dg.Children.Add(GetBronzes());
            dg.Children.Add(GetSilo());
            dg.Children.Add(GetMachinist());
            dg.Children.Add(GetDrill());
            dg.Children.Add(GetFuelTank());
            dg.Children.Add(GetStorage());
            dg.Children.Add(GetActualPoints());
            dg.Children.Add(GetTotalPoints());
            dg.Children.Add(GetMenuText());

            return dg;
        }

        private Drawing GetGround()
        {
           if (oldGround == null)
           {
               // Pixel  coordinates!!!!
               GeometryGroup g = new GeometryGroup();
               for (int i = 0; i < Config.MapWidth * 2; i++)
               {
                   for (int j = Config.MapHeight / 3 + 2; j < Config.MapHeight; j++)
                   {
                        Geometry box = new RectangleGeometry(new Rect(i * model.TileSize, j * model.TileSize, model.TileSize, model.TileSize));
                        g.Children.Add(box);
                   }
               }
               oldGround = new GeometryDrawing(GroundBrush, null, g);
           }
           return oldGround;
        }

        private Drawing GetGroundLevel()
        {
           if (oldGroundLevel == null)
           {
               // Pixel  coordinates!!!!
               GeometryGroup g = new GeometryGroup();
               for (int j = 0; j < Config.MapWidth * 2; j++)
               {
                    int i = (Config.MapHeight / 3 + 1) ;
                    Geometry box = new RectangleGeometry(new Rect(j * model.TileSize, i * model.TileSize, model.TileSize, model.TileSize));
                    g.Children.Add(box);
               }
               oldGroundLevel = new GeometryDrawing(GroundLevelBrush, null, g);
           }
           return oldGroundLevel;
        }

        private Drawing GetDrill()
        {
            if (oldDrill == null || oldPlayerPosition != model.drill.Location)
            {
                // Pixel  coordinates!!!!
                Geometry g = new RectangleGeometry(new Rect(model.drill.Location.X, model.drill.Location.Y, model.TileSize, model.TileSize));
                oldDrill = new GeometryDrawing(DrillBrush, null, g);
                oldPlayerPosition = model.drill.Location;
            }
            return oldDrill;
        }

        
        private Drawing GetMachinist()
        {
            if (oldMachinist == null)
            {
                Geometry machGeometry = new RectangleGeometry(new Rect(model.MachinistHouse.X, model.MachinistHouse.Y, model.TileSize * 3, model.TileSize * 5));
                oldMachinist = new GeometryDrawing(MachinistBrush, null, machGeometry);
            }
            return oldMachinist;
        }
        
        private Drawing GetSilo()
        {
            if (oldSilo == null)
            {
                Geometry siloGeometry = new RectangleGeometry(new Rect(model.SiloHouse.X, model.SiloHouse.Y, model.TileSize * 3, model.TileSize * 5));
                oldSilo = new GeometryDrawing(SiloBrush, null, siloGeometry);
            }
            return oldSilo;
        }

        private Drawing GetBronzes()
        {
            if (oldBronzes == null)
            {
                // Pixel  coordinates!!!!
                GeometryGroup g = new GeometryGroup();
                for (int i = 0; i < model.Minerals.Count(); i++)
                {
                    if (model.Minerals[i].Type == MineralsType.Bronze)
                    {
                        Geometry box = new RectangleGeometry(new Rect(model.Minerals[i].Location.X, model.Minerals[i].Location.Y, model.TileSize, model.TileSize));
                        g.Children.Add(box);
                    }
                }
                oldBronzes = new GeometryDrawing(BronzeBrush, null, g);
            }
            return oldBronzes;
        }

        private Drawing GetSilvers()
        {
            if (oldSilvers == null)
            {
                // Pixel  coordinates!!!!
                GeometryGroup g = new GeometryGroup();
                for (int i = 0; i < model.Minerals.Count(); i++)
                {
                    if (model.Minerals[i].Type == MineralsType.Silver)
                    {
                        Geometry box = new RectangleGeometry(new Rect(model.Minerals[i].Location.X, model.Minerals[i].Location.Y, model.TileSize, model.TileSize));
                        g.Children.Add(box);
                    }
                }
                oldSilvers = new GeometryDrawing(SilverBrush, null, g);
            }
            return oldSilvers;
        }

        private Drawing GetGolds()
        {
            if (oldGolds == null)
            {
                // Pixel  coordinates!!!!
                GeometryGroup g = new GeometryGroup();
                for (int i = 0; i < model.Minerals.Count(); i++)
                {
                    if (model.Minerals[i].Type == MineralsType.Gold)
                    {
                        Geometry box = new RectangleGeometry(new Rect(model.Minerals[i].Location.X, model.Minerals[i].Location.Y, model.TileSize, model.TileSize));
                        g.Children.Add(box);
                    }
                }
                oldGolds = new GeometryDrawing(GoldBrush, null, g);
            }
            return oldGolds;
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

        private Drawing GetActualPoints()
        {
            FormattedText textActual = new FormattedText($"Actual Points: {model.ActualPoints}", System.Globalization.CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface("Arial"), 10, Brushes.Black);
            GeometryDrawing actual = new GeometryDrawing(Brushes.Black, new Pen(Brushes.Black, 1), textActual.BuildGeometry(new Point(model.GameWidth / 3, 5)));

            return actual;
        }

        private Drawing GetTotalPoints()
        {
            FormattedText textTotal = new FormattedText($"Total Points: {model.TotalPoints}", System.Globalization.CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface("Arial"), 10, Brushes.Black);
            GeometryDrawing total = new GeometryDrawing(Brushes.Black, new Pen(Brushes.Black, 1), textTotal.BuildGeometry(new Point(model.GameWidth * 2 / 3, 5)));

            return total;
        }

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
