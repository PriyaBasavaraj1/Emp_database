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

namespace Emp_database
{
    /// <summary>
    /// Interaction logic for Launcher.xaml
    /// </summary>
    public partial class LauncherWindow : Window
    {
        public LauncherWindow()
        {
            InitializeComponent();
            this.DataContext = new LauncherWindowViewModel();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            //DialogResult = true;
        }
    }
}