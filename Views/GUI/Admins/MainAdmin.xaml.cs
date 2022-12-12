using BANK.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Menu = BANK.Models.Menu;

namespace BANKGUI.Views.GUI.Admins
{
    /// <summary>
    /// Logika interakcji dla klasy MainAdmin.xaml
    /// </summary>
    public partial class MainAdmin : Window
    {
        User user;
        List<User> users { get; set; }
        //ObservableCollection<User> users { get; set; }
        List<Account> accounts;
        public MainAdmin(User user)
        {
            InitializeComponent();
            this.user = user;
            users=Menu.Db.GetUsers();
            //users=new ObservableCollection<User>(Menu.Db.GetUsers());
            this.usersListbox.ItemsSource = users;
            accounts =Menu.Db.GetAccounts();
            DataContext = this;
            foreach (var u in users)
            {

            }
        }
    }
}
