using MYMGames.Hopscotch.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace MYMGames.Hopscotch.Helpers
{
    class BoxFactory
    {
        public static List<BoxModel> create_white_boxes()
        {
            return new List<BoxModel>()
            {
                new BoxModel() { color = new SolidColorBrush(Colors.White), visibility = Visibility.Visible, row=4, column=4, text="1" },
                new BoxModel() { color = new SolidColorBrush(Colors.White), visibility = Visibility.Visible, row=4, column=0, text="2" },
                new BoxModel() { color = new SolidColorBrush(Colors.White), visibility = Visibility.Visible, row=3, column=3, text="3" },
                new BoxModel() { color = new SolidColorBrush(Colors.White), visibility = Visibility.Visible, row=3, column=2, text="4" },
                new BoxModel() { color = new SolidColorBrush(Colors.White), visibility = Visibility.Visible, row=3, column=1, text="5" },
                new BoxModel() { color = new SolidColorBrush(Colors.White), visibility = Visibility.Visible, row=2, column=3, text="6" },
                new BoxModel() { color = new SolidColorBrush(Colors.White), visibility = Visibility.Visible, row=2, column=2, text="7" },
                new BoxModel() { color = new SolidColorBrush(Colors.White), visibility = Visibility.Visible, row=2, column=1, text="8" },
                new BoxModel() { color = new SolidColorBrush(Colors.White), visibility = Visibility.Visible, row=1, column=3, text="9" },
                new BoxModel() { color = new SolidColorBrush(Colors.White), visibility = Visibility.Visible, row=1, column=2, text="10" },
                new BoxModel() { color = new SolidColorBrush(Colors.White), visibility = Visibility.Visible, row=1, column=1, text="11" },
                new BoxModel() { color = new SolidColorBrush(Colors.White), visibility = Visibility.Visible, row=0, column=4, text="12" },
                new BoxModel() { color = new SolidColorBrush(Colors.White), visibility = Visibility.Visible, row=0, column=0, text="13" }
            };
        }
    }
}
