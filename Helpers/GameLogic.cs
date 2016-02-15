using MYMGames.Hopscotch.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Xml.Serialization;

namespace MYMGames.Hopscotch.Helpers
{
    //this class includes all the game variables statically with the public accsess to all the other
    //classes
    public class GameLogic
    {
        static Random random = new Random(DateTime.Now.Second);
        public static Stopwatch stopwatch = new Stopwatch();
        public static int error_happened;
        public static List<Question> questions { get; set; }
        public static List<Player> players { get; set; }
        public static List<BoxModel> boxes { get; set; }
        public static int current_player { get; set; }
        public static GameMode game_mode { get; set; }
        public static List<Chapter> chapters { get; set; }
        public static int current_chapter { get; set; }
        public static int current_step { get; set; }
        public static int current_score;

        //Show what to show in the screen 
        //0:nothing is wrong 
        //1:error happened change turns
        //2:change of chapter show congratz
        //3:game finish next player
        //4:game over
        //5:show the error
        //6:pop quiz incoming
        //7:time limit reached
        //8:only one foot allowed
        public static int nextStep()
        {
            //check user position here if it is true, advance to next step if not, switch player
            //if the time trial is enabled, check if the player makes the move withing the time limit
            if (game_mode.timeTrial)
            {
                if (stopwatch.IsRunning)
                {
                    if (stopwatch.ElapsedMilliseconds > 5000)
                    {
                        players.ElementAt(current_player).last_chapter_trial_amount++;
                        current_player = getNextPlayer();
                        current_step = 0;
                        current_chapter = players.ElementAt(current_player).last_chapter_played;
                        error_happened = 0;
                        loadChanges();
                        current_score = 0;
                        stopwatch.Reset();
                        stopwatch.Stop();
                        SoundManager.Instance.playSound(0);
                        return 7;
                    }
                }
            }
            //If the error is detected 2 consequtive times, change turns
            if (error_happened == 2)
            {
                players.ElementAt(current_player).last_chapter_trial_amount++;
                current_player = getNextPlayer();
                current_step = 0;
                current_chapter = players.ElementAt(current_player).last_chapter_played;
                error_happened = 0;
                loadChanges();
                current_score = 0;
                stopwatch.Reset();
                stopwatch.Stop();
                SoundManager.Instance.playSound(0);
                return 1;
            }
            /* allowing only one foot is disabled, no chance to fix bugs
            if (getCurrentStep().current_2 == 0 && KinectHelper.foot_flag == 2)
            {
                //you need to stay on one foot dude!
                if (++error_happened > 1)
                {
                    players.ElementAt(current_player).last_chapter_trial_amount++;
                    current_player = getNextPlayer();
                    current_step = 0;
                    current_chapter = players.ElementAt(current_player).last_chapter_played;
                    error_happened = 0;
                    loadChanges();
                    current_score = 0;
                    stopwatch.Reset();
                    stopwatch.Stop();
                    SoundManager.Instance.playSound(0);
                    return 8;
                }
            }*/
            bool flag = KinectHelper.testBox(getCurrentStep().current_1, getCurrentStep().current_2);
            //not first not last still on the box
            if (current_step != chapters.ElementAt(current_chapter).steps.Count - 1 && current_step != 0 && flag)
            {
                return 0;//no change
            }//last succsesful box
            else if (flag && current_step == chapters.ElementAt(current_chapter).steps.Count - 1)
            {
                //final box
            }//next box reached
            else if (KinectHelper.testBox(getCurrentStep().next_1, getCurrentStep().next_2))
            {
                //next box reached
                current_score += (5000 - (int)stopwatch.ElapsedMilliseconds) / 200;
                if (game_mode.timeTrial)
                {
                    if (stopwatch.IsRunning)
                    {
                        stopwatch.Restart();
                    }
                    else { stopwatch.Start(); }
                }
            }
            else if (current_step > 0)
            {
                //if (random.Next(0, 9) == 0) //give arguements to this method 
                //error occured switch player
                error_happened++;
                loadChanges();
                return 5;
            }
            else
            {
                return 0;//no change
            }
            error_happened = 0;
            current_step++;
            if (current_step < chapters.ElementAt(current_chapter).steps.Count)//last step?
            {
                //nothing is wrong
                int t_a = getCurrentPlayer().last_chapter_trial_amount;
                current_score += 100 - 10 * ((t_a > 5) ? 5 : t_a);
                loadChanges();
                if (game_mode.popQuiz && (random.Next(0, 9) == 5)) //ten percent of asking a pop quiz
                {
                    stopwatch.Reset();
                    stopwatch.Stop();
                    return 6;
                }
                return 0;
            }
            else
            {
                //show next chapter instructions and bravooo
                current_step = 0;
                current_chapter++;
                if (current_chapter < chapters.Count)//last chapter?
                {
                    //expect ready button 
                    getCurrentPlayer().last_chapter_played = current_chapter;
                    getCurrentPlayer().last_chapter_trial_amount = 0;
                    getCurrentPlayer().score += current_score;
                    current_score = 0;
                    loadChanges();
                    stopwatch.Reset();
                    stopwatch.Stop();
                    SoundManager.Instance.playSound(1);
                    return 2;
                }
                else
                {
                    //chapters are finished
                    getCurrentPlayer().game_finished = true;
                    getCurrentPlayer().score += current_score;
                    current_score = 0;
                    current_player = getNextPlayer();
                    stopwatch.Reset();
                    stopwatch.Stop();
                    if (current_player == -1)
                    {
                        //everyone is finished
                        SoundManager.Instance.playSound(2);
                        return 4;
                    }
                    current_step = 0;
                    current_chapter = getCurrentPlayer().last_chapter_played;
                    loadChanges();
                    SoundManager.Instance.playSound(2);
                    return 3;
                }
            }



        }

