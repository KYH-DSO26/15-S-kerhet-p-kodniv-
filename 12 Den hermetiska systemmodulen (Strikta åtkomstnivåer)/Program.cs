namespace _12_Den_hermetiska_systemmodulen__Strikta_åtkomstnivåer_;

public class NavigationsKärna
{
    // Publik och säker ingång
    public string BeräknaKurs()
    {
        // Anropa de dolda, säkrade interna metoderna sekventiellt
        string råData = HämtaSatellitRåData();
        bool validerad = ValideraSignaler(råData);

        if (!validerad) return "Kursberäkningen misslyckades. Otillförlitlig GPS-fix.";

        return "Ny kur satt";
    }

    private bool ValideraSignaler(string data)
    {
        return data.StartsWith("SATELLITE");
    }

    private string HämtaSatellitRåData() => "SATELLITE-FIX-37N-123E";
}

internal class Program
{
    static void Main(string[] args)
    {
        var kärna = new NavigationsKärna();
        string kursresultat = kärna.BeräknaKurs();

        Console.WriteLine($"Resultat: {kursresultat}");

        //kärna.ValideraSignaler("TESTDATA");         // Ger kompileringsfel
        //kärna.HämtaSatellitRåData();






        Console.Write("\n\nTryck på en tangent för att stänga fönstret...");
        Console.ReadKey();
    }
}
