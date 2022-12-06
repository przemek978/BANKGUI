using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANK.Models
{
    internal static class Menu
    {
        private static int bottomOffset;
        private static int topOffset = 1;
        public static int Selected { get; set; }
        static ConsoleColor Back = ConsoleColor.DarkBlue;
        static ConsoleColor Text = ConsoleColor.White;
        public static DB Db;
        public static void ShowCenter(string t)
        {
           int middle = Console.WindowWidth / 2 - t.Length / 2+1;
            Console.SetCursorPosition(middle, Console.CursorTop);
            Console.ForegroundColor = Text;
            Db = new DB();
            Console.WriteLine(t);
        }
        public static List<String> ConvertStringOnList(string s)
        {
            var list = new List<String>(); 
            list.Add(s);
            return list;
        }
        public static void ShowMenu(List<string> menuList, List<string> titles,bool asc=false)
        {
            int menulength = 100;
            topOffset = 1 + titles.Count-1;
            int middle = (Console.WindowWidth - menulength) / 2;
            
            Console.ResetColor();
            Console.BackgroundColor = Back;
            Console.ForegroundColor = Text;
            Console.Clear();
            foreach(var s in titles)
                ShowCenter(s);
            Console.SetCursorPosition(middle, topOffset);
            Console.CursorVisible = false;
            var selected = 0;
            var enter = false;
            for (int i = 0; i < menulength + 3; i++)
            {
                Console.Write("*");
            }
            Console.SetCursorPosition(middle, topOffset + 1);
            while (!enter)
            {
                for (var i = 0; i < menuList.Count; i++)
                {

                    Console.Write("*");
                    Console.BackgroundColor = Back;
                    Console.ForegroundColor = Text;
                    if (i == selected)
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Black;
                        ShowCenter(menuList[i]);
                        Console.ResetColor();
                    }
                    else
                    {
                        ShowCenter(menuList[i]);
                    }
                    Console.SetCursorPosition(middle + menulength + 2, topOffset + i + 1);
                    Console.BackgroundColor = Back;
                    Console.ForegroundColor = Text;
                    Console.WriteLine("*");
                    Console.SetCursorPosition(middle, topOffset + i + 2);
                }
                for (int i = 0; i < menulength + 3; i++)
                {
                    Console.BackgroundColor = Back;
                    Console.ForegroundColor = Text;
                    Console.Write("*");
                }
                bottomOffset = Console.CursorTop;
                if(asc==true)
                {
                    string s = @"

                                         /$$$$$$$   /$$$$$$  /$$   /$$ /$$   /$$
                                        | $$__  $$ /$$__  $$| $$$ | $$| $$  /$$/
                                        | $$  \ $$| $$  \ $$| $$$$| $$| $$ /$$/ 
                                        | $$$$$$$ | $$$$$$$$| $$ $$ $$| $$$$$/  
                                        | $$__  $$| $$__  $$| $$  $$$$| $$  $$  
                                        | $$  \ $$| $$  | $$| $$\  $$$| $$\  $$ 
                                        | $$$$$$$/| $$  | $$| $$ \  $$| $$ \  $$
                                        |_______/ |__/  |__/|__/  \__/|__/  \__/";
                    Console.WriteLine(s);
                }
                var kb = Console.ReadKey(true);
                switch (kb.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (selected > 0)
                            selected--;
                        else
                            selected = menuList.Count - 1;
                        break;

                    case ConsoleKey.DownArrow:
                        if (selected < menuList.Count - 1)
                            selected++;
                        else
                            selected = 0;
                        break;

                    case ConsoleKey.Enter:
                        enter = true;
                        Selected = selected;
                        break;
                }
                Console.SetCursorPosition(middle, topOffset + 1);
                
            }
            Console.SetCursorPosition(middle, bottomOffset+1);
        }
    }
}
