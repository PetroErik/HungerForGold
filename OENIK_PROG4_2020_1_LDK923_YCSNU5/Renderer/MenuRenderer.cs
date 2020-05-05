// <copyright file="MenuRenderer.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace OENIK_PROG4_2020_1_LDK923_YCSNU5
{
    using System.Windows;
    using System.Windows.Media;
    using HFG.Display;

    /// <summary>
    /// Renderer for the Menu.
    /// </summary>
    public class MenuRenderer
    {
        /// <summary>
        /// Drawing group for the menu.
        /// </summary>
        public DrawingGroup MenuGroup;
        private GameModel model;

        /// <summary>
        /// Initializes a new instance of the <see cref="MenuRenderer"/> class.
        /// Renders the Menu.
        /// </summary>
        /// <param name="model">GameModel instance.</param>
        public MenuRenderer(GameModel model)
        {
            this.model = model;
            this.MenuGroup = new DrawingGroup();

            this.MenuGroup.Children.Add(this.TitleText("Hunger for Gold", (this.model.GameWidth / 2) - 180, (this.model.GameHeight / 2) - 60, (this.model.GameWidth / 2) - 90, (this.model.GameHeight / 2) - 60));
            this.MenuGroup.Children.Add(this.TitleText("1. Start Game", this.model.StartButton[0], this.model.StartButton[1], (this.model.GameWidth / 2) - 90, this.model.GameHeight / 2));
            this.MenuGroup.Children.Add(this.TitleText("2. Continues", this.model.ContinueButton[0], this.model.ContinueButton[1], (this.model.GameWidth / 2) - 90, (this.model.GameHeight / 2) + 60));
            this.MenuGroup.Children.Add(this.TitleText("3. Highscore", this.model.HighscoreButton[0], this.model.HighscoreButton[1], (this.model.GameWidth / 2) - 90, (this.model.GameHeight / 2) + 120));
        }

        private DrawingGroup TitleText(string text, double locationboxX, double locationboxY, double locationTextX, double locationTextY)
        {
            DrawingGroup g = new DrawingGroup();

            GeometryDrawing button = new GeometryDrawing(Brushes.AliceBlue, new Pen(Brushes.Blue, 1), new RectangleGeometry(new Rect(locationboxX, locationboxY, 400, 40)));
            FormattedText textMenu = new FormattedText(text, System.Globalization.CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface("Arial"), 30, Brushes.Black, 1.25);
            GeometryDrawing menu = new GeometryDrawing(Brushes.Black, new Pen(Brushes.Black, 1), textMenu.BuildGeometry(new Point(locationTextX, locationTextY)));

            g.Children.Add(button);
            g.Children.Add(menu);

            return g;
        }
    }
}