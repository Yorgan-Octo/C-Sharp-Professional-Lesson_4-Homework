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


            //Футболка - 99.99 грн.
            //Мобильный телефон - 5000.00 грн.
            //Книга - 50.00 грн.
            //Фен - 150.00 грн.
            //Радуга - 22000.00 грн.
            //Дата покупки  (10.03.2023)



            using (StreamReader ch = new StreamReader("chek.txt"))
            {
                string line;
                while ((line = ch.ReadLine())!= null)
                {

                    string pattern = @"Дата покупки";

                    var regex = new Regex(pattern);

                    if (regex.IsMatch(line))
                    {
                        //Console.WriteLine("Gjregrf ,skf lfdyyj");

                        Console.WriteLine(Regex.Replace(line,
                                           @"^Дата покупки: (?<месяц>\d{1,2})\/(?<день>\d{1,2})\/(?<год>\d{2,4})",

                                           (месяц, день, год) => DateTime.Parse(месяц, день, год).ToString("F2", CultureInfo.CurrentCulture));

                        break;
                    }



                    Console.WriteLine(Regex.Replace(line,                                 
                                            @"(?<var1>\d+)",                                                
                                            var1 => double.Parse(var1.Value).ToString("F2", CultureInfo.CurrentCulture)));

                }



            }







            Console.ReadKey();


        }
    }
}
