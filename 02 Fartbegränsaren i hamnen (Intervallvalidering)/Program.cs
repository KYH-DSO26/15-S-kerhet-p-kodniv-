using System.Diagnostics;

namespace _02_Fartbegränsaren_i_hamnen__Intervallvalidering_;

public class HastighetsRegulator
{
    private double _aktuellKnop;

    public double AktuellKnop
    {
        get { return _aktuellKnop; }
        set {
            if (value < 0 || value > 30)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Hastigheten i hamnområdet måste ligga mellan 0 och 30 knop.");
            }
            _aktuellKnop = value; 
        }
    }

}
internal class Program
{
    static void Main(string[] args)
    {
        var regulator = new HastighetsRegulator();
        try
        {
            regulator.AktuellKnop = 35;         // Ogiltigt värde
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"Säkerhetsstopp: {ex.Message}");
        }




        // Håll konsolen öppen i debug mode.
        if (Debugger.IsAttached)
        {
            Console.Write("\n\nTryck på en tangent för att stänga fönstret...");
            Console.ReadKey();
        }
    }
}
