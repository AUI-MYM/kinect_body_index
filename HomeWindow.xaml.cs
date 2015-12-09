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
using MYMGames.Hopscotch.model;

namespace MYMGames.Hopscotch
{
    /// <summary>
    /// Interaction logic for HomeWindow.xaml
    /// </summary>
    public partial class HomeWindow : Window
    {
        public HomeWindow()
        {
            this.InitializeComponent();
            List<Menu_Item> items = new List<Menu_Item>();
            items.Add(new Menu_Item("Start Game",null));
            items.Add(new Menu_Item("Options",null));
            items.Add(new Menu_Item("Exit",Button_Click_Exit));
            this.menuItems.ItemsSource = items;
            
            KinectRegion.SetKinectRegion(this, kinectRegion);
            App app = ((App)Application.Current);
            app.KinectRegion = kinectRegion;

            // Use the default sensor
            this.kinectRegion.KinectSensor = KinectSensor.GetDefault();

            //// Add in display content
            //var sampleDataSource = SampleDataSource.GetGroup("Group-1");
            //this.itemsControl.ItemsSource = sampleDataSource;
            
        }

        private void Button_Click_Exit()
        {
            Application.Current.Shutdown();

        }
    }
}
