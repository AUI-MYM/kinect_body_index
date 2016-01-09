﻿using MYMGames.Hopscotch.Helpers;
using Parse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MYMGames.Hopscotch.View
{
    /// <summary>
    /// Interaction logic for OpeningWindow.xaml
    /// </summary>
    public partial class OpeningWindow : Window
    {
        public OpeningWindow()
        {
            InitializeComponent();
            SoundManager.playBackgroundMusic();
            ParseClient.Initialize("DSawAatii6x568hptZIEBTFmaslmTuxNdSNAUNTR", "R2Le76ZyMNZRE63TKfkJ7eebJkdrWT1EHoeDlOzH");
        }

        private void Storyboard_Completed(object sender, EventArgs e)
        {
            WindowManager.goToWindow(new HomeWindow()); 
        }
    }
}
