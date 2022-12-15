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
using Menu = BANK.Models.Menu;

namespace BANKGUI.Views.GUI.Users
{
    /// <summary>
    /// Logika interakcji dla klasy Transfer.xaml
    /// </summary>
    public partial class Transfer : Window
    {
        Account Account { get; set; }
        public Transfer(Account account)
        {
            InitializeComponent();
            Account = account;
        }

        private void submitButton_Click(object sender, RoutedEventArgs e)
        {
            Menu.Db.Transfering(Account, Menu.Db.FindAccount(accountNrTextBox.Text.TrimEnd()), Convert.ToDecimal(amountTextBox.Text), titleTextBox.Text);
            var Transact = new Transaction(titleTextBox.Text, Account.AccountNr, accountNrTextBox.Text.TrimEnd(), Convert.ToDecimal(amountTextBox.Text));
            Transact.SaveTransaction();
            ((BANKGUI.Views.GUI.Users.MainUser)(MainWindow.thisWindow)).Refresh();
            MainWindow.thisWindow.Show();
            this.Close();  
        }
    }
}
