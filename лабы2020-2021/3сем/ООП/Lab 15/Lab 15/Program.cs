using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace лаба_15
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("\n------------- Task 1 --------------");

            Process[] AllProcesses = Process.GetProcesses();
            Console.WriteLine(ThreadClass.Process(AllProcesses));
            Console.WriteLine(ThreadClass.InfoDomain());
            Console.WriteLine("Press any key");
            Console.ReadKey();
            try
            {
                Console.WriteLine("\n------------- Task 2 --------------");
                Console.WriteLine("Create new Domain");
                AppDomain newDomain = AppDomain.CreateDomain("NewMyDomain");
                //Создание нового домена
                Console.WriteLine("assembly To Load");
                Assembly assemblyToLoad = Assembly.LoadFrom("ClassLibrary1.dll");

                //Загрузка сборки в новый домен
                newDomain.Load(assemblyToLoad.FullName);
                Console.WriteLine("assembly UnLoad");
                //Выгрузка домена
                AppDomain.Unload(newDomain);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            try
            {

                //3. Создайте в отдельном потоке следующую задачу расчета (можно сделать sleep для
                //задержки) и записи в файл и на консоль простых чисел от 1 до n(задает пользователь).
                //Вызовите методы управления потоком(запуск, приостановка, возобновление и т.д.) Во
                //время выполнения выведите информацию о статусе потока, имени, приоритете, числовой
                //идентификатор и т.д.
                Console.WriteLine("Press any key");
                Console.ReadKey();
                //NumbersThread.Suspend();               
                //NumbersThread.Resume();                
                Console.WriteLine("--------- Task 3 ----------");
                Thread thread = new Thread(new ParameterizedThreadStart(ThreadClass.PrimeNumbers));
                thread.Name = "OutPrimeNumbers";
                thread.Start(1000);
                Console.WriteLine("Its priority: " + thread.Priority);
                Thread.Sleep(100);
                Console.WriteLine("Its name: " + thread.Name);
                Thread.Sleep(100);
                Console.WriteLine("Its ID: " + thread.ManagedThreadId);
                Thread.Sleep(1000);
               
                thread.Abort();
                Console.WriteLine("Press any key");
                Console.ReadKey();
                //4.Создайте два потока. Первый выводит четные числа, второй нечетные до n и
                //записывают их в общий файл и на консоль. Скорость расчета чисел у потоков – разная.
                //a.Поменяйте приоритет одного из потоков.
                //b.Используя средства синхронизации организуйте работу потоков, таким образом,
                //чтобы
                //i.выводились сначала четные, потом нечетные числа
                //ii.последовательно выводились одно четное, другое нечетное.
                
                Console.WriteLine("\n------------- Task 4 --------------");

                Console.WriteLine("Consistently:");
                OddEven.DoItConsistently();
                Console.WriteLine("Press any key");
                Console.ReadKey();
                
                
                Console.WriteLine("\nOne by one:");
                OddEven.DoItOneByOne();
                Thread.Sleep(5000);            }
            catch(Exception e)
            {
                Console.WriteLine("Error: " + e.Message);

            }
            Console.WriteLine("Press any key");
            Console.ReadKey();
            //5.Придумайте и реализуйте повторяющуюся задачу на основе класса Timer
            Console.WriteLine("\n------------- Task 5 --------------");
            Console.WriteLine("Timer");
            Console.WriteLine("\nPress any key");
            Console.ReadKey();

            TimerCallback timerCallback = new TimerCallback(WhatTimeIsIt);

            Timer timer = new Timer(timerCallback, null, 0, 1000);   
            
            void WhatTimeIsIt(object obj)
            {
                Console.WriteLine($"It's {DateTime.Now.Hour}:{DateTime.Now.Minute}:{DateTime.Now.Second}");
            }

            Console.WriteLine("\nPress any key for exit");            
            Console.ReadKey();
            Console.ReadKey();
        }
    }
}
