using BANK.Models;
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

namespace BANKGUI.Views.GUI.Users
{
    /// <summary>
    /// Logika interakcji dla klasy MainUser.xaml
    /// </summary>
    public partial class MainUser : Window
    {
        User user;
        public MainUser(User user)
        {
            InitializeComponent();
            this.user = user;
        }
    }
}
