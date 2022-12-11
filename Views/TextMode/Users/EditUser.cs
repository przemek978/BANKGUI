using BANK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANK.Views.Admins
{
    internal class EditUser
    {
        private List<String> Options = new List<String>();
        public int Selected { get; set; }
        public EditUser(User u)
        {
            Options.Add("1. Edycja nazwy użytkownika");
            Options.Add("2. Reset hasła");
            Options.Add("3. Edycja imienia i nazwiska");
            Options.Add("4. Zmiana uprawnień konta");
            Options.Add("5. Usuń konto");
            Options.Add("6. Zamknij wszystkie konta i usuń użytkownika");
            Options.Add("7. Powrót");
            List<String> list = new List<String>();
            list.Add("Edycja użytkownika");
            list.Add(u.Id + " " + u.Name + " " + u.SurName + " " + u.Pesel);
            Menu.ShowMenu(Options, list);
            Selected=Menu.Selected;
        }
        
    }
}
