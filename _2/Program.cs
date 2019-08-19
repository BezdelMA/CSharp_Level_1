using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Исполнил Бездель М.А.
//Получение информации от пользователя и вывод значений на экран тремя способами
namespace _2
{
    class Program
    {
        static void Main(string[] args)
        {
            string surname, name;
            int age, growth, wieght;
            Console.Write("Введите свою фамилию: ");
            surname = Console.ReadLine();
            Console.Write("Введите свое имя: ");
            name = Console.ReadLine();
            Console.Write("Введите свой возраст: ");
            age = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите свой рост: ");
            growth = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите свой вес: ");
            wieght = Convert.ToInt32(Console.ReadLine());
            Console.Write("Вас зовут: " + surname + " " + name + ", Ваш возраст: " + age + ", Ваш рост: " + growth + ", Ваш вес: " + wieght);
            Console.Write("\nВы: {0} {1}, {2} лет, ростом {3} сантиметра, весом {4} кг", surname, name, age, growth, wieght);
            Console.Write($"\nВы: {surname} {name}, {age} лет, ростом {growth} сантиметра, весом {wieght} кг");

            Pause();
        }

        private static void Pause()
        {
            Console.ReadKey();
        }
    }
}
