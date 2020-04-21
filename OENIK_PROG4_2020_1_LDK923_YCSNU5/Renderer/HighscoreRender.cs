//using HFG.Display;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows;
//using System.Windows.Media;

//namespace OENIK_PROG4_2020_1_LDK923_YCSNU5
//{
//    /// <summary>
//    /// NOT YET IMPLEMENTS
//    /// </summary>
//    class HighscoreRender
//    {
//        GameModel model;

//        public DrawingGroup HighscoreGroup;

//        //int?[] scores;
//        public HighscoreRender(GameModel model, List<int?> scores)
//        {
//            this.model = model;
//            HighscoreGroup = new DrawingGroup();
//            HighscoreGroup.Children.Add(TitleText("HIGHSCORE", this.model.GameWidth / 2 - 180, this.model.GameHeight / 2 - 120,
//                this.model.GameWidth / 2 - 90, this.model.GameHeight / 2 - 120
//                ));

//            //scores = new int?[5] { 1000, 2000, 3000, 4000, 5000};

//            int distance = -60;
//            if (scores.Any())
//            {
//                foreach(var score in scores)
//                { 
//                    HighscoreGroup.Children.Add(TitleText($"{score}", this.model.GameWidth / 2 - 180, this.model.GameHeight / 2 + distance,
//                      this.model.GameWidth / 2 - 90, this.model.GameHeight / 2 + distance
//                      ));
//                    distance += 60;
//                }
//               // HighscoreGroup.Children.Add(TitleText("NO HIGHSCORE", this.model.GameWidth / 2 - 180, this.model.GameHeight / 2 - 60,
//               //this.model.GameWidth / 2 - 90, this.model.GameHeight / 2 - 60
//               //));

//               // HighscoreGroup.Children.Add(TitleText("Duong Do 2", this.model.GameWidth / 2 - 180, this.model.GameHeight / 2,
//               //     this.model.GameWidth / 2 - 90, this.model.GameHeight / 2
//               //     ));
//               // HighscoreGroup.Children.Add(TitleText("Duong Do 3", this.model.GameWidth / 2 - 180, this.model.GameHeight / 2 + 60,
//               //     this.model.GameWidth / 2 - 90, this.model.GameHeight / 2 + 60
//               //     ));
//               // HighscoreGroup.Children.Add(TitleText("Duong Do 4", this.model.GameWidth / 2 - 180, this.model.GameHeight / 2 + 120,
//               //     this.model.GameWidth / 2 - 90, this.model.GameHeight / 2 + 120
//               //     ));
//               // HighscoreGroup.Children.Add(TitleText("Duong Do 5", this.model.GameWidth / 2 - 180, this.model.GameHeight / 2 + 120,
//               //     this.model.GameWidth / 2 - 90, this.model.GameHeight / 2 + 120
//               //     ));
//            }
//            else
//            {
//                HighscoreGroup.Children.Add(TitleText("NO HIGHSCORE", this.model.GameWidth / 2 - 180, this.model.GameHeight / 2 - 60,
//               this.model.GameWidth / 2 - 90, this.model.GameHeight / 2 - 60
//               ));
//            }
           
//        }


       
//    }
//}
