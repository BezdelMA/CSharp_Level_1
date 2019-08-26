using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayConstructor
{
    class Array
    {
        static int[] mass;

        public static int Cardinality(string txt)
        {
            int n = 0;
            while (true)
            {
                try
                {
                    Console.Write(txt);
                    if (!Int32.TryParse(Console.ReadLine(), out n)) throw new FormatException();
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
            }
            return n;
        }

        internal string Print()
        {
            string str = "";
            foreach (int i in mass)
                str += i + "; ";
            return str;
        }

        internal static void Print(string txt)
        {
            string str = "";
            foreach (int i in mass)
                str += i + "; ";
            Console.WriteLine("{0}{1}", txt, str);
        }

        public static int CardinalityCount(string txt)
        {
            int n = 0;
            while (true)
            {
                try
                {
                    Console.Write(txt);
                    if (!Int32.TryParse(Console.ReadLine(), out n) || n <= 1) throw new FormatException();
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
            }
            return n;
        }

        public Array(int n)
        {
            Random rnd = new Random();
            mass = new int[n];
            for (int i = 0; i < n; i++)
                mass[i] = rnd.Next(0, 100);
        }

        public Array(int n, int startElement, int step)
        {
            mass = new int[n];
            mass[0] = startElement;
            for (int i = 1; i < n; i++)
                mass[i] = mass[i - 1] + step;
        }

        public int Sum
        {
            get
            {
                int temp = 0;
                foreach (int i in mass)
                    temp += i;
                return temp;
            }
        }

        public int Length
        {
            get
            {
                return mass.Length;
            }
        }

        public int[] Invers
        {
            get
            {
            for (int i = 0; i<mass.Length; i++)
                mass[i] = -mass[i];
                return mass;
            //ToString(mass, "Массив после проведения операции инверсии: ");
            }
        }

        public static void Multi (int multiplier)
        {
            for (int i = 0; i < mass.Length; i++)
                mass[i] *= multiplier;
            //ToString(mass, "Элементы массива после умножения на заданное число: ");
        }

        public int MaxCount
        {
            get
            {
                int i = 1;
                for (int n = mass.Length - 1; n >= 0; n--)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (mass[j] > mass[n])
                        {
                            int temp = mass[j];
                            mass[j] = mass[n];
                            mass[n] = temp;
                        }
                    }
                }
                Print("Отсортированный по возрастанию массив: ");

                for (int n = mass.Length - 1; n > 0; n--)
                {
                    if (mass[mass.Length - 1] == mass[n - 1])
                        i++;
                    else break;
                }
                return i;
            }
        }

        public static void SaveToFile ()
        {
            try
            {
                StreamWriter sw = new StreamWriter("Massive.txt");
                string str = "";
                foreach (int i in mass)
                    str += i + "; ";
                sw.WriteLine("Элементы массива: {0}", str);
                sw.Close();
                Console.WriteLine("Файл сохранен");
            }
            catch
            {
                Console.WriteLine("Произошла внутрення ошибка. Файл не сохранен");
            }
        }

        public static void OpenFromFile ()
        {
            try
            {
                StreamReader sr = new StreamReader("Massive.txt");
                string str = sr.ReadLine();

                string[] txtTemp = str.Split(';');
                string txt1 = "";
                foreach (string i in txtTemp)
                    txt1 += i;

                string[] txt = txt1.Split(' ');
                int count = 0;
                foreach (var i in txt)
                {
                    if (Int32.TryParse(i, out int temp))
                        count++;
                }
                mass = new int[count];
                int number = 0;
                for (int i = 0; i < txt.Length; i++)
                {
                    if (Check(txt[i]))
                    {
                        mass[number] = Convert.ToInt32(txt[i]);
                        number++;
                    }
                }
                Print("Открытый массив из файла: ");
                sr.Close();
            }
            catch
            {
                Console.WriteLine("На диске файл не найден");
            }
        }

        static bool Check(string txt)
        {
            return Int32.TryParse(txt, out int temp);
        }
    }
}
