// <copyright file="VisualRenderer.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace OENIK_PROG4_2020_1_LDK923_YCSNU5
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows;
    using System.Windows.Media;
    using HFG.Display;

    /// <summary>
    /// Main renderer class.
    /// </summary>
    public class VisualRenderer
    {
        private BackGroundAndHouseRenderer backGroundAndHouseRenderer;
        private MenuRenderer menuRenderer;
        private GameModel model;
        private DrawingGroup background;
        private DrawingGroup backgroundClone;
        private DrawingGroup menu;
        private DrawExtension drawExtension;
        private double startingPointToDrill;

        /// <summary>
        /// Initializes a new instance of the <see cref="VisualRenderer"/> class.
        /// </summary>
        /// <param name="model">GameModel instance.</param>
        public VisualRenderer(GameModel model)
        {
            this.model = model;
            this.backGroundAndHouseRenderer = new BackGroundAndHouseRenderer(model);
            this.menuRenderer = new MenuRenderer(model);
            this.menu = this.menuRenderer.MenuGroup;
            this.background = this.backGroundAndHouseRenderer.GroundAndHouseGroup;
            this.backgroundClone = this.backGroundAndHouseRenderer.BackGroundClone();
            this.drawExtension = new DrawExtension(model.TileSize, model.TileSize);
            this.startingPointToDrill = (this.model.GameHeight / 2) - (this.model.TileSize * 4);
        }

        /// <summary>
        /// Drawing for the menu.
        /// </summary>
        /// <returns>Drawing group for the menu.</returns>
        public Drawing MenuDrawing()
        {
            DrawingGroup dg = new DrawingGroup();
            dg.Children.Add(this.backgroundClone);
            dg.Children.Add(this.menu);

            return dg;
        }

        /// <summary>
        /// Drawing for the game elements.
        /// </summary>
        /// <param name="gameOver">Bool if the game is over.</param>
        /// <returns>Returns the drawing of the game.</returns>
        public Drawing GameDrawing(bool gameOver)
        {
            DrawingGroup dg = new DrawingGroup();
            dg.Children.Add(this.background);
            dg.Children.Add(this.GetMinerals());
            dg.Children.Add(this.GetEnemies());
            dg.Children.Add(this.GetBombs());
            dg.Children.Add(this.GetFuelTank());
            dg.Children.Add(this.GetStorage());
            dg.Children.Add(this.GetActualPoints());
            dg.Children.Add(this.GetTotalPoints());
            dg.Children.Add(this.GetLevelInformation());
            dg.Children.Add(this.GetMenuText());
            dg.Children.Add(this.GetDrill());

            if (gameOver)
            {
                dg.Children.Add(this.drawExtension.DrawText("GAME OVER!", 40, (this.model.GameWidth / 2) - 120, (this.model.GameHeight / 2) - 160));
            }

            return dg;
        }

        /// <summary>
        /// Drawing for the top 5 high score.
        /// </summary>
        /// <param name="scores">List of scores.</param>
        /// <param name="message">String of a message.</param>
        /// <returns>Returns the drawing for the 5 high score.</returns>
        public Drawing HighscoreDrawing(List<int?> scores, string message)
        {
            DrawingGroup dg = new DrawingGroup();

            dg.Children.Add(this.backgroundClone);
            dg.Children.Add(this.drawExtension.TitleText("HIGHSCORE", (this.model.GameWidth / 2) - 180, (this.model.GameHeight / 2) - 120, (this.model.GameWidth / 2) - 90, (this.model.GameHeight / 2) - 120));
            int distance = -60;
            if (scores.Any())
            {
                foreach (var score in scores)
                {
                    dg.Children.Add(this.drawExtension.TitleText($"{score}", (this.model.GameWidth / 2) - 180, (this.model.GameHeight / 2) + distance, (this.model.GameWidth / 2) - 90, (this.model.GameHeight / 2) + distance));
                    distance += 60;
                }
            }
            else
            {
                dg.Children.Add(this.drawExtension.TitleText($"{message}", (this.model.GameWidth / 2) - 180, (this.model.GameHeight / 2) - 60, (this.model.GameWidth / 2) - 90, (this.model.GameHeight / 2) - 60));
            }

            return dg;
        }

        private Drawing Debug()
        {
            return this.drawExtension.DrawText($"DEBUG: {this.model.Drill.Location[0]} {this.model.Drill.Location[1]}", 30, 10, 10);
        }

        private Drawing GetDrill()
        {
            Geometry g = new RectangleGeometry(new Rect(this.model.Drill.Location[0], this.model.Drill.Location[1], this.model.TileSize, this.model.TileSize));
            Drawing oldDrill = new GeometryDrawing(this.drawExtension.DrillBrush, null, g);

            return oldDrill;
        }

        private Drawing GetMinerals()
        {
            DrawingGroup minerals = new DrawingGroup();
            GeometryGroup gBronze = new GeometryGroup();
            GeometryGroup gSliver = new GeometryGroup();
            GeometryGroup gGold = new GeometryGroup();

            for (int i = 0; i < this.model.Minerals.Count(); i++)
            {
                Geometry box = new RectangleGeometry(new Rect(this.model.Minerals[i].Location[0], this.model.Minerals[i].Location[1], this.model.TileSize, this.model.TileSize));

                if (this.model.Minerals[i].Type == MineralsType.Bronze)
                {
                    gBronze.Children.Add(box);
                }

                if (this.model.Minerals[i].Type == MineralsType.Silver)
                {
                    gSliver.Children.Add(box);
                }

                if (this.model.Minerals[i].Type == MineralsType.Gold)
                {
                    gGold.Children.Add(box);
                }
            }

            Drawing oldBronzes = new GeometryDrawing(this.drawExtension.BronzeBrush, null, gBronze);
            Drawing oldSilvers = new GeometryDrawing(this.drawExtension.SilverBrush, null, gSliver);
            Drawing oldGolds = new GeometryDrawing(this.drawExtension.GoldBrush, null, gGold);

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
            GeometryDrawing background = new GeometryDrawing(Brushes.White, new Pen(Brushes.White, 1), new RectangleGeometry(new Rect(this.model.GameWidth - 100, this.model.GameHeight - 30, this.model.Drill.FuelCapacity * 0.3, 20)));
            GeometryDrawing fuelfullnes = new GeometryDrawing(Brushes.Red, new Pen(Brushes.Red, 1), new RectangleGeometry(new Rect(this.model.GameWidth - 100, this.model.GameHeight - 30, this.model.Drill.FuelTankFullness * 0.3, 20)));

            FormattedText textFuelTank = new FormattedText("TuelTank", System.Globalization.CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface("Arial"), 12, Brushes.Black, 1.25);
            GeometryDrawing fuel = new GeometryDrawing(Brushes.Black, new Pen(Brushes.Black, 1), textFuelTank.BuildGeometry(new Point(this.model.GameWidth - 70, this.model.GameHeight - 33)));

            FormattedText textFuelCapacity = new FormattedText($"{this.model.Drill.FuelTankFullness}/{this.model.Drill.FuelCapacity}", System.Globalization.CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface("Arial"), 12, Brushes.Black, 1.25);
            GeometryDrawing cap = new GeometryDrawing(Brushes.Black, new Pen(Brushes.Black, 1), textFuelCapacity.BuildGeometry(new Point(this.model.GameWidth - 66, this.model.GameHeight - 23)));

            g.Children.Add(background);
            g.Children.Add(fuelfullnes);
            g.Children.Add(fuel);
            g.Children.Add(cap);
            return g;
        }

        private Drawing GetStorage()
        {
            DrawingGroup g = new DrawingGroup();
            GeometryDrawing background = new GeometryDrawing(Brushes.White, new Pen(Brushes.White, 1), new RectangleGeometry(new Rect(10, this.model.GameHeight - 30, this.model.Drill.StorageCapacity * 5, 20)));
            GeometryDrawing storagefullnes = new GeometryDrawing(Brushes.Green, new Pen(Brushes.Green, 1), new RectangleGeometry(new Rect(10, this.model.GameHeight - 30, this.model.Drill.StorageFullness * 5, 20)));

            FormattedText textStorage = new FormattedText("Storage", System.Globalization.CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface("Arial"), 12, Brushes.Black, 1.25);
            GeometryDrawing storage = new GeometryDrawing(Brushes.Black, new Pen(Brushes.Black, 1), textStorage.BuildGeometry(new Point(40, this.model.GameHeight - 33)));

            FormattedText textStorageCapacity = new FormattedText($"{this.model.Drill.StorageFullness}/{this.model.Drill.StorageCapacity}", System.Globalization.CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface("Arial"), 12, Brushes.Black, 1.25);
            GeometryDrawing cap = new GeometryDrawing(Brushes.Black, new Pen(Brushes.Black, 1), textStorageCapacity.BuildGeometry(new Point(46, this.model.GameHeight - 23)));

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
            FormattedText text = new FormattedText($"Drill Level: {this.model.Drill.DrillLvl}/3\tStorage Level: {this.model.Drill.StorageLvl}/3\tFuelTank Level: {this.model.Drill.FuelTankLvl}/3", System.Globalization.CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface("Arial"), 10, Brushes.Black, 1.25);
            GeometryDrawing levelText = new GeometryDrawing(Brushes.Black, new Pen(Brushes.Black, 1), text.BuildGeometry(new Point(35, 5)));

            g.Children.Add(background);
            g.Children.Add(levelText);

            return g;
        }

        private Drawing GetMenuText()
        {
            DrawingGroup g = new DrawingGroup();
            GeometryDrawing background = new GeometryDrawing(Brushes.AliceBlue, new Pen(Brushes.Blue, 1), new RectangleGeometry(new Rect(this.model.MenuButton[0], this.model.MenuButton[1], this.model.MenuButton[2], this.model.MenuButton[3])));
            FormattedText text = new FormattedText("Menu", System.Globalization.CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface("Arial"), 10, Brushes.Black, 1.25);
            GeometryDrawing menuText = new GeometryDrawing(Brushes.Black, new Pen(Brushes.Black, 1), text.BuildGeometry(new Point(3, 5)));

            g.Children.Add(background);
            g.Children.Add(menuText);

            return g;
        }

        private Drawing GetActualPoints()
        {
            return this.drawExtension.DrawText($"Actual Points: {this.model.ActualPoints}", 20, this.model.GameWidth / 3, 5);
        }

        private Drawing GetTotalPoints()
        {
            return this.drawExtension.DrawText($"Total Points: {this.model.TotalPoints}", 20, this.model.GameWidth * 2 / 3, 5);
        }
    }
}
