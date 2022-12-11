using BANK.Models;
using BANK.Views.Admins;
using BANK.Views.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANK.Views
{
    internal class ChangeTypeUser:IView
    {
        private List<String> Options = new List<String>();
        public int Selected { get; set; }
        public ChangeTypeUser()
        {
            Menu.ShowCenter("Wybierz typ użytkownika");
            Options.Add("1. Administrator");
            Options.Add("2. Klient");
            Options.Add("3. Wyjście");
            Menu.ShowMenu(Options, Menu.ConvertStringOnList("Wybierz użytkownika"),true);
            Selected = Menu.Selected;
        }
        
    }
}
