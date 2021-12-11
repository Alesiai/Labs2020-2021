using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace _13
{
    class Program
    {
        static object monitor = new object();
        static void Main(string[] args)
        {
            Thread oddThread = new Thread(Odd);
            Thread evenThread = new Thread(Even);

            oddThread.Start();
            Thread.Sleep(100);

            evenThread.Start();
            Thread.Sleep(100);
            //Console.OutputEncoding = System.Text.Encoding.UTF8;
            //try
            //{
            //    IAADisKInfo.DiskInfo();
            //    IAAFileInfo.FileInfo();
            //    IAADirInfo.DirInfo();
            //    IAAFileManager.Manager("D:\\");
            //    IAALog.CloseStream();
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //    Console.WriteLine(e.StackTrace);
            //}
        }

        static void Odd()
        {
            lock (monitor)
            {
                for (int i=1; i<=10; i = i + 2)
                {
                    Console.WriteLine($"{i}-");
                }
            }
        }
        static void Even()
        {
            lock (monitor)
            {
                for (int i = 0; i <= 10; i = i + 2)
                {
                    Console.WriteLine($"{i}-");
                }
            }
        }
    }
}
