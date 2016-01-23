using MYMGames.Hopscotch.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MYMGames.Hopscotch.View
{
    /// <summary>
    /// Interaction logic for MultiPlayerUserControl.xaml
    /// </summary>
    public partial class MultiPlayerUserControl : UserControl , INotifyPropertyChanged
    {
        public MultiPlayerUserControl()
        {
            InitializeComponent();
        }

        private void Button_Click_Exit()
        {
            Application.Current.Shutdown();

        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
    }
}
