namespace _11_Det_transaktionella_passagerarregistret__Allt_eller_inget_principen_;

public class PassagerarManifest
{
    private readonly List<string> _passagerare = new List<string>();
    public int Antal => _passagerare.Count;
    public void RegistreraGrupp(List<string> namnLista)
    {
        // Defensiv kontroll av HELA gruppen innan vi lägger in något
        if (_passagerare.Count + namnLista.Count > 12)
        {
            throw new InvalidOperationException("Transaktionen avbruten!. Gruppstorleken blir större än 12");
        }

        // Om verifieringen går bra så genomförs skrivningen
        _passagerare.AddRange(namnLista);
    }
}
internal class Program
{
    static void Main(string[] args)
    {
        var manifest = new PassagerarManifest();
        manifest.RegistreraGrupp(
            new List<string> { "Anna", "Britta", "Carin" });

        try
        {
            // Försöker att lägga till en stor grupp (10 personer till)
            // Principen är att alla i gruppen ska med, annars ingen av dem.
            var storGrupp = new List<string> {
                "D1", "D2", "D3", "D4", "D5", "D6", "D7", "D8", "D9", "D10" };

            manifest.RegistreraGrupp(storGrupp);        // Kommer att skita sig
            Console.WriteLine("Registreringen gick bra");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Säkerhetsblockering: {ex.Message}");
        }

        Console.WriteLine($"Antal passgerare: {manifest.Antal}. (Borde vara 3 ;-))");







        Console.Write("\n\nTryck på en tangent för att stänga fönstret...");
        Console.ReadKey();
    }
}
 