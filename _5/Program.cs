using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Исполнил Бездель М.А.
//Вывод на экран значения переменной по центру экрана и с использованием метода Print
namespace _5
{
    class Program
    {
        static void Main(string[] args)
        {

            string str = "Михаил Бездель, Москва";
            Console.SetWindowSize(100, 31);
            Console.SetCursorPosition(38, 16);
            Console.Write(str);
            Print(str, 38, 14);

            Pause();
        }

        private static void Print(string str, int x, int y)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(x, y);
            Console.Write(str);
        }

        private static void Pause()
        {
            Console.ReadKey();
        }
    }
}
