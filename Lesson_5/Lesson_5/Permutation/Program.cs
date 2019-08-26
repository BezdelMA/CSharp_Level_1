using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Проверка двух строк на перестановку по отношению друг к другу.
//Собственный алгоритм работает кроме случаев, типа (abba и bbab). Пока думаю, как исправить

namespace Permutation
{
    class Program
    {
        //ввод строк
        static string EnterString ()
        {
            Console.Write("Введите строку: ");
            return Console.ReadLine();
        }

        //проверка строк на перестановку друг друга
        static void Permutation (string a, string b)
        {
            char[] ch_1 = a.ToCharArray();
            char[] ch_2 = b.ToCharArray();
            if (CheckLength(ch_1, ch_2) & CheckLetters(ch_1, ch_2))
                Console.WriteLine("Строки являются перестановкой друг друга");
            else Console.WriteLine("Строки НЕ являются перестановкой друг друга");
        }

        //проверка соответствия длинны строк
        static bool CheckLength (char [] ch_1, char [] ch_2)
        {
            return ch_1.Length == ch_2.Length;
        }
        
        //проверка соответствия символов в строках
        static bool CheckLetters(char[] ch_1, char [] ch_2)
        {
            int answer_1 = 0;
            int answer_2 = 0;
            for (int i = 0; i < ch_1.Length; i++)
            {
                for (int j = 0; j < ch_2.Length; j++)
                {
                    if (ch_1[i] == ch_2[j])
                        answer_1++;
                }
            }

            for (int i = 0; i < ch_1.Length; i++)
            {
                for (int j = 0; j < ch_1.Length; j++)
                {
                    if (ch_1[i] == ch_1[j])
                        answer_2++;
                }
            }

            if (answer_1 == answer_2)
                return true;
            else
            {
                Console.WriteLine("Строки содержат разные символы");
                return false;
            }
        }

        static void Main(string[] args)
        {
            string a = EnterString();
            string b = EnterString();
            Console.WriteLine("\nСравнение строк собственным методом...");
            Permutation(a, b);
            
            Console.ReadKey();
        }
    }
}
