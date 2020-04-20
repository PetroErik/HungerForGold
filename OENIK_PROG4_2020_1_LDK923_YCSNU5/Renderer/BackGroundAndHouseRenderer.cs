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
    public class BackGroundAndHouseRenderer
    {
        GameModel model;

        public double startingPointToDrill;

        public DrawExtension drawExntension;

        public DrawingGroup groundAndHouseGroup;
        public BackGroundAndHouseRenderer(GameModel model)
        {
            this.model = model;
            drawExntension = new DrawExtension(model.TileSize, model.TileSize);
            groundAndHouseGroup = new DrawingGroup();
            startingPointToDrill = model.GameHeight / 2 - model.TileSize * 4; //Starting point to drill - draw black box
            groundAndHouseGroup.Children.Add(GetBackground());
            groundAndHouseGroup.Children.Add(GetGround());
            groundAndHouseGroup.Children.Add(GetSilo());
            groundAndHouseGroup.Children.Add(GetMachinist());

        }

            private Drawing GetGround()
            {

                // Pixel  coordinates!!!!

                //REDUCE OVERUSE FOR LOOP
                DrawingGroup ground = new DrawingGroup();
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

                Drawing oldGround = new GeometryDrawing(drawExntension.GroundBrush, null, groupGound);
                Drawing oldGroundLevel = new GeometryDrawing(drawExntension.GroundLevelBrush, null, groupGoundLevel);

                ground.Children.Add(oldGround);

                ground.Children.Add(oldGroundLevel);
            

            return ground;
        }



        private Drawing GetMachinist()
        {
            return drawExntension.DrawBoxObject(model.MachinistHouse.Location[0],
                model.MachinistHouse.Location[1], model.TileSize * 3, model.TileSize * 5,
                drawExntension.MachinistBrush
                );
        }

        private Drawing GetSilo()
        {
            return drawExntension.DrawBoxObject(model.SiloHouse.Location[0],
                model.SiloHouse.Location[1], model.TileSize * 3, model.TileSize * 5,
                drawExntension.SiloBrush
                );
        }

        private Drawing GetBackground()
        {
            return drawExntension.DrawBoxObject(0,0,model.GameWidth, model.GameHeight,
               drawExntension.BackgroundBrush
               );
        }
    }
}
