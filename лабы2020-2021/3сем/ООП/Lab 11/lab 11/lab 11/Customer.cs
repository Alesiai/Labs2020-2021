using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаба_11
{
    class Customer : IComparable
    {
        static int kol = 0;
        public readonly byte[] id;

        string name;
        string surname;
        string midName;
        string address;
        int? numCurd;
        int? balans;
        const byte poleConst = 1;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public string MidName
        {
            get
            {
                return midName;
            }
            set
            {
                midName = value;
            }
        }
        public string Surname
        {
            get
            {
                return surname;
            }
            set
            {
                surname = value;
            }
        }
        public string Address
        {
            private get
            {
                return address;
            }
            set
            {
                address = value;
            }
        }

        public int NumCurd
        {
            get
            {
                return Convert.ToInt32(numCurd);
            }
            set
            {
                numCurd = value;
            }
        }
        public Customer()
        {
            id = null;
            name = "none";
            surname = "nane";
            midName = "none";
            address = "none";
            numCurd = null;
            balans = 0;
            Customer.kol++;
        }
          
        public Customer(int id1 = 0, string name1 = "none", int? numCurd1 = null, 
            int? balans1 = null, string surname1 = "none", string midName1 = "none", string address1 = "none")
        {

            name = name1;
            surname = surname1;
            midName = midName1;
            address = address1;
            numCurd = numCurd1;
            balans = balans1;
            Customer.kol++;
        }
        
        
        public void GetInform()
        {
            Console.Write("hash Id: ");
            for (byte i = 0; i < 15; i++)
                Console.Write(id[i] + " ");

            Console.WriteLine("\nname: " + name);
            Console.WriteLine("surname: " + surname);
            Console.WriteLine("midmame: " + midName);
            Console.WriteLine("address: " + address);
            Console.WriteLine("numCurd: " + numCurd);
            Console.WriteLine("balans: " + balans);

        }
        static void GetInfo()
        {
            Console.WriteLine("Поля: ");
            Console.WriteLine("\thash Id");
            Console.WriteLine("name");
            Console.WriteLine("surname");
            Console.WriteLine("midmame");
            Console.WriteLine("address");
            Console.WriteLine("numCurd");
            Console.WriteLine("balans");
            Console.WriteLine("Количество объектов: " + Customer.kol);
            Console.WriteLine();
        }

        public int CompareTo(object o)
        {
            Customer p = o as Customer;
            if (p != null)
                return this.Name.CompareTo(p.Name);
            else
                throw new Exception("Невозможно сравнить два объекта");
        }

    }
}
