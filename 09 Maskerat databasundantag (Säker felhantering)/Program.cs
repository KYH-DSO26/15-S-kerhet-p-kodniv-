using System.Diagnostics;

namespace _09_Maskerat_databasundantag__Säker_felhantering_;


public class DataHämtningsException : Exception
{
    public DataHämtningsException(string meddelande, Exception innerException)
        : base(meddelande, innerException) { }
}
public class PassagerarDatabas
{
    public void HämtaPassagerarData()
    {
        try
        {
            // Simulerar ett internt, känsligt SQL-undantag
            throw new DataMisalignedException("Känsliga data");
        }
        catch (Exception ex)
        {
            // Maskera felet men spara originalet i en InnerException
            throw new DataHämtningsException("Kunde inte hämta passagerarlistan.", ex);
        }
    }
}

internal class Program
{
    static void Main(string[] args)
    {
        var db = new PassagerarDatabas();
        try
        {
            db.HämtaPassagerarData();
        }
        catch (DataHämtningsException ex)
        {
            Console.WriteLine($"Publikt felmeddelande: {ex.Message}");
            Console.WriteLine($"\n\nDold administratörsinfo: {ex.InnerException.Message}");
        }





        // Håll konsolen öppen i debug mode.
        if (Debugger.IsAttached)
        {
            Console.Write("\n\nTryck på en tangent för att stänga fönstret...");
            Console.ReadKey();
        }
    }
}
