namespace _14_Den_säkra_API_skölden__Sanitering_av_text_;

public class InputSanitizer
{
    public string Sanitera(string råText)
    {
        if (string.IsNullOrEmpty(råText)) return string.Empty;
        
        // Rensar bort tecken som riskerar att förstöra skärmformateringen (< och >)
        string renadText = råText.Replace("<", "[").Replace(">", "]");
        return renadText.Trim();
    }
}
internal class Program
{
    static void Main(string[] args)
    {
        var sanitizer = new InputSanitizer();
        string farligtAnrop = " <ALERT> Vattentemperatur hög! </ALERT> ";
        string rentAnrop = sanitizer.Sanitera(farligtAnrop);

        Console.WriteLine($"Rå text: '{farligtAnrop}'");
        Console.WriteLine($"Saniterad text: '{rentAnrop}'");






        Console.Write("\n\nTryck på en tangent för att stänga fönstret...");
        Console.ReadKey();
    }
}
