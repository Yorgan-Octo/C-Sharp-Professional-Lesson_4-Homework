using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task_6
{
    internal class Program
    {


        static Dictionary<string, string> user = new Dictionary<string, string>();


        static void Main(string[] args)
        {
            string login = default;
            while (true)
            {
                try
                {
                    string patern = "^[a-z]{1,8}$";
                    Regex regex = new Regex(patern);



                    Console.Write("Ведіть логін: ");
                    login = Console.ReadLine();

                    if (regex.IsMatch(login))
                    {
                        break;
                    }

                    throw new Exception("«Логін», повинен складатися тільки з символів латинського алфавіту " +
                        "та мати від 1 до 8 символів");
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ResetColor();
                }

            }

            string pasword = default;
            while (true)
            {
                try
                {
                    string patern = "^[a-z0-9]{8,16}$";
                    Regex regex = new Regex(patern);



                    Console.Write("Ведіть пароль: ");
                    pasword = Console.ReadLine();

                    if (regex.IsMatch(pasword))
                    {
                        break;
                    }

                    throw new Exception("Невырный формат пароля! Пароль повинен складаться з цифр і символів " +
                        "та мати від 8 до 16 символів");
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ResetColor();
                }

            }

            user.Add(login,pasword);

            string pasw = Console.ReadLine();



        }
    }
}
