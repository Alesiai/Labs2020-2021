using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаба_10
{
    class Collection : IEnumerator
    {
        List<Worker> elements = new List<Worker>();
        int position = -1;
        public void Add(params Worker[] item) //добавление элемента
        {
             
            foreach (var i in item)
                if (!elements.Contains(i))
                {
                    elements.Add(i);
                }
        }
        public void IndexDel(int index)
        {
            elements.RemoveAt(index);
        }

        public void DelElement(Worker element)
        {
            elements.Remove(element);
        }
        public string SearchElement(Worker worker)
        {
            return worker.ToString();
        }
        public string SearchIdElement(int id)
        {
            return elements[id].ToString();
        }
        public string OutCollection()
        {
            string str = "";
            foreach(Worker i in elements)
            {
                str += i.ToString();
                str += "\n";
            }
            return str;
        }
        public object Current
        {
            get
            {
                if (position == -1 || position >= elements.Count)
                    throw new InvalidOperationException();
                return elements[position];
            }
        }

        public bool MoveNext()
        {
            if (position < elements.Count - 1)
            {
                position++;
                return true;
            }
            else
                return false;
        }
        public void Reset()
        {
            position = -1;
        }
    }
}