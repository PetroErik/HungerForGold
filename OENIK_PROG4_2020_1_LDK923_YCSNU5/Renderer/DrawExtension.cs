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
    public class DrawExtension
    {
        Dictionary<string, Brush> brushes = new Dictionary<string, Brush>();
        private double width;
        private double height;
        public DrawExtension(double width, double height)
        {
            this.width = width;
            this.height = height;
        }

        public Drawing DrawBoxObject(double x, double y, double width, double height, Brush brush)
        {
            Geometry box = new RectangleGeometry(new Rect(x, y, width, height));
            GeometryDrawing boxObject = new GeometryDrawing(brush, null, box);
            return boxObject;
        }

        public Drawing drawText(string text, int size, double x, double y)
        {
            FormattedText upgradeText = new FormattedText(text,
                  System.Globalization.CultureInfo.CurrentCulture, FlowDirection.LeftToRight,
                  new Typeface("Arial"), size, Brushes.Black, 1.25);
            GeometryDrawing upgrade = new GeometryDrawing(Brushes.Black, new Pen(Brushes.Black, 1),
             upgradeText.BuildGeometry(new Point(x, y)));
            return upgrade;
        }

        public DrawingGroup TitleText(string text, double locationboxX, double locationboxY, double locationTextX, double locationTextY)
        {
            DrawingGroup g = new DrawingGroup();

            GeometryDrawing button = new GeometryDrawing(Brushes.AliceBlue, new Pen(Brushes.Blue, 1), new RectangleGeometry(new Rect(locationboxX, locationboxY, 400, 40)));
            FormattedText textMenu = new FormattedText(text, System.Globalization.CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface("Arial"), 30, Brushes.Black, 1.25);
            GeometryDrawing menu = new GeometryDrawing(Brushes.Black, new Pen(Brushes.Black, 1), textMenu.BuildGeometry(new Point(locationTextX, locationTextY)));

            g.Children.Add(button);
            g.Children.Add(menu);

            return g;
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
                    ib.Viewport = new Rect(0, 0, this.width, this.height);
                    ib.ViewportUnits = BrushMappingMode.Absolute;
                }

                brushes.Add(fname, ib);
            }

            return brushes[fname];
        }

        public Brush BackgroundBrush { get { return GetBrush(CONFIG.BackgroundBrush, false); } }

        public Brush DrillBrush { get { return GetBrush(CONFIG.DrillBrush, false); } }

        public Brush GroundBrush { get { return GetBrush(CONFIG.GroundBrush, true); } }

        public Brush GroundLevelBrush { get { return GetBrush(CONFIG.GroundLevelBrush, true); } }

        public Brush GoldBrush { get { return GetBrush(CONFIG.GoldBrush, true); } }

        public Brush SilverBrush { get { return GetBrush(CONFIG.SilverBrush, true); } }

        public Brush BronzeBrush { get { return GetBrush(CONFIG.BronzeBrush, true); } }

        public Brush SiloBrush { get { return GetBrush(CONFIG.SiloBrush, false); } }

        public Brush MachinistBrush { get { return GetBrush(CONFIG.MachinistBrush, false); } }

        public Brush DeletingBrush { get { return new SolidColorBrush(Colors.Black); } }

        public Brush EnemyBrush { get { return GetBrush(CONFIG.EnemyBrush, true); } }

        public Brush BombBrush {  get { return GetBrush(CONFIG.BombBrush, true); } }
    }
}
