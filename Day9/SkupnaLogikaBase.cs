abstract class SkupnaLogikaBase
{
    protected Dictionary<string, (int dx, int dy)> smeri = new Dictionary<string, (int dx, int dy)>
    {
        { "R", (1, 0) },
        { "L", (-1, 0) },
        { "U", (0, 1) },
        { "D", (0, -1) }
    };

    // Metoda za premik (implementacija bo specifična za Part1 in Part2)
    public abstract void IzvediPremik(string navodilo, int korakov);

    // Skupna logika za branje datoteke in izvajanje
    public void IzvediSkupnoLogic(string datoteka, int part)
    {
        foreach (var vrstica in File.ReadLines(datoteka))
        {
            var deli = vrstica.Split(" ");
            var navodilo = deli[0];
            var korakov = int.Parse(deli[1]);

            // Klic abstraktne metode za izvedbo premika
            IzvediPremik(navodilo, korakov);
        }

        Console.WriteLine($"Število pozicij, ki jih je rep obiskal v delu {part}, je: {ZabeleziPozicije()}");
    }

    // Abstraktna metoda za beleženje pozicij
    protected abstract int ZabeleziPozicije();
}
