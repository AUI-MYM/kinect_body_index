using Microsoft.Kinect;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace MYMGames.Hopscotch.Helpers
{
    //this class has the necessary calculations to convert kinect coordinates to the virtual coordinate system of the boxes
    //it checks  wheter the feet of the player are inside the box or not.
    class KinectHelper
    {
        public static Stopwatch stopwatch = new Stopwatch();

        /// <summary>
        /// Array for the bodies
        /// </summary>
        private static Body[] bodies = null;
        public static double reference_point_x;
        public static double reference_point_y;
        //these are x and y coefficients to convert kinect coordinate to the box coordinate
        public static int[] x_coef = new int[] { 9, 1, 7, 5, 3, 7, 5, 3, 7, 5, 3, 9, 1 };
        public static int[] y_coef = new int[] { 9, 9, 7, 7, 7, 5, 5, 5, 3, 3, 3, 1, 1 };

        public static string DistanceText { get; private set; }

        public static int foot_flag { get; set; } //0: right on air 1:left on air 2:both down

        public static float differenceBetweenFeet { get; set; }

        public static float posX_left { get; set; }

        public static float posY_left { get; set; }

        public static float posX { get; set; }

        public static float posY { get; set; }

        public static float posX_right { get; set; }

        public static float posY_right { get; set; }

        //everytime a frame is recivevd this event is triggered
        public static void Reader_FrameArrived(object sender, BodyFrameArrivedEventArgs e)
        {
            bool canRun = false;
            if (!stopwatch.IsRunning)
            {
                stopwatch.Start();
                canRun = true;
            }
            else
            {
                canRun = (stopwatch.ElapsedMilliseconds >= 100);
                if (canRun)
                {
                    stopwatch.Reset();
                }


            }
            if (canRun)
            {
                bool dataReceived = false;

                using (BodyFrame bodyFrame = e.FrameReference.AcquireFrame())
                {
                    if (bodyFrame != null)
                    {
                        if (bodies == null)
                        {
                            bodies = new Body[bodyFrame.BodyCount];
                        }

                        // The first time GetAndRefreshBodyData is called, Kinect will allocate each Body in the array.
                        // As long as those body objects are not disposed and not set to null in the array,
                        // those body objects will be re-used.
                        bodyFrame.GetAndRefreshBodyData(bodies);
                        dataReceived = true;
                    }
                }

                if (dataReceived)
                {
                    foreach (Body body in bodies)
                    {
                        if (body.IsTracked)
                        {
                            IReadOnlyDictionary<JointType, Joint> joints = body.Joints;

                            // convert the joint points to depth (display) space
                            Dictionary<JointType, Point> jointPoints = new Dictionary<JointType, Point>();
                            float left_foot_y = 0;
                            float right_foot_y = 0;
                            float left_foot_x = 0;
                            float right_foot_x = 0;
                            float left_foot_z = 0;
                            float right_foot_z = 0;


                            foreach (JointType jointType in joints.Keys)
                            {
                                // sometimes the depth(Z) of an inferred joint may show as negative
                                // clamp down to 0.1f to prevent coordinatemapper from returning (-Infinity, -Infinity)
                                CameraSpacePoint position = joints[jointType].Position;
                                if (position.Z < 0)
                                {
                                    position.Z = 0.1f;
                                }
                                if (jointType == JointType.FootLeft)
                                {
                                    left_foot_x = position.X;
                                    left_foot_y = position.Y;
                                    left_foot_z = position.Z;
                                }

                                if (jointType == JointType.FootRight)
                                {
                                    right_foot_x = position.X;
                                    right_foot_y = position.Y;
                                    right_foot_z = position.Z;
                                }


                            }
                            differenceBetweenFeet = Math.Abs(right_foot_y - left_foot_y);
                            /* old school position calculation
                            posX = (right_foot_x + left_foot_x) / 2.0f;
                            posY = (right_foot_z + left_foot_z) / 2.0f;
                            */
                            posX_left = left_foot_x;
                            posY_left = left_foot_z;
                            posX_right = right_foot_x;
                            posY_right = right_foot_z;
                            //the foot flag indicates which foot is up in the air 
                            if (right_foot_y - left_foot_y > 0.12)
                            {
                                foot_flag = 0;
                            }
                            else if (left_foot_y - right_foot_y > 0.12)
                            {
                                foot_flag = 1;
                            }
                            else foot_flag = 2;
                        }
                    }

                }
            }

        }
        //this method tests if the user is in at least one of the boxes,checks the position of lower foot
        public static bool testBox(int box1, int box2)
        {
            double x_left = posX_left * 250 + reference_point_x / 2 - 25;
            double y_left = (posY_left - 1.0) * 250 - 25;
            double x_right = posX_right * 250 + reference_point_x / 2 - 25;
            double y_right = (posY_right - 1.0) * 250 - 25;
            if (foot_flag == 0)
            {
                return textBox_(box1, x_left, y_left) && textBox_(-1, x_right, y_right);
            }
            else if (foot_flag == 1)
            {
                return textBox_(box1, x_right, y_right) && textBox_(box2, x_right, y_right);
            }
            else
            {
                return textBox_(box1, x_left, y_left) && textBox_(box2, x_right, y_right);
            }
        }

        private static bool textBox_(int box1, double x, double y)
        {
            if (box1 < 1) return true;
            x = x - (reference_point_x - 520) / 2;
            y = y - (reference_point_y - 520) / 2;
            double center_x = 52 * x_coef[box1 - 1];
            double center_y = 52 * y_coef[box1 - 1];
            double diff_x = Math.Abs(center_x - x);
            double diff_y = Math.Abs(center_y - y);
            return diff_x < 57.5 && diff_y < 57.5;
        }
    }
}

