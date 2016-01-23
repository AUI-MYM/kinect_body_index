using MYMGames.Hopscotch.Model;
using Parse;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MYMGames.Hopscotch.Helpers
{
    //This class also handles offline storage of the leaderboard
    public class ParseConnector
    {
        private static bool connected;
        private static string file_name = "Leaderboard.xml";
        private static List<LeaderboardModel> sycned_items = null;
        public static async Task<List<LeaderboardModel>> getLeaderboard()
        {
            if (sycned_items != null) return sycned_items;
            List<LeaderboardModel> items = new List<LeaderboardModel>();
            try
            {
                var query = from leaderboard in ParseObject.GetQuery("Leaderboard")
                            orderby leaderboard["score"]
                            select leaderboard;
                var scores = await query.FindAsync();
                int rankCounter = 1;
                foreach (ParseObject obj in scores.AsEnumerable<ParseObject>().Reverse())
                {
                    items.Add(new LeaderboardModel()
                    {
                        rank = rankCounter++,
                        score = obj.Get<int>("score"),
                        user_name = obj.Get<string>("user_name"),
                        id = obj.ObjectId

                    });
                }
                sycned_items = items;
                connected = true;
            } catch (System.Net.WebException e)
            {
                connected = false;
                loadOffline();
                return sycned_items;
            }
            return items;
        }

        public static void addScore(string user_name, int score)
        {
            ParseObject po = new ParseObject("Leaderboard");
            po["user_name"] = user_name;
            po["score"] = score;
            po.SaveAsync();
        }

        public static void resetLeaderboard()
        {
            throw new NotImplementedException();
        }

        public static void storeOffline()
        {
            if (sycned_items == null || sycned_items.Count == 0) return;
            using (FileStream outFile = File.Create(file_name))
            {
                XmlSerializer formatter = new XmlSerializer(typeof(List<LeaderboardModel>));
                formatter.Serialize(outFile, sycned_items);
                outFile.Close();
            }
        }

        public static void loadOffline()
        {
            using (FileStream aFile = new FileStream(file_name, FileMode.Open))
            {
                XmlSerializer formatter = new XmlSerializer(typeof(List<LeaderboardModel>));
                byte[] buffer = new byte[aFile.Length];
                aFile.Read(buffer, 0, (int)aFile.Length);
                MemoryStream stream = new MemoryStream(buffer);
                sycned_items = (List<LeaderboardModel>)formatter.Deserialize(stream);
                aFile.Close();
            }
        }
    }
}
