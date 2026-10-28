using System.Diagnostics;

namespace _06_Det_robusta_bokningsnumret;

public class BokningsReferens
{
    public string Kod { get; }
    public BokningsReferens(string kod)
    {
        if (string.IsNullOrWhiteSpace(kod) || kod.Length != 8 || !kod.StartsWith("BÅT-"))
        {
            throw new FormatException(
                "Bokningsnummer måste ha formatet 'BÅT-' följt av fyra siffror (t. ex. BÅT-1234).");
        }
        Kod = kod;
    }
}
internal class Program
{
    static void Main(string[] args)
    {
        try
        {
            var bokning = new BokningsReferens("BIL-1234");
            //bokning.Kod = "BÅT-1111";     // Ger kompileringsfel!
        }
        catch (FormatException ex)
        {
            Console.WriteLine($"Formatfel stoppat: {ex.Message}");
        }




        // Håll konsolen öppen i debug mode.
        if (Debugger.IsAttached)
        {
            Console.Write("\n\nTryck på en tangent för att stänga fönstret...");
            Console.ReadKey();
        }
    }
}
