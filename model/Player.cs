using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace MYMGames.Hopscotch.Model
{
    public class Player
    {
        #region randomNames
        private string[] random_names = {"Johnny",
            "Maryann",
            "Lupita",
            "Colby",
            "Evelia",
            "Maritza",
            "Rina",
            "Quentin",
            "Valene",
            "Valencia",
            "Ryan",
            "Nannette",
            "Mavis",
            "Cayla",
            "Kylee",
            "Alexander",
            "Doria",
            "Regina",
            "Latrina",
            "Blanca",
            "Michelle",
            "Mira",
            "Delila",
            "Charlesetta",
            "Sheridan",
            "Abdul",
            "Rob",
            "Rodrigo",
            "Jayna",
            "Sunny",
            "Petronila",
            "Clair",
            "Dianne",
            "Tamisha",
            "Caryn",
            "Lorina",
            "Zelda",
            "Alexis",
            "Fay",
            "Pamala",
            "Boris",
            "Malka",
            "Elanor",
            "Deloris",
            "Dinorah",
            "Joanne",
            "Kanesha",
            "Dolores",
            "Priscilla",
            "Chaya"};
        #endregion
        private static Random random = new Random(DateTime.Now.Second);
        public string name { get; set; }
        public int score { get; set; }
        public int last_chapter_played { get; set; }
        public int last_chapter_trial_amount { get; set; }
        public Brush border_color { get; set; }
        private bool _game_finished;
        public bool game_finished {
            get { return _game_finished; }
            set
            {
                _game_finished = value;
                if (_game_finished)
                {
                    border_color = new SolidColorBrush(Colors.Green);
                }
            }
        }
        private bool _current_user;
        public bool current_user
        {
            get { return _current_user; }
            set { _current_user = value;
                    if (_current_user)
                    {
                        border_color = new SolidColorBrush(Colors.Orange);
                    }
                    else if(!_game_finished)
                    {
                        border_color = new SolidColorBrush(Colors.Transparent);
                    }
            }
        }
        private Uri avatar_path;
        private ImageSource avatar = null;
        public ImageSource Avatar
        {
            get
            {
                if (avatar == null && avatar_path != null)
                {
                    avatar = new BitmapImage(avatar_path);
                }

                return avatar;
            }

            private set { }
        }
        public Player(string avatar_path)
        {
            int index = random.Next(0, random_names.Length - 1);
            name = random_names[index];
            score = 0;
            game_finished = false;
            this.avatar_path = new Uri(avatar_path, UriKind.Relative);
            last_chapter_played = 0;
            last_chapter_trial_amount = 0;
        }
    }
}
