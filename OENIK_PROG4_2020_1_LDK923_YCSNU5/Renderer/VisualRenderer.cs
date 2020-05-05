using HFG.Display;
using HFG.Display.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace OENIK_PROG4_2020_1_LDK923_YCSNU5
{
    class VisualRenderer
    {
        BackGroundAndHouseRenderer backGroundAndHouseRenderer;
        MenuRenderer menuRenderer;
        //HighscoreRender highscoreRender;

        GameModel model;

        DrawingGroup background;
        DrawingGroup backgroundClone;

        DrawingGroup menu;
        //DrawingGroup highscore;

        DrawExtension drawExtension;


        double startingPointToDrill;

        public VisualRenderer(GameModel model)
        {
            this.model = model;

            this.backGroundAndHouseRenderer = new BackGroundAndHouseRenderer(model);

            this.menuRenderer = new MenuRenderer(model);
            menu = this.menuRenderer.menuGroup;


            background = this.backGroundAndHouseRenderer.groundAndHouseGroup;
            backgroundClone = this.backGroundAndHouseRenderer.BackGroundClone();



            this.drawExtension = new DrawExtension(model.TileSize, model.TileSize);

            startingPointToDrill = model.GameHeight / 2 - model.TileSize * 4;

        }

        public Drawing MenuDrawing()
        {
            DrawingGroup dg = new DrawingGroup();
            dg.Children.Add(backgroundClone);

            dg.Children.Add(menu);
            return dg;
        }

        public Drawing GameDrawing(bool gameOver)
        {

            DrawingGroup dg = new DrawingGroup();
            dg.Children.Add(background);
            dg.Children.Add(GetMinerals());
            dg.Children.Add(GetEnemies());
            dg.Children.Add(GetBombs());
            dg.Children.Add(GetFuelTank());
            dg.Children.Add(GetStorage());
            dg.Children.Add(GetActualPoints());
            dg.Children.Add(GetTotalPoints());
            dg.Children.Add(GetLevelInformation());
            dg.Children.Add(GetMenuText());
            dg.Children.Add(GetDrill());

            if (gameOver)
            {
                dg.Children.Add(drawExtension.drawText("GAME OVER!", 40, model.GameWidth / 2 - 120, model.GameHeight / 2 - 160));

            }

            return dg;
        }

        public Drawing HighscoreDrawing(List<int?> scores, string message)
        {
            DrawingGroup dg = new DrawingGroup();

            dg.Children.Add(backgroundClone);
            dg.Children.Add(drawExtension.TitleText("HIGHSCORE", this.model.GameWidth / 2 - 180, this.model.GameHeight / 2 - 120,
                 this.model.GameWidth / 2 - 90, this.model.GameHeight / 2 - 120
                 ));

            //scores = new int?[5] { 1000, 2000, 3000, 4000, 5000};

            int distance = -60;
            if (scores.Any())
            {
                foreach (var score in scores)
                {
                    dg.Children.Add(drawExtension.TitleText($"{score}", this.model.GameWidth / 2 - 180, this.model.GameHeight / 2 + distance,
                      this.model.GameWidth / 2 - 90, this.model.GameHeight / 2 + distance
                      ));
                    distance += 60;
                }
            }
            else
            {
                dg.Children.Add(drawExtension.TitleText($"{message}", this.model.GameWidth / 2 - 180, this.model.GameHeight / 2 - 60,
               this.model.GameWidth / 2 - 90, this.model.GameHeight / 2 - 60
               ));
            }
            return dg;
        }

        private Drawing Debug()
        {
            return drawExtension.drawText($"DEBUG: {model.drill.Location[0]} {model.drill.Location[1]}", 30, 10, 10);
        }

        private Drawing GetDrill()
        {
            Geometry g = new RectangleGeometry(new Rect(this.model.drill.Location[0], model.drill.Location[1], model.TileSize, model.TileSize));
            Drawing oldDrill = new GeometryDrawing(drawExtension.DrillBrush, null, g);

            return oldDrill;
        }

        private Drawing GetMinerals()
        {
            DrawingGroup minerals = new DrawingGroup();

            // Pixel  coordinates!!!!
            GeometryGroup gBronze = new GeometryGroup();
            GeometryGroup gSliver = new GeometryGroup();
            GeometryGroup gGold = new GeometryGroup();

            for (int i = 0; i < model.Minerals.Count(); i++)
            {
                Geometry box = new RectangleGeometry(new Rect(model.Minerals[i].Location[0], model.Minerals[i].Location[1], model.TileSize, model.TileSize));

                if (model.Minerals[i].Type == MineralsType.Bronze)
                {
                    gBronze.Children.Add(box);
                }

                if (model.Minerals[i].Type == MineralsType.Silver)
                {
                    gSliver.Children.Add(box);
                }
                if (model.Minerals[i].Type == MineralsType.Gold)
                {
                    gGold.Children.Add(box);
                }
            }

            Drawing oldBronzes = new GeometryDrawing(drawExtension.BronzeBrush, null, gBronze);
            Drawing oldSilvers = new GeometryDrawing(drawExtension.SilverBrush, null, gSliver);
            Drawing oldGolds = new GeometryDrawing(drawExtension.GoldBrush, null, gGold);

            minerals.Children.Add(oldBronzes);
            minerals.Children.Add(oldSilvers);
            minerals.Children.Add(oldGolds);

            return minerals;
        }

        private Drawing GetEnemies()
        {
            GeometryGroup enemies = new GeometryGroup();
            for (int i = 0; i < this.model.Enemies.Count(); i++)
            {
                Geometry box = new RectangleGeometry(new Rect(this.model.Enemies[i].Location[0], this.model.Enemies[i].Location[1], this.model.TileSize, this.model.TileSize));
                enemies.Children.Add(box);
            }

            Drawing enems = new GeometryDrawing(this.drawExtension.EnemyBrush, null, enemies);

            return enems;
        }

        private Drawing GetBombs()
        {
            GeometryGroup bombs = new GeometryGroup();
            for (int i = 0; i < this.model.Bombs.Count(); i++)
            {
                Geometry box = new RectangleGeometry(new Rect(this.model.Bombs[i].Location[0], this.model.Bombs[i].Location[1], this.model.TileSize, this.model.TileSize));
                bombs.Children.Add(box);
            }

            Drawing bmbs = new GeometryDrawing(this.drawExtension.BombBrush, null, bombs);

            return bmbs;
        }

        private Drawing GetFuelTank()
        {
            DrawingGroup g = new DrawingGroup();
            GeometryDrawing background = new GeometryDrawing(Brushes.White, new Pen(Brushes.White, 1), new RectangleGeometry(new Rect(model.GameWidth - 100, model.GameHeight - 30, model.drill.FuelCapacity * 0.3, 20)));
            GeometryDrawing fuelfullnes = new GeometryDrawing(Brushes.Red, new Pen(Brushes.Red, 1), new RectangleGeometry(new Rect(model.GameWidth - 100, model.GameHeight - 30, model.drill.FuelTankFullness * 0.3, 20)));

            FormattedText textFuelTank = new FormattedText("TuelTank", System.Globalization.CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface("Arial"), 12, Brushes.Black, 1.25);
            GeometryDrawing fuel = new GeometryDrawing(Brushes.Black, new Pen(Brushes.Black, 1), textFuelTank.BuildGeometry(new Point(model.GameWidth - 70, model.GameHeight - 33)));

            FormattedText textFuelCapacity = new FormattedText($"{model.drill.FuelTankFullness}/{model.drill.FuelCapacity}", System.Globalization.CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface("Arial"), 12, Brushes.Black, 1.25);
            GeometryDrawing cap = new GeometryDrawing(Brushes.Black, new Pen(Brushes.Black, 1), textFuelCapacity.BuildGeometry(new Point(model.GameWidth - 66, model.GameHeight - 23)));

            g.Children.Add(background);
            g.Children.Add(fuelfullnes);
            g.Children.Add(fuel);
            g.Children.Add(cap);
            return g;
        }

        private Drawing GetStorage()
        {
            DrawingGroup g = new DrawingGroup();
            GeometryDrawing background = new GeometryDrawing(Brushes.White, new Pen(Brushes.White, 1), new RectangleGeometry(new Rect(10, model.GameHeight - 30, model.drill.StorageCapacity * 5, 20)));
            GeometryDrawing storagefullnes = new GeometryDrawing(Brushes.Green, new Pen(Brushes.Green, 1), new RectangleGeometry(new Rect(10, model.GameHeight - 30, model.drill.StorageFullness * 5, 20)));

            FormattedText textStorage = new FormattedText("Storage", System.Globalization.CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface("Arial"), 12, Brushes.Black, 1.25);
            GeometryDrawing storage = new GeometryDrawing(Brushes.Black, new Pen(Brushes.Black, 1), textStorage.BuildGeometry(new Point(40, model.GameHeight - 33)));

            FormattedText textStorageCapacity = new FormattedText($"{model.drill.StorageFullness}/{model.drill.StorageCapacity}", System.Globalization.CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface("Arial"), 12, Brushes.Black, 1.25);
            GeometryDrawing cap = new GeometryDrawing(Brushes.Black, new Pen(Brushes.Black, 1), textStorageCapacity.BuildGeometry(new Point(46, model.GameHeight - 23)));

            g.Children.Add(background);
            g.Children.Add(storagefullnes);
            g.Children.Add(storage);
            g.Children.Add(cap);
            return g;
        }

        private Drawing GetLevelInformation()
        {
            DrawingGroup g = new DrawingGroup();
            GeometryDrawing background = new GeometryDrawing(Brushes.AliceBlue, new Pen(Brushes.Blue, 1), new RectangleGeometry(new Rect(30, 0, 300, 20)));
            FormattedText text = new FormattedText($"Drill Level: {model.drill.DrillLvl}/3\tStorage Level: {model.drill.StorageLvl}/3\tFuelTank Level: {model.drill.FuelTankLvl}/3", System.Globalization.CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface("Arial"), 10, Brushes.Black, 1.25);
            GeometryDrawing levelText = new GeometryDrawing(Brushes.Black, new Pen(Brushes.Black, 1), text.BuildGeometry(new Point(35, 5)));

            g.Children.Add(background);
            g.Children.Add(levelText);

            return g;
        }

        private Drawing GetMenuText()
        {
            DrawingGroup g = new DrawingGroup();
            GeometryDrawing background = new GeometryDrawing(Brushes.AliceBlue, new Pen(Brushes.Blue, 1), new RectangleGeometry(new Rect(model.MenuButton[0], model.MenuButton[1], model.MenuButton[2], model.MenuButton[3])));
            FormattedText text = new FormattedText("Menu", System.Globalization.CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface("Arial"), 10, Brushes.Black, 1.25);
            GeometryDrawing menuText = new GeometryDrawing(Brushes.Black, new Pen(Brushes.Black, 1), text.BuildGeometry(new Point(3, 5)));

            g.Children.Add(background);
            g.Children.Add(menuText);

            return g;
        }

        private Drawing GetActualPoints()
        {
            return drawExtension.drawText($"Actual Points: {model.ActualPoints}", 20, model.GameWidth / 3, 5);
        }

        private Drawing GetTotalPoints()
        {
            return drawExtension.drawText($"Total Points: {model.TotalPoints}", 20, model.GameWidth * 2 / 3, 5);
        }
    }
}
