using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task_4
{
    internal class Program
    {
        static void Main()
        {

            //Створіть текстовий файл - чек
            //на кшталт «Найменування товару – 0.00(ціна)грн.»
            //з певною кількістю найменувань товарів та датою здійснення покупки.
            //Виведіть на екран інформацію з чека у форматі поточної локалі користувача та у форматі локалі en-US.

            FileInfo file = new FileInfo("chek.txt");

            if (!file.Exists)
            {
                using (StreamWriter wr = new StreamWriter(file.FullName))
                {
                    wr.WriteLine("Футболка - 99 грн.");
                    wr.WriteLine("Мобильный телефон - 500 грн.");
                    wr.WriteLine("Книга - 50 грн.");
                    wr.WriteLine("Фен - 150 грн.");
                    wr.WriteLine("Радуга - 2200 грн.");
                }
            }


            using (StreamReader ch = new StreamReader("chek.txt"))
            {
                string line;
                while ((line = ch.ReadLine()) != null)
                {

                    string pattern = @"Дата покупки";

                    var regex = new Regex(pattern);
 
                    Console.WriteLine(Regex.Replace(line, @"(?<var1>\d+)",var1 => double.Parse(var1.Value).ToString("F2", CultureInfo.CurrentCulture)));

                    Console.WriteLine(new String('-', 50));
                }

                DateTime data = DateTime.Now;
                Console.WriteLine($"Дата покупки: " + data.ToString("D", CultureInfo.CurrentCulture));

            }

            Console.WriteLine(new String('=', 50));

            var us = new CultureInfo("en-US");
            using (StreamReader ch = new StreamReader("chek.txt"))
            {
                string line;
                while ((line = ch.ReadLine()) != null)
                {

                    string pattern = @"Дата покупки";

                    var regex = new Regex(pattern);

                    Console.WriteLine(Regex.Replace(line, @"(?<var1>\d+)", var1 => double.Parse(var1.Value).ToString("F2", us)));
                    Console.WriteLine(new String('-', 50));
                }

                DateTime data = DateTime.Now;
                Console.WriteLine($"Дата покупки: " + data.ToString("D", us));

            }


            Console.ReadKey();

        }
    }
}
