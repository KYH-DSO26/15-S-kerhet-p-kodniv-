namespace _08_Rollbaserad_dörrvakt__Minsta_behörighet_i_logik_;

public class LänspumpSystem
{
    public void StartaLänspump(string användarRoll)
    {
        if (användarRoll != "Kapten" && användarRoll != "Maskinist")
        {
            throw new UnauthorizedAccessException(
                "Behörighet saknas! Endast Kapten eller Maskinist får starta länspumpen.");
        }

        Console.WriteLine("Säkerhetsverifiering godkänd. Länspumpen har startats.");
    }
}
internal class Program
{
    static void Main(string[] args)
    {
        var pump = new LänspumpSystem();

        try
        {
            pump.StartaLänspump("Maskinist");
            pump.StartaLänspump("Gäst");
        }
        catch (UnauthorizedAccessException ex)
        {
            Console.WriteLine($"\n\nSäkerhetsalarm: {ex.Message}");
        }






        Console.Write("\n\nTryck på en tangent för att stänga fönstret...");
        Console.ReadKey();
    }
}
