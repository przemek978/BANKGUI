using BANK.Views.Admins;
using BANK.Views.Users;
using BANK.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BANK.Models;

namespace BANK.Controllers
{
    internal class UserMenuController
    {
        public UserMenuController(User user, int typelogin, int wybor=1)
        {
            if (wybor == 1)
            {
                if (user != null)
                {
                    while (true)
                    {
                        if (typelogin == 1)
                        {
                            var view = new MainAdmin(user);
                            switch (view.Selected)
                            {
                                case 0:
                                    var list = new ListUsers();
                                    list.Show();
                                    break;
                                case 1:
                                    var newuser = new Register();
                                    break;
                                case 2:
                                    var newaccount = new CreateAccount();
                                    break;
                                case 3:
                                    var manage = new ListUsers();
                                    manage.ShowMenu();
                                    break;
                                case 4:
                                    return;
                                case 5:
                                    Environment.Exit(0);
                                    break;
                                default:
                                    break;
                            }
                        }
                        else
                        {
                            var view = new MainUser(user);
                            var accounts = new ListAccounts();
                            var transacts = new ListTransactions();
                            switch (view.Selected)
                            {
                                case 0:
                                    accounts.Show(user, "Twoje konta");
                                    break;
                                case 1:
                                    var sourceaccount = accounts.ShowMenu(user, "Wybierz konto do przelewu");
                                    var transfer = new Transfer(sourceaccount);
                                    transfer.ShowMenu();
                                    break;
                                case 2:
                                    var account = accounts.ShowMenu(user, "Wybierz konto do wyświetlenia historii operacji");
                                    transacts.Show(account);
                                    break;
                                case 3:
                                    transacts.Show(user);
                                    break;
                                case 4:
                                    var UserToEdit = new EditController(user, 2);
                                    break;
                                case 5:
                                    return;
                                case 6:
                                    Environment.Exit(0);
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                }
            }
            else
            {
                if (typelogin == 1)
                {
                    var MainAdmin = new BANKGUI.MainAdmin(user);
                    MainAdmin.Show();
                }
                else
                {

                }
            }
        }
    }
}
