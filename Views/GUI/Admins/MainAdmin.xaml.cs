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

namespace BANKGUI.Views.GUI.Admins
{
    /// <summary>
    /// Logika interakcji dla klasy MainAdmin.xaml
    /// </summary>
    public partial class MainAdmin : Window
    {
        User user;
        public MainAdmin(User user)
        {
            InitializeComponent();
            this.user = user;
        }
    }
}
