using System;
using System.Collections;
using System.Collections.Generic;

public class PhoneCall
{
    public string PhoneNumber { get; set; }
    public DateTime CallDate { get; set; }
    public DateTime StartTime { get; set; }
    public int Minutes { get; set; }

    public PhoneCall(string phoneNumber, DateTime callDate, DateTime startTime, int minutes)
    {
        PhoneNumber = phoneNumber;
        CallDate = callDate;
        StartTime = startTime;
        Minutes = minutes;
    }
}

public class Program
{
    public static void Main()
    {
        Queue<PhoneCall> phoneCallsQueue = new Queue<PhoneCall>();

        phoneCallsQueue.Enqueue(new PhoneCall("89608954710", DateTime.Parse("2024-01-01"), DateTime.Parse("2024-01-01 10:00"), 30));
        phoneCallsQueue.Enqueue(new PhoneCall("89608554720", DateTime.Parse("2024-01-01"), DateTime.Parse("2024-01-01 11:00"), 20));
        phoneCallsQueue.Enqueue(new PhoneCall("89608954710", DateTime.Parse("2024-01-02"), DateTime.Parse("2024-01-02 12:00"), 15));
        phoneCallsQueue.Enqueue(new PhoneCall("89608554720", DateTime.Parse("2024-01-03"), DateTime.Parse("2024-01-03 13:00"), 25));
        phoneCallsQueue.Enqueue(new PhoneCall("89765439999", DateTime.Parse("2024-01-03"), DateTime.Parse("2024-01-03 14:00"), 40));

        Dictionary<string, int> phoneMinDict = new Dictionary<string, int>();

        Hashtable phoneMinTable = new Hashtable();

        while (phoneCallsQueue.Count > 0)
        {
            PhoneCall call = phoneCallsQueue.Dequeue();

            //обновляем словарь
            if (phoneMinDict.ContainsKey(call.PhoneNumber))
            {
                phoneMinDict[call.PhoneNumber] += call.Minutes;
            }
            else
            {
                phoneMinDict[call.PhoneNumber] = call.Minutes;
            }

            //обновляем хэштаблицу
            if (phoneMinTable.ContainsKey(call.PhoneNumber))
            {
                phoneMinTable[call.PhoneNumber] = Convert.ToInt32(phoneMinTable[call.PhoneNumber]) + call.Minutes;
            }
            else
            {
                phoneMinTable[call.PhoneNumber] = call.Minutes;
            }
        }

        Console.WriteLine("Отчёт по данным из словаря:");
        foreach (var entry in phoneMinDict)
        {
            Console.WriteLine($"ТеЛеФоН: {entry.Key}, Минуты: {entry.Value}");
        }

        Console.WriteLine("Отчёт по данным из хештаблицы:");
        foreach (DictionaryEntry entry in phoneMinTable)
        {
            Console.WriteLine($"ТеЛеФоНчИк: {entry.Key}, Минуты: {entry.Value}");
        }

        // Задание 2: Суммарное время разговоров по каждому дню по всем номерам
        Dictionary<DateTime, int> dailyMinDict = new Dictionary<DateTime, int>();
        Hashtable dailyMinTable = new Hashtable();

        // Примерные данные (можно заменить считыванием из файла или ввода пользователем)
        phoneCallsQueue.Enqueue(new PhoneCall("89608954710", DateTime.Parse("2024-01-01"), DateTime.Parse("2024-01-01 10:00"), 30));
        phoneCallsQueue.Enqueue(new PhoneCall("89608554720", DateTime.Parse("2024-01-01"), DateTime.Parse("2024-01-01 11:00"), 20));
        phoneCallsQueue.Enqueue(new PhoneCall("89608954710", DateTime.Parse("2024-01-02"), DateTime.Parse("2024-01-02 12:00"), 15));
        phoneCallsQueue.Enqueue(new PhoneCall("89608554720", DateTime.Parse("2024-01-03"), DateTime.Parse("2024-01-03 13:00"), 25));
        phoneCallsQueue.Enqueue(new PhoneCall("89765439999", DateTime.Parse("2024-01-03"), DateTime.Parse("2024-01-03 14:00"), 40));

        while (phoneCallsQueue.Count > 0)
        {
            PhoneCall call = phoneCallsQueue.Dequeue();

            // Обновляем словарь
            if (dailyMinDict.ContainsKey(call.CallDate))
            {
                dailyMinDict[call.CallDate] += call.Minutes;
            }
            else
            {
                dailyMinDict[call.CallDate] = call.Minutes;
            }

            // Обновляем хештаблицу
            if (dailyMinTable.ContainsKey(call.CallDate))
            {
                dailyMinTable[call.CallDate] = Convert.ToInt32(dailyMinTable[call.CallDate]) + call.Minutes;
            }
            else
            {
                dailyMinTable[call.CallDate] = call.Minutes;
            }
        }

        Console.WriteLine("Отчёт по суммарному времени разговоров по каждому дню (словарь):");
        foreach (var entry in dailyMinDict)
        {
            Console.WriteLine($"Дата: {entry.Key.ToString("yyyy-MM-dd")}, Минуты: {entry.Value}");
        }

        Console.WriteLine("Отчёт по суммарному времени разговоров по каждому дню (хештаблица):");
        foreach (DictionaryEntry entry in dailyMinTable)
        {
            Console.WriteLine($"Дата: {(Convert.ToDateTime(entry.Key)).ToString("yyyy-MM-dd")}, Минуты: {entry.Value}");
        }
    }
}
