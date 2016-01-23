using MYMGames.Hopscotch.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYMGames.Hopscotch.Helpers
{
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
                        new Step() { current_1 = 0, current_2 = 0, finish = 13, next_1 = 1, next_2 = 0, start = 1},
                        new Step() { current_1 = 1, current_2 = 0, finish = 13, next_1 = 3, next_2 = 0, start = 1},
                        new Step() { current_1 = 3, current_2 = 0, finish = 13, next_1 = 4, next_2 = 6, start = 1},
                        new Step() { current_1 = 4, current_2 = 6, finish = 13, next_1 = 7, next_2 = 0, start = 1},
                        new Step() { current_1 = 7, current_2 = 0, finish = 13, next_1 = 8, next_2 = 10, start = 1},
                        new Step() { current_1 = 8, current_2 = 10, finish = 13, next_1 = 11, next_2 = 0, start = 1},
                        new Step() { current_1 = 11, current_2 = 0, finish = 13, next_1 = 13, next_2 = 0, start = 1},
                        new Step() { current_1 = 13, current_2 = 0, finish = 13, next_1 = 0, next_2 = 0, start = 1}
                    }
               },
                new Chapter()
                {
                    steps = new List<Step>()
                    {
                        new Step() { current_1 = 0, current_2 = 0, finish = 12, next_1 = 1, next_2 = 0, start = 1},
                        new Step() { current_1 = 1, current_2 = 0, finish = 12, next_1 = 3, next_2 = 0, start = 1},
                        new Step() { current_1 = 3, current_2 = 0, finish = 12, next_1 = 7, next_2 = 6, start = 1},
                        new Step() { current_1 = 7, current_2 = 6, finish = 12, next_1 = 9, next_2 = 0, start = 1},
                        new Step() { current_1 = 9, current_2 = 0, finish = 12, next_1 = 12, next_2 = 0, start = 1},
                        new Step() { current_1 = 12, current_2 = 0, finish = 12, next_1 = 0, next_2 = 0, start = 1}
                    }
               },
                new Chapter()
                {
                    steps = new List<Step>()
                    {
                        new Step() { current_1 = 0, current_2 = 0, finish = 2, next_1 = 1, next_2 = 0, start = 1},
                        new Step() { current_1 = 1, current_2 = 0, finish = 2, next_1 = 3, next_2 = 0, start = 1},
                        new Step() { current_1 = 3, current_2 = 0, finish = 2, next_1 = 4, next_2 = 0, start = 1},
                        new Step() { current_1 = 4, current_2 = 0, finish = 2, next_1 = 5, next_2 = 0, start = 1},
                        new Step() { current_1 = 5, current_2 = 0, finish = 2, next_1 = 2, next_2 = 0, start = 1},
                        new Step() { current_1 = 2, current_2 = 0, finish = 2, next_1 = 0, next_2 = 0, start = 1}
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
                        new Step() { current_1 = 0, current_2 = 0, finish = 13, next_1 = 1, next_2 = 0, start = 1},
                        new Step() { current_1 = 1, current_2 = 0, finish = 13, next_1 = 3, next_2 = 0, start = 1},
                        new Step() { current_1 = 3, current_2 = 0, finish = 13, next_1 = 4, next_2 = 6, start = 1},
                        new Step() { current_1 = 4, current_2 = 6, finish = 13, next_1 = 7, next_2 = 0, start = 1},
                        new Step() { current_1 = 7, current_2 = 0, finish = 13, next_1 = 8, next_2 = 10, start = 1},
                        new Step() { current_1 = 8, current_2 = 10, finish = 13, next_1 = 11, next_2 = 0, start = 1},
                        new Step() { current_1 = 11, current_2 = 0, finish = 13, next_1 = 13, next_2 = 0, start = 1},
                        new Step() { current_1 = 13, current_2 = 0, finish = 1, next_1 = 11, next_2 = 0, start = 13},
                        new Step() { current_1 = 11, current_2 = 0, finish = 1, next_1 = 8, next_2 = 10, start = 13},
                        new Step() { current_1 = 8, current_2 = 10, finish = 1, next_1 = 7, next_2 = 0, start = 13},
                        new Step() { current_1 = 7, current_2 = 0, finish = 1, next_1 = 4, next_2 = 6, start = 13},
                        new Step() { current_1 = 4, current_2 = 6, finish = 1, next_1 = 3, next_2 = 0, start = 13},
                        new Step() { current_1 = 3, current_2 = 0, finish = 1, next_1 = 1, next_2 = 0, start = 13},
                        new Step() { current_1 = 1, current_2 = 0, finish = 1, next_1 = 0, next_2 = 0, start = 13}
                    }
               },
                new Chapter()
                {
                    steps = new List<Step>()
                    {
                        new Step() { current_1 = 0, current_2 = 0, finish = 12, next_1 = 1, next_2 = 0, start = 1},
                        new Step() { current_1 = 1, current_2 = 0, finish = 12, next_1 = 3, next_2 = 0, start = 1},
                        new Step() { current_1 = 3, current_2 = 0, finish = 12, next_1 = 7, next_2 = 6, start = 1},
                        new Step() { current_1 = 7, current_2 = 6, finish = 12, next_1 = 9, next_2 = 0, start = 1},
                        new Step() { current_1 = 9, current_2 = 0, finish = 12, next_1 = 12, next_2 = 0, start = 1},
                        new Step() { current_1 = 12, current_2 = 0, finish = 12, next_1 = 0, next_2 = 0, start = 1},
                        new Step() { current_1 = 12, current_2 = 0, finish = 1, next_1 = 9, next_2 = 0, start = 12},
                        new Step() { current_1 = 9, current_2 = 0, finish = 1, next_1 = 7, next_2 = 6, start = 12},
                        new Step() { current_1 = 7, current_2 = 6, finish = 1, next_1 = 3, next_2 = 0, start = 12},
                        new Step() { current_1 = 3, current_2 = 0, finish = 1, next_1 = 1, next_2 = 0, start = 12},
                        new Step() { current_1 = 1, current_2 = 0, finish = 1, next_1 = 0, next_2 = 0, start = 12},
                    }
               },
                new Chapter()
                {
                    steps = new List<Step>()
                    {
                        new Step() { current_1 = 0, current_2 = 0, finish = 2, next_1 = 1, next_2 = 0, start = 1},
                        new Step() { current_1 = 1, current_2 = 0, finish = 2, next_1 = 3, next_2 = 0, start = 1},
                        new Step() { current_1 = 3, current_2 = 0, finish = 2, next_1 = 4, next_2 = 0, start = 1},
                        new Step() { current_1 = 4, current_2 = 0, finish = 2, next_1 = 5, next_2 = 0, start = 1},
                        new Step() { current_1 = 5, current_2 = 0, finish = 2, next_1 = 2, next_2 = 0, start = 1},
                        new Step() { current_1 = 2, current_2 = 0, finish = 2, next_1 = 0, next_2 = 0, start = 1},
                        new Step() { current_1 = 2, current_2 = 0, finish = 1, next_1 = 5, next_2 = 0, start = 2},
                        new Step() { current_1 = 5, current_2 = 0, finish = 1, next_1 = 4, next_2 = 0, start = 2},
                        new Step() { current_1 = 4, current_2 = 0, finish = 1, next_1 = 3, next_2 = 0, start = 2},
                        new Step() { current_1 = 3, current_2 = 0, finish = 1, next_1 = 1, next_2 = 0, start = 2},
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
