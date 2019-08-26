using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fraction
{
    class Fraction
    {
        int x, y;
        public int X
        {
            get
            {
                return x;
            }

            set
            {
                x = value;
            }
        }

        public int Y
        {
            get
            {
                return y;
            }

            set
            {
                while (true)
                {
                    try
                    {
                        if (value == 0) throw new Exception("Знаменатель не может быть равен нулю! Повторите ввод: ");
                        y = value;
                    }
                    catch (Exception ex)
                    {
                        Console.Write(ex.Message);
                        value = Check();
                        continue;
                    }
                    break;
                }
            }       
        }

        public Fraction()
        {

        }

        public Fraction(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static Fraction Enter (string txt)
        {
            Write("числитель", txt);
            int x = Check();
            Write("знаменатель", txt);
            int y = Check();
             
            return new Fraction(x, y);
        }

        static void Write (string txt, string txt2)
        {
            Console.Write("Введите {0} {1}: ", txt, txt2);
        }

        public static void Write_2(Fraction a, string txt)
        {
            txt = "Результат " + txt;
            if (a.x == 0) Console.WriteLine("{0}0", txt);
            else if (a.x == a.y) Console.WriteLine("{0}1", txt);
            else Console.WriteLine("{0}{1}/{2}", txt, a.x, a.y);
        }

        public static int Check()
        {
            int i = 0;
            while(true)
            {
                try
                {
                    i = Int32.Parse(Console.ReadLine());
                    return i;
                }
                catch (FormatException)
                {
                    Console.Write("Неверный формат данных. Повторите ввод: ");
                    continue;
                }
            }
        }

        static Fraction Reduction(Fraction z)
        {
            for (int i = z.y; i > 0; i--)
            {
                if (z.x % i == 0 & z.y % i == 0)
                {
                    z.x /= i;
                    z.y /= i;
                }
            }
            return z;
        }

        public static Fraction operator +(Fraction a, Fraction b)
        {
            Fraction z = new Fraction
            {
                x = (a.x * b.y) + (b.x * a.y),
                y = a.y * b.y
            };
            z = Reduction(z);

            return z;
        }

        public static Fraction operator -(Fraction a, Fraction b)
        {
            Fraction z = new Fraction
            {
                x = (a.x * b.y) - (b.x * a.y),
                y = a.y * b.y
            };
            z = Reduction(z);

            return z;
        }

        public static Fraction operator *(Fraction a, Fraction b)
        {
            Fraction z = new Fraction
            {
                x = a.x * b.x,
                y = a.y * b.y
            };
            z = Reduction(z);

            return z;
        }

        public static Fraction operator /(Fraction a, Fraction b)
        {
            Fraction z = new Fraction
            {
                x = a.x * b.y,
                y = a.y * b.x
            };
            z = Reduction(z);

            return z;
        }
    }
}
