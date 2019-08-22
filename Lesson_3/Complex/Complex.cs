using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complex
{
    class Complex
    {
        public double X { set; get; }
        public double Y { set; get; }

        public Complex()
        {

        }

        public Complex(double x, double y)
        {
            X = x;
            Y = y;
        }

        public static Complex Add(int i)
        {
            Complex a = new Complex
            {
                X = Program.Check("вещественную", i),
                Y = Program.Check("мнимую", i)
            };

            return a;
        }

        public static void Write(string txt, Complex z)
        {
            char ch;
            if (z.Y > 0)
            {
                ch = '+';
            }
            else ch = ' ';
            Console.WriteLine("Результат {0} чисел: {1:F2}{2}{3:F2}i\n", txt, z.X, ch, z.Y);
        }

        public static Complex operator -(Complex a, Complex b)
        {
            return new Complex(a.X - b.X, a.Y - b.Y);
        }

        public static Complex operator +(Complex a, Complex b)
        {
            return new Complex(a.X + b.X, a.Y + b.Y);
        }

        public static Complex operator *(Complex a, Complex b)
        {
            return new Complex((a.X * b.X) - (a.Y * b.Y), (a.X * b.Y) + (a.Y * b.X));
        }

        public static Complex operator /(Complex a, Complex b)
        {
            double c = Math.Pow(b.X, 2);
            double d = Math.Pow(b.Y, 2);
            return new Complex(((a.X * b.X) + (a.Y * b.Y)) / (c + d), ((a.Y * b.X) - (a.X * b.Y)) / (c + d));
        }
    }

}
