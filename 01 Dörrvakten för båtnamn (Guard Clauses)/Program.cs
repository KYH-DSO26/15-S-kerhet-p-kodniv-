using System.Diagnostics;

namespace _01_Dörrvakten_för_båtnamn__Guard_Clauses_;

public class SäkerFarkost
{
    public string Namn { get; set; }
    public string Registreringsnummer { get; set; }

    public SäkerFarkost(string namn, string registreringsnummer)
    {
        if (string.IsNullOrWhiteSpace(namn))
        {
            throw new ArgumentException("Båtens namn får inte vara tomt!");
        }
        Namn = namn;
        Registreringsnummer = registreringsnummer;
    }
}
internal class Program
{
    static void Main(string[] args)
    {
        Console.Write("\n\nAnge båtens namn: ");
        var namn = Console.ReadLine();

        Console.Write("\n\nAnge registreringsnummer: ");
        var regnr = Console.ReadLine();


        try
        {
            //var båt = new SäkerFarkost("   ", "REG123");
            var båt = new SäkerFarkost(namn, regnr);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Valideringsfel fångat: {ex.Message}");
        }





        // Håll konsolen öppen i debug mode.
        if (Debugger.IsAttached)
        {
            Console.Write("\n\nTryck på en tangent för att stänga fönstret...");
            Console.ReadKey();
        }
    }
}
