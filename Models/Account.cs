﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANK.Models
{
    internal class Account
    {
        [Key]
        public string AccountNr { get; set; }
        public decimal Balance { get; set; }
        public int UserId { get; set; }

        public Account(string accountNr, int userId, decimal balance=0)
        {
            AccountNr = accountNr;
            Balance = balance;
            UserId = userId;
        }

    }
}
