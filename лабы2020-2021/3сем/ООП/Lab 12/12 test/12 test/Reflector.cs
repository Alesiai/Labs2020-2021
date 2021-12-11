using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp1
{
    class Reflector
    {
        //имя сборки Type.GetType
        public static Type GetTypeByString(string name)
        {
            return Type.GetType("ConsoleApp1." + name);
        }

        //есть ли публичные конструкторы методы поля
        public static void ToFile(string ClassName, string name)
        {
            StreamWriter writer = new StreamWriter(@"D:\Main " + name + " .txt");
            Type t1 = GetTypeByString(ClassName);
            writer.WriteLine($"Class {t1.Name}");

            writer.WriteLine("Constructure:");
            foreach (var x in t1.GetConstructors())
            {
                writer.WriteLine(x);
            }
            writer.WriteLine("Methods:");
            foreach (var x in t1.GetMethods())
            {
                writer.WriteLine(x);
            }
            writer.WriteLine("fields:");
            foreach (var x in t1.GetFields())
            {
                writer.WriteLine(x);
            }
            writer.Close();
        }

        //публичные методы
        public static void GetPublicMethods(string ClassName)
        {
            Type t = GetTypeByString(ClassName);
            Console.WriteLine($"Public class methods {t.Name}:");
            foreach (var x in t.GetMethods())
            {
                if (x.IsPublic)
                    Console.WriteLine(x);
            }
            Console.WriteLine();
        }

        //поля и св-ва
        public static void GetField(string ClassName)
        {
            Type t = GetTypeByString(ClassName);
            Console.WriteLine($"Class fields and properties {t.Name}");
            foreach (var x in t.GetFields())
            {
                Console.WriteLine(x);
            }
            Console.WriteLine();
            foreach (var x in t.GetProperties())
            {
                Console.WriteLine(x);
            }
            Console.WriteLine();
        }

        //интерфейсы
        public static void GetInterfaces(string ClassName)
        {
            Type t = GetTypeByString(ClassName);
            Console.WriteLine($"Class interface {t.Name}");
            foreach (var x in t.GetInterfaces())
            {
                Console.WriteLine(x);
            }
            Console.WriteLine();
        }
        //по имени класса имена методов, которые содержат заданный(пользователем) тип параметра
        public static void GetMethodsByParam(string ClassName, string param)
        {
            Type t = GetTypeByString(ClassName);
            Console.WriteLine($"Class method {t.Name} with parametr {param}");
            foreach (var x in t.GetMethods())
            {
                foreach (var y in x.GetParameters())
                {
                    if (y.ParameterType.ToString() == param)
                        Console.WriteLine(x);
                }
            }
            Console.WriteLine();
        }
        
        //2 задание с create
        public static void Create(string ClassName)
        {
            Type t = GetTypeByString(ClassName);
            object obj = Activator.CreateInstance(t);
            Console.WriteLine(obj);
        }

        //метод Invoke
        public static void CallMethodFromFile(string ClassName, string MethodName)
        {
            StreamReader reader = new StreamReader(@"D:\Main params.txt");
            List<string> param = new List<string>();
            while (!reader.EndOfStream)
            {
                param.Add(reader.ReadLine());
            }
            foreach (var x in GetTypeByString(ClassName).GetMethods())
            {
                if (x.Name == MethodName)
                {   

                    x.Invoke(null,param.ToArray());
                }
            }

            reader.Close();
        }
        
    }
}