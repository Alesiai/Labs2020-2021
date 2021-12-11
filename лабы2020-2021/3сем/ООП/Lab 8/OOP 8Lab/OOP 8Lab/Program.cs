using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace лаба_8
{
    
    class Program
    {
        static void Main()
        {
            CollectionType<int> Arr = new CollectionType<int>();
            CollectionType<int> Arr1 = new CollectionType<int>();

            Arr.Add(1);
            Arr.Add(2);
            Arr.Add(3);
            Arr.Add(4);
            Arr.Add(5);
            Arr.Add(6);
            Arr.Add(7);
            Arr.Add(8, 9, 10);
            Arr.Print();
            Console.WriteLine("\n");
            
            Arr1.Add(1);
            Arr1.Add(2);
            Arr1.Add(4);
            Arr1.Add(5);
            Arr1.Add(6);
            Arr1 -= 5;
            Arr1.Print();
            Arr1.WriteToFile();

            CollectionType<int> Arr2;
            //пересечение
            Arr2 = Arr * Arr1;
            Arr2.Print();
            //объединение
            Arr2 = Arr1 & Arr;
            Arr2.Print();

            string str = "hello";
            str = OperationExpension.AddPoint(str);
            Console.WriteLine(str);
            Console.WriteLine("sum = " + OperationExpension.Sum(Arr, Arr1));

            Console.WriteLine("Сравнение множеств 1<2: " + (Arr < Arr1));
            Console.WriteLine("проверка на подмножество 1 во 2: " + (Arr > Arr1));
            
            int a;
            a = OperationExpension.GetMaxElement(Arr) - OperationExpension.GetMinElement(Arr1);
            Console.WriteLine("разность max и min {0}", a);

            string str1 = "hello.";
            Console.WriteLine(str1);
            str1 = str1.DeletePoint();
            Console.WriteLine("without dot", str1);
            try
            {
                Arr1.Add(4);
                Arr1.Add(Convert.ToInt32("sdkjvs"));
                Arr1.Add(6);
            }
            catch(Exception e)
            {
                Console.WriteLine("error: {0}", e);
            }
            finally
            {
                Console.WriteLine("Проверка окончена");
            }
            CollectionType<int> ReadFileArr = new CollectionType<int>();
            string[] list = CollectionType<int>.ReadFromFile();
            foreach(string i in list)
            {
                try
                {
                    ReadFileArr.Add(Convert.ToInt32(i));
                }
                catch (Exception e)
                {
                    Console.WriteLine("Ошибка записи\n" + e);
                }
            }
            ReadFileArr.Print();

            CollectionType<Plant> plant = new CollectionType<Plant>();
            Plant pl1 = new Plant();
            Plant pl2 = new Plant();
            Plant pl3 = new Plant();
            
            plant.Add(pl1);
            plant.Add(pl2);
            plant.Add(pl3);
            Console.WriteLine (pl1);

            Console.ReadKey();           
        }
    }
}
