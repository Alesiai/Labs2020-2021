
using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace _13
{
    class IAADirInfo
    {
        public static void DirInfo()
        {
            string dirName = "D:\\Main";

            DirectoryInfo dirInfo = new DirectoryInfo(dirName);

            if (Directory.Exists(dirName))
            {
                IAALog.WriteMessage("Подучение информации о папке", dirInfo.Name, dirInfo.FullName);
                Console.WriteLine($"Название каталога: {dirInfo.Name}");
                Console.WriteLine($"Полное название каталога: {dirInfo.FullName}");
                Console.WriteLine($"Время создания каталога: {dirInfo.CreationTime}");
                Console.WriteLine($"Корневой каталог: {dirInfo.Root}");
                Console.WriteLine($"Количество файлов: {dirInfo.GetFiles().Length}");
                Console.WriteLine($"Количество каталогов: {dirInfo.GetDirectories().Length}");

                Console.WriteLine("Подкаталоги:");
                string[] dirs = Directory.GetDirectories(dirName);
                foreach (string s in dirs)
                {
                    Console.WriteLine(s);
                }
                Console.WriteLine();
                Console.WriteLine("Файлы:");
                string[] files = Directory.GetFiles(dirName);
                foreach (string s in files)
                {
                    Console.WriteLine(s);
                }
            }
            else
            {
                IAALog.WriteMessage("Поиск файла - Файл отсутствует");
                Console.WriteLine("File is not found!" + "\n");
            }
        }
    }
}
