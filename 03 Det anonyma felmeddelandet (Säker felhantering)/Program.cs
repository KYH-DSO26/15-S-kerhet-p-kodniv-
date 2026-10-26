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
        hanterare.LäsKänsligFil(@"C:\DoldaFiler\KänsligData.txt");      // Den filen finns inte





        Console.Write("\n\nTryck på en tangent för att stänga fönstret...");
        Console.ReadKey();
    }
}
