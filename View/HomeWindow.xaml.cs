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
using Microsoft.Kinect;
using Microsoft.Kinect.Wpf.Controls;
using MYMGames.Hopscotch.Model;
using MYMGames.Hopscotch.Helpers;
using Parse;

namespace MYMGames.Hopscotch.View
{
    /// <summary>
    /// Interaction logic for HomeWindow.xaml
    /// </summary>
    public partial class HomeWindow : Window
    {
        public HomeWindow()
        {
            this.InitializeComponent();
            KinectRegion.SetKinectRegion(this, kinectRegion);
            App app = ((App)Application.Current);
            app.KinectRegion = kinectRegion;
            // Use the default sensor
            this.kinectRegion.KinectSensor = KinectSensor.GetDefault();
        }


    

        private void Button_Click_Exit()
        {
            Application.Current.Shutdown();

        }

        private void MenuButton_MouseEnter(object sender, MouseEventArgs e)
        {
            SoundManager.playMenuSound();
        }
    }
}
