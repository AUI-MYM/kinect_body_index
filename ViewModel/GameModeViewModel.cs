using MYMGames.Hopscotch.Helpers;
using MYMGames.Hopscotch.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MYMGames.Hopscotch.ViewModel
{
    class GameModeViewModel : ViewModelBase
    {
        public string welcomeText { get; set; }
        public RelayCommand GoBackToMainMenu { get; set; }
        public GameModeViewModel()
        {
            welcomeText = "HELLO WORLD";
            GoBackToMainMenu = new RelayCommand(goToMainMenu);
        }

        private void goToMainMenu(object obj)
        {
            HomeWindow hw = new HomeWindow();
            hw.Show();
            Application.Current.MainWindow.Close();
            Application.Current.MainWindow = hw;
            
        }
    }
}
