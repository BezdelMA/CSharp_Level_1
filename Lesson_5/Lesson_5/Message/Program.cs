using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

//Программа по работе с тектом, как с массивом данных

namespace Message
{
    class Program
    {
        private static string DataRead()
        {
            string str = "";
            StreamReader sr = new StreamReader ("data.txt", Encoding.UTF8, false);
            str = sr.ReadLine();
            sr.Close();
            return str;
        }

        static void Main(string[] args)
        {
            MessageString message = new MessageString(DataRead());
            Console.WriteLine(message.Print);
            Console.WriteLine("\nОбработка текста методом, удаляющим слова, содержащие не более 5 символов:\n");
            MessageString messageConclusion = MessageString.Conclusion(message, 5);
            Console.WriteLine(messageConclusion.Print);
            string max = message.MaxLength;
            Console.WriteLine("\nСамое длинное слово в тексте: {0}. Содержит {1} символов", max, max.Length);
            MessageString messageMax= MessageString.Max(message, 10);
            Console.WriteLine("\nСлова, содержащие 10 и более символов: {0}", messageMax.Print);
            MessageString maxBuilder = MessageString.MaxBuilder(message, 10);
            Console.WriteLine("\nСлова, содержащие 10 и более символов: {0}", maxBuilder.Print);
            MessageString deleteChar = MessageString.DeleteChar(message, 'я');
            Console.WriteLine("\nТекст без слов, заканчивающихся на букву 'я': {0}\n\nКоличество слов до операции: {1}\nКоличество слов после операции: {2}", deleteChar.Print, message.Length, deleteChar.Length);
            
            Console.ReadKey();
        }
    }
}
