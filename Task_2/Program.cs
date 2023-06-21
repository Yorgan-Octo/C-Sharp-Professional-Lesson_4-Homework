using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task_2
{
    internal class Program
    {
        static void Main()
        {
            string url = "https://tv-project.com/ru/contact-address";

            WebRequest request = WebRequest.Create(url);
            WebResponse response = request.GetResponse();

            string responseFromServer;
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                responseFromServer = reader.ReadToEnd();
            }

            using (StreamWriter writer = File.CreateText("Log.txt"))
            {

                var regex = new Regex(@"(?<phone>[+3(0-90-90-9)\s]{2,}[0-9]{3}[\s\-][0-9]{2}[\s\-][0-9]{2})");

                foreach (Match m in regex.Matches(responseFromServer))
                {
                    writer.WriteLine("Тел. номер: {0,-25}", m.Groups["phone"]);
                }

                regex = new Regex(@"(?<email>[0-9A-Za-z_.-]+@[0-9a-zA-Z-]+\.[a-zA-Z]{2,4})");

                foreach (Match m in regex.Matches(responseFromServer))
                {
                    writer.WriteLine("E-Mail: {0,-25}", m.Groups["email"]);
                }

            }

            Console.ReadKey();
        }
    }
}
