using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYMGames.Hopscotch.Model
{
    public class LeaderboardModel
    {
        public int rank { get; set; }
        public string user_name { get; set; }
        public int score { get; set; }
        public bool synced { get; set; }
        public string id { get; set; }
        public string avatarid { get; set; }
        public LeaderboardModel()
        {
            synced = false;
        }
    }
}
