using MYMGames.Hopscotch.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MYMGames.Hopscotch.Model
{
    public class Menu_Item
    {
        public string text { get; set; }
        public RelayCommand theCommand { get; set; }
        public Menu_Item(string text, RelayCommand rc)
        {
            this.text = text;
            this.theCommand = rc;
        }
    }
}
