using System.Diagnostics;

namespace _05_Den_SURRADE_kompassen__Minsta_behörighet_;

public class DigitalKompass
{
    public int Kurs { get; private set; }
    public void UpdateKurs(int nyKurs)
    {
        if (nyKurs < 0 || nyKurs > 359)
        {
            throw new ArgumentOutOfRangeException("Kompasskurs måste vara mellan 0 och 359 grader");
        }
        Kurs = nyKurs;
    }
}
internal class Program
{
    static void Main(string[] args)
    {
        var kompass = new DigitalKompass();

        //kompass.Kurs = 25;    // Ger kompileringsfel pga private set!

        kompass.UpdateKurs(10);
        Console.WriteLine($"Aktuell kurs: {kompass.Kurs}°");
        
        try
        {
            kompass.UpdateKurs(365);    // Felaktigt värde
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"Kursfel: {ex.Message}");
        }



        // Håll konsolen öppen i debug mode.
        if (Debugger.IsAttached)
        {
            Console.Write("\n\nTryck på en tangent för att stänga fönstret...");
            Console.ReadKey();
        }
    }
}
