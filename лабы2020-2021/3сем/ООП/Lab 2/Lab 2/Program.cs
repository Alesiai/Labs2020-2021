using System;
using System.Text;

//namespace Exersize_1
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            bool bool_type = true;
//            int int_type = 1;
//            double double_type = 1.5;
//            char char_type = 'A';
//            string string_type = "String";
//            Console.WriteLine("Exersize 1a \nbool_type = " + bool_type +
//                "\nint_type = " + int_type +
//                "\ndouble_type = " + double_type +
//                "\nchar_type = " + char_type +
//                "\nstring_type = " + string_type);

//            ushort ushort_type = 52;
//            uint new_ushot_type = ushort_type;

//            short short_type = 11;
//            int new_short_type = short_type;

//            byte byte_type = 15;
//            short new_byte_type = byte_type;

//            int_type = 150;
//            long new_int_type = int_type;

//            float float_type = 1.8f;
//            double new_float_type = float_type;
//            Console.ReadKey();

//            Console.WriteLine("\n\nExersize 1b \nНеявные приведения:");//не теряется информация
//            Console.WriteLine("Ushort = {0} Uint = {1}", ushort_type, new_ushot_type);
//            Console.WriteLine("Short = {0} Int = {1}", short_type, new_short_type);
//            Console.WriteLine("Byte = {0} Short = {1}", byte_type, new_byte_type);
//            Console.WriteLine("Int = {0} Long = {1}", int_type, new_int_type);
//            Console.WriteLine("Float = {0} Double = {1}", float_type, new_float_type);

//            Console.WriteLine("\nЯвные приведения:");
//            short_type = (short)int_type;
//            Console.WriteLine("Int = {0} Short = {1}", int_type, short_type);

//            int_type = (int)new_int_type;
//            Console.WriteLine("Long = {0} Int = {1}", new_int_type, int_type);

//            short_type = 45;
//            byte_type = (byte)short_type;
//            Console.WriteLine("Short = {0} Byte = {1}", short_type, byte_type);

//            double_type = 245.45567;
//            int_type = (int)double_type;
//            float_type = (float)double_type;
//            Console.WriteLine("Double = {0} Int = {1}", double_type, int_type);
//            Console.WriteLine("Double = {0} Float = {1}", double_type, float_type);
//            Console.ReadKey();

//            Console.WriteLine("\n\nExersize 1c \nУпаковка:\n");
//            int num = 123;
//            object packed_num = num;//ссылка в куче
//            Console.WriteLine("Число для упаковки: {0} \nУпакованное число: {1}\n", num, packed_num);

//            num = 125;
//            packed_num = num;
//            int unpacked_num = (int)packed_num;
//            Console.WriteLine("Распаковка:\nЧисло для упаковки: {0} \nУпакованное число: {1} \nРаспакованное число: {2}\n", num, packed_num, unpacked_num);
//            Console.ReadKey();

//            Console.WriteLine("\n\nExersize 1d \nРабота с неявно типизированной переменной:\n");
//            int int_num = 1;
//            var var_symb = 'a';
//            var result = int_num + var_symb;
//            Console.WriteLine("Var = {0} Int = {1} \nVar+Int = {2}\n", var_symb, int_num, result);
//            Console.ReadKey();

//            Console.WriteLine("\n\nExersize 1f \nработа с Nullable переменной\n");
//            int? number = 7;
//            Console.WriteLine("Проверим число:");
//            if (number.HasValue)
//            {
//                Console.WriteLine(number.Value + " не Nullable");
//            }
//            else
//            {
//                Console.WriteLine(number.Value + "Nullable");
//            }


//            int? new_number = null;
//            Console.WriteLine("\nПроверим новое число");
//            if (new_number.HasValue)
//            {
//                Console.WriteLine(new_number.Value + " не Nullable");
//            }
//            else
//            {
//                Console.WriteLine("Nullable");
//            }
//            Console.ReadKey();
//        }
//    }
//}

//namespace Exersize_2
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            Console.WriteLine("Exersize 2a: Сравнение строковых литералов\n");

