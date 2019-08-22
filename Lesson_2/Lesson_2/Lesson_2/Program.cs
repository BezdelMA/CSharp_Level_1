using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Исполнил Бездель М.А.
//Решены все задачи, в том числе со звездочками. Старался все сделать красиво.
//После выполнения выбранной программы снова появляется Меню, пока не будет нажата кнопка выхода
//Везде добавлены проверки на корректный ввод данных (чисел), в том числе в Меню
//Постарался сделать качественно
namespace Lesson_2
{
    class Program
    {
        public static List<int> iList = new List<int>();

        private static bool Password()
        {
            bool bl;
            int i = 3;

            do
            {
                if (i == 0)
                    break;
                else
                {
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("\nВведите логин и пароль для запуска программы\n");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Внимание!!! Количество оставшихся попыток: {0}.\nВведите логин: ", i);
                    string user = Console.ReadLine();
                    user = user.ToLower();
                    Console.Write("Введите пароль: ");
                    string password = Console.ReadLine();
                    bl = Check(user, password);
                    i--;
                }
            }
            while (!bl);
            Console.Clear();
            if (i > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Пароль принят. Для продолжения нажмите любую клавишу");
                Pause();
                return true;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Ошибка! Вы не прошли идентификацию!");
                Pause();
                return false;
            }
        }

        private static bool Check(string user, string password)
        {
            if (user == "root" & password == "GeekBrains")
                return true;
            else return false;
        }

        private static void Menu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Введите номер программы из списка для запуска\n");
            Console.WriteLine("1. Поиск наименшего из трех чисел");
            Console.WriteLine("2. Подсчет количества цифр в числе");
            Console.WriteLine("3. Подсчет суммы положительных нечетных введенных Вами чисел");
            Console.WriteLine("4. Рассчет индекса массы тела и рекомендации по изменению веса");
            Console.WriteLine("5. Подсчет количества «хороших» чисел в диапазоне от 1 до 1 000 000 000");
            Console.WriteLine("6. Рекурсивный метод");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("\nДля выхода нажмите клавишу «0»");
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void Pause()
        {
            Console.ReadKey();
        }

        static void Main(string[] args)
        {
            Console.Title = "Lesson 2";
            int vvod;
            bool bl;
            bool pass = Password();
            Console.ForegroundColor = ConsoleColor.White;
            if (pass == true)
            {
                do
                {
                    do
                    {
                        Menu();
                        bl = Int32.TryParse(Console.ReadLine(), out vvod);
                    }
                    while (!bl);
                    switch (vvod)
                    {
                        case 1:
                            Min();
                            break;
                        case 2:
                            CountNumber();
                            break;
                        case 3:
                            Summa();
                            break;
                        case 4:
                            IMT();
                            break;
                        case 5:
                            GoodNumber();
                            break;
                        case 6:
                            Recursiv();
                            break;
                        case 0:
                            break;
                    }
                }
                while (vvod != 0);
            }
            else
            {
                Console.Clear();
                Console.Write("Для выхода нажмите любую клавишу");
                Pause();
            }
        }

        private static void Min()
        {
            Console.Clear();
            Console.WriteLine("Программа по поиску минимального из введенных трех чисел");
            int[] mass = new int[3];
            for (int i = 0; i <3; i++)
            {
                bool bl;
                int x;
                string txt = "";
                do
                {
                    Console.WriteLine("{0} Введите {1} число: ", txt, i + 1);
                    bl = Int32.TryParse(Console.ReadLine(), out x);
                    txt = "ОШИБКА!!!";
                }
                while (bl != true);

                mass[i] = x;
            }
            Enumeration("Введенные Вами числа: ");

            void Enumeration (string text)
            {
                string str = text;
                foreach (int i in mass)
                {
                    str += i + "; ";
                }
                Console.WriteLine(str);
            }
            Array.Sort(mass);
            Enumeration("Отсортированный массив: ");
            Console.WriteLine("Наименьшее введенное Вами число: {0}", mass[0]);
            Pause();
        }

        private static void CountNumber()
        {
            int i;
            int vvod;
            bool bl;
            Console.Clear();

            do
            {
                Console.Write("Введите число: ");
                bl = Int32.TryParse(Console.ReadLine(), out vvod);
            }
            while (bl != true);

            if (vvod < 0)
            {
                vvod *= -1;
            }

            for (i = 1; ; )
            {
                vvod /= 10;
                if (vvod < 1) break;
                i++;
            }
            Console.Write("Количество цифр в введенном Вами числом равно: {0}", i);
            Pause();
        }

