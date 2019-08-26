using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complex
{
    class Program
    {
        public static double Check(string txt, int i)
        {
            double z = 0;
            bool bl = false;
            while (!bl)
            {
                Console.Write("Введите {0} часть {1} комплексного числа: ", txt, i);
                bl = Double.TryParse(Console.ReadLine(), out z);
            }
            return z;
        }

        static void Main(string[] args)
        {
            #region Class
            Console.WriteLine("Работа класса Complex");
            Complex a = Complex.Add(1);
            Complex b = Complex.Add(2);

            Complex.Write("сложения", a+b);
            Complex.Write("вычитания", a-b);
            Complex.Write("умножения", a*b);
            Complex.Write("деления", a/b);
            Console.ReadKey();
            #endregion

            #region Struct
            Console.WriteLine("Работа структуры StructComplex");
            StructComplex c = StructComplex.Add_2(1);
            StructComplex d = StructComplex.Add_2(2);

            StructComplex.StructWrite("сложения", c+d);
            StructComplex.StructWrite("вычитания", c-d);
            StructComplex.StructWrite("умножения", c*d);
            StructComplex.StructWrite("деления", c/d);
            #endregion
            Console.ReadKey();
        }
    }
}
