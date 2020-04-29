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
    class MenuRenderer
    {
        GameModel model;

        public DrawingGroup menuGroup;
        public MenuRenderer(GameModel model)
        {
            this.model = model;
            menuGroup = new DrawingGroup();

            menuGroup.Children.Add(TitleText("Hunger for Gold", this.model.GameWidth / 2 - 180, this.model.GameHeight / 2 - 60,
                this.model.GameWidth / 2 - 90, this.model.GameHeight / 2 - 60
                ));
            menuGroup.Children.Add(TitleText("1. Start Game", this.model.StartButton[0], this.model.StartButton[1],
                this.model.GameWidth / 2 - 90, this.model.GameHeight / 2
                ));
            menuGroup.Children.Add(TitleText("2. Continues", this.model.ContinueButton[0], this.model.ContinueButton[1],
                this.model.GameWidth / 2 - 90, this.model.GameHeight / 2 + 60
                ));
            menuGroup.Children.Add(TitleText("3. Highscore", this.model.HighscoreButton[0], this.model.HighscoreButton[1],
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

