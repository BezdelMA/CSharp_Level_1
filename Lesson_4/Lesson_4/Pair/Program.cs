using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pair
{
    class Program
    {
        private static int PairCounter(int[] mass)
        {
            int count = 0;
            for (int i = 1; i < mass.Length; i++)
            {
                if (mass[i] % 3 == 0 || mass[i - 1] % 3 == 0)
                    count++;
            }
            return count;
        }

        private static void MassEnter(int[] mass)
        {
            Random rnd = new Random();
            for (int i = 0; i < 20; i++)
            {
                mass[i] = (rnd.Next(-10000, 10000));
            }
        }

        private static string ToString(int[] mass)
        {
            string str = "";
            for (int i = 0; i < mass.Length; i++)
            {
                str += Convert.ToString(mass[i]) + "; ";
            }
            return str;
        }

        static void Main(string[] args)
        {
            int[] mass = new int[20];
            MassEnter(mass);
            
            string str = ToString(mass);
            Console.WriteLine("Исходный массив: {0}", str);

            int pairCounter = PairCounter(mass);
            Console.WriteLine("Количество пар в массиве: {0}", pairCounter);

            WriteToFile(str, pairCounter);
            Console.ReadKey();
        }

        private static void WriteToFile(string str, int pairCounter)
        {
            StreamWriter sw = new StreamWriter("Mass.txt");
            sw.WriteLine("Исходный массив: {0}", str);
            sw.WriteLine("Количество пар в массиве: {0}", pairCounter);
            sw.Close();
        }
    }
}
