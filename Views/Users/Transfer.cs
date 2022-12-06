using BANK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANK.Views.Users
{
    internal class Transfer
    {
        decimal amount;
        public Account source,dest;
        public Transfer(Account account)
        {
            source = account;
        }
        public void ShowMenu()
        {
            string NrDestination, title;
            if (source != null)
            {
                Menu.ShowCenter("Nr konta odbiorcy");
                NrDestination = Console.ReadLine();
                NrDestination = NrDestination.Trim();

                Menu.ShowCenter("Tytuł przelewu");
                title = Console.ReadLine();
                while (true)
                {
                    Menu.ShowCenter("Podaj Kwote");
                    Decimal.TryParse(Console.ReadLine(), out amount );
                    if (amount < 0)
                    {
                        Menu.ShowCenter("Kwota jest mniejsza od 0");
                        continue;
                    }
                    if (amount > source.Balance)
                    {
                        Menu.ShowCenter("Niewystarczające srodki na koncie");
                        continue;
                    }
                    else break;
                }

                foreach (var a in Menu.Db.GetAccounts())
                {
                    if (NrDestination == a.AccountNr)
                    {
                        dest = a;
                    }
                }
                if (dest == null)
                {
                    Menu.ShowCenter("Przelew nie został zrealizowny");
                    Console.ReadKey();
                }
                else
                {
                    Menu.Db.Transfering(source, dest, amount, title);
                    var Transact = new Transaction(title, source.AccountNr, dest.AccountNr, amount);
                    Transact.SaveTransaction();
                }
            }
        }
       
    }
}
