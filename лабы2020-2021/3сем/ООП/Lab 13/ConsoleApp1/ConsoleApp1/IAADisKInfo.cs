using System;
using System.IO;

namespace _13
{
    class IAADisKInfo
    {
        public static void DiskInfo()
        {
            IAALog.WriteMessage("Получение общих сведений о дисках");
            DriveInfo[] drives = DriveInfo.GetDrives(); 

            foreach (DriveInfo drive in drives)
            {
                Console.WriteLine($"Название: {drive.Name}");
                Console.WriteLine($"Тип: {drive.DriveType}");
                Console.WriteLine($"Доступное пространство на диске: {drive.AvailableFreeSpace}");
                Console.WriteLine($"Объем диска: {drive.TotalSize}");
                Console.WriteLine($"Свободное пространство: {drive.TotalFreeSpace}");
                Console.WriteLine($"Метка: {drive.VolumeLabel}");
                Console.WriteLine($"Корневой каталог: {drive.RootDirectory}");
                Console.WriteLine();
            }
        }
    }
}
