using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task_3
{
    internal class Program
    {
        static void Main()
        {




            var prepositions = new[] { "без", "в", "від", "для", "до", "з", "за", "на", "над", "під", "по", "біля", "про", "ради", "через" };
            //string text = "Виглянув за столу, прийшов до струмка, лежить на столу";

            string text = default;

            FileInfo file = new FileInfo(@"text.txt");


            if (!file.Exists)
            {
                using (StreamWriter sr = new StreamWriter(file.FullName))
                {
                    sr.WriteLine("Виглянув за столу, прийшов до струмка, лежить на столу");
                }
            }

            using (StreamReader sr = new StreamReader(file.FullName))
            {
                text += sr.ReadToEnd();
            }

            Console.WriteLine(text);

            foreach (string element in prepositions)
            {
                string pattern = $@"\b{element}\b";
                text = Regex.Replace(text, pattern, "ГАВ", RegexOptions.IgnoreCase);
            }

            Console.WriteLine(text);
            Console.ReadKey();

        }
    }
}
