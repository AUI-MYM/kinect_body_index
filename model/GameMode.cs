﻿using MYMGames.Hopscotch.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace MYMGames.Hopscotch.Model
{
    public class GameMode
    {
        public int age_range_code { get; set; } // 0: 3-5, 1: 6-7, 2:8+
        public bool timeTrial { get; set;}
        public bool popQuiz { get; set; }
        public int levelCode { get; set; } //defining the difficulty, 0:easy 1:medium 2:hard
        public string Title { get; set;}
        private Uri imagePath;
        private ImageSource image = null;
        public ImageSource Image
        {
            get
            {
                if (image == null && imagePath != null)
                {
                    image = new BitmapImage(imagePath);
                }

                return image;
            }

            private set { }
        }

        public GameMode(string title, string image_path, RelayCommand command, int difficulty)
        {
            this.levelCode = difficulty;
            this.Title = title;
            this.imagePath = new Uri(image_path, UriKind.Relative);
            theCommand = command;
        }

        private RelayCommand _theCommand;
        public RelayCommand theCommand
        {
            get { return _theCommand; }
            set { _theCommand = value; }
        }
    }
}
