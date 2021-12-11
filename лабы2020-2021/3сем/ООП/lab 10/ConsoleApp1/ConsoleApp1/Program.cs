using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаба_10
{
    
    class Program
    {
        static void Changed(object sender, NotifyCollectionChangedEventArgs e)
        {
            Console.WriteLine("эта штука работает");
        }
        static void Main(string[] args)
        {
           Collection workerss = new Collection();

           Worker[] workers = new Worker[]
           {
                new Worker("Alisa"),
                new Worker("Vika"),
                new Worker("Chris"),
                new Worker("Liz")
           };
            
           foreach(var i in workers)
                    Console.WriteLine(i.ToString());

            Worker worker = new Worker("Pitr", 2000);
            workerss.Add(worker);

            workerss.DelElement(workers[1]);

            Console.WriteLine(workerss.OutCollection());

            //хранение в виде хэш-таблицы
            Hashtable hashtable = new Hashtable();
           

            hashtable.Add(0, "hello");
            hashtable.Add(1, "hello1");
            hashtable.Add(2, "hello2");
            hashtable.Add(3, 300);
            hashtable.Add(4, 400);
            hashtable.Add(5, 500);
            hashtable.Add(6, 600);
            hashtable.Add(7, 700);
            hashtable.Add(8, 800);
            foreach (DictionaryEntry i in hashtable)
            {
               Console.WriteLine("Key = {0}, Value = {1}", i.Key, i.Value);
            }
            hashtable.Remove(4);
            hashtable.Remove(5);
            hashtable.Remove(6);
            
            Stack stack = new Stack();  

            foreach (DictionaryEntry i in hashtable)
            {
                stack.Push(i.Value);
            }

            foreach(var i in stack)
            {
                Console.WriteLine(i.ToString());
            }
            foreach (object i in stack)
            {
                if(i.ToString() == (300).ToString())
                Console.WriteLine("Value = " + i.ToString());
            }
            Console.WriteLine("Задание 3------------------------------------------------------------------");
            //похож на список List за тем исключением, что позволяет известить внешние объекты о том, что коллекция была изменена.
            ObservableCollection<Worker> collection = new ObservableCollection<Worker>();

            collection.CollectionChanged += Changed;
            collection.Add(new Worker("name1"));

            Worker w0 = new Worker("name2");
            collection.Add(w0);

            Worker w1 = new Worker("name3");
            collection.Add(w1);

            collection.Remove(w1);

            foreach (Worker worker0 in collection)
            {
                Console.WriteLine(worker0);
                Console.WriteLine();
            }

            Console.ReadKey();
        }

    }
}
