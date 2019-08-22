using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    class Program
    {

        static void Print (List<Students> sList)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(sList[i].surname + " " + sList[i].name + " " + sList[i].univercity + " " + sList[i].faculty + " " + sList[i].departament + " " + sList[i].age + " " + sList[i].level + " " + sList[i].non + " " + sList[i].city);
            }
        }

        static void Main(string[] args)
        {
            List<Students> sList = Students.ListGeneric();
            Console.WriteLine("Количество студентов, учащихся на 5 и 6 курсе: {0}", Students.Number_5_6(sList));
            Students.Couting_18_20(ref sList);
            Console.WriteLine("Началась сортировка коллекции по возрасту студентов...");
            sList.Sort(Students.CompareDate);
            Console.WriteLine("\nСортировка коллекции по возрасту студентов выполнена\nСписок первых 10 самых молодых студентов: ");
            Print(sList);

            Console.WriteLine("\n\nНачалась сортировка коллекции по курсу и возрасту студентов...");
            Students.SortDateLevel(sList);
            Console.WriteLine("\nСортировка коллекции по курсу и возрасту студентов выполнена\nСписок первых 10 самых молодых студентов 1 курса: ");
            Print(sList);

            Console.ReadKey();
        }
    }
}
