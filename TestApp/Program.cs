using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TestApp.BLL;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new CbrService();
            var curs = service.Get();

            Console.WriteLine("Курс валют");
            Console.WriteLine("USD: " + curs.USD + " руб.");
            Console.WriteLine("EUR: " + curs.EUR + " руб.");
        }
    }
}
