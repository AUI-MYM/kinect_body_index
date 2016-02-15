using MYMGames.Hopscotch.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MYMGames.Hopscotch.Model
{
    class PlayerAvatar : Player
    {
        public bool active { get; set; }
        public bool isEnabled { get; set; }
        public int selected_avatar_index;
        private List<Avatar> _avatars;
        public List<Avatar> avatars
        {
            get
            {
                return _avatars;
            }
            set
            {
                _avatars = value;
            }
        }
        public PlayerAvatar(string avatar_path, RelayCommand command, int player_index) : base(avatar_path)
        {
            _avatars = AvatarFactory.getListOfAvatars(command, player_index);
            _avatars.First().active = true;
            selected_avatar_index = 0;
            isEnabled = true;
            active = false;
        }

        public string getSelectedAvatar()
        {
            foreach (Avatar avatar in avatars)
            {
                if (avatar.active) return "../Images/avatars/avatar" + avatar.avatar_id.Substring(2) + ".jpg";
            }
            return null;
        }
    }
}