//            string str1 = "Hello";
//            string str2 = "Hello, world!";
//            bool result = str1.Equals(str2);
//            Console.WriteLine("Строка 1: {0}\nСтрока 2: {1}\nИтог сравнения: {2}\n", str1, str2, result);
//            Console.ReadKey();

//            Console.WriteLine("Exersize 2b: сцепление,копирование, выделение подстроки, разделение строки на слова, " +
//                "вставки подстроки в заданную позицию, удаление заданной подстроки.Продемонстрируйте интерполирование строк.\n");

//            string str3 = "Hello,", str4 = "world", str5 = "!";
//            string str6 = str3 + " " + str4, str7 = String.Concat(str6, str5), str8 = str7;
//            Console.WriteLine("Строка 1: {0}\nСтрока 2: {1}\nСтрока 3: {2}\nРезультат сцепления строки 1-2: {3}\nРезультат сцепления 1-2-3: {4}\n" +
//            "Результат копирования строки 1-2-3: {4}\n", str3, str4, str5, str6, str7, str8);


//            string str9 = "Hello world !";
//            string[] words = str9.Split(new char[] { ' ' });
//            Console.WriteLine("Начальная строка: {0}\nРазделение строки на подстроки (слова):", str9);
//            foreach (string s in words)
//            {
//                Console.WriteLine(s);
//            }

//            Console.WriteLine("\nВ строку: {0} вставили подстроку: {1} на 6-ю позицию:", str2, str1);
//            str2 = str2.Insert(6, str1);
//            Console.WriteLine(str2);

//            Console.WriteLine("\nИз строки: {0} удалили 6 символов с 6-й позиции:", str2);
//            str2 = str2.Remove(6, 6);
//            Console.WriteLine(str2);
//            Console.ReadKey();

//            Console.WriteLine("\nExersize 2c: строки null и пустные строки\nпроверка строки empty:");
//            string empty = "";
//            string nullString = null;
//            if (String.IsNullOrEmpty(empty))
//            {
//                Console.WriteLine("is null or empty");
//            }
//            Console.WriteLine("\nПроверка на то, равны ли строки null и empty:");
//            bool result2 = empty.Equals(nullString);
//            Console.WriteLine("Результат проверки " + result2);
//            Console.ReadKey();

//            Console.WriteLine("\nExersize 2d:");
//            StringBuilder sb = new StringBuilder("ривеет мир");
//            Console.WriteLine("Начальная строка:" + sb);
//            sb.Insert(0, "П");
//            sb.Insert(11, "!");
//            sb.Remove(4, 1);
//            Console.WriteLine("Строка после редакции: " + sb);
//            Console.ReadKey();
//        }
//    }
//}


namespace Exersize_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Exersize 3a \nСоздание и вывод матрицы:");
            int[,] mas = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            int rows = mas.GetUpperBound(0) + 1;
            int columns = mas.Length / rows;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write($"{mas[i, j]} \t");
                }
                Console.WriteLine();

            }
            Console.ReadKey();

            Console.WriteLine("\n\nExersize 3b \nодномерный массив строк: ");
            string[] string_mass = { "first", "second", "third" };
            int string_mass_length = string_mass.Length;
            for (int i = 0; i < string_mass_length; ++i)
            {
                Console.WriteLine(string_mass[i]);
            }
            Console.WriteLine("Введите номер элемента, который нужно заменить:");
            int k = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("элемент заменили на : not second\n");
            for (int i = 0; i < string_mass_length; ++i)
            {
                if (i == k)
                {
                    string_mass[i] = "not second";
                }
            }
            for (int i = 0; i < string_mass_length; ++i)
            {
                Console.WriteLine(string_mass[i]);
            }
            Console.WriteLine("Длинна массива : {0}", string_mass_length);
            Console.ReadKey();

            Console.WriteLine("\n\nExersize 3c \nступенчатая матрица: ");
            int[][] step_mass = new int[3][];
            step_mass[0] = new int[2] { 1, 2 };
            step_mass[1] = new int[3] { 1, 2, 3 };
            step_mass[2] = new int[4] { 1, 2, 3, 4 };
            for (int i = 0; i < step_mass.Length; i++)
            {
                for (int j = 0; j < step_mass[i].Length; j++)
                {
                    Console.Write($"{step_mass[i][j]} \t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.ReadKey();

            Console.WriteLine("Exersize 3d: неявно типизированные переменные для хранения массива и строки.: ");
            var varMas = new[] { 1, 2, 3, 4, 5 };
            for (int ind = 1; ind <= varMas.Length; ind++)
            {
                Console.WriteLine(ind);
            }
            Console.ReadKey();
        }
    }
}

