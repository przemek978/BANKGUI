using BANK.Controllers;
using BANK.Models;
using Microsoft.AspNetCore.Identity;
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

namespace BANKGUI
{
    /// <summary>
    /// Logika interakcji dla klasy Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        User user=new User();
        public Login()
        {
            InitializeComponent();
        }

        private void Login_submit(object sender, RoutedEventArgs e)
        {

            var passwordHasher = new PasswordHasher<String>();
            Menu.Db = new DB();
            bool IsLoged = false;
            foreach (var us in Menu.Db.GetUsers())
            {
                if (us.Username == usernameBox.Text)
                {
                    if (passwordHasher.VerifyHashedPassword(null, us.Password, passwordBox.Password) == PasswordVerificationResult.Success)
                    {
                        user = us;
                        IsLoged = true;
                        break;
                    }
                }

            }
            if (TypeUserComboBox.Text == "Admin")
            {
                MainWindow.typeLogin = 1;
            }
            else
            {
                MainWindow.typeLogin = 2;

            }
            if (IsLoged == true)
            {
                if ((MainWindow.typeLogin == 1 && user.typeID == 1) || MainWindow.typeLogin == 2)
                {
                    var Main = new UserMenuController(user, MainWindow.typeLogin, MainWindow.wybor);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Nie posiadasz uprawnień administratora","Coś poszlo nie tak", MessageBoxButton.OK);
                }
            }
            else
            {
                MessageBox.Show("Nieprawidłowa nazwa uzytkownika lub hasło","Coś poszlo nie tak", MessageBoxButton.OK);
            }
        }
    }
}
