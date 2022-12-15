using BANK;
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

namespace BANKGUI.Views.GUI.Users
{
    /// <summary>
    /// Logika interakcji dla klasy ChangePassword.xaml
    /// </summary>
    public partial class ChangePassword : Window
    {
        User user;
        public ChangePassword(User user)
        {
            InitializeComponent();
            this.user = user;  
        }

        private void submit_Click(object sender, RoutedEventArgs e)
        {
            if (passwordtextBox.Password == repasswordtextBox.Password)
            {
                var passwordHasher = new PasswordHasher<String>();
                string Password, RePassword;

                var hashed = passwordHasher.HashPassword(null,passwordtextBox.Password);
                Menu.Db.ChangePassword(user, hashed);
                MessageBox.Show("Hasło zostało zmienione", "OK", MessageBoxButton.OK);
                MainWindow.thisWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Hasła nie są takie same", "Coś poszlo nie tak", MessageBoxButton.OK);
            }
            
           
        }
    }
}
