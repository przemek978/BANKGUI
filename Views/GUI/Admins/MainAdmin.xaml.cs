using BANK.Controllers;
using BANK.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
        public List<User> Users { get; set; }
        public List<Account> UserAccounts { get; set; }
        List<Account> accounts;
        public User SelectedUser { get; set; }
        public Account SelectedAccount { get; set; }

        public MainAdmin(User user)
        {
            InitializeComponent();
            this.user = user;
            Users = Menu.Db.GetUsers();
            accounts = Menu.Db.GetAccounts();
            UserAccounts = new List<Account>();
            //WindowState = WindowState.Maximized;    
            DataContext = this;
        }
        public void RefreshAccounts(object sender, SelectionChangedEventArgs e)
        {
            if (SelectedUser != null)
            {
                DetailsTextBlock.Text = SelectedUser.ToStringExt();
                UserAccounts.Clear();
                foreach (Account account in accounts)
                {
                    if (SelectedUser.Id == account.UserId)
                    {
                        UserAccounts.Add(account);
                    }
                }
                accountsListbox.Items.Refresh();
                DataContext = this;
            }
            else
            {
                DetailsTextBlock.Text = "";
            }
        }
        public void SelectAccount(object sender, SelectionChangedEventArgs e)
        {
            if (SelectedAccount != null)
            {
                DetailsTextBlock.Text = SelectedAccount.ToStringExt();
            }
            else
            {
                if (SelectedUser != null)
                {
                    DetailsTextBlock.Text = SelectedUser.ToStringExt();
                }
                else
                {
                    DetailsTextBlock.Text = "";
                }
            }
        }
        public void Refresh()
        {
            //Users.Clear();
            Users = Menu.Db.GetUsers();
            accounts = Menu.Db.GetAccounts();
            usersListbox.ItemsSource = Users;
            UserAccounts.Clear();
            if (SelectedUser != null)
            {
                foreach (Account account in accounts)
                {
                    if (SelectedUser.Id == account.UserId)
                    {
                        UserAccounts.Add(account);
                    }
                }
            }
            accountsListbox.ItemsSource = UserAccounts;
            accountsListbox.Items.Refresh();
            usersListbox.Items.Refresh();
            DataContext = this;
        }
        private void addUser_Click(object sender, RoutedEventArgs e)
        {
            //WindowState = WindowState.Minimized;
            this.Hide();
            var add = new AddEditUser();
            add.Show();
            MainWindow.thisWindow = this;
        }

        private void editUser_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            var add = new AddEditUser(SelectedUser);
            add.Show();
            MainWindow.thisWindow = this;
        }

        private void deleteUser_Click(object sender, RoutedEventArgs e)
        {
            Menu.Db.DeleteUser(SelectedUser);
            this.Refresh();
        }

        private void addAccount_Click(object sender, RoutedEventArgs e)
        {
            // Menu.Db.CreateAccount(SelectedAccount);
            if (SelectedUser.Id!= null)
            {
                Random rnd = new Random();
                string AccountNr;
                while (true)
                {
                    AccountNr = "78";
                    for (int i = 0; i < 24; i++)
                    {
                        if (i % 4 == 0)
                        {
                            AccountNr += " ";
                        }
                        AccountNr += Convert.ToString(rnd.Next() % 10);
                    }
                    foreach (var ac in Menu.Db.accounts.ToList())
                    {
                        if (String.Compare(ac.AccountNr, AccountNr) == 0)
                        {
                            continue;
                        }
                    }
                    break;
                }

                var Account = new Account(AccountNr, SelectedUser.Id);
                Menu.Db.CreateAccount(Account);
            }
            this.Refresh();
        }

        private void deleteAccount_Click(object sender, RoutedEventArgs e)
        {
            Menu.Db.DeleteAccount(SelectedAccount);
            this.Refresh();
        }

        private void passwordResetButton_Click(object sender, RoutedEventArgs e)
        {
            Menu.Db.ResetPassword(SelectedUser);
            this.Refresh();
            MessageBox.Show("Hasło zostało zresetowane na PESEL", "OK", MessageBoxButton.OK);
        }

        private void logout_Click(object sender, RoutedEventArgs e)
        {
            var Main = new MainController(MainWindow.wybor);
            this.Close();
        }
    }
}
