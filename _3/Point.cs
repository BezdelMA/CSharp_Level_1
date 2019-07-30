using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _3
{
    class Point
    {
        public int x;
        public int y;

        public Point (Random rnd)
        {
            GetRandom(rnd);
        }

        public void GetRandom (Random rnd)
        {
            x = rnd.Next(1, 100);
            y = rnd.Next(1, 30);
        }

        internal void Show(int _x, int _y, int i)
        {
            Console.WriteLine("Координаты точки № {0}: {1}, {2}", i, _x, _y);
        }

        internal static void Distance(Point p1, Point p2)
        {
            double distance = Math.Sqrt(Math.Pow(p2.x - p1.x, 2) + Math.Pow(p2.y - p1.y, 2));
            Console.WriteLine("Расстояние между двумя произвольными точками равна: {0:F2}", distance);
        }
    }
}
