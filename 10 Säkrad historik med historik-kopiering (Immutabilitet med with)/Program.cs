using System.Diagnostics;

namespace _10_Säkrad_historik_med_historik_kopiering__Immutabilitet_med_with_;

public record Färdplan(string RuttID, string StartHamn, string DestinationHamn);
internal class Program
{
    static void Main(string[] args)
    {
        Färdplan originalPlan = new Färdplan("RUTT-404", "Pireus", "Mykonos");

        // Skapa en ny säker instans utan att röra originalet
        Färdplan uppdateradPlan = originalPlan with { DestinationHamn = "Naxos" };

        Console.WriteLine($"Originalplan: {originalPlan.DestinationHamn}");
        Console.WriteLine($"Ändrad plan: {uppdateradPlan.DestinationHamn}");
        Console.WriteLine($"\n\nKomplett ändrad plan: {uppdateradPlan}");




        // Håll konsolen öppen i debug mode.
        if (Debugger.IsAttached)
        {
            Console.Write("\n\nTryck på en tangent för att stänga fönstret...");
            Console.ReadKey();
        }
    }
}
