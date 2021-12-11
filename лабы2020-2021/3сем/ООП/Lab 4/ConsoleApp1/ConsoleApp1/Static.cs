using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    static class StaticOperation
    {
        public static string Doots(this string d)//метод расширения
        {
            string res = d.Replace(" ", ".");
            return res;
        }
        
        public static Set<int> DeleteTheNull(this Set<int> d)
        {
            bool flag = false;
            foreach (var item in d)
            {
                if (item == 0)
                    flag = true;
            }
            if (flag) d.Remove(0);
            return d;
        }

        public static int GetMaxElement( this Set<int> set1)
        { 
            int maxstr =  -99999999;
            foreach (var item in set1)
            {
                if (item > maxstr)
                {
                    maxstr = item;
                }
            }
            return maxstr;
        }

        public static int GetMinElement( this Set<int> set1)
        {
            int minstr = 99999999;
            foreach (var item in set1)
            {
                if (item < minstr)
                {
                    minstr = item;
                }
            }
            return minstr;
        }
        public static int GetSum( this Set<int> set1)
        {
            int sum = 0;
            foreach (var item in set1)
            {
                sum += item;
            }
            return sum;
        }
        public static int GetDifference(this Set<int> set1)
        {
            int diff = set1.GetMaxElement() - set1.GetMinElement();
            return diff;
        }
        
  
    public static int GetCount(this Set<int> set1)
        {
            int sum = 0;
            foreach (var item in set1)
            {
                sum ++;
            }
            return sum;
        }
    }

    }

