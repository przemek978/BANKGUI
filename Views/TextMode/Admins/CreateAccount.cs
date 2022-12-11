using BANK.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BANK.Views.Admins
{
    internal class CreateAccount
    {
        private List<String> Options = new List<String>();
        private User User { get; set; }
        public int Selected { get; set; }
        public CreateAccount()
        {
            Console.Clear();
            foreach (var u in Menu.Db.GetUsers())
                Options.Add(u.Id + " " + u.Name + " " + u.SurName);
            Options.Add("Powrót");
            Menu.ShowMenu(Options, Menu.ConvertStringOnList("Wybierz użytkownika"));
            Selected = Menu.Selected;
            if (Selected< Menu.Db.GetUsers().Count)
            {
                Random rnd = new Random();
                string AccountNr;
                while (true)
                {
                    AccountNr = "78";
                    for (int i = 0; i < 24; i++)
                    {
                        if (i % 4 == 0)
                        {
                            AccountNr += " ";
                        }
                        AccountNr += Convert.ToString(rnd.Next() % 10);
                    }
                    foreach (var ac in Menu.Db.accounts.ToList())
                    {
                        if (String.Compare(ac.AccountNr, AccountNr) == 0)
                        {
                            continue;
                        }
                    }
                    break;
                }

                Console.Clear();

                var Account = new Account(AccountNr, Selected + 1);
                Menu.Db.CreateAccount(Account);
                Menu.ShowCenter("Pomyślnie utworzono nowe konto");
            }

        }
    }
}
