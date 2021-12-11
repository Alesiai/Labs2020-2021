using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Лаба_11
{  
    class Program
    {
        static void Main(string[] args)
        {
            //Задайте массив типа string, содержащий 12 месяцев (June, July, May,
            //December, January ….). Используя LINQ to Object напишите запрос выбирающий
            //последовательность месяцев с длиной строки равной n, запрос возвращающий
            //только летние и зимние месяцы, запрос вывода месяцев в алфавитном порядке,
            //запрос считающий месяцы содержащие букву «u» и длиной имени не менее 4 - х..
                
            string[] monthes = { "January", "February", "March", "April", "May", "June", "July", "August", 
                "September", "October", "November", "December" };

            var select1 = from i in monthes
                          where i.Length == 4
                          select i;
            Console.WriteLine("4 month long: ");
            foreach (string i in select1)
                Console.WriteLine(i);
            
            string[] summer_winterMonthes = { "December", "January", "February", "June", "July", "August" };
            var select2 = from i in monthes
                          where monthes.Contains(i)
                          select i;
           
            Console.WriteLine("\nwinter  and summer consist of: ");
            foreach (string i in select2)
                Console.WriteLine(i);
            
            
            Console.WriteLine("\nmounth in ABC: ");
            var select3 = from i in monthes
                          orderby i
                          select i;
            foreach (string i in select3)
                Console.WriteLine(i);
            
             Console.WriteLine("\nmounth with a 'u' and longer than 4: ");
            var select4 = from i in monthes
                          where i.Contains("u") && i.Length >= 4
                          select i;
            foreach (string i in select4)
                Console.WriteLine(i);

            //Создайте коллекцию List<T> и параметризируйте ее типом(классом)
            //из лабораторной №3(при необходимости реализуйте нужные интерфейсы).
            //Заполните ее минимум 8 элементами.

            List<Customer> customers = new List<Customer>
            {
                new Customer(1, "Jon", 1234),
                new Customer(1, "Jake", 12345),
                new Customer(3, "Pitr", 123456),
                new Customer(4, "Mark", 1234567),
                new Customer(1, "Kevin", 12345678),
                new Customer(6, "Bill", 123456789),
                new Customer(1, "Boss", 1234567890),
                new Customer(8, "Kirill", 234567890),
            };


            //список покупателей в алфавитном порядке;
            //список покупателей, у которых номер кредитной карточки находится в заданном интервале
            //максимального покупателя(критерии определить самостоятельно)
            //первых пять покупателей с максимальной суммой на карте
           
            List<Customer> cust1 = (from i in customers
                                    orderby i 
                                    select i).ToList();
            foreach (var i in cust1)
                Console.WriteLine("CUST: " + i.Name);
           
            List<Customer> cust2 = (from i in customers
                                    where i.NumCurd >= 123456 && i.NumCurd <= 123456789
                                    select i).ToList();
            Console.WriteLine("\n123456 < Num of card < 123456789:");
            foreach (var i in cust2)
                Console.WriteLine("Cust name: " + i.Name + " card number:" +i.NumCurd);


            int maxNumCurd = (from t in customers select t.NumCurd).Max();
            Console.WriteLine("max card number " + maxNumCurd);


            //4. Придумайте и напишите свой собственный запрос, в котором было бы не менее 5 операторов 
            //из разных категорий: условия, проекций, упорядочивания, группировки, агрегирования, 
            //кванторов и разбиения
            
            //условие 
            List<Customer> cust4_1 = (from i in customers
                                      where i.Name == "jon"
                                      select i).ToList();
            //проекция
            var names = customers.Select(u => u.Name);

            //упорядочивание
            List<Customer> cust4_3 = (from i in customers
                                    orderby i.Name descending
                                      select i).ToList();
            //группировка
            var SortedByGroup = from t in customers group t by t.id;
            
            //кванторы     
            int[] numbers = { 10, 9, 8, 7, 6 };
            bool hasTheNumberNine = numbers.Contains(9); // true
            bool hasMoreThanZeroElements = numbers.Any(); // true
            bool hasOddNum = numbers.Any(k => k % 2 == 1); // true
            bool allOddNums = numbers.All(k => k % 2 == 1); // false

            //5. Join
            var result = from i in summer_winterMonthes
                         join m in monthes on i equals m
                         select new {i};

            foreach (var i in result)
                Console.WriteLine("\nmounth with join: " + i);
            Console.ReadKey();
        }
    }
}
