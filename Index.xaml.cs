﻿using BANK.Controllers;
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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BANKGUI
{
    /// <summary>
    /// Logika interakcji dla klasy Index.xaml
    /// </summary>
    public partial class Index : Window
    {
        public Index()
        {
            InitializeComponent();
        }
        private void TextMode_Click(object sender, RoutedEventArgs e)
        {
            var Main = new MainController(1);
            this.Close();
        }

        private void GUI_Click(object sender, RoutedEventArgs e)
        {
            var Main = new MainController(2);
            this.Close();
        }
    }
}
