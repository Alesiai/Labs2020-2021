using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace лаба_15
{
    class ThreadClass
    {
        public static void PrimeNumbers(object N)
        {                         
            using (StreamWriter file = new StreamWriter("PrimeNumbers.txt"))
            {                
                //Нахождение простых чисел
                for (int i = 2; i <= (int)N; i++)
                {
                    if (IsSimple(i))
                    {
                        Thread.Sleep(100);
                        Console.Write(i.ToString() + ", ");
                        file.WriteLine(i.ToString());
                    }
                }

                file.Close();
            }
            Console.WriteLine("PrimeNumbers stopped");
        }
    
        static bool IsSimple(int N)
            {
            bool tf = false;            
            for (int i = 2; i < (int)(N / 2); i++)
            {
                if (N % i == 0)
                {
                    tf = false;
                    break;
                }
                else
                {
                    tf = true;
                }
            }
            return tf;
        }
        public static void WriteFile(string str, string path = "writer")
        {
            using (StreamWriter writeFile = new StreamWriter(path))
            {
                writeFile.WriteLine(str);
            }
        }
        public static string Process(params Process[] process)
        {
            string str = "";
            
            foreach (Process pr in process)
            {
                try
                {
                        str += "\nID:" + pr.Id.ToString();
                        str += "\nProcessName: " + pr.ProcessName;
                        str += "\nStartInfo" + pr.StartInfo;
                        //str += "\nStartTime" + pr.StartTime;
                        str += "\nBasePriority" + pr.BasePriority;
                        //str += "\nUserProcessorTime" + pr.UserProcessorTime;
                        str += "\nVirtualMemorySize" + (pr.VirtualMemorySize64 / 1048576).ToString();
                        str += "\nPagedMemorySize64" + (pr.PagedMemorySize64 / 1048576).ToString() + "\n";
                }
                catch(Exception e)
                {
                    Console.WriteLine("Ошибка: {0}", e.Message);
                }
                
                
            }            
            return str;
        }
        public static string InfoDomain()
        {
            string str = "\nFriendlyName: " 
                + AppDomain.CurrentDomain.FriendlyName 
                + "\nSetupInformation: " 
                + AppDomain.CurrentDomain.SetupInformation;
            str += "\nAssemblies: ";
            foreach (var x in AppDomain.CurrentDomain.GetAssemblies())
            {
                str += x + "\n";
            }
            return str;
        }        

    }  
}
