using MYMGames.Hopscotch.Model;
using Parse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYMGames.Hopscotch.Helpers
{
    public class ParseConnector
    {
        public static async Task<List<LeaderboardModel> > getLeaderboard()
        {
            var query = from leaderboard in ParseObject.GetQuery("Leaderboard")
                        orderby leaderboard["score"]
                        select leaderboard;
            var scores = await query.FindAsync();
            int rankCounter = 1;
            List<LeaderboardModel> items = new List<LeaderboardModel>();
            foreach (ParseObject obj in scores.AsEnumerable<ParseObject>())
            {
                items.Add(new LeaderboardModel()
                {
                    rank = rankCounter++, score=obj.Get<int>("score"), user_name=obj.Get<string>("user_name") 
                });
            }
            return items;
        }

        public static void addScore(string user_name, int score)
        {
            
        } 
    }
}
