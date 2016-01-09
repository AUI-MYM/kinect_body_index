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
using System.Windows.Controls;

namespace MYMGames.Hopscotch.ViewModel
{
    class HomeViewModel : ViewModelBase
    {
        public HomeViewModel()
        {
            initMainMenu(null);
            //startGame(null);
        }
        private void clearfields()
        {
            ChooseDifficulty = "";
            menuItems = new List<Menu_Item>();
            GameModes = new List<GameMode>();
            popQuizList = new List<StringBoolDuo>();
            popQuizListAgeList = new List<StringBoolDuo>();
            timeTrialList = new List<StringBoolDuo>();
            readyList = new List<Menu_Item>();
        }

        public void initMainMenu(Object obj)
        {
            clearfields();
            screenStep = 0;
            List<Menu_Item> items = new List<Menu_Item>();
            items.Add(new Menu_Item("START GAME", new RelayCommand(startGame)));
            items.Add(new Menu_Item("LEADERBOARD", new RelayCommand(showLeaderboard)));
            items.Add(new Menu_Item("EXIT", new RelayCommand(exit)));
            menuItems = items;
            MainMenuUserControl mmuc = new MainMenuUserControl();
            CurrentPage = mmuc;
        }

        private void showLeaderboard(object obj)
        {
            clearfields();
            screenStep = 5;
            setLeaderboardBackground();
            CurrentPage = new LeaderboardUserControl();
        }

        private async void setLeaderboardBackground()
        {
            List<LeaderboardModel> items = await ParseConnector.getLeaderboard();
            leaderboardlist = items;
        }

        private void startGame(Object obj)
        {
            clearfields();
            ChooseDifficulty = "Choose Difficulty";
            screenStep = 1;
            List<GameMode> items = new List<GameMode>();
            items.Add(new GameMode("Easy", "../Images/download400_400.jpg", new RelayCommand(setDifficulty),0));
            items.Add(new GameMode("Medium", "../Images/download400_400.jpg", new RelayCommand(setDifficulty),1));
            items.Add(new GameMode("Hard", "../Images/download400_400.jpg", new RelayCommand(setDifficulty),2));
            GameModes = items;
            DifficultyUserControl duc = new DifficultyUserControl();
            CurrentPage = duc;
        }

        private void setDifficulty(object obj)
        {
            int levelCode = (int)obj;
            screenStep = 2 + levelCode;
            selectedGameMode = GameModes.ElementAt(levelCode);
            clearfields();
            ChooseDifficulty = "Select game options";
            List<Menu_Item> ready_item = new List<Menu_Item>();
            ready_item.Add(new Menu_Item("Ready!", new RelayCommand(openGameModeWindow)));
            readyList = ready_item;
            List<StringBoolDuo> time_list = new List<StringBoolDuo>()
            {
                new StringBoolDuo() { text="Allow time trial", value=false }
            };
            timeTrialList = time_list;
            time_list = new List<StringBoolDuo>()
            {
                new StringBoolDuo() { text="Allow quiz challenges", value=false }
            };
            popQuizList = time_list;
            time_list = new List<StringBoolDuo>()
            {
                new StringBoolDuo() { text = "3-5 years old", value = false },
                new StringBoolDuo() { text = "6-7 years old", value = false },
                new StringBoolDuo() { text = "8+ years old", value = false }
            };
            popQuizListAgeList = time_list;
            CurrentPage = new AdvancedOptionsUserControl();
        }

        private void openGameModeWindow(object obj)
        {
            //TODO fetch what has been choosen and validate
            GameModeWindow newWindow = new GameModeWindow();
            WindowManager.goToWindow(newWindow);
            
        }

        private List<Menu_Item> _menuItems;
        public List<Menu_Item> menuItems
        {
            get { return _menuItems; }
            private set { _menuItems = value; RaisePropertyChanged("menuItems"); }
        }

        private List<Menu_Item> _readyList;
        public List<Menu_Item> readyList
        {
            get { return _readyList; }
            private set { _readyList = value; RaisePropertyChanged("readyList"); }
        }

        private List<StringBoolDuo> _timeTrialList;
        public List<StringBoolDuo> timeTrialList
        {
            get { return _timeTrialList; }
            private set { _timeTrialList = value; RaisePropertyChanged("timeTrialList"); }
        }

        private List<StringBoolDuo> _popQuizList;
        public List<StringBoolDuo> popQuizList
        {
            get { return _popQuizList; }
            private set { _popQuizList = value; RaisePropertyChanged("popQuizList"); }
        }

        private List<StringBoolDuo> _popQuizListAgeList;
        public List<StringBoolDuo> popQuizListAgeList
        {
            get { return _popQuizListAgeList; }
            private set { _popQuizListAgeList = value; RaisePropertyChanged("popQuizListAgeList"); }
        }



        private List<GameMode> _GameModes;
        public List<GameMode> GameModes
        {
            get { return _GameModes; }
            private set { _GameModes = value; RaisePropertyChanged("GameModes"); }
        }

        private List<LeaderboardModel> _leaderboardList;
        public List<LeaderboardModel> leaderboardlist
        {
            get { return _leaderboardList; }
            private set { _leaderboardList = value; RaisePropertyChanged("LeaderboardModel"); }
        }

        private string _ChooseDifficulty ="";
        public string ChooseDifficulty
        {
            get { return _ChooseDifficulty; }
            private set { _ChooseDifficulty = value; RaisePropertyChanged("ChooseDifficulty"); }
        }

        private RelayCommand _backButtonCommand;
        public RelayCommand backButtonCommand
        {
            get
            {
                if (_backButtonCommand == null)
                    _backButtonCommand = new RelayCommand(goBackButton);
                return _backButtonCommand;
            }
        }

        private GameMode _selectedGameMode;
        public GameMode selectedGameMode
        {
            get
            {
                return _selectedGameMode;
            }
            set
            {
                _selectedGameMode = value;
                RaisePropertyChanged("selectedGameMode");
            }
        }
        /**
         screen step indicates in which step the start game process in
            0 -> main menu
            1 -> start game menu
            2 -> start easy
            3 -> start medium
            4 -> start hard
            5 -> game window*/
        private int _screenStep = 0;
        public int screenStep
        {
            get
            {
                return _screenStep;
            }
            set
            {
                if (_screenStep != value)
                {
                    backButtonVisibility = value > 0;
                    _screenStep = value;
                }
            }
        }

        private bool _backButtonVisibility;
        public bool backButtonVisibility
        {
            get
            {
                return _backButtonVisibility;
            }
            set
            {
                if (_backButtonVisibility != value)
                {
                    _backButtonVisibility = value;
                    RaisePropertyChanged("backButtonVisibility");
                }
            }
        }

        private UserControl _CurrentPage;
        public UserControl CurrentPage
        {
            get { return _CurrentPage; }
            set { _CurrentPage = value;  RaisePropertyChanged("CurrentPage"); }
        }

        private void goBackButton(object obj)
        {
            switch (screenStep)
            {
                case 0:
                    //do nothing
                    break;
                case 1:
                    initMainMenu(null);
                    break;
                case 2:
                case 3:
                case 4:
                    startGame(null);
                    break;
                case 5:
                    initMainMenu(null);
                    break;
            }
        }
        public void exit(object obj)
        {
            Application.Current.Shutdown();
        }

        internal class StringBoolDuo
        {
            public string text { get; set; }
            public bool value { get; set; }
        }
    }
}
