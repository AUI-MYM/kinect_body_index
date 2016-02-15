using MYMGames.Hopscotch.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MYMGames.Hopscotch.Helpers
{
    //responsible from maintaining the state a navigation through multiple windows
    public class WindowManager
    {
        private static WindowManager instance;
        private Stack<Window> pageStack;

        private WindowManager() { }

        public static WindowManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new WindowManager();
                    instance.pageStack = new Stack<Window>();
                }
                return instance;
            }
        }

        public static bool goBack()
        {
            Window theWindow = Instance.pageStack.Pop();
            if (theWindow == null)
                return false;
            if (theWindow is HomeWindow)
            {
                theWindow.Hide();
                theWindow = new HomeWindow();
            }
            Window oldWindow = Application.Current.MainWindow;
            Application.Current.MainWindow = theWindow;
            theWindow.Show();
           
            //System.Threading.Thread.Sleep(200); //200 ms sleep
            if (!(oldWindow is HomeWindow))
                oldWindow.Close();
            return true;
        }

        public static bool goToWindow(Window nextWindow)
        {
            Window oldWindow = Application.Current.MainWindow;
            Instance.pageStack.Push(oldWindow);
            Application.Current.MainWindow = nextWindow;
            nextWindow.Show();
            //System.Threading.Thread.Sleep(200); //200 ms sleep
            oldWindow.Hide();
            return true;
        }
    }
}
