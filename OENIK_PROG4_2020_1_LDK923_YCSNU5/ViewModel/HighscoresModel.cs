using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using HFG.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OENIK_PROG4_2020_1_LDK923_YCSNU5.ViewModel
{
    public class HighscoresModel : ViewModelBase
    {
        public BindingList<int?> scoresList;
        public ICommand backCommand;
        public HighscoreLogic highScoreLogic;

        public void Test()
        {
            Console.WriteLine("OK");
        }

        public HighscoresModel()
        {
            highScoreLogic = new HighscoreLogic();
            scoresList = new BindingList<int?>();
            //foreach (var score in highScoreLogic.Top5HighScore())
            //{
            //    scoresList.Add(score);
            //}
            backCommand = new RelayCommand(() => Test());

        }
    }
}
