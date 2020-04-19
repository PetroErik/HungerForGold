using HFG.Display;
using OENIK_PROG4_2020_1_LDK923_YCSNU5.RenderAndControl;
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
    public class BackGroundAndHouseRenderer
    {
        GameModel model;

        Drawing oldBackground;
        Drawing oldGround;
        Drawing oldGroundLevel;

        Drawing oldSilo;
        Drawing oldMachinist;

        public double startingPointToDrill;


        DrawExtension drawExntension;
        public DrawingGroup groundAndDeleting = new DrawingGroup();

        public BackGroundAndHouseRenderer(GameModel model)
        {
            this.model = model;
            drawExntension = new DrawExtension(model);

            startingPointToDrill = model.GameHeight / 2 - model.TileSize * 4; //Starting point to drill - draw black box

            groundAndDeleting.Children.Add(GetGround());
            groundAndDeleting.Children.Add(GetSilo());
            groundAndDeleting.Children.Add(GetMachinist());
            groundAndDeleting.Children.Add(GetBackground());

        }

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

                oldGround = new GeometryDrawing(drawExntension.GroundBrush, null, groupGound);
                oldGroundLevel = new GeometryDrawing(drawExntension.GroundLevelBrush, null, groupGoundLevel);
                groundAndDeleting.Children.Add(oldGround);
                groundAndDeleting.Children.Add(oldGroundLevel);
            }

            return groundAndDeleting;
        }

        private Drawing drawText(string text, int size, double x, double y )
        {
            FormattedText upgradeText = new FormattedText(text,
                  System.Globalization.CultureInfo.CurrentCulture, FlowDirection.LeftToRight,
                  new Typeface("Arial"), size, Brushes.Black);
            GeometryDrawing upgrade = new GeometryDrawing(Brushes.Black, new Pen(Brushes.Black, 1),
             upgradeText.BuildGeometry(new Point(x, y)));
            return upgrade;
        }
        
        private Drawing DrawBoxObject(double x, double y, double width, double height, Brush brush)
        {
            GeometryGroup g = new GeometryGroup();
            Geometry box = new RectangleGeometry(new Rect(x, y, width, height));
            g.Children.Add(box);
            GeometryDrawing boxObject = new GeometryDrawing(brush, null, g);
            return boxObject;
        }

        private Drawing GetMachinist()
        {
            return DrawBoxObject(model.MachinistHouse.Location[0],
                model.MachinistHouse.Location[1], model.TileSize * 3, model.TileSize * 5,
                drawExntension.MachinistBrush
                );
        }

        private Drawing GetSilo()
        {
            return DrawBoxObject(model.SiloHouse.Location[0],
                model.SiloHouse.Location[1], model.TileSize * 3, model.TileSize * 5,
                drawExntension.SiloBrush
                );
        }

        private Drawing GetBackground()
        {
            return DrawBoxObject(0,0,model.GameWidth, model.GameHeight,
               drawExntension.BackgroundBrush
               );
        }
    }
}
