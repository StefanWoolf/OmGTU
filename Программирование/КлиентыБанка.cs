using System;
using System.Linq;

public class Client
{
    public int AccountNumber { get; set; }
    public string FullName { get; set; }
    public double Income { get; set; }
    public double Expense { get; set; }
    public double Nalog => Income * 0.05; //налог
    public double Balance => Income - Expense - Nalog; 

    public Client(int accountNumber, string fullName, double income, double expense)
    {
        AccountNumber = accountNumber;
        FullName = fullName;
        Income = income;
        Expense = expense;
    }
}

public class Plachy
{
    public static void Main()
    {
        List<Client> clients = new List<Client>
        {
            new Client(1, "Иванов Иван Иванович", 14567, 5330),
            new Client(2, "Петров Петр Петрович", 15032, 16432),
            new Client(3, "Сидоров Сидор Сидорович", 24322, 19987),
            new Client(4, "Александров Александр Александрович", 5000, 9000),
            new Client(5, "Михайлов Михаил Михайлович", 25055, 15555)
        };

        int negativeBalanceCount = clients.Count(c => c.Balance < 0);
        Console.WriteLine($"Количество клиентов с отрицательным балансом: {negativeBalanceCount}");

        var richClient = clients.OrderByDescending(c => c.Balance).FirstOrDefault();
        if (richClient != null)
            Console.WriteLine($"Клиент с самым большим балансом: {richClient.FullName}, Баланс: {richClient.Balance}");

        var negativeBalanceClients = clients.Where(c => c.Balance < 0);
        double averNegativeBalance = 0;
        if (negativeBalanceClients.Any())
            averNegativeBalance = negativeBalanceClients.Average(c => c.Income);

        Console.WriteLine($"Средний доход по счетам с отрицательным балансом: {averNegativeBalance}");

        double totalNalog= clients.Sum(c => c.Nalog);
        Console.WriteLine($"Суммарная сумма налогов со всех клиентов: {totalNalog}");
    }
}
    