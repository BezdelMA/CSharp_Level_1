using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Испольнил Бездель М.А.
//Рассчет индекса массы тела
namespace _2._1
{
    class Program
    {
        static void Main(string[] args)
        {
            double growth, wieght, i;

            Console.WriteLine("Программа расчитывания индекса массы тела");
            Console.Write("Введите рост в сантиметрах: ");

            growth = (Convert.ToDouble(Console.ReadLine()))/100;

            Console.Write("Введите вес в килограммах: ");

            wieght = Convert.ToDouble(Console.ReadLine());

            i = wieght / (growth * growth);

            Console.WriteLine("Индекс массы тела по введенным параметрам равен: {0:F2}", i);

            Pause();
        }

        private static void Pause()
        {
            Console.ReadKey();
        }
    }
}
