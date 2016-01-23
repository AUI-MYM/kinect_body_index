using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace MYMGames.Hopscotch.Model
{
    public class BoxModel
    {
        public Visibility visibility { get; set; }
        public Brush color { get; set; }
        public string text { get; set; }
        public int row { get; set; }
        public int column { get; set; }
    }
}
