namespace _15_Robust_fallback_konfigurator__Exception_säkrad_state_machine_;

public class ElsystemKonfigurator
{
    public string AktuelltLäge { get; private set; }
    public void LaddaKonfiguration(string filData)
    {
        try
        {
            Console.WriteLine("Försöker applicera filkonfiguration...");
            if (filData.Contains("KORRUPT"))
            {
                throw new FormatException("Kritiskt syntaxfel i konfigurationsfilen.");
            }
            AktuelltLäge = filData;
        }
        catch (FormatException ex)
        {
            Console.WriteLine($"Fel upptäckt: {ex.Message}");
            AktiveraFabriksinställningar(); // Självläkning / Fallback
        }
    }
    private void AktiveraFabriksinställningar()
    {
        Console.WriteLine("Säkerhetsåtgärd: Laddar stabila fabriksinställningar (Säkert standardläge).");
        AktuelltLäge = "Fabriksläge: Minimal strömförbrukning.";
    }
}

internal class Program
{
    static void Main(string[] args)
    {
        var konfigurator = new ElsystemKonfigurator();

        konfigurator.LaddaKonfiguration("KORRUPT_DATA_STRÖM_AV_000");

        Console.WriteLine($"Systemstatus efter laddning: {konfigurator.AktuelltLäge}");





        Console.Write("\n\nTryck på en tangent för att stänga fönstret...");
        Console.ReadKey();
    }
}
