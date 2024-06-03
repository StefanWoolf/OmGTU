using System;

//интерфейс
public interface IMathOperations
{
    double Add(double a, double b);
    double Subtract(double a, double b);
    double Multiply(double a, double b);
    double Divide(double a, double b);
    double Square(double a);
    double Sin(double a);
    double Cos(double a);
}
public class MathOperations : IMathOperations
{
    public double Add(double a, double b)
    {
        return a + b;
    }

    public double Subtract(double a, double b)
    {
        return a - b;
    }

    public double Multiply(double a, double b)
    {
        return a * b;
    }

    public double Divide(double a, double b)
    {
        if (b == 0)
            throw new DivideByZeroException("Деление на ноль невозможно");
        return a / b;
    }

    public double Square(double a)
    {
        if (a < 0)
            throw new ArgumentException("Квадратный корень из отрицательного числа не существует");
        return Math.Sqrt(a);
    }

    public double Sin(double a)
    {
        return Math.Sin(a);
    }

    public double Cos(double a)
    {
        return Math.Cos(a);
    }
}

//делегаты для мат операций
public delegate double TwoOperation(double a, double b);
public delegate double OneOperation(double a);

public class Program
{
    public static void Main()
    {
        IMathOperations mathOperations = new MathOperations();

        Dictionary<string, TwoOperation> twoOperations = new Dictionary<string, TwoOperation>
        {
            { "Add", mathOperations.Add },
            { "Subtract", mathOperations.Subtract },
            { "Multiply", mathOperations.Multiply },
            { "Divide", mathOperations.Divide }
        };

        Dictionary<string, OneOperation> oneOperations = new Dictionary<string, OneOperation>
        {
            { "Square", mathOperations.Square },
            { "Sin", mathOperations.Sin },
            { "Cos", mathOperations.Cos }
        };

        while (true)
        {
            Console.WriteLine("Выберите тип математической операции:");
            Console.WriteLine("1. Add (Сложение)");
            Console.WriteLine("2. Subtract (Вычитание)");
            Console.WriteLine("3. Multiply (Умножение)");
            Console.WriteLine("4. Divide (Деление)");
            Console.WriteLine("5. Square (Квадратный корень)");
            Console.WriteLine("6. Sin (Синус)");
            Console.WriteLine("7. Cos (Косинус)");
            Console.WriteLine("8. Exit (Выход)");
            string input = Console.ReadLine();

            if (input == "8")
                break;

            try
            {
                if (twoOperations.ContainsKey(input))
                {
                    Console.Write("Введите первое число: ");
                    double a = double.Parse(Console.ReadLine());
                    Console.Write("Введите второе число: ");
                    double b = double.Parse(Console.ReadLine());
                    double result = twoOperations[input](a, b);
                    Console.WriteLine($"Результат: {result}");
                }
                else if (oneOperations.ContainsKey(input))
                {
                    Console.Write("Введите число: ");
                    double a = double.Parse(Console.ReadLine());
                    double result = oneOperations[input](a);
                    Console.WriteLine($"Результат: {result}");
                }
                else
                {
                    Console.WriteLine("Некорректный выбор операции. Попробуйте снова.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Ошибка: Введено некорректное число.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }
}
