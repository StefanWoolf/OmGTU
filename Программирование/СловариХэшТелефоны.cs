using System;
using System.Collections;
using System.Linq;

public class PhoneCall
{
    public string FromNumber { get; set; }
    public string ToNumber { get; set; }
    public DateTime CallDate { get; set; }
    public int Minutes { get; set; }

    public PhoneCall(string fromNumber, string toNumber, DateTime callDate, int minutes)
    {
        FromNumber = fromNumber;
        ToNumber = toNumber;
        CallDate = callDate;
        Minutes = minutes;
    }
}

public class Program
{
    public static void Main()
    {
        // Примерные данные звонков (можно заменить считыванием из файла или ввода пользователем)
        List<PhoneCall> phoneCalls = new List<PhoneCall>
        {
            new PhoneCall("89608954710", "89608554720", DateTime.Parse("2024-01-01"), 31),
            new PhoneCall("89608954710", "89608554721", DateTime.Parse("2024-01-01"), 26),
            new PhoneCall("89608954710", "89608554720", DateTime.Parse("2024-01-02"), 15),
            new PhoneCall("89608954710", "89608554722", DateTime.Parse("2024-01-03"), 25),
            new PhoneCall("89608954711", "89765439999", DateTime.Parse("2024-01-03"), 47),
            new PhoneCall("89608954712", "89608554720", DateTime.Parse("2024-01-01"), 30),
            new PhoneCall("89608954712", "89608554721", DateTime.Parse("2024-01-01"), 29),
            new PhoneCall("89608954710", "89608554720", DateTime.Parse("2024-01-02"), 15),
            new PhoneCall("89608954711", "89608554722", DateTime.Parse("2024-01-03"), 25),
            new PhoneCall("89608954710", "89765439999", DateTime.Parse("2024-01-03"), 40)
        };

        string phoneNumber = "89608954710";

        //количество звонков по номерам
        Dictionary<string, int> callFrequency = new Dictionary<string, int>();

        //общее время разговоров по номерам
        Dictionary<string, int> callDurations = new Dictionary<string, int>();

        foreach (var call in phoneCalls)
        {
            if (call.FromNumber == phoneNumber)
            {
                if (callFrequency.ContainsKey(call.ToNumber))
                    callFrequency[call.ToNumber]++;
                else
                    callFrequency[call.ToNumber] = 1;

                if (callDurations.ContainsKey(call.ToNumber))
                    callDurations[call.ToNumber] += call.Minutes;
                else
                    callDurations[call.ToNumber] = call.Minutes;
            }
        }

        //находим номер на который чаще всего звонил выбранный абонент
        var mostCallNumber = callFrequency.OrderByDescending(x => x.Value).FirstOrDefault();
        Console.WriteLine($"Номер, на который чаще всего звонил {phoneNumber}: {mostCallNumber.Key} ({mostCallNumber.Value} звонков)");

        //находим номер с которым наибольшее количество минут разговаривал абонент
        var mostTalkNumbers = callDurations.OrderByDescending(x => x.Value).FirstOrDefault();
        Console.WriteLine($"Номер, с которым наибольшее количество минут разговаривал {phoneNumber}: {mostTalkNumbers.Key} ({mostTalkNumbers.Value} минут)");

        //групировка данных по датам
        var callsGroupDate = phoneCalls.GroupBy(call => call.CallDate.Date).ToDictionary(g => g.Key, g => g.ToList());

        //находим номера, с которыми было наибольшее количество минут разговоров по каждой дате
        var maxMinutDate = new Dictionary<string, Dictionary<DateTime, (string ToNumber, int Minutes)>>();

        foreach (var call in phoneCalls)
        {
            if (!maxMinutDate.ContainsKey(call.FromNumber))
                maxMinutDate[call.FromNumber] = new Dictionary<DateTime, (string ToNumber, int Minutes)>();

            if (!maxMinutDate[call.FromNumber].ContainsKey(call.CallDate.Date))
                maxMinutDate[call.FromNumber][call.CallDate.Date] = (call.ToNumber, call.Minutes);
            else if (maxMinutDate[call.FromNumber][call.CallDate.Date].Minutes < call.Minutes)
                maxMinutDate[call.FromNumber][call.CallDate.Date] = (call.ToNumber, call.Minutes);
        }

        // Выводим результаты
        foreach (var fromNumber in maxMinutDate.Keys)
        {
            Console.WriteLine($"\nНомер: {fromNumber}");
            foreach (var date in maxMinutDate[fromNumber].Keys)
            {
                var (toNumber, minutes) = maxMinutDate[fromNumber][date];
                Console.WriteLine($"Дата: {date.ToShortDateString()}, Номер: {toNumber}, Минуты: {minutes}");
            }
        }
    }
}
