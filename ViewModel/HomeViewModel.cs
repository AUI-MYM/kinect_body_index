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
using System.Windows.Media;

namespace MYMGames.Hopscotch.ViewModel
{
    class HomeViewModel : ViewModelBase
    {
        public HomeViewModel()
        {
            initMainMenu(null);
        }
        #region ui set methods
        //after each change of usercontrol, the lists are cleared to avoid the conflicts
        private void clearfields()
        {
            ChooseDifficulty = "";
            menuItems = new List<Menu_Item>();
            GameModes = new List<GameMode>();
            popQuizList = new List<StringBoolDuo>();
            popQuizListAgeList = new List<StringBoolDuo>();
            timeTrialList = new List<StringBoolDuo>();
            readyList = new List<Menu_Item>();
            multiPlayers = new List<PlayerAvatar>();
        }
        //the method initializes the main menu by creating the related menu items
        public void initMainMenu(Object obj)
        {
            clearfields();
            screenStep = 0;
            List<Menu_Item> items = new List<Menu_Item>();
            items.Add(new Menu_Item("START GAME", new RelayCommand(selectNumberOfPlayers)));
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
            ChooseDifficulty = "Leaderboard";
            leaderboardlist = new List<LeaderboardModel>() { (new LeaderboardModel() { rank = 1, score = 1, user_name = "Connecting..." }) };
            setLeaderboardBackground();
            CurrentPage = new LeaderboardUserControl();
        }

        private async void setLeaderboardBackground()
        {
            leaderboardlist = await ParseConnector.getLeaderboard();
        }

        private void startGame(Object obj)
        {
            players = new List<Player>();
            foreach(PlayerAvatar pa in multiPlayers)
            {
                if (pa.active)
                {
                    players.Add(new Player(pa.getSelectedAvatar()));
                }
            }
            clearfields();
            ChooseDifficulty = "Choose Difficulty";
            screenStep = 1;
            List<GameMode> items = new List<GameMode>();
            items.Add(new GameMode("Easy", "../Images/level1.png", new RelayCommand(setDifficulty),0));
            items.Add(new GameMode("Medium", "../Images/level2.png", new RelayCommand(setDifficulty),1));
            items.Add(new GameMode("Hard", "../Images/level3.png", new RelayCommand(setDifficulty),1));
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
                new StringBoolDuo() { text = "5-7 years old", value = false },
                new StringBoolDuo() { text = "8-10 years old", value = false },
                new StringBoolDuo() { text = "11+ years old", value = false }
            };
            popQuizListAgeList = time_list;
            CurrentPage = new AdvancedOptionsUserControl();
        }

