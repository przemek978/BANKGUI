using BANK.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANK.Views.Admins
{
    internal class LoginAdmin : IView
    {
        User user;
        public LoginAdmin()
        {

        }
        public User View()
        {
            bool stop = false;
            while (stop == false)
            {

                string Password;
                Console.Clear();
                Menu.ShowCenter("Nazwa Użytkownika");
                var Name = Console.ReadLine();
                Console.Clear();

                Menu.ShowCenter("Haslo");
                Password = Console.ReadLine();
                Console.Clear();

                var passwordHasher = new PasswordHasher<String>();
                foreach (var us in Menu.Db.GetUsers())
                {
                    if (us.Username == Name && us.typeID == 1)
                    {
                        if (passwordHasher.VerifyHashedPassword(null, us.Password, Password) == PasswordVerificationResult.Success)
                        {
                            user = us;
                            stop = true;
                            break;
                        }
                    }
                }
                if (stop == false)
                {
                    Menu.ShowCenter("Błedna nazwa lub haslo");
                    Menu.ShowCenter("Nacinij dowlny klawisz aby kontynuowac lub esc aby przerwac logowanie");
                    var a = Console.ReadKey();
                    if (a.Key == ConsoleKey.Escape)
                    {
                        return null;
                    }
                }
            }
            return user;
        }
        public User GetUser()
        {
            return user;
        }
    }
}
