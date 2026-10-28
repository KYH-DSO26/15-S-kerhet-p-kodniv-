using System.Diagnostics;

namespace Säkrad_API_parser__TryParse_mönstret_;

public class VäderParser
{
    public double TolkaVindhastighet (string apiData)
    {
        if (double.TryParse(apiData, out double resultat))
        {
            return resultat;
        }

        // Simulera en dold systemlogg för administratörer
        System.Diagnostics.Debug.WriteLine($"[VARNING LOGG] Kunde inte tolka API-data: '{apiData}'");
        return 0.0d;    // Säkert standardvärde
    }
}
internal class Program
{
    static void Main(string[] args)
    {
        var parser = new VäderParser();
        double vind1 = parser.TolkaVindhastighet("14,5");   // OBS kommatecken i svensk Windows
        double vind2 = parser.TolkaVindhastighet("STORM");

        Console.WriteLine($"Vind 1: {vind1} knop");
        Console.WriteLine($"Vind 2 (Fallback): {vind2} knop");



        // Håll konsolen öppen i debug mode.
        if (Debugger.IsAttached)
        {
            Console.Write("\n\nTryck på en tangent för att stänga fönstret...");
            Console.ReadKey();
        }
    }
}
