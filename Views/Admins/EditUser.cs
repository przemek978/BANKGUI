using BANK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANK.Views.Users
{
    internal class EditUser
    {
        private List<String> Options = new List<String>();
        public int Selected { get; set; }
        public EditUser(User u)
        {
            Options.Add("1. Edycja nazwy użytkownika");
            Options.Add("2. Zmiana hasła");
            Options.Add("3. Edycja imienia i nazwiska");
            Options.Add("4. Usuń konto");
            Options.Add("5. Powrót");

            Menu.ShowMenu(Options,Menu.ConvertStringOnList("Edycja użytkownika"));
            Selected=Menu.Selected;
        }
        
    }
}
