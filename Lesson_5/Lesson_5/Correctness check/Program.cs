using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Программа на проверку введенного логина. Все условия соблюдены, программа работает
//В том числе, производится проверка с использованием регулярных выражений

namespace Correctness_check
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Внимание!!! Логин должен содержать от 2 до 10 символов\nсодержать буквы только латинского алфавита и цифры,\nпри этом цифра не может быть первой\n");
            bool flag = false;
            while (!flag)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\nВведите логин: ");
                Login login = new Login(Console.ReadLine());
                flag = login.Check();
                login.CheckRegular();
            }
            Console.ReadKey();
        }
    }
}
