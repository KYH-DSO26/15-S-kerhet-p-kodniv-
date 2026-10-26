namespace _13_Säkrad_Logger_med_Hash_kontroll__Dataintegritet_;

public class Loggrad
{
    public string Text { get; set; } // Kan avsiktligt manipuleras i testet
    public int SparadHash { get; }
    public Loggrad(string text)
    {
        Text = text;
        SparadHash = text.GetHashCode(); // Generera unik checksumma vid skapandet
    }
}
public class SäkradLogger
{
    private Loggrad _aktuellLogg;
    public void SkrivLogg(string text) => _aktuellLogg = new Loggrad(text);
    public void ManipuleraTest() => _aktuellLogg.Text = "Ändrad text i smyg!";
    public bool VerifieraIntegritet()
    {
        if (_aktuellLogg == null) return true;
        return _aktuellLogg.Text.GetHashCode() == _aktuellLogg.SparadHash;
    }
}
internal class Program
{
    static void Main(string[] args)
    {
        var logger = new SäkradLogger();
        logger.SkrivLogg("Systemet startat normalt.");
        Console.WriteLine($"Verifiering 1: {logger.VerifieraIntegritet()} (Ska vara True)");
        logger.ManipuleraTest(); // Simulerat intrång
        Console.WriteLine($"Verifiering 2 efter intrång: {logger.VerifieraIntegritet()} (Ska vara False!)");







        Console.Write("\n\nTryck på en tangent för att stänga fönstret...");
        Console.ReadKey();
    }
}
