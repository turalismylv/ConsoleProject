using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1.Helpers
{
    static class Helper
    {
        public static void Print(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }
        public static void Printslow(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            foreach (char item in text)
            {
                Console.Write(item);
                Thread.Sleep(20);

            }
            Console.WriteLine();
            Thread.Sleep(1000);
            Console.ResetColor();
        }
    }
}
