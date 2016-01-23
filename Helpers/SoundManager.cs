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
        SoundPlayer player;
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

        public void playMenuSound()
        {
            player = new SoundPlayer(menuUri);
            player.Load();

            bool soundFinished = true;

            if (soundFinished)
            {
                soundFinished = false;
                Task.Factory.StartNew(() => { player.PlaySync(); soundFinished = true; });
            }
        }

        public void playBackgroundMusic()
        {
            player = new SoundPlayer(soundtrackUri);
            player.Load();
            player.PlayLooping();
        }
        //0: applause
        //1: bravo
        //2: game finished
        public void playSound(int mode)
        {
            player.Stop();
            string[] sounds = new string[] { "applause_y.wav", "cheering.wav", "yay_z.wav" };
            string sound_path = "Sounds/" + sounds[mode];
            var t = Task.Factory.StartNew(() => { _playSound(sound_path, SoundPlayed); });
            
            
        }

        private void _playSound(string sound_uri, EventHandler doneCallback = null)
        {
            using (var player = new SoundPlayer(sound_uri))
            {
                player.PlaySync();
            }
            if (doneCallback != null)
            {
                // the callback is executed on the thread.
                doneCallback(this, new EventArgs());
            }
        }

        void SoundPlayed(object sender, EventArgs e)
        {
            playBackgroundMusic();
        }
    }
}
