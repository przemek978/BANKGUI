using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANK.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string sourceaccountnr { get; set; } 
        public string destinationaccountnr { get; set; }
        public decimal Amount { get; set; } 
        public Transaction(string title, string sourceaccountnr, string destinationaccountnr, decimal amount)
        {
            Title = title;
            this.sourceaccountnr = sourceaccountnr;
            this.destinationaccountnr = destinationaccountnr;
            Amount = amount;
        }  
        public void SaveTransaction()
        {
            int newid;
            if (Menu.Db.transacts.Count == 0)
            {
                newid = 1;
            }
            else
            {
                newid = Menu.Db.transacts[Menu.Db.transacts.Count - 1].Id + 1;
            }
            this.Id = newid;
            Menu.Db.GetContext().transacts.Add(this);
            Menu.Db.GetContext().SaveChanges();
        }
        public override string ToString()
        {
            return Title + "\tKwota: " + Amount;
        }
        public string ToStringExt()
        {
            return Title + "\nZ: "+sourceaccountnr+"\nDo: "+destinationaccountnr+"\nKwota:" + Amount;
        }
    }

}
