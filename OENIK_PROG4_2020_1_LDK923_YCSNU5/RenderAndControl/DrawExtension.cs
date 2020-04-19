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

namespace OENIK_PROG4_2020_1_LDK923_YCSNU5.RenderAndControl
{
    public class DrawExtension
    {
        Dictionary<string, Brush> brushes = new Dictionary<string, Brush>();
        private GameModel model;
        public DrawExtension(GameModel model)
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

    }
}
