using BANK.Controllers;
using BANK.Models;
using BANK.Views.Admins;
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
using Menu = BANK.Models.Menu;

namespace BANKGUI.Views.GUI
{
    /// <summary>
    /// Logika interakcji dla klasy AddEditUser.xaml
    /// </summary>
    public partial class AddEditUser : Window
    {
        string password, repassword;
        int typeID;
        int id;
        public User user;
        public bool IsEdit = false;
        public AddEditUser(User u = null)
        {
            InitializeComponent();
            //WindowState = WindowState.Normal;
            if (MainWindow.typeLogin == 1)
            {
                TypeUserComboBox.Visibility = Visibility.Visible;
            }
            else
            {
                TypeUserComboBox.Visibility = Visibility.Collapsed;
                typeID = 2;
            }
            if (u != null)
            {
                typeID = u.typeID;
                IsEdit = true;
                id = u.Id;
                user = u;
                passwordfieldstackpanel.Visibility = Visibility.Collapsed;
                usernametextBox.Text = user.Username;
                usernametextBox.IsEnabled = false;
                nametextBox.Text = user.Name;
                surnametextBox.Text = user.SurName;
                peseltextBox.Text = user.Pesel;
                password = user.Password;
                repassword = user.Password;
                this.Height = 360;

            }
            else
            {
                passwordfieldstackpanel.Visibility = Visibility.Visible;
                this.Height = 480;
            }
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow.thisWindow.Show();
        }

        private void submit_Click(object sender, RoutedEventArgs e)
        {
            if (passwordtextBox.Password == repasswordtextBox.Password)
            {
                if (TypeUserComboBox.Text == "Admin" && MainWindow.typeLogin == 1)
                {
                    typeID = 1;
                }
                else if (TypeUserComboBox.Text == "User")
                {
                    typeID = 2;
                }
                user = new User(0, usernametextBox.Text, nametextBox.Text, surnametextBox.Text, peseltextBox.Text, passwordtextBox.Password, typeID);
                if (IsEdit)
                {
                    user.Id = id;
                    user.Password = password;
                    var edit = new EditController(user, MainWindow.typeLogin, MainWindow.wybor);
                }
                else
                {
                    Menu.Db.Register(user);
                }
                this.Close();
                if (MainWindow.typeLogin == 1)
                {
                    ((BANKGUI.Views.GUI.Admins.MainAdmin)(MainWindow.thisWindow)).Refresh();
                }
                else ((BANKGUI.Views.GUI.Users.MainUser)(MainWindow.thisWindow)).Refresh();
                MainWindow.thisWindow.Show();
            }

            else
            {

            }

        }
    }
}
