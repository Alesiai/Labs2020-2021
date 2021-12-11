using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace лаба_8
{
    static class OperationExpension
    {
        public static string AddPoint(this string d)//метод расширения(добавление точки в конце строки)
        {
            return d +='.';
        }
        public static string DeletePoint(this string d) 
        {
            string str = d;
            for (int i = 0; i<str.Length; i++)
            {
                if (str[i] == '.')
                {
                    
                     str = str.Replace(".", "!");
                }
            }
            return d;
        }
        public static CollectionType<int> RemoveNull(CollectionType<int> list) //удаление нулевых элементов
        {
            list.RemoveEl(0);
            return list;
        }

        public static int Sum(CollectionType<int> list1, CollectionType<int> list2)
        {
            int sum = 0;
            foreach(var item in list1)
            {
                sum += item;            
            }
            foreach(var item in list2)
            {
                sum += item;
            }            
            return sum;
        }

        public static int GetMaxElement(CollectionType<int> CollectionType1)
        {
            int maxstr = CollectionType1.GetElem(0);
            foreach (var item in CollectionType1)
            {
                if (item > maxstr)
                {
                    maxstr = item;
                }
            }
            return maxstr;
        }

        public static int GetMinElement(CollectionType<int> CollectionType1)
        {
            int minstr = CollectionType1.GetElem(0);
            foreach (var item in CollectionType1)
            {
                if (item < minstr)
                {
                    minstr = item;
                }
            }
            return minstr;
        }
    }
}
