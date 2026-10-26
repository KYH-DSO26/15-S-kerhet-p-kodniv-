namespace _04_Det_låsta_loggboksinlägget__Immutabilitet_med_Record_;

public record Loggboksinlägg(
    DateTime Tidsstämpel,       // Förklarande kommentar
    string Meddelande, 
    string Signatur
    );
internal class Program
{
    static void Main(string[] args)
    {
        var logg = new Loggboksinlägg(DateTime.Now,
            "Ankrat vid Hydra. Perfekt fäste och skydd för SW vind",
            "Kapten Bölja");

        // Om följande rad tas fram blir det kompileringsfel!
        //logg.Meddelande = "Ändrat i smyg";

        Console.WriteLine($"Logg sparad: {logg}");




        Console.Write("\n\nTryck på en tangent för att stänga fönstret...");
        Console.ReadKey();
    }
}
