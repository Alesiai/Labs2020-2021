//Класс множество Set.Дополнительно перегрузить
//следующие операции: - удалить элемент из множества
//(типа set-item); * пересечение множеств; < сравнение
//множеств; > проверка на подмножество; & придумайте
//использование.
//Методы расширения:
//1) Добавление точки в конце строки
//2) Удаление нулевых элементов из множества


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
        {
        static void Main(string[] args)
        {
            Console.WriteLine("Первое множество");
            Set<int> myList1 = new Set<int>();
            for (int i = 0; i < 15; i++)
            {
                myList1.Add(i);
            }
            Console.WriteLine(myList1);

            Console.WriteLine("\nВторое множество");
            Set<int> myList2 = new Set<int>(1, 2, 3, 4);
            Console.WriteLine(myList2);
            

            Console.WriteLine("\nУдалили 4 из 2-го множества");
            myList2 -= 4;
            Console.WriteLine(myList2);

            Set<int> myList3 = new Set<int>();

            Console.WriteLine("\nпересечение множеств");
            myList3 = myList2 * myList1;
            Console.WriteLine(myList3);

            Console.WriteLine("\nобъединение множеств (что-то для &)");
            myList3 = myList2 & myList1;
            Console.WriteLine(myList3);

            if (myList1 > myList2)
                Console.WriteLine("\n1-е множество больше второго");
            else
                Console.WriteLine("\n2-е множество больше второго");

            if (myList1 < myList2)
                Console.WriteLine("\nв 1-м множество есть второе подмножество");
            else
                Console.WriteLine("\nв 1-м множество нет второго подмножества");


            myList1.owner.Getinfo();
            Console.WriteLine(myList1.creationDate);

            Console.WriteLine($"\nМакс эл-т 1-го мн-ва: {myList1.GetMaxElement()}");
            Console.WriteLine($"Мин эл-т 1-го мн-ва: {myList1.GetMinElement()}");
            Console.WriteLine($" Разница между минимальным и максимальным эл-ми 1-го мн-ва: {myList1.GetDifference()}");
            Console.WriteLine($"\nСумма эл-в 1-го мн-ва: {myList1.GetSum() }");
            Console.WriteLine($"\nКоличество эл-в 1-го мн-ва: {myList1.GetCount() }");
            Console.WriteLine("\nУдалили ноль:");
            myList1.DeleteTheNull();
            Console.WriteLine(myList1);

            string testString = "one two three";
            Console.WriteLine( "\nСтрока: "+ testString + "\nРазбили точками: "+testString.Doots());
            
            Console.ReadKey();
            
        }
        }
}
