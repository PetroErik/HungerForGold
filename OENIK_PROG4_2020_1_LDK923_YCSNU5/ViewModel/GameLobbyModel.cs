using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace OENIK_PROG4_2020_1_LDK923_YCSNU5.ViewModel
{
    public class GameLobbyModel: ViewModelBase
    {
        public ICommand startCommand { get; private set; }
        public ICommand continueCommand { get; private set; }
        public ICommand highScoreCommand { get; private set; }

        public void Test()
        {
            MessageBox.Show("click button");
        }

        // https://stackoverflow.com/questions/42229838/switching-views-in-mvvm-wpf
        // navigation view between window
        // everytime something happens, add new data to conn table
        // if we got gold, auto change location of goal base on repository
        //

        public void OpenHighScoreWindow()
        {
            Highscores win = new Highscores();
            win.ShowDialog();
        }

        public GameLobbyModel()
        {
            startCommand = new RelayCommand(() => Test());
            continueCommand = new RelayCommand(() => Test());
            highScoreCommand = new RelayCommand(() => OpenHighScoreWindow());

        }

    }
}
