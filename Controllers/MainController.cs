using BANK.Models;
using BANK.Views;
using BANK.Views.Admins;
using BANK.Views.Users;
using BANKGUI;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANK.Controllers
{
    internal class MainController
    {
        public MainController(int wybor)
        {

            if (wybor == 1)
            {
                while (true)
                {
                    MainWindow.ShowHideConsole(5);
                    var view = new ChangeTypeUser();
                    switch (view.Selected)
                    {
                        case 0:
                            var loginadmin = new LoginAdmin();
                            var admin = loginadmin.View();
                            var Mainadmin = new UserMenuController(admin, 1);
                            break;
                        case 1:
                            var loginuser = new LoginUser();
                            var user = loginuser.View();
                            var Mainuser = new UserMenuController(user, 2);
                            break;

                        case 2:
                            Environment.Exit(0);
                            break;
                        default:
                            break;
                    }
                }
            }
            else
            {
                var Login = new Login();
                Login.Show();
            }
            
        }
    }
}

