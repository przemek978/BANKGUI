using BANK.Controllers;
using BANK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANK.Views
{
    internal class ListAccounts
    {
        private List<String> Options = new List<String>();
        public int Selected { get; set; }
        public List<Account> accounts { get; set; }
        public ListAccounts()
        {
            accounts= Menu.Db.GetAccounts(); 
        }
        public void Show(User u,string message)
        {
            Console.Clear();
            Menu.ShowCenter(message);
            foreach (var a in accounts)
            {
                if (u.Id == a.UserId)
                    Menu.ShowCenter(a.AccountNr + " " + a.Balance+" zł");
            }
            Console.WriteLine();
            Menu.ShowCenter("Nacisnij dowolny klawisz aby powrócic");
            Console.ReadKey();
            Console.Clear();
        }
        public Account ShowMenu(User u,string message)
        {
            List<Account> useraccounts =new List<Account>();
            foreach (var a in accounts)
            {
                if (u.Id == a.UserId)
                    useraccounts.Add(a);
            }
            foreach (var ua in useraccounts)
            {
                Options.Add(ua.AccountNr + " " + ua.Balance+ " zł");
            }
            Options.Add("Powrót");
            Menu.ShowMenu(Options, Menu.ConvertStringOnList(message));
            if (Menu.Selected == Options.Count - 1)
            {
                return null;
            }
            return useraccounts[Menu.Selected];
        }
        public void DelAccount(Account account,int type)
        {
            if (account != null)
            {
                if (type == 1)
                {
                    Menu.ShowCenter("Usuwasz poniższe konto wypłacając srodki klientowi");
                    Menu.ShowCenter(account.AccountNr + " " + account.Balance);
                    Console.ReadKey();
                    Menu.Db.DeleteAccount(account);
                }
                else
                {
                    Menu.ShowCenter("Czy napewno chcesz usunąć konto srodki uprzednio powinny byc przelane na inny rachunek");
                    Menu.ShowCenter(account.AccountNr + " " + account.Balance);
                    Console.ReadKey();
                    if (account.Balance == 0)
                    {
                        Menu.Db.DeleteAccount(account);
                    }
                }
            }
        }
    }
}
