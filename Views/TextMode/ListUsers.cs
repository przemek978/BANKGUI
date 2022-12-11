using BANK.Controllers;
using BANK.Models;
using BANK.Views.Admins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANK.Views
{
    internal class ListUsers
    {
        private List<String> Options = new List<String>();
        public int Selected { get; set; }
        public List<User> users { get; set; }
        public ListUsers()
        {
            users = Menu.Db.GetUsers();
        }
        public void Show()
        {
            Console.Clear();
            foreach (var u in users)
            {
                Menu.ShowCenter(u.Name + " " + u.SurName + " " + u.Pesel + " " + u.Username);
            }
            Console.WriteLine();
            Menu.ShowCenter("Nacisnij dowolny klawisz aby powrócic");
            Console.ReadKey();
            Console.Clear();
        }
        public void ShowMenu()
        {
            foreach (var u in users)
            {
                Options.Add(u.Name + " " + u.SurName+" "+ u.Pesel+ " "+ u.Username);
            }
            Options.Add("Powrót");
            Menu.ShowMenu(Options, Menu.ConvertStringOnList("Wybierz użytkownika do edycji danych"));
            if (Menu.Selected == Options.Count - 1)
            {
                return;
            }
            var UserToEdit = new EditController(users[Menu.Selected],1);
        }

    }
}
