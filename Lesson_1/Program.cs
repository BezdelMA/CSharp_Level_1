using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Испольнил Бездель М.А.
//Получение информации от пользователя, запись в List и вывод значений, используя циклы
namespace _1
{
    class Program
    {
        static void Main(string[] args)
        {
            int point = 0;
            Console.WriteLine("Укажите следующие данные: ");
            List<string> qList = new List<string>
            {
                Question.Ques("фамилия"),
                Question.Ques("имя"),
                Question.Ques("возраст"),
                Question.Ques("рост"),
                Question.Ques("вес")
            };

            Console.WriteLine("Введенные Вами данные: ");
            foreach (string i in qList)
            {
                Question.WriteQues(i, point);
                point++;
            }
            Pause();
        }

        private static void Pause()
        {
            Console.ReadKey();
        }
    }
}
