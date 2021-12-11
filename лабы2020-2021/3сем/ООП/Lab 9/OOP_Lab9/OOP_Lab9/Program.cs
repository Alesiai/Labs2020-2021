using System;
using System.Text;

namespace OOP_Lab9
{
    public class Director
    {
        public int salary = 1000;
        public int raising_power = 50;

        public void Raising()
        {
            Console.WriteLine("Вызвался метод поышения\n");
            Console.WriteLine($"Текущая зарплата: {salary}");
            this.RaisingEvent?.Invoke();
        }

        public void Fine(int heal)
        {
            if (RaisingEvent != null)
                salary += raising_power;    
            Console.WriteLine($"Вызвался метод штрафа, зарплата до штрафа: {salary}");

            if(FineEvent != null)
                salary -=this.FineEvent(heal);

            Console.WriteLine($"Текущая зарплата после штрафа: {salary}");
        }

        public delegate void RasingHandler();
        public event RasingHandler RaisingEvent;
        
        public delegate int FineHandler(int heal);
        public event FineHandler FineEvent;

    }

    class Program
    {
        public static int TakeFine(int take_fine)
        {
            Console.WriteLine("Получил штраф");
            return take_fine;           
        }

        //////////////////////////////////for Func
        public static string DeletePunctSigns(string str)
        {
            StringBuilder rc = new StringBuilder();

            for (int i = 0, j = 0; i < str.Length; i++)
                if (str[i] != ',' && str[i] != '.' && str[i] != '!' && str[i] != ':' && str[i] != ';')
                    rc.Append(str[i], 1);

           Console.WriteLine($"Строка без знаков пунктуации: {rc}");
           return rc.ToString();
        }

        public static string ToUpperCase(string str)
        {
            Console.WriteLine($"Строка в верхнем регистре: {str.ToUpper()}");
            return str.ToUpper();
        }

        public static string DeleteUnnecessarySpace(string str)
        {
            StringBuilder rc = new StringBuilder();

            for (int i = 0; i < str.Length; i++)
                if (str[i] == ' ')
                {
                    rc.Append(str[i], 1);
                    while (str[i + 1] == ' ')
                        i++;
                }
                else
                    rc.Append(str[i], 1);
            Console.WriteLine($"Строка без лишних пробелов: {rc}");
            return rc.ToString();
        }

        ///////////////////////////////////for Action

        public static void AddSymbols(string str, string additionSymbols)
        {
            str = str.Insert(0, additionSymbols);
            str += additionSymbols;

            Console.WriteLine($"\n\nРузультат: {str}");
        }

        static void Main(string[] args)
        {
            Director turner = new Director();
            turner.RaisingEvent += () => Console.WriteLine("turner повышен!");
            turner.RaisingEvent += () => Console.WriteLine($"turner получил прибывку к зарплате: {turner.raising_power}");
            turner.FineEvent += TakeFine;

            turner.Raising();
            turner.Fine(20);

            Director correspondence_student = new Director();
            correspondence_student.RaisingEvent += () => Console.WriteLine("correspondence student повышен!");
            correspondence_student.RaisingEvent += () => Console.WriteLine($"correspondence student получил прибывку к зарплате: " +
                $"{turner.raising_power}");
            correspondence_student.Raising();

            //работа со строками
            Action<string, string> formatingForTitle;

            formatingForTitle = AddSymbols;
            formatingForTitle("qwerty", "!!!");

            string testString = "Делегат, Func возвращает результат,    действия и может принимать, параметры!";
            Func<string, string> func;
            func = DeletePunctSigns;
            func += ToUpperCase;
            func += DeleteUnnecessarySpace;

            string result = func(testString);
        }  
    }
}
