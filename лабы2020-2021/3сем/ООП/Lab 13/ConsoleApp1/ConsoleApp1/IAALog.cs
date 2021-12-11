
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace _13
{
    class IAALog
    {
        static StreamWriter writer;
        static IAALog()
        {
            string Path = @"D:\IAA_Log.txt";
            writer = new StreamWriter(Path, true);
        }

        public static void WriteMessage(string Event, string FileName, string Way)
        {
            writer.WriteLine(Event);
            writer.WriteLine("Work in File: " + FileName);
            writer.WriteLine("Location: " + Way);
            writer.WriteLine("Time: " + DateTime.Now + "\n");
        }

        public static void WriteMessage(string Event)
        {
            writer.WriteLine(Event);
            writer.WriteLine("Time: " + DateTime.Now + "\n");
        }

        public static void CloseStream()
        {
            writer.Close();
        }
    }
}