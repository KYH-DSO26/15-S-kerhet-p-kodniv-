namespace _03_Det_anonyma_felmeddelandet__Säker_felhantering_;

public class FilHanterare
{
    public void LäsKänsligFil(string sökväg)
    {
        try
        {
            string data = File.ReadAllText(sökväg);
            Console.WriteLine(data);
        }
        catch (FileNotFoundException)
        {
            // Visa ett sterilt meddelande
            Console.WriteLine("Ett internt systemfel uppstod. Åtgärden kunde inte slutföras.");
        }
        catch (DirectoryNotFoundException)
        {
            // Visa ett annat sterilt meddelande
            Console.WriteLine("Ett annat fel uppstod. Försök igen.");
        }
    }
}
internal class Program
{
    static void Main(string[] args)
    {
        var hanterare = new FilHanterare();
        var filnamn = "C:/Windows/KänsligData.txt";
        Console.WriteLine($"Läser in \"{filnamn}\"");
        hanterare.LäsKänsligFil(filnamn);      // Den filen finns inte


        filnamn = @"C:\DoldaFiler\KänsligData.txt";
        Console.WriteLine($"\n\nLäser in '{filnamn}'");
        hanterare.LäsKänsligFil(filnamn);      // Den filen finns inte





        Console.Write("\n\nTryck på en tangent för att stänga fönstret...");
        Console.ReadKey();
    }
}
