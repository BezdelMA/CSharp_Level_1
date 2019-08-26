using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Two_Dimensional_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            Two_Array mass = new Two_Array(5, 5);
            Console.WriteLine("Исходный массив: \n{0}", mass.Print);
            Console.WriteLine("Сумма всех элементов массива: {0}", Two_Array.Sum());
            Console.WriteLine("Сумма всех элементов массива, имеющих значение больше 15: {0}", Two_Array.Sum(15));
            Console.WriteLine("Минимальный элемента массива: {0}", mass.Min);
            Console.WriteLine("Максимальный элемент массива: {0}", mass.Max);
            
            Console.ReadKey();
        }
    }
}
