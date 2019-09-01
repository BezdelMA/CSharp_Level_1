using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fraction
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Программа работы с рациональными (дробными) числами");

            Fraction a = Fraction.Enter("первого числа");
            Fraction b = Fraction.Enter("второго числа");

            Fraction.Write_2(a+b, "сложения: ");
            Fraction.Write_2(a-b, "вычитания: ");
            Fraction.Write_2(a * b, "умножения: ");
            Fraction.Write_2(a/b, "деления: ");

            Console.ReadKey();
        }
    }
}
