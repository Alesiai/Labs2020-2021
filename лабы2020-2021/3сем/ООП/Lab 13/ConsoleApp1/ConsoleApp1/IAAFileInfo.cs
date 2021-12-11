using System;
using System.IO;

namespace _13
{
    class IAAFileInfo
    {
        public static void FileInfo()
        {
            string path = @"D:\Main\note.txt";
            FileInfo fileInf = new FileInfo(path);
            if (fileInf.Exists)
            {
                IAALog.WriteMessage("Получение информации о папке", fileInf.Name, fileInf.FullName);
                Console.WriteLine("Имя файла: {0}", fileInf.Name);
                Console.WriteLine("Время создания: {0}", fileInf.CreationTime);
                Console.WriteLine("Размер: {0}", fileInf.Length);
                Console.WriteLine("Расширение файла: {0}", fileInf.Extension);
                Console.WriteLine("Полный путь: {0}", fileInf.DirectoryName);
                Console.WriteLine();
            }
            else
            {
                IAALog.WriteMessage("Поиск файла - Файл отсутствует");
                Console.WriteLine("File is not found!" + "\n");
            }
        }
    }
}
