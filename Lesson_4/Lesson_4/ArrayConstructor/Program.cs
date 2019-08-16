using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayConstructor
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = Array.CardinalityCount("Введите желаемое количество элементов в массиве: ");
            int startElement = Array.Cardinality("Задайте начальное значение массива: ");
            int step = Array.Cardinality("Задайте шаг значений элементов массива: ");
            Array mass = new Array(n, startElement, step);
            Console.WriteLine("Массив заполнен следующими элементами: {0}", mass.Print());


            n = Array.CardinalityCount("Введите желаемое количество элементов в массиве: ");
            mass = new Array(n);
            Console.WriteLine("Массив заполнен следующими элементами: {0}", mass.Print());
            int sum = mass.Sum;
            Console.WriteLine("Сумма элементов массива равна: {0}", sum);
            int [] mass_1 = mass.Invers;
            Console.WriteLine("Элементы массива после инверсии: {0}", mass.Print());
            int multiplier = Array.Cardinality("Введите значение, на которое умножить каждый элемент массива: ");
            Array.Multi(multiplier);
            Console.WriteLine("Элементы массива после умножения на заданное число: {0}", mass.Print());
            int maxCount = mass.MaxCount;
            Console.WriteLine("Количество максимальных значений массива: {0}", maxCount);

            Array.SaveToFile();
            Array.OpenFromFile();

            Console.ReadKey();
        }
    }
}
