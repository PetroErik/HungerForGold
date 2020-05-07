// <copyright file="DrawExtension.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace OENIK_PROG4_2020_1_LDK923_YCSNU5
{
    using System.Collections.Generic;
    using System.Reflection;
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using HFG.Display;

    /// <summary>
    /// Extension class for rendering.
    /// </summary>
    public class DrawExtension
    {
        private Dictionary<string, Brush> brushes = new Dictionary<string, Brush>();
        private double width;
        private double height;

        /// <summary>
        /// Gets the brush for the background of the game.
        /// </summary>
        public Brush BackgroundBrush
        {
            get { return this.GetBrush(CONFIG.BackgroundBrush, false); }
        }

        /// <summary>
        /// Gets the brsuh for the drill element.
        /// </summary>
        public Brush DrillBrush
        {
            get { return this.GetBrush(CONFIG.DrillBrush, false); }
        }

        /// <summary>
        /// Gets the brush for the ground.
        /// </summary>
        public Brush GroundBrush
        {
            get { return this.GetBrush(CONFIG.GroundBrush, true); }
        }

        /// <summary>
        /// Gets the brush for the grass.
        /// </summary>
        public Brush GroundLevelBrush
        {
            get { return this.GetBrush(CONFIG.GroundLevelBrush, true); }
        }

        /// <summary>
        /// Gets the brush for the gold mineral.
        /// </summary>
        public Brush GoldBrush
        {
            get { return this.GetBrush(CONFIG.GoldBrush, true); }
        }

        /// <summary>
        /// Gets the brush for the silver mineral.
        /// </summary>
        public Brush SilverBrush
        {
            get { return this.GetBrush(CONFIG.SilverBrush, true); }
        }

        /// <summary>
        /// Gets the brush for the bronze mineral.
        /// </summary>
        public Brush BronzeBrush
        {
            get { return this.GetBrush(CONFIG.BronzeBrush, true); }
        }

        /// <summary>
        /// Gets the brush for the Silo.
        /// </summary>
        public Brush SiloBrush
        {
            get { return this.GetBrush(CONFIG.SiloBrush, false); }
        }

        /// <summary>
        /// Gets the brush for the Machinist.
        /// </summary>
        public Brush MachinistBrush
        {
            get { return this.GetBrush(CONFIG.MachinistBrush, false); }
        }

        /// <summary>
        /// Gets the brush for the enemy.
        /// </summary>
        public Brush EnemyBrush
        {
            get { return this.GetBrush(CONFIG.EnemyBrush, true); }
        }

        /// <summary>
        /// Gets the brush for the bomb.
        /// </summary>
        public Brush BombBrush
        {
            get { return this.GetBrush(CONFIG.BombBrush, true); }
        }

        public Brush FireBrush
        {
            get { return this.GetBrush(CONFIG.EnemyBrush, false); }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DrawExtension"/> class.
        /// </summary>
        /// <param name="width">Width of the game.</param>
        /// <param name="height">Height of the game.</param>
        public DrawExtension(double width, double height)
        {
            this.width = width;
            this.height = height;
        }

        /// <summary>
        /// Drawing a box.
        /// </summary>
        /// <param name="x">Top left X coordinate.</param>
        /// <param name="y">Top left Y coordinate.</param>
        /// <param name="width">Width of the box.</param>
        /// <param name="height">Height of the box.</param>
        /// <param name="brush">Brush of the box.</param>
        /// <returns>Return the drawing of a box.</returns>
        public Drawing DrawBoxObject(double x, double y, double width, double height, Brush brush)
        {
            Geometry box = new RectangleGeometry(new Rect(x, y, width, height));
            GeometryDrawing boxObject = new GeometryDrawing(brush, null, box);
            return boxObject;
        }

        /// <summary>
        /// Drawing a text.
        /// </summary>
        /// <param name="text">Text to be written.</param>
        /// <param name="size">Size of the letter.</param>
        /// <param name="x">Top left X coordinate.</param>
        /// <param name="y">Top left Y coordinate.</param>
        /// <returns>Returns the drawing of the text.</returns>
        public Drawing DrawText(string text, int size, double x, double y)
        {
            FormattedText upgradeText = new FormattedText(text, System.Globalization.CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface("Arial"), size, Brushes.Black, 1.25);
            GeometryDrawing upgrade = new GeometryDrawing(Brushes.Black, new Pen(Brushes.Black, 1), upgradeText.BuildGeometry(new Point(x, y)));
            return upgrade;
        }

        /// <summary>
        /// Drawing of a title text.
        /// </summary>
        /// <param name="text">Text to be written.</param>
        /// <param name="locationboxX">X coordinate of the box.</param>
        /// <param name="locationboxY">Y coordinate of the box.</param>
        /// <param name="locationTextX">X coordinate of the text.</param>
        /// <param name="locationTextY">Y coordinate of the text.</param>
        /// <returns>Returns the drawing of a title text.</returns>
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

        /// <summary>
        /// Sets the brush for a game element.
        /// </summary>
        /// <param name="fname">Name of the image to set as the brush.</param>
        /// <param name="isTiled">Bool variable if the element should be tiled.</param>
        /// <returns>Returns the brush for an element.</returns>
        private Brush GetBrush(string fname, bool isTiled)
        {
            if (!this.brushes.ContainsKey(fname))
            {
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

                this.brushes.Add(fname, ib);
            }

            return this.brushes[fname];
        }
    }
}
