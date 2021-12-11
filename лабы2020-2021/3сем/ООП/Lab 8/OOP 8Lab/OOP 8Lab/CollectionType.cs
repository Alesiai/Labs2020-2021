using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace лаба_8
{
    class CollectionType<T> : Interface<T> where T : new()
    {
        private List<T> elements = new List<T>();

        public T GetElem(int i)
        {
            return elements[i];
        }

        public void RemoveEl(T item) //удаление элемента
        {
            elements.Remove(item);
        }
        public void Add(params T[] item) //добавление элемента
        {
            foreach (T i in item)
                if (!elements.Contains(i))
                {
                    elements.Add(i);
                }
        }
        public void Print()       //вывод массива
        {
            foreach (T str in this.elements)
            {
                Console.Write(str + " ");
            }
            Console.WriteLine();
        }
        public void WriteToFile(string path = @"D:\temp\file.txt")
        {
            StreamWriter writer = new StreamWriter(path);
            if (writer == null)
                throw new Exception("Файл не открылся");

            foreach(T i in elements)
                writer.WriteLine(i);

            writer.Close();
        }

        static public string[] ReadFromFile(string path = @"D:\temp\file.txt")
        {
            StreamReader reader = new StreamReader(path);
            if (reader == null)
                throw new Exception("Файл не открылся");

            List<string> line = new List<string>();
            
            while (!reader.EndOfStream)
            {
                line.Add(reader.ReadLine());

            }
            reader.Close();
            string[] str = new string[line.Count];
            int i = 0;
            foreach(string j in line)
            {
                str[i] = j;
                i++;
            }
            return str;
        }
        public IEnumerator<T> GetEnumerator()   //перебор элементов
        {
            return elements.GetEnumerator();
        }
        public int Count => elements.Count(); //записывает в Count количество элементов
        public static CollectionType<T> Intersection(CollectionType<T> obj1, CollectionType<T> obj2) //пересечение
        {
            var resultCollectionType = new CollectionType<T>();

            if (obj1.Count < obj2.Count)
            {
                foreach (var item in obj1.elements)
                {
                    if (obj2.elements.Contains(item))
                    {
                        resultCollectionType.Add(item);
                    }
                }
            }
            else
            {
                foreach (var item in obj2.elements)
                {
                    if (obj1.elements.Contains(item))
                    {
                        resultCollectionType.Add(item);
                    }
                }
            }
            return resultCollectionType;
        }

        public static bool Check(CollectionType<T> obj1, CollectionType<T> obj2) //Проверка на подмножество
        {

            byte schet = 0;

            foreach (var item in obj1.elements)
            {
                if (obj2.elements.Contains(item))
                {
                    schet++;
                }
            }

            if (schet == obj2.Count)
                return true;
            else
                return false;
        }
        public static bool Comparison(CollectionType<T> obj1, CollectionType<T> obj2) //сравнение
        {
            bool check = false;
            if (obj1.Count == obj2.Count)
            {
                foreach (var item in obj1.elements)
                {
                    if (obj2.elements.Contains(item))
                    {
                        check = true;
                    }
                    else
                        check = false;
                }
            }
            return check;
        }
        public static CollectionType<T> Union(CollectionType<T> obj1, CollectionType<T> obj2)//объединение
        {
            var resultCollectionType = new CollectionType<T>();

            var items = new List<T>();
            if (obj1.elements != null && obj1.elements.Count > 0)
            {
                items.AddRange(new List<T>(obj1.elements));
            }
            if (obj2.elements != null && obj2.elements.Count > 0)
            {
                items.AddRange(new List<T>(obj2.elements));
            }
            resultCollectionType.elements = items.Distinct().ToList();
            return resultCollectionType;
        }
       

        public static CollectionType<T> operator -(CollectionType<T> list, T item)    //удаление элемента
        {
            list.RemoveEl(item);
            return list;
        }

        public static CollectionType<T> operator *(CollectionType<T> list1, CollectionType<T> list2)     //пересечение множеств
        {
            return Intersection(list1, list2);
        }

        public static CollectionType<T> operator &(CollectionType<T> list1, CollectionType<T> list2) //объединение множеств
        {
            return Union(list1, list2);
        }

        public static bool operator <(CollectionType<T> list1, CollectionType<T> list2) //сравнение множеств
        {
            return Comparison(list1, list2);
        }
        public static bool operator >(CollectionType<T> list1, CollectionType<T> list2) //проверка на подмножество
        {
            return Check(list1, list2);
        }

        public class Owner
        {
            int id;
            string name;
            string organiz;
            public Owner(int id, string name, string organiz)
            {
                this.id = id;
                this.name = name;
                this.organiz = organiz;
            }
        }
        public readonly Owner owner = new Owner(1, "Alesia", "BSTU");

        public class Date
        {
            DateTime date = DateTime.Today;

            public override String ToString()
            {
                return date.ToShortDateString();
            }
        }

        public readonly Date date = new Date();
    }

}
