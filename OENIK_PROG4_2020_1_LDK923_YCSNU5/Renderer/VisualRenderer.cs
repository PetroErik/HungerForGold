using HFG.Display;
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
        HighscoreRender highscoreRender;

        GameModel model;

        DrawingGroup background;
        DrawingGroup menu;
        DrawingGroup highscore;

        DrawExtension drawExtension;


        double startingPointToDrill;

        public VisualRenderer(GameModel model)
        {
            this.model = model;

            this.backGroundAndHouseRenderer = new BackGroundAndHouseRenderer(model);
            this.menuRenderer = new MenuRenderer(model);
            this.highscoreRender = new HighscoreRender(model);

            background = this.backGroundAndHouseRenderer.groundAndHouseGroup;
            menu = this.menuRenderer.menuGroup;
            highscore = this.highscoreRender.HighscoreGroup;

            this.drawExtension = new DrawExtension(model.TileSize, model.TileSize);

            startingPointToDrill = model.GameHeight / 2 - model.TileSize * 4;

        }

        public Drawing MenuDrawing()
        {
            DrawingGroup dg = new DrawingGroup();
            dg.Children.Add(background);

            dg.Children.Add(menu);
            return dg;
        }

        public Drawing GameDrawing()
        {
            this.model.drill.FuelTankLvl = 100;
            this.model.drill.FuelTankFullness = 100;
            DrawingGroup dg = new DrawingGroup();
            dg.Children.Add(background);
            dg.Children.Add(GetDrill());
            dg.Children.Add(GetMinerals());
            dg.Children.Add(GetFuelTank());
            dg.Children.Add(GetStorage());
            dg.Children.Add(GetActualPoints());
            dg.Children.Add(GetTotalPoints());
            dg.Children.Add(Debug());
            return dg;
        }

        public Drawing HighscoreDrawing()
        {
            DrawingGroup dg = new DrawingGroup();
            dg.Children.Add(background);
            dg.Children.Add(highscore);
            return dg;
        }


        Point oldPlayerPosition;
        Point currentPos;


        private Drawing Debug()
        {
            return drawExtension.drawText($"DEBUG: {model.drill.Location[0]} {model.drill.Location[1]}", 30, 10, 10);
        }
        Drawing oldDrill;
        private Drawing GetDrill()
        {
            currentPos = new Point(model.drill.Location[0], model.drill.Location[1]);

            if (oldPlayerPosition != currentPos)
            {


                // Pixel  coordinates!!!!
                Geometry g = new RectangleGeometry(new Rect(this.model.drill.Location[0], model.drill.Location[1], model.TileSize, model.TileSize));
                oldDrill = new GeometryDrawing(drawExtension.DrillBrush, null, g);

                //Draw black box
                if (oldPlayerPosition.Y >= startingPointToDrill)
                {
                    //Geometry blackbox = new RectangleGeometry(new Rect(oldPlayerPosition.X, oldPlayerPosition.Y, model.TileSize, model.TileSize));
                    //GeometryDrawing drawingBlackBox = new GeometryDrawing(drawExtension.DeletingBrush, null, blackbox);
                    //background.Children.Add(drawingBlackBox);
                }

                oldPlayerPosition = currentPos;

            }
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


        private Drawing GetFuelTank()
        {
            DrawingGroup g = new DrawingGroup();
            GeometryDrawing background = new GeometryDrawing(Brushes.White, new Pen(Brushes.White, 1), new RectangleGeometry(new Rect(model.GameWidth - 100, model.GameHeight - 20, model.drill.FuelCapacity * 0.3, 10)));
            GeometryDrawing fuelfullnes = new GeometryDrawing(Brushes.Red, new Pen(Brushes.Red, 1), new RectangleGeometry(new Rect(model.GameWidth - 100, model.GameHeight - 20, model.drill.FuelTankFullness * 0.3, 10)));

            FormattedText textFuelTank = new FormattedText("TuelTank", System.Globalization.CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface("Arial"), 8, Brushes.Black, 1.25);
            GeometryDrawing fuel = new GeometryDrawing(Brushes.Black, new Pen(Brushes.Black, 1), textFuelTank.BuildGeometry(new Point(model.GameWidth - 70, model.GameHeight - 30)));

            FormattedText textFuelCapacity = new FormattedText($"{model.drill.FuelTankFullness}/{model.drill.FuelCapacity}", System.Globalization.CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface("Arial"), 8, Brushes.Black, 1.25);
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

            FormattedText textStorage = new FormattedText("Storage", System.Globalization.CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface("Arial"), 8, Brushes.Black, 1.25);
            GeometryDrawing storage = new GeometryDrawing(Brushes.Black, new Pen(Brushes.Black, 1), textStorage.BuildGeometry(new Point(40, model.GameHeight - 30)));

            FormattedText textStorageCapacity = new FormattedText($"{model.drill.StorageFullness}/{model.drill.StorageCapacity}", System.Globalization.CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface("Arial"), 8, Brushes.Black, 1.25);
            GeometryDrawing cap = new GeometryDrawing(Brushes.Black, new Pen(Brushes.Black, 1), textStorageCapacity.BuildGeometry(new Point(42, model.GameHeight - 20)));

            g.Children.Add(background);
            g.Children.Add(storagefullnes);
            g.Children.Add(storage);
            g.Children.Add(cap);
            return g;
        }

        private Drawing GetActualPoints()
        {
            FormattedText textActual = new FormattedText($"Actual Points: {model.ActualPoints}", System.Globalization.CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface("Arial"), 10, Brushes.Black, 1.25);
            GeometryDrawing actual = new GeometryDrawing(Brushes.Black, new Pen(Brushes.Black, 1), textActual.BuildGeometry(new Point(model.GameWidth / 3, 5)));

            return actual;
        }

        private Drawing GetTotalPoints()
        {
            FormattedText textTotal = new FormattedText($"Total Points: {model.TotalPoints}", System.Globalization.CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface("Arial"), 10, Brushes.Black, 1.25);
            GeometryDrawing total = new GeometryDrawing(Brushes.Black, new Pen(Brushes.Black, 1), textTotal.BuildGeometry(new Point(model.GameWidth * 2 / 3, 5)));

            return total;
        }
    }
}
