using HFG.Display;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace OENIK_PROG4_2020_1_LDK923_YCSNU5
{
    /// <summary>
    /// NOT YET IMPLEMENTS
    /// </summary>
    class HighscoreRender
    {
        GameModel model;

        public DrawingGroup HighscoreGroup;
        public HighscoreRender(GameModel model)
        {
            this.model = model;
            HighscoreGroup = new DrawingGroup();

            HighscoreGroup.Children.Add(TitleText("HIGHSCORE", this.model.GameWidth / 2 - 180, this.model.GameHeight / 2 - 120,
                this.model.GameWidth / 2 - 90, this.model.GameHeight / 2 - 120
                ));

            HighscoreGroup.Children.Add(TitleText("Duong Do 1", this.model.GameWidth / 2 - 180, this.model.GameHeight / 2 - 60,
                this.model.GameWidth / 2 - 90, this.model.GameHeight / 2 - 60
                ));
            HighscoreGroup.Children.Add(TitleText("Duong Do 2", this.model.GameWidth / 2 - 180, this.model.GameHeight / 2,
                this.model.GameWidth / 2 - 90, this.model.GameHeight / 2
                ));
            HighscoreGroup.Children.Add(TitleText("Duong Do 3", this.model.GameWidth / 2 - 180, this.model.GameHeight / 2 + 60,
                this.model.GameWidth / 2 - 90, this.model.GameHeight / 2 + 60
                ));
            HighscoreGroup.Children.Add(TitleText("Duong Do 4", this.model.GameWidth / 2 - 180, this.model.GameHeight / 2 + 120,
                this.model.GameWidth / 2 - 90, this.model.GameHeight / 2 + 120
                ));
            HighscoreGroup.Children.Add(TitleText("Duong Do 5", this.model.GameWidth / 2 - 180, this.model.GameHeight / 2 + 120,
                this.model.GameWidth / 2 - 90, this.model.GameHeight / 2 + 120
                ));
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
