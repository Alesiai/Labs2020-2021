using System;
using System.IO;
using System.IO.Compression;

namespace _13
{
    class IAAFileManager
    {
        static void Make_Directory(string Way)
        {
            if (!Directory.Exists(Way))
            {
                Directory.CreateDirectory(Way);
            }
        }

        static void Make_File_Write(string Way, DirectoryInfo info)
        {
            StreamWriter writer = new StreamWriter(Way);

            DirectoryInfo[] directories = info.GetDirectories();

            writer.WriteLine("All Directoies of " + info.Name);

            foreach (var item in directories)
            {
                writer.Write(item.Name + " ");
            }
            writer.WriteLine();

            FileInfo[] files = info.GetFiles();

            writer.WriteLine("All Files of " + info.Name);

            foreach (var item in files)
            {
                writer.Write(item.Name + " ");
            }

            writer.Close();
        }

        static void Move_Type(string From, string To, string Type)
        {
            DirectoryInfo directory = new DirectoryInfo(From);
            if (directory.Exists)
            {
                var files = directory.GetFiles();
                foreach (var item in files)
                {
                    if (item.Extension == Type)
                    {
                        File.Copy(item.FullName, To + item.Name, true);
                    }
                }
            }
            else
            {
                Console.WriteLine("Not found way: " + From);
            }
        }

        public static void Manager(string Disk)
        {
            DirectoryInfo dir = new DirectoryInfo(Disk);
            if (dir.Exists)
            {
                string sub_name = Disk + "IAA_Inspect\\";

                Make_Directory(sub_name);
                IAALog.WriteMessage("Создание папки", "IAA_Inspect", sub_name);

                string File_Name = sub_name + "IAA_dirinfo.txt";

                Make_File_Write(File_Name, dir);
                IAALog.WriteMessage("Создание файла", "IAA_dirinfo.txt", File_Name);

                string New_Name = File_Name.Insert(File_Name.Length - 4, "_2");

                File.Copy(File_Name, New_Name, true);
                IAALog.WriteMessage("Создание копии файла", "IAA_dirinfo.txt", File_Name);
                IAALog.WriteMessage("Новый скопированный файл", "IAA_dirinfo_2.txt", File_Name);

                File.Delete(File_Name);
                IAALog.WriteMessage("Удаление файла", "IAA_dirinfo.txt", File_Name);

                string sub_name_2 = Disk + "IAA_Files\\";

                Make_Directory(sub_name_2);
                IAALog.WriteMessage("Создание папки", "IAA_Files", sub_name_2);

                Move_Type(Disk, sub_name_2, ".txt");
                IAALog.WriteMessage("Перемещение файлов определенного типа", Disk, Disk);

                if (!Directory.Exists(sub_name + "IAA_Files\\"))
                {
                    Directory.Move(sub_name_2, sub_name + "IAA_Files\\");
                    IAALog.WriteMessage("Перемещение папки IAA_Files в IAA_Inspect");
                }

                if (!File.Exists(sub_name + "Archive.zip"))
                {
                    ZipFile.CreateFromDirectory(sub_name + "IAA_Files\\", sub_name + "Archive.zip");
                }
                var a = ZipFile.OpenRead(sub_name + "Archive.zip");
                bool Flag = true;
                foreach (var item in a.Entries)
                {
                    if (File.Exists("D:\\IAA_ZIP\\" + item.Name))
                    {
                        Flag = false;
                        break;
                    }
                }
                if (Flag)
                {
                    ZipFile.ExtractToDirectory(sub_name + "Archive.zip", "D:\\IAA_ZIP");
                }
                IAALog.WriteMessage("Работа с архивом");
            }
            else
            {
                Console.WriteLine("Disk " + Disk + " is not ready or find!");
            }
        }
    }
}