//namespace Exersize_4
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            Console.WriteLine("Exersize 4a-b \nСоздание и выведение кортежа");
//            (int age, string name, char sex, string surname, ulong dateOfBirth) tuple = (18, "Alesia", 'w', "Ivanova", 13_01_2002);
//            Console.WriteLine(tuple);
//            Console.ReadKey();

//            Console.WriteLine("\n\nExersize 4b выведение воборочных эл-в кортежа");
//            Console.WriteLine("Имя: {0}; Фамилия: {1}; Возраст:{2};", tuple.name, tuple.surname, tuple.age);
//            Console.ReadKey();

//            Console.WriteLine("\n\nExersize 4с распоковка кортежа");
//            (string first, string middle, string last) = ("Неllo", "world", "!!");
//            Console.WriteLine($"{first}, {middle}, {last}");
//            Console.ReadKey();

//            Console.WriteLine("\n\nExersize 4d сравнение кортежей");
//            (int a, int b) t1 = (1, 42);
//            (int a, int b) t2 = (2, 41);
//            Console.WriteLine("кортеж 1: {0}, кортеж 2:{1}, результат сравнения {2}", t1, t2, t1.CompareTo(t2));
//            (int c, double d) t3 = (1, 42);
//            (int c, double d) t4 = (1, 42);
//            Console.WriteLine("кортеж 1: {0}, кортеж 2:{1}, результат сравнения {2}", t3, t4, t4.CompareTo(t3));
//            Console.ReadKey();
//        }

//    }
//}
//namespace Exersize_5
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            int[] a = new int[] { 3, 4, 1, 2, 5 };
//            string s = "Hello";
//            Console.WriteLine("Exersize5: \nМассив: {0} {1} {2} {3} {4}\nСтрока {5}\n", a[0], a[1], a[2], a[3], a[4], s);
//            var tuple = GetValues(a, s);
//            Console.WriteLine($"Максимальный элемент: {tuple.Max}");
//            Console.WriteLine($"Минимальный элемент: {tuple.Min}");
//            Console.WriteLine($"Сумма элементов: {tuple.Sum}");
//            Console.WriteLine($"Первый символ строки: {tuple.First}");
//            Console.ReadKey();
//        }
//        private static (int Max, int Min, int Sum, string First) GetValues(int[] a, string s)
//        {

//            var result = (Max: a[0], Min: a[0], Sum: 0, First: "");

//            for (int i = 0; i < a.Length; i++)
//            {
//                if (result.Max < a[i])
//                {
//                    result.Max = a[i];
//                }
//            }

//            for (int i = 0; i < a.Length; i++)
//            {
//                if (result.Min > a[i])
//                {
//                    result.Min = a[i];
//                }
//            }

//            for (int i = 0; i < a.Length; i++)
//            {
//                result.Sum += a[i];
//            }

//            result.First = s.Remove(1);

//            return result;
//        }
//    }
//}
//namespace Exersize_5
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            Console.WriteLine("Exersize6:");
//            int a = 2147483647;
//            var unchecked_v = Unhecked_f(a);
//            Console.WriteLine("Unhecked: {0}", unchecked_v);
//            Console.WriteLine("Checked: {0}");
//            var checked_v = Checked_f(a);
//            Console.WriteLine("Checked: {0}", checked_v);

//            Console.ReadKey();
//        }

//        private static int  Checked_f(int a)
//        {
//            var result = checked(a+10);
//            return result;
//        }

//        private static int Unhecked_f(int a)
//        {
//            var result = unchecked(a+10);
//            return result;
//        }
//    }
//}