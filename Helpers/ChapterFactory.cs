using MYMGames.Hopscotch.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYMGames.Hopscotch.Helpers
{
    //this class is responsible from creating each step required for each of the chapters of the difficulty levels
    //it also includes the corresponding triggers to the steps. 
    class ChapterFactory
    {
        public static List<Chapter> getEasyChapters()
        {
            return new List<Chapter>()
            {
                new Chapter()
                {
                    steps = new List<Step>()
                    {
                        new Step() { current_1 = 0, current_2 = 0, finish = 13, next_1 = 1, next_2 = 0, start = 1, trigger_no = "11", comment="easy1_1"},
                        new Step() { current_1 = 1, current_2 = 0, finish = 13, next_1 = 3, next_2 = 0, start = 1, trigger_no = "12", comment="easy1_2",error_trigger_no="29", error_comment="red3"},
                        new Step() { current_1 = 3, current_2 = 0, finish = 13, next_1 = 4, next_2 = 6, start = 1, trigger_no = "13", comment="easy1_3",error_trigger_no="38", error_comment="red4_red6"},
                        new Step() { current_1 = 4, current_2 = 6, finish = 13, next_1 = 7, next_2 = 0, start = 1, trigger_no = "14", comment="easy1_4",error_trigger_no="33", error_comment="red7"},
                        new Step() { current_1 = 7, current_2 = 0, finish = 13, next_1 = 8, next_2 = 10, start = 1, trigger_no = "15", comment="easy1_5",error_trigger_no="39", error_comment="red8_red10"},
                        new Step() { current_1 = 8, current_2 = 10, finish = 13, next_1 = 11, next_2 = 0, start = 1, trigger_no = "16", comment="easy1_6",error_trigger_no="37", error_comment="red11"},
                        new Step() { current_1 = 11, current_2 = 0, finish = 13, next_1 = 13, next_2 = 0, start = 1, trigger_no = "17", comment="easy1_7"},
                        new Step() { current_1 = 13, current_2 = 0, finish = 13, next_1 = 0, next_2 = 0, start = 1, trigger_no = "11", comment="easy1_1"}
                    }
               },
                new Chapter()
                {
                    steps = new List<Step>()
                    {
                        new Step() { current_1 = 0, current_2 = 0, finish = 12, next_1 = 1, next_2 = 0, start = 1, trigger_no = "18", comment="easy2_1"},
                        new Step() { current_1 = 1, current_2 = 0, finish = 12, next_1 = 3, next_2 = 0, start = 1, trigger_no = "19", comment="easy2_2",error_trigger_no="29", error_comment="red3"},
                        new Step() { current_1 = 3, current_2 = 0, finish = 12, next_1 = 7, next_2 = 6, start = 1, trigger_no = "20", comment="easy2_3",error_trigger_no="40", error_comment="red6_red7"},
                        new Step() { current_1 = 7, current_2 = 6, finish = 12, next_1 = 9, next_2 = 0, start = 1, trigger_no = "21", comment="easy2_4",error_trigger_no="35", error_comment="red9"},
                        new Step() { current_1 = 9, current_2 = 0, finish = 12, next_1 = 12, next_2 = 0, start = 1, trigger_no = "22", comment="easy2_5"},
                        new Step() { current_1 = 12, current_2 = 0, finish = 12, next_1 = 0, next_2 = 0, start = 1, trigger_no = "18", comment="easy2_1"}
                    }
               },
                new Chapter()
                {
                    steps = new List<Step>()
                    {
                        new Step() { current_1 = 0, current_2 = 0, finish = 2, next_1 = 1, next_2 = 0, start = 1, trigger_no = "23", comment="easy3_1"},
                        new Step() { current_1 = 1, current_2 = 0, finish = 2, next_1 = 3, next_2 = 0, start = 1, trigger_no = "24", comment="easy3_2",error_trigger_no="29", error_comment="red3"},
                        new Step() { current_1 = 3, current_2 = 0, finish = 2, next_1 = 4, next_2 = 0, start = 1, trigger_no = "25", comment="easy3_3",error_trigger_no="30", error_comment="red4"},
                        new Step() { current_1 = 4, current_2 = 0, finish = 2, next_1 = 5, next_2 = 0, start = 1, trigger_no = "26", comment="easy3_4",error_trigger_no="31", error_comment="red5"},
                        new Step() { current_1 = 5, current_2 = 0, finish = 2, next_1 = 2, next_2 = 0, start = 1, trigger_no = "27", comment="easy3_5"},
                        new Step() { current_1 = 2, current_2 = 0, finish = 2, next_1 = 0, next_2 = 0, start = 1, trigger_no = "23", comment="easy3_6"}
                    }
               }
            };
        }
        public static List<Chapter> getMediumChapters()
        {
            return new List<Chapter>()
            {
                new Chapter()
                {
                    steps = new List<Step>()
                    {
                        new Step() { current_1 = 0, current_2 = 0, finish = 13, next_1 = 1, next_2 = 0, start = 1 , trigger_no = "11", comment="easy1_1"},
                        new Step() { current_1 = 1, current_2 = 0, finish = 13, next_1 = 3, next_2 = 0, start = 1 , trigger_no = "12", comment="easy1_2",error_trigger_no="29", error_comment="red3"},
                        new Step() { current_1 = 3, current_2 = 0, finish = 13, next_1 = 4, next_2 = 6, start = 1, trigger_no = "13", comment="easy1_3",error_trigger_no="38", error_comment="red4_red6"},
                        new Step() { current_1 = 4, current_2 = 6, finish = 13, next_1 = 7, next_2 = 0, start = 1, trigger_no = "14", comment="easy1_4",error_trigger_no="33", error_comment="red7"},
                        new Step() { current_1 = 7, current_2 = 0, finish = 13, next_1 = 8, next_2 = 10, start = 1, trigger_no = "15", comment="easy1_5",error_trigger_no="39", error_comment="red8_red10"},
                        new Step() { current_1 = 8, current_2 = 10, finish = 13, next_1 = 11, next_2 = 0, start = 1, trigger_no = "16", comment="easy1_7",error_trigger_no="37", error_comment="red11"},
                        new Step() { current_1 = 11, current_2 = 0, finish = 13, next_1 = 13, next_2 = 0, start = 1, trigger_no = "17", comment="easy1_7"},
                        new Step() { current_1 = 13, current_2 = 0, finish = 1, next_1 = 11, next_2 = 0, start = 13, trigger_no = "41", comment="medium1_8",error_trigger_no="37", error_comment="red11"},
                        new Step() { current_1 = 11, current_2 = 0, finish = 1, next_1 = 8, next_2 = 10, start = 13, trigger_no = "42", comment="medium1_9",error_trigger_no="39", error_comment="red8_red10"},
                        new Step() { current_1 = 8, current_2 = 10, finish = 1, next_1 = 7, next_2 = 0, start = 13, trigger_no = "43", comment="medium1_10",error_trigger_no="33", error_comment="red7"},
                        new Step() { current_1 = 7, current_2 = 0, finish = 1, next_1 = 4, next_2 = 6, start = 13, trigger_no = "44", comment="medium1_11",error_trigger_no="38", error_comment="red4_red6"},
                        new Step() { current_1 = 4, current_2 = 6, finish = 1, next_1 = 3, next_2 = 0, start = 13, trigger_no = "45", comment="medium1_12",error_trigger_no="29", error_comment="red3"},
                        new Step() { current_1 = 3, current_2 = 0, finish = 1, next_1 = 1, next_2 = 0, start = 13, trigger_no = "46", comment="medium1_13"},
                        new Step() { current_1 = 1, current_2 = 0, finish = 1, next_1 = 0, next_2 = 0, start = 13, trigger_no = "47", comment="medium1_14"}
                    }
               },
                new Chapter()
                {
                    steps = new List<Step>()
                    {
                        new Step() { current_1 = 0, current_2 = 0, finish = 12, next_1 = 1, next_2 = 0, start = 1, trigger_no = "18", comment="easy2_1"},
                        new Step() { current_1 = 1, current_2 = 0, finish = 12, next_1 = 3, next_2 = 0, start = 1, trigger_no = "19", comment="easy2_2",error_trigger_no="29", error_comment="red3"},
                        new Step() { current_1 = 3, current_2 = 0, finish = 12, next_1 = 7, next_2 = 6, start = 1, trigger_no = "20", comment="easy2_3",error_trigger_no="40", error_comment="red6_red7"},
                        new Step() { current_1 = 7, current_2 = 6, finish = 12, next_1 = 9, next_2 = 0, start = 1, trigger_no = "21", comment="easy2_4",error_trigger_no="35", error_comment="red9"},
                        new Step() { current_1 = 9, current_2 = 0, finish = 12, next_1 = 12, next_2 = 0, start = 1, trigger_no = "22", comment="easy2_5"},
                        new Step() { current_1 = 12, current_2 = 0, finish = 12, next_1 = 0, next_2 = 0, start = 1, trigger_no = "48", comment="medium2_6",error_trigger_no="35", error_comment="red9"},
                        new Step() { current_1 = 12, current_2 = 0, finish = 1, next_1 = 9, next_2 = 0, start = 12, trigger_no = "49", comment="medium2_7",error_trigger_no="40", error_comment="red6_red7"},
                        new Step() { current_1 = 9, current_2 = 0, finish = 1, next_1 = 7, next_2 = 6, start = 12, trigger_no = "50", comment="medium2_8",error_trigger_no="29", error_comment="red3"},
                        new Step() { current_1 = 7, current_2 = 6, finish = 1, next_1 = 3, next_2 = 0, start = 12, trigger_no = "51", comment="medium2_9"},
                        new Step() { current_1 = 3, current_2 = 0, finish = 1, next_1 = 1, next_2 = 0, start = 12, trigger_no = "52", comment="medium2_10"},
                        new Step() { current_1 = 1, current_2 = 0, finish = 1, next_1 = 0, next_2 = 0, start = 12},
                    }
               },
                new Chapter()
                {
                    steps = new List<Step>()
                    {
                        new Step() { current_1 = 0, current_2 = 0, finish = 2, next_1 = 1, next_2 = 0, start = 1, trigger_no = "23", comment="easy3_1"},
                        new Step() { current_1 = 1, current_2 = 0, finish = 2, next_1 = 3, next_2 = 0, start = 1, trigger_no = "24", comment="easy3_2",error_trigger_no="29", error_comment="red3"},
                        new Step() { current_1 = 3, current_2 = 0, finish = 2, next_1 = 4, next_2 = 0, start = 1, trigger_no = "25", comment="easy3_3",error_trigger_no="30", error_comment="red4"},
                        new Step() { current_1 = 4, current_2 = 0, finish = 2, next_1 = 5, next_2 = 0, start = 1, trigger_no = "26", comment="easy3_4",error_trigger_no="31", error_comment="red5"},
                        new Step() { current_1 = 5, current_2 = 0, finish = 2, next_1 = 2, next_2 = 0, start = 1, trigger_no = "27", comment="easy3_5"},
                        new Step() { current_1 = 2, current_2 = 0, finish = 2, next_1 = 0, next_2 = 0, start = 1, trigger_no = "53", comment="medium3_6",error_trigger_no="31", error_comment="red5"},
                        new Step() { current_1 = 2, current_2 = 0, finish = 1, next_1 = 5, next_2 = 0, start = 2, trigger_no = "54", comment="medium3_7",error_trigger_no="30", error_comment="red4"},
                        new Step() { current_1 = 5, current_2 = 0, finish = 1, next_1 = 4, next_2 = 0, start = 2, trigger_no = "55", comment="medium3_8",error_trigger_no="29", error_comment="red3"},
                        new Step() { current_1 = 4, current_2 = 0, finish = 1, next_1 = 3, next_2 = 0, start = 2, trigger_no = "56", comment="medium3_9"},
                        new Step() { current_1 = 3, current_2 = 0, finish = 1, next_1 = 1, next_2 = 0, start = 2, trigger_no = "57", comment="medium3_10"},
                        new Step() { current_1 = 1, current_2 = 0, finish = 1, next_1 = 0, next_2 = 0, start = 2},
                    }
               }
            };
        }
        public static List<Chapter> getHardChapters()
        {
            return new List<Chapter>()
            {
                new Chapter()
                {
                    steps = new List<Step>()
                    {
                        new Step() { current_1 = 0, current_2 = 0, finish = 13, next_1 = 1, next_2 = 0, start = 1},
                        new Step() { current_1 = 1, current_2 = 0, finish = 13, next_1 = 3, next_2 = 0, start = 1},
                        new Step() { current_1 = 3, current_2 = 0, finish = 13, next_1 = 7, next_2 = 6, start = 1},
                        new Step() { current_1 = 7, current_2 = 6, finish = 13, next_1 = 9, next_2 = 0, start = 1},
                        new Step() { current_1 = 9, current_2 = 0, finish = 13, next_1 = 12, next_2 = 0, start = 1},
                        new Step() { current_1 = 12, current_2 = 0, finish = 13, next_1 = 7, next_2 = 10, start = 1},
                        new Step() { current_1 = 7, current_2 = 10, finish = 13, next_1 = 11, next_2 = 0, start = 1},
                        new Step() { current_1 = 11, current_2 = 0, finish = 13, next_1 = 13, next_2 = 0, start = 1},
                        new Step() { current_1 = 13, current_2 = 0, finish = 1, next_1 = 11, next_2 = 0, start = 13},
                        new Step() { current_1 = 11, current_2 = 0, finish = 1, next_1 = 7, next_2 = 8, start = 13},
                        new Step() { current_1 = 7, current_2 = 8, finish = 1, next_1 = 5, next_2 = 0, start = 13},
                        new Step() { current_1 = 5, current_2 = 0, finish = 1, next_1 = 2, next_2 = 0, start = 13},
                        new Step() { current_1 = 2, current_2 = 0, finish = 1, next_1 = 5, next_2 = 0, start = 13},
                        new Step() { current_1 = 5, current_2 = 0, finish = 1, next_1 = 4, next_2 = 7, start = 13},
                        new Step() { current_1 = 4, current_2 = 7, finish = 1, next_1 = 3, next_2 = 0, start = 13},
                        new Step() { current_1 = 3, current_2 = 0, finish = 1, next_1 = 1, next_2 = 0, start = 13},
                        new Step() { current_1 = 1, current_2 = 0, finish = 1, next_1 = 0, next_2 = 0, start = 13},
                    }
               }
            };
        }
    }
}
