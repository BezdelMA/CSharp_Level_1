using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Испольнил Бездель М.А.
//Обмен данными двух переменных с использованием третьей и без использования дополнительной переменной с использованием методов
namespace _4
{
    class Program
    {
        static void Main(string[] args)
        {
            int x, y;

            Console.Write("Введите значение Х: ");
            x = Convert.ToInt32(Console.ReadLine());

            Console.Write("Введите значение Y: ");
            y = Convert.ToInt32(Console.ReadLine());

            Print(x, y, "Введенные значения переменных");
            Change(x, y);
            Change_2(x, y);

            Pause();
        }

        private static void Change_2(int x, int y)
        {
            x += y;
            y = x - y;
            x = x - y;
            Print(x, y, "Измененные значения переменных БЕЗ использования дополнительной переменной");
        }

        private static void Change(int x, int y)
        {
            var tmp = x;
            x = y;
            y = tmp;
            Print(x, y, "Измененные значения переменных С использованием дополнительное переменной");
        }

        private static void Print(int x, int y, string txt)
        {
            Console.Write("{0}: X - {1}, Y - {2}\n", txt, x, y);
        }

        private static void Pause()
        {
            Console.ReadKey();
        }
    }
}