        internal static Question getRandomQuestion()
        {
            return questions.ElementAt(random.Next(0, questions.Count - 1));
        }

        public static Step getCurrentStep()
        {
            return chapters.ElementAt(current_chapter).steps.ElementAt(current_step);
        }
        //reflects the steps changes on the carpet and on the screen
        public static void loadChanges()
        {
            if (error_happened == 2)
            {
                Step theStep = chapters.ElementAt(current_chapter).steps.ElementAt(current_step);
                Step firstStep = chapters.ElementAt(current_chapter).steps.ElementAt(0);
                CarpetConnector.sendData(firstStep.trigger_no);
                CarpetConnector.sendData(theStep.error_trigger_no);
                setAllBoxesToWhite();
                if (theStep.start > 0) boxes.ElementAt(theStep.start - 1).color = new SolidColorBrush(Colors.Purple);
                if (theStep.finish > 0) boxes.ElementAt(theStep.finish - 1).color = new SolidColorBrush(Colors.Orange);
                if (theStep.next_1 > 0) boxes.ElementAt(theStep.next_1 - 1).color = new SolidColorBrush(Colors.Red);
                if (theStep.next_2 > 0) boxes.ElementAt(theStep.next_2 - 1).color = new SolidColorBrush(Colors.Red);
            }
            else
            {
                Step theStep = chapters.ElementAt(current_chapter).steps.ElementAt(current_step);
                CarpetConnector.sendData(theStep.trigger_no);
                setAllBoxesToWhite();
                if (theStep.next_1 > 0) boxes.ElementAt(theStep.next_1 - 1).color = new SolidColorBrush(Colors.Yellow);
                if (theStep.next_2 > 0) boxes.ElementAt(theStep.next_2 - 1).color = new SolidColorBrush(Colors.Yellow);
                if (theStep.current_1 > 0) boxes.ElementAt(theStep.current_1 - 1).color = new SolidColorBrush(Colors.Green);
                if (theStep.current_2 > 0) boxes.ElementAt(theStep.current_2 - 1).color = new SolidColorBrush(Colors.Green);
                if (theStep.start > 0) boxes.ElementAt(theStep.start - 1).color = new SolidColorBrush(Colors.Purple);
                if (theStep.finish > 0) boxes.ElementAt(theStep.finish - 1).color = new SolidColorBrush(Colors.Orange);
            }
        }

        private static void setAllBoxesToWhite()
        {
            foreach (BoxModel bm in boxes)
            {
                bm.color = new SolidColorBrush(Colors.White);
            }
        }
        //returns -1 if everyone finishes
        private static int getNextPlayer()
        {
            for (int i = 0; i < players.Count; i++)
            {
                if (players.ElementAt((i + current_player + 1) % players.Count).game_finished) continue;
                else
                {
                    players.ElementAt(current_player).current_user = false;
                    players.ElementAt((i + current_player + 1) % players.Count).current_user = true;
                    return (i + current_player + 1) % players.Count;
                }
            }
            return -1;
        }

        //args: step chapter player
        internal static void configureBoxes(int s, int c, int p)
        {
            current_chapter = c;
            current_step = s;
            current_player = p;
            loadChanges();
        }

        public static Player getCurrentPlayer()
        {
            return players.ElementAt(current_player);
        }
        //read questions from the related xml files
        public static void loadQuestions()
        {
            /* Depricated code for creating a sample xml file for questions
            List<Question> list = new List<Question>()
            {
                new Question() { image_path="sample_question.png", question_text="Am I a question?", answer="Yes" }
            };
            using (FileStream outFile = File.Create("3-5.xml"))
            {
                XmlSerializer formatter = new XmlSerializer(typeof(List<Question>));
                formatter.Serialize(outFile, list);
                outFile.Close();
            }
            */
            string[] file_names = new string[] { "5-7.xml", "8-10.xml", "11+.xml" };
            string file_name = file_names[game_mode.age_range_code];
            using (FileStream aFile = new FileStream(file_name, FileMode.Open))
            {
                XmlSerializer formatter = new XmlSerializer(typeof(List<Question>));
                byte[] buffer = new byte[aFile.Length];
                aFile.Read(buffer, 0, (int)aFile.Length);
                MemoryStream stream = new MemoryStream(buffer);
                questions = (List<Question>)formatter.Deserialize(stream);
                aFile.Close();
            }
        }
    }
}
