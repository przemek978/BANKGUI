using BANK.Models;
using BANK.Views.Admins;
using BANK.Views.Users;
using BANK.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANK.Controllers
{
    internal class EditController
    {
        public EditController(User user, int typelogin)
        {
            while (true)
            {
                if (typelogin == 1)
                {
                    var view = new Views.Admins.EditUser(user);
                    switch (view.Selected)
                    {
                        case 0:
                            user = Menu.Db.EditUsername(user);
                            break;
                        case 1:
                            Menu.Db.ResetPassword(user);
                            break;
                        case 2:
                            Menu.Db.EditNames(user);
                            break;
                        case 3:
                            Menu.Db.EditTypeID(user);
                            break;
                        case 4:
                            var listaccount = new ListAccounts();
                            listaccount.DelAccount(listaccount.ShowMenu(user, "Wybierz konto do usunięcia"), 1);
                            break;
                        case 5:
                            User du = new User();
                            foreach (var u in Menu.Db.GetUsers())
                            {
                                if (u.Id == user.Id && u.Username == user.Username)
                                {
                                    du = u;
                                }
                            }
                            Menu.Db.DeleteUser(du);
                            return;
                        case 6:
                            return;
                        default:
                            break;
                    }
                }
                else
                {

                    var view = new Views.Users.EditUser(user);
                    switch (view.Selected)
                    {
                        case 0:
                            user = Menu.Db.EditUsername(user);
                            break;
                        case 1:
                            Menu.Db.ChangePassword(user);
                            break;
                        case 2:
                            Menu.Db.EditNames(user);
                            break;
                        case 3:
                            var listaccount = new ListAccounts();
                            listaccount.DelAccount(listaccount.ShowMenu(user, "Wybierz konto do usunięcia"), 2);
                            break;
                        case 4:
                            return;
                        default:
                            break;
                    }
                }

            }

        }
    }
}
