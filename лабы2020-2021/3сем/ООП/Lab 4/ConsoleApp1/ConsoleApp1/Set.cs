using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Owner
    {
        public readonly int id;
        public readonly string name;
        public readonly string organisation;

        public Owner(int id, string name, string organisation)
        {
            this.id = id;
            this.name = name;
            this.organisation = organisation;
        }
        public void Getinfo()
        {
            Console.WriteLine($"\nID: {id} Name: {name} Organization: {organisation}");
        }
    }

    public class Set<T>
    {
        public override string ToString()
        {
            return "{ " + string.Join(", ", _items) + " }";
        }
        public Set(params T[] elements)
        {
            foreach (T el in elements)
                Add(el);
        }

        public readonly Owner owner = new Owner(3, "Alesia", "BSTU");//только вывод
        public readonly Date creationDate = new Date(14, 10, 2020);
       
        public class Date
        {
            private ushort day, month;
            public ushort Day
            {
                get => day;
                set
                {
                    if (value > 31)
                    {
                        day = 31;
                    }
                    else
                    {
                        day = value;
                    }
                }
            }
            public ushort Month
            {
                get => month;
                set
                {
                    if (value > 12)
                    {
                        month = 12;
                    }
                    else
                    {
                        month = value;
                    }
                }
            }
            public int Year { get; set; }

            public Date(ushort day, ushort month, int year)
            {
                Day = day;
                Month = month;
                Year = year;
            }


 

            public override string ToString() => $"{Day}.{Month}.{Year}";

            public override bool Equals(object o)
            {

                if ((o == null) || !GetType().Equals(o.GetType()))
                {
                    return false;
                }
                else
                {
                    var d = (Date)o;
                    return (d.Day == Day) && (d.Month == Month) && (d.Year == Year);
                }
            }
        }


        private List<T> _items = new List<T>();

        public int Count => _items.Count;

        public void Add(T item)
        {
            if (!_items.Contains(item))
            {
                _items.Add(item);
            }
        }


        public void Remove(T item)
        {
            _items.Remove(item);
        }

        //определение Set<T> для функций
        public static Set<T> Union(Set<T> set1, Set<T> set2)//объединение
        {
            var resultSet = new Set<T>();

            var items = new List<T>();
            if (set1._items != null && set1._items.Count > 0)
            {
                items.AddRange(new List<T>(set1._items));
            }
            if (set2._items != null && set2._items.Count > 0)
            {
                items.AddRange(new List<T>(set2._items));
            }
            resultSet._items = items.Distinct().ToList();
            return resultSet;
        }

        public static Set<T> Intersection(Set<T> set1, Set<T> set2) //пересечение и
        {
            var resultSet = new Set<T>();

            if (set1.Count < set2.Count)
            {
                foreach (var item in set1._items)
                {
                    if (set2._items.Contains(item))
                    {
                        resultSet.Add(item);
                    }
                }
            }
            else
            {
                foreach (var item in set2._items)
                {
                    if (set1._items.Contains(item))
                    {
                        resultSet.Add(item);
                    }
                }
            }
            return resultSet;
        }


        public static bool Subset(Set<T> set1, Set<T> set2)//подмножество
        {
            bool result = set1._items.All(s => set2._items.Contains(s));
            return result;
        }

        //открытое определение экземпляра SET
        public IEnumerator<T> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        public static Set<T> operator -(Set<T> list, T item)
        {
            list.Remove(item);
            return list;
        }
        public static Set<T> operator &(Set<T> list1, Set<T> list2)
        {
            var resultSum = new Set<T>();
            resultSum = Set<T>.Union(list1, list2);
            return resultSum;
        }
        public static Set<T> operator *(Set<T> list1, Set<T> list2)
        {
            var resultSum = new Set<T>();
            resultSum = Set<T>.Intersection(list1, list2);
            return resultSum;
        }

 /*public static Set<T> operator -(Set<T> list, T item)
        {
            list.Remove(item);
            return list;
        }*/

        public static bool operator >(Set<T> list1, Set<T> list2)
        {
            return (list1.Count > list2.Count);
              
        }

        public static bool operator <(Set<T> list1, Set<T> list2)
        {
                // Проверяем входные данные на пустоту.
                if (list1 == null)
                {
                    throw new ArgumentNullException(nameof(list1));
                }

                if (list2 == null)
                {
                    throw new ArgumentNullException(nameof(list2));
                }

                // Перебираем элементы первого множества.
                // Если все элементы первого множества содержатся во втором,
                // то это подмножество. Возвращаем истину, иначе ложь.
                var result = list2._items.All(s => list1._items.Contains(s));
                return result;
        }

    }

}
