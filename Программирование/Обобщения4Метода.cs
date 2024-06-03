using System;

public class Calculator<T>
{
    public T Num1 { get; set; }
    public T Num2 { get; set; }

    public Calculator(T num1, T num2)
    {
        Num1 = num1;
        Num2 = num2;
    }

    public void Add()
    {
        dynamic n1 = Num1;
        dynamic n2 = Num2;
        Console.WriteLine($"Результат сложения: {n1 + n2}");
    }

    public void Subtract()
    {
        dynamic n1 = Num1;
        dynamic n2 = Num2;
        Console.WriteLine($"Результат вычитания: {n1 - n2}");
    }

    public void Multiply()
    {
        dynamic n1 = Num1;
        dynamic n2 = Num2;
        Console.WriteLine($"Результат умножения: {n1 * n2}");
    }

    public void Divide()
    {
        dynamic n1 = Num1;
        dynamic n2 = Num2;
        if (n2 == 0)
            Console.WriteLine("Ошибка: Нельзя делить на ноль!");
        else
            Console.WriteLine($"Результат деления: {n1 / n2}");
    }
}

public class Ystallll
{
    public static void Main()
    {
        while (true)
        {
            Console.WriteLine("Меню:");
            Console.WriteLine("1. Работа с целыми числами");
            Console.WriteLine("2. Работа с вещественными числами");
            Console.WriteLine("3. Выход");
            Console.Write("Выберите опцию(цифру): ");
            string input = Console.ReadLine();

            if (input == "3")
                break;

            if (input == "1")
            {
                Console.Write("Введите первое целое число: ");
                int num1 = int.Parse(Console.ReadLine());
                Console.Write("Введите второе целое число: ");
                int num2 = int.Parse(Console.ReadLine());

                Calculator<int> intCalculator = new Calculator<int>(num1, num2);
                PerformOperations(intCalculator);
            }
            else if (input == "2")
            {
                Console.Write("Введите первое вещественное число: ");
                double num1 = double.Parse(Console.ReadLine());
                Console.Write("Введите второе вещественное число: ");
                double num2 = double.Parse(Console.ReadLine());

                Calculator<double> doubleCalculator = new Calculator<double>(num1, num2);
                PerformOperations(doubleCalculator);
            }
            else
                Console.WriteLine("Некорректный выбор. Попробуйте снова.");
        }
    }

    public static void PerformOperations<T>(Calculator<T> calculator)
    {
        calculator.Add();
        calculator.Subtract();
        calculator.Multiply();
        calculator.Divide();
    }
}
