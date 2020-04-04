using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
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
        public BindingList<int> scoresList;
        public ICommand backCommand;

        public void Test()
        {
            Console.WriteLine("OK");
        }

        public HighscoresModel()
        {
            scoresList = new BindingList<int>();
            scoresList.Add(100);
            scoresList.Add(200);
            scoresList.Add(300);
            backCommand = new RelayCommand(() => Test());

        }
        
    }
}
