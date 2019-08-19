using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Программа по учету сдачи экзаменов студентами.
//Реализован ввод данных и вывод их на экран, если число студентов уже более 10
//Остальной функционал дописать не успел

namespace Student
{
    class Program
    {
        private static void Print(List<Student> student)
        {
            Console.WriteLine(student.Count);
            foreach (var i in student)
            {
                Console.WriteLine(i.Write());
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Программа по учету сдачи экзаменов студентами\n\n");
            List<Student> student = new List<Student>();
            Console.WriteLine("Для запуска программы нажмите любую клавишу");
            ConsoleKeyInfo key = Console.ReadKey();
            Console.WriteLine();
            int j = 0;
            do
            {
                Student i = Student.EnterStudent();
                student.Add(i);
                j++;
                if (j >= 10)
                {
                    Console.WriteLine("Для выхода из программы нажмине Escape");
                    key = Console.ReadKey();
                }
                if (j == 100) break;
                if (j < 10) continue;
            }
            while (key.Key != ConsoleKey.Escape);
            Print(student);
            Console.ReadKey();
        }
    }
}
