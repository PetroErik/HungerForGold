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
    class MenuRenderer
    {
        GameModel model;

        Drawing oldBackground;
        Drawing oldGround;
        Drawing oldGroundLevel;

        Drawing oldDrill;
        Drawing oldSilo;
        Drawing oldMachinist;


        public DrawingGroup groupButton;


        Dictionary<string, Brush> brushes = new Dictionary<string, Brush>();

        public MenuRenderer(GameModel model)
        {
            this.model = model;
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
        Brush SiloBrush { get { return GetBrush(CONFIG.SiloBrush, false); } }
        Brush MachinistBrush { get { return GetBrush(CONFIG.MachinistBrush, false); } }

        Brush DeletingBrush { get { return new SolidColorBrush(Colors.Black); } }

        [Obsolete]
        public Drawing BuildDrawing()
        {
            DrawingGroup dg = new DrawingGroup();

            groupButton = new DrawingGroup();
            dg.Children.Add(GetBackground());
            dg.Children.Add(GetGround());
            dg.Children.Add(GetSilo());
            dg.Children.Add(GetMachinist());
            dg.Children.Add(GetDrill());

            groupButton.Children.Add(TitleText("Hunger for Gold", this.model.GameWidth / 2 - 180, this.model.GameHeight / 2 - 60,
                this.model.GameWidth / 2 - 90, this.model.GameHeight / 2 - 60
                ));
            groupButton.Children.Add(TitleText("1. Start Game", this.model.GameWidth / 2 - 180, this.model.GameHeight / 2,
                this.model.GameWidth / 2 - 90, this.model.GameHeight / 2
                ));
            groupButton.Children.Add(TitleText("2. Continues", this.model.GameWidth / 2 - 180, this.model.GameHeight / 2 + 60,
                this.model.GameWidth / 2 - 90, this.model.GameHeight / 2 + 60
                ));
            groupButton.Children.Add(TitleText("3. Highscore", this.model.GameWidth / 2 - 180, this.model.GameHeight / 2 + 120,
                this.model.GameWidth / 2 - 90, this.model.GameHeight / 2 + 120
                ));

            dg.Children.Add(groupButton);

            return dg;
        }

        DrawingGroup groundAndDeleting = new DrawingGroup();

        private Drawing GetGround()
        {
            if (oldGround == null)
            {
                // Pixel  coordinates!!!!

                //REDUCE OVERUSE FOR LOOP
                GeometryGroup groupGound = new GeometryGroup();
                GeometryGroup groupGoundLevel = new GeometryGroup();

                int numOfGroundLevel = (CONFIG.MapHeight / 3 + 1);
                for (int i = 0; i < CONFIG.MapWidth * 2; i++)
                {
                    Geometry groundLevelBox = new RectangleGeometry(new Rect(i * model.TileSize, numOfGroundLevel * model.TileSize, model.TileSize, model.TileSize));
                    groupGoundLevel.Children.Add(groundLevelBox);

                    for (int j = CONFIG.MapHeight / 3 + 2; j < CONFIG.MapHeight; j++)
                    {
                        Geometry box = new RectangleGeometry(new Rect(i * model.TileSize, j * model.TileSize, model.TileSize, model.TileSize));
                        groupGound.Children.Add(box);
                    }
                }

                oldGround = new GeometryDrawing(GroundBrush, null, groupGound);
                oldGroundLevel = new GeometryDrawing(GroundLevelBrush, null, groupGoundLevel);
                groundAndDeleting.Children.Add(oldGround);
                groundAndDeleting.Children.Add(oldGroundLevel);
            }
           
            return groundAndDeleting;
        }

        private Drawing GetDrill()
        {
            // Pixel  coordinates!!!!
            Geometry g = new RectangleGeometry(new Rect(this.model.drill.Location[0], model.drill.Location[1], model.TileSize, model.TileSize));
            oldDrill = new GeometryDrawing(DrillBrush, null, g);

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

        private DrawingGroup TitleText(string text, double locationboxX, double locationboxY, double locationTextX, double locationTextY)
        {
            DrawingGroup g = new DrawingGroup();

            GeometryDrawing button = new GeometryDrawing(Brushes.AliceBlue, new Pen(Brushes.Blue, 1), new RectangleGeometry(new Rect(locationboxX, locationboxY, 400, 40)));
            FormattedText textMenu = new FormattedText(text, System.Globalization.CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface("Arial"), 30, Brushes.Black);
            GeometryDrawing menu = new GeometryDrawing(Brushes.Black, new Pen(Brushes.Black, 1), textMenu.BuildGeometry(new Point(locationTextX, locationTextY)));

            g.Children.Add(button);
            g.Children.Add(menu);

            return g;
        }
    }
}

