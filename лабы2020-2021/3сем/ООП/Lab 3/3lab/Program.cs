using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lab3
{
    partial class Customer//определить один класс в нескольких файлах
    {
        private int id = 0;
        private string Name = "";
        private string Surname = "";
        private int Ncard = 0;
        private string Adress = "";
        private int Balance = 0;
        private readonly int CustomerID;//поле для чтения
        private static int size = 0;

        public static int Size => size;

        public int ID
        {
            get { return this.id; }
            set { this.id = value; }

        }
        public string NAME 
        {
            get { return this.Name; }
            set { this.Name = value; }

        }
        public string SURNAME
        {
            get { return this.Surname; }
            set { this.Surname = value; }

        }
        public int NCARD 
        {
            get { return this.Ncard; }
            set { this.Ncard = value; }

        }
        public string ADRESS 
        {
            get { return this.Adress; }
            set { this.Adress = value; }

        }
        public int BALANCE
        {
            get { return this.Balance; }
            set { this.Balance = value; }

        }

        public Customer()
        {
            this.id = 0;
            this.Name = "no";
            this.Surname = "no";
            this.Ncard = 0000;
            this.Adress="no";
            this.Balance = 0;
            this.CustomerID = GetHashCode();
            size++;
        }

        public Customer(int iden, string m, string mod, int y, string col, int c)
        {
            this.id = iden;
            this.Name = m;
            this.Surname = mod;
            this.Ncard = y;
            this.Adress = col;
            this.Balance = c;
            this.CustomerID = GetHashCode();
            size++;
        }

        static Customer()
        {
            Console.WriteLine("Добавлен первый покупатель");
        }

        public Customer(int iden, string m, int y)
        {
            this.id = iden;
            this.Name = m;
            this.Ncard = y;
            this.CustomerID = GetHashCode();
            size++;
        }
        public void AddBalance(int toAdd) => this.Balance += toAdd;

        public void GetBalance(out int balance) => balance = this.Balance;

        public void AddBalanceTo(ref int addTo) => addTo += this.Balance;
    }

    class Program
    {
     
        static void Main(string[] args)
        {
            var ListOfCustumers = new List<Customer>
            {
                 new Customer(1,"Alisa","Ivanova",7230,"Levkova 18",3000),
                 new Customer(2,"Den","Tsarevich",8523,"Jakubova 5",3700),
                 new Customer(3,"Kirill","Mihalevich",1203,"Lenina 9",2900),
                 new Customer(4,"Viktoria",3654),
                 new Customer(5,"Liz","Izmer",2378,"Minskaya 96",9999),
            };
            Customer someCustomer = new Customer();
            ListOfCustumers.Add(someCustomer);
            Console.WriteLine("РАЗМЕР: "+Customer.Size);

            Console.WriteLine("\nСписок покупателей:");
            foreach (Customer pers in ListOfCustumers)
            {  
               
                Console.WriteLine(pers);
                if (pers.ID == 2)
                {
                    pers.AddBalance(5000);
                }
            }
            Console.WriteLine("\nИнформация о пользователях с номером карты в промежутке 1000-5000:");
            foreach (Customer pers in ListOfCustumers)
            {
                    if (pers.NCARD>1000 && pers.NCARD<5000)
                    {
                    Console.WriteLine(pers);
                }
            }
            int newID=2;
            Console.WriteLine("\nИнформация о ID:2");
            foreach (Customer pers in ListOfCustumers)
            {
                if (pers.ID == newID)
                    Console.WriteLine(pers);
            }

            Console.WriteLine("\nПользователи по алфавиту: ");
            ListOfCustumers.Sort((l, r) => l.NAME.CompareTo(r.NAME));
            foreach (Customer pers in ListOfCustumers)
            {
                    Console.WriteLine(pers);
            }

            Console.WriteLine("\nАноним: ");
            var user = new { Name = "Anonim" };//4
            Console.WriteLine(user.Name);

            Console.WriteLine("\nРЕзультат сравнения 1 и 2 покупателя: ");
            Console.WriteLine(Equals(ListOfCustumers[0], ListOfCustumers[1]));
            Console.WriteLine("\nРЕзультат Equals ");
            Console.WriteLine(ListOfCustumers.Equals(ListOfCustumers));
            Console.ReadLine();
        }
    }
}
