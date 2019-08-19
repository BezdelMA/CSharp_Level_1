using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student
{
    class Student
    {
        string surname;
        string name;
        string point;
        
        public string Surname
        {
            get
            {
                return surname;
            }

            set
            {
                surname = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public string Point
        {
            get
            {
                return point;
            }

            set
            {
                point = value;
            }
        }

        public string Print
        {
            get
            {
                string str = "";
                foreach (var i in point)
                    str += i + " ";
                return str;
            }
        }

        internal string Write()
        {
            return surname + " " + name + " " + point;
        }

        public Student()
        {

        }

        public Student(string surname, string name, string point)
        {
            Surname = surname;
            Name = name;
            Point = point;
        }

        public static Student EnterStudent()
        {
            Console.Write("Введите фамилию студента: ");
            string surname = CheckString(20, "Фамилия");
            Console.Write("Введите имя студента: ");
            string name = CheckString(15, "Имя");
            Console.Write("Через пробел введите 3 оценки студента: ");
            string point = CheckPoint();

            return new Student(surname, name, point);
        }

        public static string CheckString(int p, string temp)
        {
            while (true)
            {
                try
                {
                    string txt = Console.ReadLine();
                    if (txt.Length > p) throw new Exception("Повторите ввод: ");
                    return txt;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("{0} содержит не более {1} символов. {2}", temp, p, ex.Message);
                    continue;
                }
            }
        }

        public static string CheckPoint()
        {
            while (true)
            {
                try
                {
                    string txt = Console.ReadLine();
                    string[] temp = txt.Split(' ');
                    txt = "";
                    for (int i = 0; i < 3; i++)
                    {
                        if (!Int32.TryParse(temp[i], out int x) || temp[i].Length > 1 || x > 5 || x < 1) throw new Exception("Оценки должны содержать только целые цифры от 1 до 5. Повторите ввод: ");
                        else
                        {
                            txt += temp[i] + " ";
                        }
                    }
                    return txt;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
            }

        }
    }
}
