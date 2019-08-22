using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{
    delegate double FuncMin(double x, double a);

    class Program
    {
        static readonly List<FuncMin> list = new List<FuncMin>{FuncMin_1, FuncMin_2};
        static void Menu()
        {
            Console.WriteLine("1. Выполнить функцию a*x^2");
            Console.WriteLine("2. Выполнить функцию a*sin(x)");
            Console.WriteLine("3. После выполнения функции a*x^2 вывести на экран все значения функции");
            Console.WriteLine("4. После выполнения функции a*sin(x) вывести на экран все значения функции");
            Console.WriteLine("Для выхода нажмите 0");
        }

        static double FuncMin_1 (double a, double x)
        {
            return a * Math.Pow(x, 2);
        }

        static double FuncMin_2(double a, double x)
        {
            return a * Math.Sin(x);
        }

        static double Enter(string txt)
        {
            double x;
            while (true)
            {
                try
                {
                    Console.Write(txt);
                    if (!Double.TryParse(Console.ReadLine(), out x)) throw new FormatException();
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
                break;
            }
            return x;
        }

        static void SaveToFile (FuncMin F, string fileName, double a, double b, double h)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            while (a <= b)
            {
                bw.Write(F(a, b));
                a += h;
            }
            bw.Close();
            fs.Close();
        }

        static double[] Load (string fileName, out double min)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            min = double.MaxValue;
            double[] mass = new double[fs.Length / sizeof(double)];
            double d;

            for (int i = 0; i < fs.Length/sizeof(double); i++)
            {
                d = br.ReadDouble();
                mass[i] = d;
                if (d < min) min = d;
            }

            return mass;
        }

        static string Print (double[] mass)
        {
            string str = "";
            foreach (var i in mass)
                str += i + "; ";

            return str;
        }

        static void Function (FuncMin F, string fileName)
        {
            Console.Clear();
            double a = 0;
            double b = 0;
            double h = 0;
            while (true)
            {
                try
                {
                    a = Enter("Введите значение нижнего предела: ");
                    b = Enter("Введите значение верхнего предела: ");
                    if (a > b) throw new Exception("Нижний предел не может быть больше верхнего!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
                break;
            }
            h = Enter("Введите значение шага: ");
            SaveToFile(F, fileName, a, b, h);
            Load(fileName, out double min);
            Console.WriteLine("Минимальное значение, полученное при выполнении функции: {0}", min);
        }

        static void Main(string[] args)
        {
            bool flag;
            int digit;
            double[] mass;
            do
            {
                Console.Clear();
                Menu();
                flag = Int32.TryParse(Console.ReadLine(), out digit); 
                switch (digit)
                {
                    case 1:
                        Function(list[digit-1], @"data_1.txt");
                        break;
                    case 2:
                        Function(list[digit-1], @"data_2.txt");
                        break;
                    case 3:
                        {
                            mass = Load(@"data_1.txt", out double min);
                            Console.WriteLine("В ходе выполнения функции получаны следующие значения: {0}", Print(mass));
                        }
                            break;
                    case 4:
                        {
                            mass = Load(@"data_2.txt", out double min);
                            Console.WriteLine("В ходе выполнения функции получаны следующие значения: {0}", Print(mass));
                        }
                            break;
                }
                Console.ReadKey();
            }
            while (digit != 0);

            Console.ReadKey();
        }
    }
}
