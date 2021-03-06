﻿using System;
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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Voicerecognition
{
    /// <summary>
    /// Interaction logic for YesNoShutDown.xaml
    /// </summary>
    public partial class YesNoShutDown : Window
    {
        public YesNoShutDown()
        {
            InitializeComponent();
        }

        private void yesBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            System.Diagnostics.Process.Start("shutdown", "/s /t 3");
        }

        private void noBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
