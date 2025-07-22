using System;
using System.Collections.Generic;
using System.Linq;

public class Part2
{
    // HashSet za shranjevanje napolnjenih pozicij v 3D prostoru
    private HashSet<(int x, int y, int z)> filled = new HashSet<(int x, int y, int z)>();

    // Minimalne in maksimalne koordinate, ki jih najdemo v podatkih
    private int minCoord = int.MaxValue;
    private int maxCoord = int.MinValue;

    // Metoda za zagon simulacije
    public void PozeniSimulacijo(string[] podanePodatke)
    {
        // Obdelava vhodnih podatkov in iskanje napolnjenih pozicij
        foreach (var line in podanePodatke)
        {
            var parts = line.Split(',');
            int x = int.Parse(parts[0]);
            int y = int.Parse(parts[1]);
            int z = int.Parse(parts[2]);

            // Dodamo napolnjeno kocko v HashSet
            filled.Add((x, y, z));

            // Posodobimo minimalne in maksimalne koordinate
            foreach (int stevilo in new[] { x, y, z })
            {
                minCoord = Math.Min(minCoord, stevilo);
                maxCoord = Math.Max(maxCoord, stevilo);
            }
        }

        int vsota = 0;  // Število neprekritih strani

        // Preverimo vse napolnjene pozicije
        foreach (var (x, y, z) in filled)
        {
            var pos = new[] { x, y, z };  // Trenutna pozicija

            // Preverimo vse tri koordinate (x, y, z)
            for (int koordinata = 0; koordinata < 3; koordinata++)
            {
                // Pripravimo premike v pozitivni in negativni smeri po trenutni osi
                var dpos = new int[] { 0, 0, 0 };
                dpos[koordinata] = 1;  // Premik za 1 v pozitivno smer

                var dneg = new int[] { 0, 0, 0 };
                dneg[koordinata] = -1;  // Premik za 1 v negativno smer

                // Preverimo, ali sta sosednji kocki izpostavljeni (če nista napolnjeni)
                foreach (var nbr in new[] { Add(pos, dpos), Add(pos, dneg) })
                {
                    if (Exposed(nbr))  // Če je sosednja kocka izpostavljena
                    {
                        vsota++;  // Povečamo števec izpostavljenih strani
                    }
                }
            }
        }

        // Izpišemo končni rezultat
        Console.WriteLine($"Rezultat del 2 je: {vsota}");
    }

    // Pomožna funkcija za seštevanje dveh 3D koordinat
    private (int, int, int) Add(int[] a, int[] b)
    {
        return (a[0] + b[0], a[1] + b[1], a[2] + b[2]);
    }

    // Funkcija za preverjanje, ali je dana pozicija izpostavljena zunanjosti
    private bool Exposed((int x, int y, int z) pozicija)
    {
        // Če je pozicija že napolnjena, ni izpostavljena
        if (filled.Contains(pozicija)) return false;

        var stack = new Stack<(int x, int y, int z)>();
        stack.Push(pozicija);  // Zaženemo iskanje iz podane pozicije
        var seen = new HashSet<(int x, int y, int z)>();  // Shranimo že obiskane pozicije

        // DFS (globinsko iskanje) za preverjanje, ali lahko dosežemo mejo prostora
        while (stack.Count > 0)
        {
            var pop = stack.Pop();

            // Če smo našli napolnjeno kocko, jo ignoriramo
            if (filled.Contains(pop)) continue;

            // Če je kocka izven meja (minCoord in maxCoord), je izpostavljena zunanjosti
            if (pop.x < minCoord || pop.x > maxCoord ||
                pop.y < minCoord || pop.y > maxCoord ||
                pop.z < minCoord || pop.z > maxCoord)
            {
                return true;
            }

            // Če je pozicija že obiskana, jo preskočimo
            if (seen.Contains(pop)) continue;
            seen.Add(pop);  // Oznaka, da smo obiskali pozicijo

            // Preverimo vse tri smeri (x, y, z) in dodamo sosednje pozicije v stack
            for (int koordinata = 0; koordinata < 3; koordinata++)
            {
                var dpos = new int[] { 0, 0, 0 };
                dpos[koordinata] = 1;

                var dneg = new int[] { 0, 0, 0 };
                dneg[koordinata] = -1;

                stack.Push(Add(new[] { pop.x, pop.y, pop.z }, dpos));  // Premik v pozitivno smer
                stack.Push(Add(new[] { pop.x, pop.y, pop.z }, dneg));  // Premik v negativno smer
            }
        }

        // Če ne najdemo izhoda, pozicija ni izpostavljena
        return false;
    }
}
