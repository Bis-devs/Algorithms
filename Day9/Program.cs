class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Izberite del 1 ali 2 za dan 9: ");
        string izbira = Console.ReadLine();

        SkupnaLogikaBase logika;

        if (izbira == "1")
        {
            logika = new Part1Logika();
        }
        else if (izbira == "2")
        {
            logika = new Part2Logika();
        }
        else
        {
            Console.WriteLine("Neveljavna izbira.");
            return;
        }

        // Izvedi logiko na podlagi izbire uporabnika
        logika.IzvediSkupnoLogic("./day9.txt", izbira == "1" ? 1 : 2);
    }
}
