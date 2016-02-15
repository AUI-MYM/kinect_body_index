using MYMGames.Hopscotch.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYMGames.Hopscotch.Helpers
{
    //generates the list of avatars with the names and assign the commands, which are the actions 
    //that is executed after every click event, corresponding player indexes.
    class AvatarFactory
    {
        public static List<Avatar> getListOfAvatars(RelayCommand command, int player_index)
        {
            return new List<Avatar>()
            {
                new Avatar("f1", command, player_index),
                new Avatar("m1", command, player_index),
                new Avatar("f2", command, player_index),
                new Avatar("m2", command, player_index),
                new Avatar("f3", command, player_index),
                new Avatar("m3", command, player_index),
                new Avatar("f4", command, player_index),
                new Avatar("m4", command, player_index)
            };
        }
    }
}
