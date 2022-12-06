using BANK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANK.Views
{
    internal class ListTransactions
    {
        private List<String> Options = new List<String>();
        public int Selected { get; set; }
        public List<Transaction> transacts { get; set; }
        public ListTransactions()
        {
            transacts = Menu.Db.GetTransactions();
        }
        public void Show(User user)
        {
            Console.Clear();
            List<Account> myaccounts = new List<Account>();
            foreach (var a in Menu.Db.GetAccounts())
            {
                if (a.UserId == user.Id)
                    myaccounts.Add(a);
            }
            foreach (var t in transacts)
            {
                foreach (var a in myaccounts)
                {
                    if (a.AccountNr == t.sourceaccountnr || a.AccountNr == t.destinationaccountnr)
                    {
                        Menu.ShowCenter(t.sourceaccountnr + " --> " + t.destinationaccountnr + " Saldo " + t.Amount + " zł " + t.Title);
                    }

                }
            }
            Console.WriteLine();
            Menu.ShowCenter("Nacisnij dowolny klawisz aby powrócic");
            Console.ReadKey();
            Console.Clear();
        }
        public void Show(Account account)
        {
            if (account != null)
            {
                Console.Clear();

                foreach (var t in transacts)
                {
                    if (account.AccountNr == t.sourceaccountnr || account.AccountNr == t.destinationaccountnr)
                    {
                        Menu.ShowCenter(t.sourceaccountnr + " --> " + t.destinationaccountnr + " Saldo " + t.Amount + " zł " + t.Title);
                    }
                }
                Console.WriteLine();
                Menu.ShowCenter("Nacisnij dowolny klawisz aby powrócic");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
