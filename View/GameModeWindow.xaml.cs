using Microsoft.Kinect;
using Microsoft.Kinect.Wpf.Controls;
using MYMGames.Hopscotch.Helpers;
using MYMGames.Hopscotch.Model;
using MYMGames.Hopscotch.ViewModel;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace MYMGames.Hopscotch.View
{
    /// <summary>
    /// Interaction logic for GameModeWindow.xaml
    /// </summary>
    public partial class GameModeWindow : Window
    {
        #region fields
        /// <summary>
        /// Reader for body frames
        /// </summary>
        private BodyFrameReader bodyFrameReader = null;
        private DispatcherTimer dispatcherTimer;
        public QuestionModel currentQuestion
        {
            get; set;
        }
        private int time_elapsed;
        private bool stall;
        private bool game_finished;
        #endregion

        public GameModeWindow()
        {
            InitializeComponent();
            KinectRegion.SetKinectRegion(this, kinectRegion);
            this.kinectRegion.KinectSensor = KinectSensor.GetDefault();
            this.bodyFrameReader = kinectRegion.KinectSensor.BodyFrameSource.OpenReader();
            box_items.ItemsSource = GameLogic.boxes;
            stall = false;
            game_finished = false;
            if (GameLogic.game_mode.popQuiz)
            {
                GameLogic.loadQuestions();
            }
            
        }

        /// <summary>
        /// Execute start up tasks
        /// </summary>
        /// <param name="sender">object sending the event</param>
        /// <param name="e">event arguments</param>
        private void GameModeWindow_Loaded(object sender, RoutedEventArgs e)
        {
            if (this.bodyFrameReader != null)
            {
                bodyFrameReader.FrameArrived += KinectHelper.Reader_FrameArrived;
            }
            dispatcherTimer = new System.Windows.Threading.DispatcherTimer(DispatcherPriority.Render);
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 200);
            time_elapsed = 0;
            KinectHelper.reference_point_x = referenceGrid.ActualWidth;
            KinectHelper.reference_point_y = referenceGrid.ActualHeight;
            dispatcherTimer.Start();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            Storyboard myStoryboard = (Storyboard)this.Resources["TestStoryboard"];
            TranslateTransform myTranslate = new TranslateTransform();
            //myTranslate.X = KinectHelper.posX * 270 + referenceGrid.ActualWidth/2 -25;
            //myTranslate.Y = (KinectHelper.posY - 1.6) * 270 -25;
            myTranslate.X = KinectHelper.posX_left * 250 + referenceGrid.ActualWidth / 2 - 25;
            myTranslate.Y = (KinectHelper.posY_left - 1.2) * 250 - 25;
            grid_left.RenderTransform = myTranslate;
            Storyboard.SetTarget(myStoryboard.Children.ElementAt(0) as DoubleAnimation, grid_left);
            Storyboard.SetTarget(myStoryboard.Children.ElementAt(1) as DoubleAnimation, grid_left);

            Storyboard myStoryboard2 = (Storyboard)this.Resources["TestStoryboard"];
            TranslateTransform myTranslate2 = new TranslateTransform();
            //myTranslate.X = KinectHelper.posX * 270 + referenceGrid.ActualWidth/2 -25;
            //myTranslate.Y = (KinectHelper.posY - 1.6) * 270 -25;
            myTranslate2.X = KinectHelper.posX_right * 250 + referenceGrid.ActualWidth / 2 - 25;
            myTranslate2.Y = (KinectHelper.posY_right - 1.2) * 250 - 25;
            grid_right.RenderTransform = myTranslate2;
            Storyboard.SetTarget(myStoryboard2.Children.ElementAt(0) as DoubleAnimation, grid_right);
            Storyboard.SetTarget(myStoryboard2.Children.ElementAt(1) as DoubleAnimation, grid_right);
            
            if (GameLogic.game_mode.timeTrial)
            {
                time_text.Text = "Time remaining: " + (5 - GameLogic.stopwatch.ElapsedMilliseconds / 1000);
            }
            score_text.Text = "Score: " + GameLogic.current_score;

            /*
            if (KinectHelper.foot_flag == 0)
            {
                //true means right foot above
                grid_left.Visibility = Visibility.Visible;
                grid_right.Visibility = Visibility.Hidden;
            }
            else if (KinectHelper.foot_flag == 1)
            {
                grid_left.Visibility = Visibility.Hidden;
                grid_right.Visibility = Visibility.Visible;
            }
            else
            {
                grid_left.Visibility = Visibility.Visible;
                grid_right.Visibility = Visibility.Visible;
            }*/

            /*
                Reference notes:
                    starting point distance 1.05m
                    camera height: 0.45m
            */
            //Game Logic
            //DistanceText.Text = "Flag: " + KinectHelper.foot_flag;
            //DistanceText.Text = "Time: " + GameLogic.stopwatch.ElapsedMilliseconds;
            
            if (!stall)
            {
                time_elapsed += 200;
                if (time_elapsed == 1000)
                {
                    time_elapsed = 0;

                    
                    
                    int status = GameLogic.nextStep();
                    string username = null;
                    if (GameLogic.current_player > -1)
                        username = GameLogic.getCurrentPlayer().name;
                    box_items.ItemsSource = GameLogic.boxes;
                    box_items.Items.Refresh();
                    players_icontrol.Items.Refresh();
                    switch (status)
                    {
                        //0:nothing is wrong 
                        //1:error happened change turns
                        //2:change of chapter show congratz
                        //3:game finish next player
                        //4:game over
                        //5:show the error
                        //6:pop quiz incoming
                        //7:time limit reached
                        //8:only one foot allowed
                        case 0:
                            break;
                        case 1:
                            show_message_wait_for_ready("Next Player: " + username);
                            break;
                        case 2:
                            show_message_wait_for_ready("Bravoo!! Tell me when you are ready");
                            break;
                        case 3:
                            show_message_wait_for_ready("Congratulations you finished all!! Your turn " + username + "!!");
                            break;
                        case 4:
                            game_finished = true;
                            show_message_wait_for_ready("The game ends...");
                            break;
                        case 5:
                            break;
                        case 6:
                            showQuestionAndWaitForTheAnswer();
                            break;
                        case 7:
                            show_message_wait_for_ready("Oohh Time has finished!! Your turn " + username + "!!");
                            break;
                        case 8:
                            show_message_wait_for_ready("You need to stand on one foot!! Your turn " + username + "!!");
                            break;
                    }
                }
            }

            
        }

        private void show_message_wait_for_ready(string message)
        {
            box_items.ItemsSource = GameLogic.boxes;
            box_items.Items.Refresh();
            referenceGrid.Visibility = Visibility.Hidden;
            Message_Grid.Visibility = Visibility.Visible;
            Message_Text.Text = message;
            stall = true;
            if (game_finished)
            {
                textBlock.Text = "Main Menu";
                if (dispatcherTimer.IsEnabled)
                {
                    dispatcherTimer.Stop();
                }
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            if (this.bodyFrameReader != null)
            {
                // BodyFrameReader is IDisposable
                this.bodyFrameReader.Dispose();
                this.bodyFrameReader = null;
            }
            if (game_finished)
            {
                foreach (Player p in GameLogic.players)
                {
                    ParseConnector.addScore(p.name, p.score);
                }
            }

        }

        private void Button_Click_Ready(object sender, RoutedEventArgs e)
        {
            if (game_finished)
            {
                WindowManager.goBack();
                return;
            }
            Message_Grid.Visibility = Visibility.Hidden;
            referenceGrid.Visibility = Visibility.Visible;
            stall = false;

        }
        private void showQuestionAndWaitForTheAnswer()
        {
            Question question = GameLogic.getRandomQuestion();
            bool theAnswer = question.answer.Equals("Yes");
            currentQuestion = new QuestionModel()
            {
                text = question.question_text,
                answer = theAnswer,
                image_path = question.image_path
            };
            question_panel.DataContext = currentQuestion;
            referenceGrid.Visibility = Visibility.Hidden;
            question_grid.Visibility = Visibility.Visible;
            stall = true;
        }

        private void Button_Click_Yes(object sender, RoutedEventArgs e)
        {
            GameLogic.error_happened = (true != currentQuestion.answer) ? 2 : 0;
            if (GameLogic.error_happened < 2)
            {
                GameLogic.current_score += 50;
                GameLogic.stopwatch.Start();
            }
            GameLogic.loadChanges();
            box_items.ItemsSource = GameLogic.boxes;
            box_items.Items.Refresh();
            players_icontrol.Items.Refresh();
            referenceGrid.Visibility = Visibility.Visible;
            question_grid.Visibility = Visibility.Hidden;
            stall = false;
        }
        private void Button_Click_No(object sender, RoutedEventArgs e)
        {
            GameLogic.error_happened = (false != currentQuestion.answer) ? 2 : 0;
            if (GameLogic.error_happened < 2)
            {
                GameLogic.current_score += 50;
                GameLogic.stopwatch.Start();
            }
            GameLogic.loadChanges();
            box_items.ItemsSource = GameLogic.boxes;
            box_items.Items.Refresh();
            players_icontrol.Items.Refresh();
            referenceGrid.Visibility = Visibility.Visible;
            question_grid.Visibility = Visibility.Hidden;
            stall = false;
        }
    }
}
