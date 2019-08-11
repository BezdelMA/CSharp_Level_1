using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Number
{
    class Program
    {
        public static List<int> iList = new List<int>();
        static int Check()
        {
            bool bl = false;
            int i = 0;
            while(!bl)
            {
                bl = Int32.TryParse(Console.ReadLine(), out i);
                if (!bl) Console.WriteLine("Некорректные данные. Повторите ввод!");
                if (i > 0 & i % 2 == 1) iList.Add(i);
            }
            return i;
        }

        static void Write (string txt)
        {
            string numbers = "";
            foreach (var i in iList)
            {
                numbers += i + "; ";
            }
            Console.Write("{0} {1}", txt, numbers);
        }

        static void Summa()
        {
            int sum = 0;
            foreach (var i in iList)
            {
                sum += i;
            }
            Console.Write("\nСумма введенных Вами положительных нечетных чисел равна: {0}", sum);
        }

        static void Main(string[] args)
        {
            int num;
            Console.Write("Через клавишу «Enter» введите последовательность целых чисел. Для окончания ввода нажмите клавишу «0»\n");
            do
            {
                num = Check();
                if (num == 0) break;
            }
            while (true);

            Write("Положительные нечетные числа из введенных Вами: ");
            Summa();

            Console.ReadKey();
        }
    }
}
