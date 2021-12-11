using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab7
{
    public class BouquetOverflowException : Exception
    {
        public readonly DateTime time;
        public BouquetOverflowException(int currentCountOfFlowers, int maxCountOfFlowers) : base($"Слишком много цветов в букете, текущее кол-во: {currentCountOfFlowers}, максимально допустимое: {maxCountOfFlowers}: больше добавить невозможно.")
        {
            time = DateTime.Now;
        }
        
    }

    public class ZeroFlowersException : Exception
    {
        public readonly DateTime time;
        public ZeroFlowersException() : base("В букете нету цветов! Добавьте хотя бы 1")
        {
            time = DateTime.Now;
        }

    }

    public class ExpensiveException : Exception
    {
        public readonly DateTime time;
        public ExpensiveException(float exceptionPrice, float necessarySum) : base($"Слишком дорогой букет, текущая бюджет: {exceptionPrice}, необходимая стоимость: {necessarySum}.")
        {
            time = DateTime.Now;
        }

    }
    public class InvalidInputException : Exception
    {
        public readonly DateTime time;
        public InvalidInputException(string message) : base(message)
        {
            time = DateTime.Now;
        }

    }
}
