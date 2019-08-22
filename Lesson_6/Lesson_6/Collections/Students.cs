using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    class Students
    {
        public string surname, name, univercity, faculty, departament;
        public int age, level, non;
        public string city;

        /// <summary>
        /// конструктор класса Студенты
        /// </summary>
        /// <param name="surname">Фамилия</param>
        /// <param name="name">Имя</param>
        /// <param name="univercity">Университет</param>
        /// <param name="faculty">Факультет</param>
        /// <param name="departament">Кафедра</param>
        /// <param name="age">Возраст</param>
        /// <param name="level">Курс</param>
        /// <param name="non">Не понял</param>
        /// <param name="city">Город</param>
        public Students (string surname, string name, string univercity, string faculty, string departament, int age, int level, int non, string city)
        {
            this.surname = surname;
            this.name = name;
            this.univercity = univercity;
            this.faculty = faculty;
            this.departament = departament;
            this.age = age;
            this.level = level;
            this.non = non;
            this.city = city;
        }

        /// <summary>
        /// Метод составления коллекции при считывании данных с файла
        /// </summary>
        /// <returns></returns>
        public static List<Students> ListGeneric()
        {
            List<Students> sList = new List<Students>();
            StreamReader sr = new StreamReader(@"students.csv");
            string temp = sr.ReadToEnd();
            char[] delim = new char [] { ';', ',', '.', '\r', '\n' };
            string[] tmp = temp.Split(delim, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; (i+9) < tmp.Length;)
            {
                sList.Add(new Students(tmp[i], tmp[i + 1], tmp[i + 2], tmp[i + 3], tmp[i + 4], Convert.ToInt32(tmp[i + 5]), Convert.ToInt32(tmp[i + 6]), Convert.ToInt32(tmp[i + 7]), tmp[i + 8]));
                i += 9;
            }
            return sList;
        }
        /// <summary>
        /// метод подсчета количества студентов, обучающихся на 5 и 6 курсах
        /// </summary>
        /// <param name="sList">коллекция студентов</param>
        /// <returns></returns>
        public static int Number_5_6 (List<Students> sList)
        {
            int count = 0;
            foreach (Students i in sList)
            {
                if (i.level == 5 || i.level == 6)
                    count++;
            }

            return count;
        }
        /// <summary>
        /// метод подсчета на каком курсе сколько студентов в возрасте от 18 до 20 лет включительно
        /// </summary>
        /// <param name="sList">коллекция студентов</param>
        public static void Couting_18_20 (ref List<Students> sList)
        {
            List<Students> temp = new List<Students>();
            Console.WriteLine("Дождитесь окончания подсчета...");
            for (int i = 0; i < sList.Count; i++)
            {
                if (sList[i].age >= 18 & sList[i].age <= 20)
                    temp.Add(sList[i]);
            }
            int[] level_temp = new int[temp.Count];
            for (int i = 0; i < temp.Count; i++)
            {
                level_temp[i] = temp[i].level;
            }

            SortedDictionary<int, int> dictionary = new SortedDictionary<int, int>();
            foreach (int i in level_temp)
            {
                if (dictionary.ContainsKey(i))
                    ++dictionary[i];
                else dictionary[i] = 1;
            }

            foreach (KeyValuePair<int, int> i in dictionary)
                Console.WriteLine("Количество студентов на {0} курсе: {1}", i.Key, i.Value);
        }
        /// <summary>
        /// Сортировка по возрасту
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static int CompareDate(Students a, Students b)
        {
            return a.age.CompareTo(b.age);
        }
        /// <summary>
        /// Сортировка по курсу и возрасту
        /// </summary>
        /// <param name="sList"></param>
        /// <returns></returns>
        public static List<Students> SortDateLevel (List<Students> sList)
        {
            sList.OrderBy(x => x.level).ThenBy(x => x.age);
            return sList;
        }
        
    }
}
