using MYMGames.Hopscotch.Helpers;
using MYMGames.Hopscotch.Model;
using MYMGames.Hopscotch.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace MYMGames.Hopscotch.ViewModel
{
    class GameModeViewModel : ViewModelBase
    {
        public GameModeViewModel()
        {
            GoBackToMainMenu = new RelayCommand(goToMainMenu);
            //boxes = GameLogic.boxes;
            players = GameLogic.players;
            pop_quiz_text = "Quizes: ";
            if (GameLogic.game_mode.popQuiz)
            {
                string[] temp = new string[] { "5-7 Years", "8-11 Years", "11+ Years" };
                pop_quiz_text += temp[GameLogic.game_mode.age_range_code];
            }
            else
            {
                pop_quiz_text += "No";
            }
            time_limit_text = (GameLogic.game_mode.timeTrial) ? "Time limit: Yes" : "Time limit: No";
        }

        #region ui elements
        public string pop_quiz_text { get; set; }
        public string time_limit_text { get; set; }
        private List<Player> _players;
        public List<Player> players
        {
            get { return _players; }
            set { _players = value; RaisePropertyChanged("players"); }
        }
        public RelayCommand GoBackToMainMenu { get; set; }
        private List<BoxModel> _boxes;//depricated
        public List<BoxModel> boxes
        {
            get { return _boxes; }
            set { _boxes = value; RaisePropertyChanged("boxes"); }
        }
        #endregion

        #region navigation
        private void goToMainMenu(object obj)
        {
            WindowManager.goBack(); 
        }
        #endregion
    }
}
