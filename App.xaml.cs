﻿//------------------------------------------------------------------------------
// <copyright file="App.xaml.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

namespace MYMGames.Hopscotch
{
    using System;
    using System.Windows;
    using Microsoft.Kinect.Wpf.Controls;
    /// <summary>
    /// Interaction logic for App
    /// </summary>
    public partial class App : Application
    {
        public KinectRegion KinectRegion { get; internal set; }
    }
}

