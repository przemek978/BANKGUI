using BANK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANK.Views.Users
{
    internal class MainUser:IView
    {
        private List<String> Options = new List<String>();
        private User User { get; set; }
        public int Selected { get; set; }
        public MainUser(User user)
        {
            User = user;
            Options.Add("1. Wyświetl Konta i ich salda");
            Options.Add("2. Nowy przelew");
            Options.Add("3. Historia transakcji konta");
            Options.Add("4. Historia transakcji wszystkich kont");
            Options.Add("5. Zarządzaj kontem");
            Options.Add("6. Wyloguj");
            Options.Add("7. Wyloguj i zamknij");
            Menu.ShowMenu(Options, Menu.ConvertStringOnList("Witaj " + User.Username),true);
            Selected = Menu.Selected;
        }
    }
}
