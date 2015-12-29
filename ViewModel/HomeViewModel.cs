using Microsoft.Kinect.Wpf.Controls;
using MYMGames.Hopscotch.Helpers;
using MYMGames.Hopscotch.Model;
using MYMGames.Hopscotch.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MYMGames.Hopscotch.ViewModel
{
    class HomeViewModel : ViewModelBase
    {
        public HomeViewModel()
        {
            initMainMenu(null);
        }

        public void initMainMenu(Object obj)
        {
            List<Menu_Item> items = new List<Menu_Item>();
            items.Add(new Menu_Item("START GAME", new RelayCommand(startGame)));
            items.Add(new Menu_Item("OPTIONS", null));
            items.Add(new Menu_Item("EXIT", new RelayCommand(exit)));
            menuItems = items;
        }

        private void startGame(Object obj)
        {
            List<Menu_Item> items = new List<Menu_Item>();
            items.Add(new Menu_Item("OPTION 1", new RelayCommand(openGameModeWindow)));
            items.Add(new Menu_Item("OPTION 2", null));
            items.Add(new Menu_Item("BACK", new RelayCommand(initMainMenu)));
            menuItems = items;
        }

        private void openGameModeWindow(object obj)
        {
            GameModeWindow newWindow = new GameModeWindow();
            newWindow.Show();
            Application.Current.MainWindow.Close();
            Application.Current.MainWindow = newWindow;
            
        }

        private List<Menu_Item> _menuItems;
        public List<Menu_Item> menuItems
        {
            get { return _menuItems; }
            private set { _menuItems = value; RaisePropertyChanged("menuItems"); }
        }

        public void exit(object obj)
        {
            Application.Current.Shutdown();
        }
    }
}
