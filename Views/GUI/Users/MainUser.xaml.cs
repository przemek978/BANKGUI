using BANK.Controllers;
using BANK.Models;
using BANK.Views;
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
    /// Logika interakcji dla klasy MainUser.xaml
    /// </summary>
    public partial class MainUser : Window
    {
        User user;
        List<Account> accounts;
        public List<Account> UserAccounts { get; set; }
        public List<Transaction> Transacts { get; set; }
        public Account SelectedAccount { get; set; }
        public Transaction SelectedTransfer { get; set; }
        public MainUser(User user)
        {
            InitializeComponent();
            this.user = user;
            accounts = Menu.Db.GetAccounts();
            UserAccounts = new List<Account>();
            Transacts = new List<Transaction>();    
            foreach (Account account in accounts)
            {
                if (user.Id == account.UserId)
                {
                    UserAccounts.Add(account);
                }
            }
            DataContext = this;
        }
        public void Refresh()
        {
            //Users.Clear();
            accounts = Menu.Db.GetAccounts();
            UserAccounts.Clear();
            foreach (Account account in accounts)
            {
                if (user.Id == account.UserId)
                {
                    UserAccounts.Add(account);
                }
            }
            var transacts = Menu.Db.GetTransactions();
            Transacts.Clear();
            foreach (var t in transacts)
            {
                if (t.sourceaccountnr == SelectedAccount.AccountNr)
                {
                    Transacts.Add(t);
                }
            }
            transactionhistoryListbox.ItemsSource = Transacts;
            transactionhistoryListbox.Items.Refresh();
            accountsListbox.ItemsSource =UserAccounts;
            accountsListbox.Items.Refresh();
            DataContext = this;
        }
        public void SelectAccount(object sender, SelectionChangedEventArgs e)
        {
            var transacts = Menu.Db.GetTransactions();
            Transacts.Clear();  
            foreach(var t in transacts)
            {
                if (t.sourceaccountnr == SelectedAccount.AccountNr)
                {
                    Transacts.Add(t);
                }
            }
            transactionhistoryListbox.Items.Refresh();
            DataContext = this;

        }
        public void SelectTransfer(object sender, SelectionChangedEventArgs e)
        {
            DetailsTextBlock.Text = SelectedTransfer.ToStringExt();
        }
        private void transferButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedAccount != null)
            {
                this.Hide();
                var transfer = new Transfer(SelectedAccount);
                transfer.Show();
            }
            else
            {
                MessageBox.Show("Wybierz konto", "Error", MessageBoxButton.OK);
            }
            MainWindow.thisWindow = this;
        }

        private void editUserButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            var add = new AddEditUser(user);
            add.Show();
            MainWindow.thisWindow = this;
        }

        private void passwordChangeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            var changepass = new ChangePassword(user);
            changepass.Show();
            MainWindow.thisWindow = this;
        }

        private void logout_Click(object sender, RoutedEventArgs e)
        {
            var Main = new MainController(MainWindow.wybor);
            this.Close();
        }
    }
}
