using BANK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BANK.Views.Admins
{
    internal class Register
    {
        public Register()
        {
            //var Db = new DB();
            Console.Clear();
            string Password, RePassword, Pesel, Name, SurName, UserName = "";
            int typeid;
            bool con = true;
            while (con == true)
            {
                con = false;
                Menu.ShowCenter("Nazwa Użytkownika");
                UserName = Console.ReadLine();
                foreach (var u in Menu.Db.users.ToList())
                {
                    if (string.Compare(u.Username, UserName) == 0)
                    {
                        Console.Clear();
                        Menu.ShowCenter("Nazwa użytkownika juz istnieje");
                        con = true;

                    }
                }
            }
            Console.Clear();
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
            while (true)
            {
                Menu.ShowCenter("Podaj Pesel");
                Pesel = Console.ReadLine();
                Console.Clear();
                if (Pesel.Length != 11)
                {
                    Menu.ShowCenter("Niepoprawny pesel");
                    continue;
                }
                else break;
            }
            Menu.ShowCenter("Podaj Imie");
            Name = Console.ReadLine();
            Console.Clear();

            Menu.ShowCenter("Podaj Nazwisko");
            SurName = Console.ReadLine();
            Console.Clear();

            Menu.ShowCenter("Podaj id typu użytkownika");
            typeid = int.Parse(Console.ReadLine());
            Console.Clear();


            Menu.Db.Register(new User(0, UserName, Name, SurName, Pesel, Password,typeid));
            Menu.ShowCenter("Pomyślnie zarejstrowano");
        }
    }
}
