using System;
using System.Collections.Generic;

public class Currency
{
    private static readonly Dictionary<string, double> ExchangeRates = new Dictionary<string, double>
    {
        { "USD_EUR", 0.85 },
        { "USD_RUB", 75.0 },
        { "EUR_USD", 1.18 },
        { "EUR_RUB", 88.0 },
        { "RUB_USD", 0.013 },
        { "RUB_EUR", 0.011 }
    };

    public double Value { get; }
    public string Type { get; }

    public Currency(double value, string type)
    {
        Value = value;
        Type = type;
    }

    public Currency ConvertTo(string targetType)
    {
        if (Type == targetType) return this;

        string key = $"{Type}_{targetType}";
        if (ExchangeRates.TryGetValue(key, out double rate))
        {
            return new Currency(Value * rate, targetType);
        }
        throw new InvalidOperationException("error");
    }
}

class Program
{
    static void Main()
    {
        var input = Console.ReadLine().Split();
        double amount = double.Parse(input[0]);
        string type = input[1].ToUpper();

        Currency currency = new Currency(amount, type);

        Console.WriteLine($"{amount} {type} в EUR: {currency.ConvertTo("EUR").Value}");
        Console.WriteLine($"{amount} {type} в RUB: {currency.ConvertTo("RUB").Value}");
        Console.WriteLine($"{amount} {type} в USD: {currency.ConvertTo("USD").Value}");
    }
}
