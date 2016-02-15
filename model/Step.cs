using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYMGames.Hopscotch.Model
{
    public class Step
    {
        public int next_1 { get; set; }
        public int next_2 { get; set; }
        public int start { get; set; }
        public int finish { get; set; }
        public int current_1 { get; set; }
        public int current_2 { get; set; }
        public bool quesition_asked { get; set; }
        public string trigger_no { get; set; }
        public string comment { get; set; }
        public string error_trigger_no { get; set; }
        public string error_comment { get; set; }
    }
}
