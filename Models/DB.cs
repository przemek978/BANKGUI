using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace BANK.Models
{
    internal class DB
    {
        DbContextOptions<ModelContext> Options;
        public ModelContext modelContext;
        public List<User> users;
        public List<Account> accounts;
        public List<Transaction> transacts;
        public DB()
        {
            Options = new DbContextOptionsBuilder<ModelContext>()
                    .UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=./BankDB.mdf;Integrated Security=True").Options;

            modelContext = new ModelContext(Options);
            users = modelContext.users.ToList();
            accounts = modelContext.accounts.ToList();
            transacts = modelContext.transacts.ToList();
        }

        //User
        public void Register(User user)
        {
            int newid;
            if (users.Count == 0)
            {
                newid = 1;
            }
            else
            {
                newid = users[users.Count - 1].Id + 1;
            }
            var passwordHasher = new PasswordHasher<String>();
            user.Id = newid;
            var hashed = passwordHasher.HashPassword(null, user.Password);
            user.Password = hashed;
            modelContext.users.Add(user);
            modelContext.SaveChanges();
        }
        public void ResetPassword(User user)
        {
            Console.Clear();
            var passwordHasher = new PasswordHasher<String>();
            var hashed = passwordHasher.HashPassword(null, user.Pesel);

            users[FindUser(user)].Password = hashed;
            modelContext.SaveChanges();
        }
        public void ChangePassword(User user)
        {
            Console.Clear();
            var passwordHasher = new PasswordHasher<String>();
            string Password, RePassword;
            while (true)
            {
                Menu.ShowCenter("Podaj Haslo");
                Password = Console.ReadLine();
                Console.Clear();

                Menu.ShowCenter("Powtórz Haslo");
                RePassword = Console.ReadLine();
                Console.Clear();
                
                if (Password != RePassword)
                {
                    Menu.ShowCenter("Podane hasla nie sa takie same");
                    continue;
                }
                if (Password.Length < 5)
                {
                    Menu.ShowCenter("Haslo musi mieć conajmniej 5 znaków");
                    continue;
                }

                else break;

            }
            var hashed = passwordHasher.HashPassword(null,Password);

            users[FindUser(user)].Password = hashed;
            modelContext.SaveChanges();
        }
        public User EditUsername(User user)
        {
            Console.Clear();
            bool con = true;
            string UserName = "";
            while (con == true)
            {
                con = false;
                Menu.ShowCenter("Nazwa Użytkownika");
                UserName = Console.ReadLine();
                foreach (var u in users.ToList())
                {
                    if (string.Compare(u.Username, UserName) == 0)
                    {
                        Console.Clear();
                        Menu.ShowCenter("Nazwa użytkownika juz istnieje lub jest taka sama");
                        con = true;

                    }
                }
            }
            if (UserName != "")
            {
                users[FindUser(user)].Username = UserName;
                user.Username = UserName;
            }
            modelContext.SaveChanges();
            return user;

        }
        public User EditNames(User user)
        {
            Console.Clear();
            string Name = "", SurName = "";
            Menu.ShowCenter("Podaj Imie");
            Name = Console.ReadLine();

            Menu.ShowCenter("Podaj Nazwisko");
            SurName = Console.ReadLine();
            Console.Clear();

            if (Name != "")
            {
                users[FindUser(user)].Name = Name;
                user.Name = Name;
            }
            if (SurName != "")
            {
                users[FindUser(user)].SurName = SurName;
                user.SurName = SurName;
            }
            modelContext.SaveChanges();
            return user;
        }
        public void EditTypeID(User user)
        {
            Console.Clear();
            int id = 0;
            Menu.ShowCenter("Zmiana typu uprawnień użytkownika");
            Menu.ShowCenter("1.Administrator");
            Menu.ShowCenter("2.Klient");
            id = int.Parse(Console.ReadLine());
            if (id == 1 || id == 2)
            {
                users[FindUser(user)].typeID = id;
            }
            modelContext.SaveChanges();
        }
        public void DeleteUser(User user)
        {
            foreach (var ac in accounts)
            {
                if (ac.UserId == user.Id)
                {
                    DeleteAccount(ac);  
                }
            }
            modelContext.users.Remove(user);
            modelContext.SaveChanges();

        }
        //Account
        public void CreateAccount(Account account)
        {
            modelContext.accounts.Add(account);
            modelContext.SaveChanges();
        }
        public void DeleteAccount(Account account)
        {
            var index = FindAccount(account);
            var newaccount = accounts[index];
            DeleteTransacts(account);
            modelContext.accounts.Remove(newaccount);
            modelContext.SaveChanges();
        }
        ///Transact///////////////////////////////////////////////////////////////////////////////////////////////////////
        public void Transfering(Account source, Account destination, decimal amount, string title)
        {
            accounts[FindAccount(source)].Balance = source.Balance - amount;
            accounts[FindAccount(destination)].Balance = destination.Balance + amount;
            //CreateTransaction(source,destiantion,amount,title);
            modelContext.SaveChanges();
        }
        public void DeleteTransacts(Account account)
        {
            foreach (var t in modelContext.transacts.ToList())
            {
                if(t.sourceaccountnr==account.AccountNr || t.destinationaccountnr == account.AccountNr)
                {
                    modelContext.transacts.Remove(t);
                }
            }
            modelContext.SaveChanges();
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public int FindAccount(Account account)
        {
            int i = 0;
            foreach (var a in accounts)
            {
                if (a.AccountNr == account.AccountNr)
                {
                    return i;
                }
                i++;
            }
            return -1;
        }
        public int FindUser(User user)
        {
            int i = 0;
            foreach (var u in users)
            {
                if (u.Id == user.Id && u.Username == user.Username)
                {
                    return i;
                }
                i++;
            }
            return -1;
        }
        public List<User> GetUsers()
        {
            return users;
        }
        public List<Account> GetAccounts()
        {
            return accounts;
        }
        public List<Transaction> GetTransactions()
        {
            return transacts;
        }
        public ModelContext GetContext()
        {
            return modelContext;
        }

    }
}
