using MYMGames.Hopscotch.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace MYMGames.Hopscotch.Model
{
    // The model of the avatar view
    class Avatar
    {
        public Brush borderColor { get; set; }
        public string avatar_id { get; set; }
        private bool _active;
        public bool active
        {
            get
            {
                return _active;
            }
            set
            {
                _active = value;
                if (_active) borderColor = new SolidColorBrush(Colors.Green);
                else borderColor = new SolidColorBrush(Colors.Transparent);
            }
        }
        private Uri avatar_path;
        private ImageSource _avatar = null;
        public ImageSource avatar
        {
            get
            {
                if (_avatar == null && avatar_path != null)
                {
                    _avatar = new BitmapImage(avatar_path);
                }

                return _avatar;
            }

            private set { }
        }
        private RelayCommand _command;
        public RelayCommand command
        {
            get
            {
                return _command;
            }
            set
            {
                _command = value;
            }
        } 

        public Avatar(string avatar_id, RelayCommand command, int player_index)
        {
            avatar_path = new Uri("../Images/avatars/avatar" + avatar_id + ".jpg", UriKind.Relative);
            borderColor = new SolidColorBrush(Colors.Transparent);
            _command = command;
            this.avatar_id = player_index + " " + avatar_id;
        }
    }
}
