using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace MYMGames.Hopscotch.Helpers
{
    public class SoundManager
    {
        static string menuUri = "Sounds/menu.wav";
        static string soundtrackUri = "Sounds/soundtrack.wav";
        private SoundManager()
        {

        }

        private static SoundManager instance;
        public static SoundManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SoundManager();
                }
                return instance;
            }
        }

        public static void playMenuSound()
        {
            SoundPlayer player = new SoundPlayer(menuUri);
            player.Load();

            bool soundFinished = true;

            if (soundFinished)
            {
                soundFinished = false;
                Task.Factory.StartNew(() => { player.PlaySync(); soundFinished = true; });
            }
        }

        public static void playBackgroundMusic()
        {
            

            bool soundFinished = true;

            if (soundFinished)
            {
                soundFinished = false;
                Task.Factory.StartNew(() => {
                    SoundPlayer player = new SoundPlayer(soundtrackUri);
                    player.Load();
                    player.PlaySync(); soundFinished = true; });
            }
        }
    }
}
