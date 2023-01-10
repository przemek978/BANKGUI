using BANK.Controllers;
using BANK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BANKGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static int wybor;    // 1 to textmode a 2 to gui
        public static int typeLogin;// 1 to admin a 2 to user
        public static User user;
        public static Window thisWindow;
        public MainWindow()
        {
            //var Main = new MainController();
            InitializeComponent();
            var win = new Index();
            this.Close();

            ShowHideConsole(0);

            win.Show();
        }
        public static void ShowHideConsole(int SW)
        {
            [DllImport("kernel32.dll")]
            static extern IntPtr GetConsoleWindow();

            [DllImport("user32.dll")]
            static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

            var handle = GetConsoleWindow();

            ShowWindow(handle, SW);// 0 ukrywa a 5 pokazuje
        }
        



    }
}