        private static void Summa()
        {
            int i = 1;
            int summ = 0;
            int number;
            bool bl;
            List<int> iList = new List<int>();

            Console.Clear();
            do
            {
                do
                {
                    Console.WriteLine("Введите {0} число. Для выхода введите «0»", i);
                    bl = Int32.TryParse(Console.ReadLine(), out number);
                }
                while (bl != true);
                i++;
                if (number > 0 && number%2 == 1)
                {
                    iList.Add(number);
                    summ += number;
                }
            }
            while (number != 0);

            Console.WriteLine("Колличество введенных чисел: {0}.", i-1);
            string txt = "Положительные и нечетные числа: ";
            foreach (int num in iList)
            {
                txt += num + "; ";
            }
            Console.WriteLine(txt);
            Console.WriteLine("Сумма положительных и нечетных чисел равна: {0}", summ);
            Pause();
        }

        private static void IMT()
        {
            Console.Clear();
            double wieght = CheckNumber("вес в килограммах");
            double growth = CheckNumber("рост в сантиметрах")/100;
            double indexMass = wieght / (Math.Pow(growth, 2));
            Console.Clear();
            Console.WriteLine("Ваш вес: {0} килограмм, Ваш рост: {1} метра.\nИндекс массы тела: {2:F2}", wieght, growth, indexMass);
            CheckIndex(wieght, growth, indexMass);
            Pause();
        }

        private static void CheckIndex(double wieght, double growth, double indexMass)
        {
            double wieghtMax = 24.99 * (Math.Pow(growth, 2));
            double wieghtMin = 18.5 * (Math.Pow(growth, 2));
            if (indexMass >= 18.5 & indexMass <= 24.99)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Ваше тело не требует изменений");
            }
            else if (indexMass < 18.5)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Ваш вес НЕ в норме. Нормальный вес должен находится в пределах от {0:F2} до {1:F2}\nВам необходимо набрать минимум {2:F2} килограмм", wieghtMin, wieghtMax, wieghtMin - wieght);
            }
            else if (indexMass > 24.99)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Ваш вес НЕ в норме. Нормальный вес должен находится в пределах от {0:F2} до {1:F2}\nВам необходимо скинуть минимум {2:F2} килограмм", wieghtMin, wieghtMax, wieght - wieghtMax);
            }
        }

        private static double CheckNumber(string txt)
        {
            bool bl;
            double x;
            do
            {
                string error = "";
                Console.Write("{0} Введите Ваш {1}: ", error, txt);
                bl = double.TryParse(Console.ReadLine(), out x);
                if (bl == false) error += "ОШИБКА!!!";
            }
            while (!bl);
            return x;
        }

        private static void GoodNumber()
        {
            Console.Clear();
            int sum = 0;
            int k = 0;
            int j;
            DateTime timeStart = DateTime.Now;
            Console.Write("Программа выполняется. Ждите...");
            for (int i = 1; i <= 1000000000; i++)
            {
                j = i;
                sum = 0;
                do
                {
                    sum += j % 10;
                    j /= 10;
                }
                while (j >= 1);

                if (i % sum == 0)
                {
                    k++;
                }
            }
            DateTime timeFinish = DateTime.Now;
            TimeSpan time = timeFinish - timeStart;
            Console.Clear();
            Console.WriteLine("Количество «хороших» чисел в диапазоне от 1 до 1 000 000 000 равно: {0}.\nВремя выполнения программы: {1}", k, time);
            Pause();
        }

        private static void Recursiv()
        {
            Console.Clear();
            int a = ChekNumberRecursive("Введите первое число: ");
            int b;
            do
            {
                b = ChekNumberRecursive("Введите Второе число. ВНИМАНИЕ!!! Оно должно быть больше " + a + ": ");
            }
            while (a >= b);
            RecursiveMake(a, b);
            Pause();
        }

        private static int ChekNumberRecursive(string txt)
        {
            bool bl;
            int x;
            do
            {
                Console.Write(txt);
                bl = Int32.TryParse(Console.ReadLine(), out x);
            }
            while (!bl);
            return x;
        }

        private static void RecursiveMake(int a, int b)
        {
            iList.Add(a);
            int sum = 0;
            Console.Write(a + ", ");
            a++;
            if (a<=b)
            {
                RecursiveMake(a, b);
            }
            else
            {
                foreach (var i in iList)
                {
                    sum += i;
                }
                Console.Write("\nСумма перечисленных чисел равна: {0}", sum);
            }
        }

    }
}
