using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

//Класс Login с конструктором и методами проверки корректности
//Проверку на первый символ вынес отдельно от проверки на отсутствие русских букв специально, для некоего логирования.
//В случае некорректного ввода на консоль выводится причина отказа в логировании
//Основных метода 2: проверка без использования регулярных выражений и с ихиспользованием.

namespace Correctness_check
{
    class Login
    {
        string login;

        public Login()
        {

        }

        public Login (string login)
        {
            this.login = login.ToLower();
        }

        internal bool Check()
        {
            Console.WriteLine("Проверка корректности логина БЕЗ использования регулярных выражений");
            if (CheckLength() & CheckLetter() & CheckNotNumber())
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Логин принят");
                return true;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Некоректный ввод.");
                return false;
            }
        }

        internal void CheckRegular()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Проверка корректности логина C использованием регулярных выражений");
            Regex regex = new Regex(@"[a-z]{1}[a-z0-9]{1,9}");
            if (regex.IsMatch(login))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Логин принят");
             }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Некоректный ввод. Повторите попытку: ");
             }
        }

        private bool CheckLength()
        {
            if (login.Length >= 2 & login.Length <= 10)
                return true;
            else
            {
                Console.WriteLine("Длинна не соответствует");
                return false;
            }
        }

        private bool CheckLetter()
        {
            int j = 0;
            foreach (var i in login)
            {
                if (i >= 'a' & i <= 'z')
                    j++;
                if (i >= '0' & i <= '9')
                    j++;
            }
            if (j == login.Length)
                return true;
            else
            {
                Console.WriteLine("Не только латинские буквы и цифры");
                return false;
            }
        }

        private bool CheckNotNumber()
        {
            if (Char.IsDigit(login[0]))
            {
                Console.WriteLine("Первый символ НЕ буква");
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
