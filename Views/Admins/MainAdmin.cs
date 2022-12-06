using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BANK.Models;

namespace BANK.Views.Admins
{
    internal class MainAdmin:IView
    {
        private List<String> Options = new List<String>();
        private User User { get; set; }
        public int Selected { get; set; }
        public MainAdmin(User user)
        {
            User = user;
            Options.Add("1. Wyświetl użytkowników");
            Options.Add("2. Dodaj użytkownika");
            Options.Add("3. Załóż Konto");
            Options.Add("4. Zarządzaj użytkownikami");
            Options.Add("5. Wyloguj");
            Options.Add("6. Wyloguj i zamknij");
            Menu.ShowMenu(Options, Menu.ConvertStringOnList("Witaj " + User.Username), true);
            Selected = Menu.Selected;
        }
        
    }
}
