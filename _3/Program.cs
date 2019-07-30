using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
//Исполнил Бездель М.А.
//Рассчет расстояния между двумя произвольными (рандомными) точками
//Постарался все сделать используя классы, конструкторы и методы
//Возникла проблема, когда рандом выдавал одинаковые значения для обеих точек, решил установив паузу в методе GetRandom длительностью 15мс
namespace _3
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            Point p1 = new Point(rnd);
            Point p2 = new Point(rnd);

            p1.Show(p1.x, p1.y, 1);
            p2.Show(p2.x, p2.y, 2);

            Point.Distance(p1, p2);

            Pause();
        }

        private static void Pause()
        {
            Console.ReadKey();
        }
    }
}