        private void selectNumberOfPlayers(object obj)
        {
            clearfields();
            screenStep = 6;
            ChooseDifficulty = "Set player details";
            multiPlayers = new List<PlayerAvatar>()
            {
                new PlayerAvatar("../Images/avatars/avatar1f.jpg", new RelayCommand(clickOnAvatar), 0),
                new PlayerAvatar("../Images/avatars/avatar1f.jpg", new RelayCommand(clickOnAvatar), 1),
                new PlayerAvatar("../Images/avatars/avatar1m.jpg", new RelayCommand(clickOnAvatar), 2),
                new PlayerAvatar("../Images/avatars/avatar1m.jpg", new RelayCommand(clickOnAvatar), 3)
            };
            multiPlayers.First().active = true;
            multiPlayers.First().isEnabled = false;
            CurrentPage = new MultiPlayerUserControl();
        }
        //this the event on clicking the avatar selection of each player
        //below code finds exactly which list to update contents, and updates it
        private void clickOnAvatar(object obj)
        {
            int player_index = int.Parse(((string)obj).Split(' ')[0]);
            int avatar_index = (int.Parse(((string)obj).Split(' ')[1].Substring(1)) - 1) * 2;
            switch (((string)obj).Split(' ')[1][0])
            {
                case 'm':
                    avatar_index++;
                    break;
            }
            PlayerAvatar pa = _multiPlayers.ElementAt(player_index);
            pa.avatars.ElementAt(pa.selected_avatar_index).active = false;
            pa.avatars.ElementAt(avatar_index).active = true;
            pa.selected_avatar_index = avatar_index;
            //multiPlayers = multiPlayers;
            //((MultiPlayerUserControl)_CurrentPage).playerList.Items.Refresh();
            //a workaround to refresh the avatar lists, rather than refreshing the whole list, because it causes to lose focus on the avatar image
            ContentPresenter cp = ((MultiPlayerUserControl)_CurrentPage).playerList.ItemContainerGenerator.ContainerFromIndex(player_index) as ContentPresenter;
            ItemsControl ic = FindVisualChild<ItemsControl>(cp,0);
            if (ic != null)
            {
                ic.Items.Refresh();
            }
        }
        //copy paste method from stackoverflow, it looks for an element in the visualtreehelper
        public T FindVisualChild<T>(DependencyObject depObj, int index) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        if (index == 0)
                            return (T)child;
                        else
                        {
                            index--;
                        }
                    }

                    T childItem = FindVisualChild<T>(child, index);
                    if (childItem != null) return childItem;
                }
            }
            return null;
        }


        private void openGameModeWindow(object obj)
        {
            //TODO fetch what has been choosen and validate
            GameLogic.players = this.players;
            selectedGameMode.popQuiz = popQuizList.First().value;
            selectedGameMode.timeTrial = timeTrialList.First().value;
            selectedGameMode.age_range_code = 0;
            for (int i=0; i< popQuizListAgeList.Count; i++)
            {
                if (popQuizListAgeList.ElementAt(i).value)
                    selectedGameMode.age_range_code += i;
            }
            GameLogic.game_mode = selectedGameMode;
            switch(selectedGameMode.levelCode)
            {
                case 0:
                    GameLogic.chapters = ChapterFactory.getEasyChapters();
                    break;
                case 1:
                    GameLogic.chapters = ChapterFactory.getMediumChapters();
                    break;
                case 2:
                    GameLogic.chapters = ChapterFactory.getHardChapters();
                    break;
            }

            GameLogic.boxes = BoxFactory.create_white_boxes();
            GameLogic.configureBoxes(0,0,0);
            GameLogic.getCurrentPlayer().current_user = true;
            GameModeWindow newWindow = new GameModeWindow();
            WindowManager.goToWindow(newWindow);
            
        }
        #endregion

        #region ui object lists
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
            private set { _leaderboardList = value; RaisePropertyChanged("leaderboardlist"); }
        }

        private List<PlayerAvatar> _multiPlayers;
        public List<PlayerAvatar> multiPlayers
        {
            get { return _multiPlayers; }
            private set { _multiPlayers = value; RaisePropertyChanged("multiPlayers"); }
        }

        private List<Player> _players;
        public List<Player> players
        {
            get { return _players; }
            private set { _players = value; RaisePropertyChanged("players"); }
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

        private RelayCommand _nextToDifficultySelectionCommand;
        public RelayCommand nextToDifficultySelectionCommand
        {
            get
            {
                if (_nextToDifficultySelectionCommand == null)
                    _nextToDifficultySelectionCommand = new RelayCommand(startGame);
                return _nextToDifficultySelectionCommand;
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
        private UserControl _CurrentPage;
        public UserControl CurrentPage
        {
            get { return _CurrentPage; }
            set { _CurrentPage = value; RaisePropertyChanged("CurrentPage"); }
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

        private bool _visibilityNextButton;
        public bool visibilityNextButton
        {
            get
            {
                return _visibilityNextButton;
            }

            set
            {
                _visibilityNextButton = value;
                RaisePropertyChanged("visibilityNextButton");
            }
        }

        #endregion

        #region navigation methods

        /**
         screen step indicates in which step the start game process in
            0 -> main menu
            1 -> start game menu
            2 -> start easy
            3 -> start medium
            4 -> start hard
            5 -> leaderboard
            6 -> select number of players*/
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

        private void goBackButton(object obj)
        {
            switch (screenStep)
            {
                case 0:
                    //do nothing
                    break;
                case 1:
                    selectNumberOfPlayers(null);
                    break;
                case 2:
                case 3:
                case 4:
                    startGame(null);
                    break;
                case 5:
                    initMainMenu(null);
                    break;
                case 6:
                    initMainMenu(null);
                    break;
            }
        }
        //close the application entirely if this window is closed
        public void exit(object obj)
        {
            Application.Current.Shutdown();
        }

        #endregion

        internal class StringBoolDuo
        {
            public string text { get; set; }
            public bool value { get; set; }
        }
    }
}
