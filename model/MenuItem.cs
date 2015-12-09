using MYMGames.Hopscotch.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MYMGames.Hopscotch.model
{
    class Menu_Item
    {
        public string text { get; set; }
        public delegate void onClick();
        public onClick theClick { get; set; }
        public Menu_Item(string text, onClick oc)
        {
            this.text = text;
            this.theClick = oc;
        }

        private ICommand _theCommand;

        public ICommand theCommand
        {
            get
            {
                if (_theCommand == null)
                {
                    _theCommand = new RelayCommand(
                        param => this.Execute(),
                        param => this.CanSave()
                    );
                }
                return _theCommand;
            }
        }

        private bool CanSave()
        {
            return true;
        }

        private void Execute()
        {
            if (theClick != null)
            {
                theClick();
            }
        }
    }
}
