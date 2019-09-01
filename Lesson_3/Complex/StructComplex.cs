using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complex
{
    struct StructComplex
    {
        public double X { set; get; }
        public double Y { set; get; }

        public StructComplex(double x, double y)
        {
            X = x;
            Y = y;
        }

        public static StructComplex Add_2(int i)
        {
            StructComplex a = new StructComplex
            {
                X = Program.Check("вещественную", i),
                Y = Program.Check("мнимую", i)
            };

            return a;
        }

        public static void StructWrite(string txt, StructComplex q)
        {
            char ch;
            if (q.Y > 0)
            {
                ch = '+';
            }
            else ch = ' ';
            Console.WriteLine("Результат {0} чисел: {1:F2}{2}{3:F2}i\n", txt, q.X, ch, q.Y);
        }


        public static StructComplex operator -(StructComplex a, StructComplex b)
        {
            return new StructComplex(a.X - b.X, a.Y - b.Y);
        }

        public static StructComplex operator +(StructComplex a, StructComplex b)
        {
            return new StructComplex(a.X + b.X, a.Y + b.Y);
        }

        public static StructComplex operator *(StructComplex a, StructComplex b)
        {
            return new StructComplex((a.X * b.X) - (a.Y * b.Y), (a.X * b.Y) + (a.Y * b.X));
        }

        public static StructComplex operator /(StructComplex a, StructComplex b)
        {
            double c = Math.Pow(b.X, 2);
            double d = Math.Pow(b.Y, 2);
            return new StructComplex(((a.X * b.X) + (a.Y * b.Y)) / (c + d), ((a.Y * b.X) - (a.X * b.Y)) / (c + d));
        }
    }
}
