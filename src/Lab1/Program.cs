using System;
using Itmo.ObjectOrientedProgramming.Lab1.PulseEngines;

namespace Itmo.ObjectOrientedProgramming.Lab1;

public static class Program
{
    public static void Main()
    {
        var a = new PulseEngineC();
        int b = a.CalculateFuelConsumptionForFlight(1000);
        Console.WriteLine("Имя: {0}", b);
    }
}