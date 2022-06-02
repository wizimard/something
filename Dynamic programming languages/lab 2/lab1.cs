using System;
using System.Globalization;

namespace Dynamic_lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            Calc calc = new Calc(); //создание экземляра Calc
            calc.main(); // вызов метода main
        }
    }
    class Calc
    {
        private double a; // приватная переменная a типа double
        private const int b = 340; // приватная константа b равная 340
        private const double c = 1.07; // приватная константа c равная 1.07
        private double d; // приватная переменная d типа double
        private int f; // приватная переменная f типа int
        private const double x = 1.4422; // приватная константа x равная 3^(1/3)
        public void main()
        {
            this.inputArguments();
            // вычисление функции
            this.calculate();
        }
        public void inputArguments()
        {
            Console.WriteLine("Последовательно введите аргументы. " +
                "Ниже представлена таблица с описанием аргументов");
            // вывод информации об аргументах
            this.info();
            //вводим переменную a, пока не будет удовлетворяющего значения
            do
            {
                Console.WriteLine("Введите аргумент a");
                this.a = double.Parse(Console.ReadLine().Trim(), 
                    CultureInfo.InvariantCulture.NumberFormat);
            } while (!this.isCorrectArgument(this.a, 0.01, 0.8, 1.17));
            //вводим переменную d, пока не будет удовлетворяющего значения
            do
            {
                Console.WriteLine("Введите аргумент d");
                this.d = double.Parse(Console.ReadLine().Trim(), 
                    CultureInfo.InvariantCulture.NumberFormat);
            } while (!this.isCorrectArgument(this.d, 0.01, 2, 5.13));
            do
            //вводим переменную f, пока не будет удовлетворяющего значения
            {
                Console.WriteLine("Введите аргумент f");
                this.f = int.Parse(Console.ReadLine().Trim(), 
                    CultureInfo.InvariantCulture.NumberFormat);
            } while (!this.isCorrectArgument(this.f, 12, 12, 144));
        }
        // метод для проверки корректности числа
        private bool isCorrectArgument(double number, double delta, 
            double start, double end)
        {
            return (number >= start) && (number <= end) && 
                (Math.Round(number / delta, 4) % 1 == 0);
        }
        // метод, выводяющий информацию об аргументах
        public void info()
        {
            Console.WriteLine("| Аргумент |  Диапазон         | Дискрет аргумента  |");
            Console.WriteLine("|    a     | [0.8; 1.17]       |        0.01        |");
            Console.WriteLine("|    b     | [равно 340]       |   константа 340    |");
            Console.WriteLine("|    c     | [равно 1.07]      |   константа 1.07   |");
            Console.WriteLine("|    d     | [2; 5.13]         |        0.01        |");
            Console.WriteLine("|    f     | [12; 144]         |        12          |");
            Console.WriteLine("|    x     | [равнен 3^(1/3)]  |  константа 3^(1/3) |");
        }
        // метод вычисления функции и вывода результата
        public void calculate()
        {
            // инициализация и переменной типа double и присвоение ей значения
            double result = this.formatNumber((this.a * x + b) / 
                (c * Math.Pow(x, 2) + this.d * x + this.f));
            Console.WriteLine("|\tАргумент\t|\tЗначение аргумента\t|\tРезультат функции\t|");
            Console.WriteLine($"|\ta\t\t|\t{this.a}\t\t\t|\t\t\t\t|");
            Console.WriteLine($"|\tb\t\t|\t{b}\t\t\t|\t\t\t\t|");
            Console.WriteLine($"|\tc\t\t|\t{c}\t\t\t|\t{result}\t\t\t|");
            Console.WriteLine($"|\td\t\t|\t{this.d}\t\t\t|\t\t\t\t|");
            Console.WriteLine($"|\tf\t\t|\t{this.f}\t\t\t|\t\t\t\t|");
            Console.WriteLine($"|\tx\t\t|\t{x}\t\t\t|\t\t\t\t|");
            this.a = this.d = this.f = 0;
        }
        public double formatNumber(double number)
        {
            return Math.Truncate(number * 10000) / 10000;
        }
    }
}
