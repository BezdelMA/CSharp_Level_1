using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Исполнил Бездель М.А.
//По сериализации вопросов нет, как делать понял

namespace Serialization
{
    //Создание публичного класса Студентов
    [Serializable]
    public class Students
    {
        public string surname, name, univercity, faculty, departament;
        public int age, level, groupe;
        public string city;

        //Конструктор по умолчанию
        public Students()
        {

        }

        //Конструктор создания нового экземпляра класса
        public Students(string surname, string name, string univercity, string faculty, string departament, int age, int level, int groupe, string city)
        {
            this.surname = surname;
            this.name = name;
            this.univercity = univercity;
            this.faculty = faculty;
            this.departament = departament;
            this.age = age;
            this.level = level;
            this.groupe = groupe;
            this.city = city;
        }

        //Метод открытия файла и расфосовки его по полям класса
        public static List <Students> OpenFile()
        {
            Console.WriteLine("Открытие файла началось...");
            List<Students> sList = new List<Students>();
            StreamReader sr = new StreamReader(@"students.csv");
            string temp = sr.ReadToEnd();
            char[] delim = new char[] { ';', ',', '.', '\r', '\n' };
            string[] tmp = temp.Split(delim, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; (i + 9) < tmp.Length;)
            {
                sList.Add(new Students(tmp[i], tmp[i + 1], tmp[i + 2], tmp[i + 3], tmp[i + 4], Convert.ToInt32(tmp[i + 5]), Convert.ToInt32(tmp[i + 6]), Convert.ToInt32(tmp[i + 7]), tmp[i + 8]));
                i += 9;
            }
            Console.WriteLine("Файл успешно загружен");
            return sList;
        }

        //Метод сериализации коллекции List в формат *.xml
        public static void Serializations (string fileName, List <Students> obj)
        {
            Console.WriteLine("Сериализация началась...");
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Students>));
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            xmlFormat.Serialize(fs, obj);
            fs.Close();
            Console.WriteLine("Сериализация успешно завершена");
        }

        //Метод десериализации из формата *.xml в коллекцию List
        public static List<Students> DeSerializations (string fileName)
        {
            Console.WriteLine("Десериализация началась...");
            List<Students> sList = new List<Students>();
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Students>));
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            sList = (List<Students>)xmlFormat.Deserialize(fs);
            Console.WriteLine("Десериализация успешно завершена");
            return sList;
        }
    }
    class Program
    {
        //Демонстрация работы методов
        static void Main(string[] args)
        {
            Students students = new Students();
            List<Students> sList = Students.OpenFile();
            Students.Serializations(@"data.xml", sList);
            List<Students> sList2 = Students.DeSerializations(@"data.xml");
            Console.ReadKey();
        }
    }
}
